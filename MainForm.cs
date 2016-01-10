using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;
using System.Linq.Dynamic;


namespace PreSQL
{

    public partial class MainForm : Form
    {
        public DB db;
        public TreeHelper th;
        private RequestList requestList = new RequestList();
        public MainForm()
        {
            InitializeComponent();
            th = new TreeHelper(treeView);
            db = new DB(this);
        }


        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void clrRequestBtn_Click(object sender, EventArgs e)
        {
            requestBox.Text = "";
        }

        private void clrResultBtn_Click(object sender, EventArgs e)
        {
            resultBox.Text = "";
        }

        private void clrPersingResultBtn_Click(object sender, EventArgs e)
        {
            resultBox.Text = "";
        }

         private void button2_Click(object sender, EventArgs e)
        {
            resultBox.Text = "";
        }
         
        private void button10_Click(object sender, EventArgs e)
        {
            db.FillDS();
        }

        //выполнить запрос
        private void requestBtn_Click(object sender, EventArgs e)
        {
            resultBox.Text = "";
            resultBox.Text = "";

            requestList.AddStr(requestBox.Text);

            Antlr4.Runtime.ICharStream input = new Antlr4.Runtime.AntlrInputStream(requestBox.Text);
            PreSQLLexer lexer = new PreSQLLexer(input);
            Antlr4.Runtime.CommonTokenStream tokens = new Antlr4.Runtime.CommonTokenStream(lexer);
            PreSQLParser parser = new PreSQLParser(tokens);
            parser.RemoveErrorListeners(); // remove ConsoleErrorListener
            parser.AddErrorListener(new ErrorListener()); // добавит листенер, который будет сообщать об ошибках распарсивания
            //parser.AddParseListener(new Listener()); // add ours
            parser.BuildParseTree = true;
            Antlr4.Runtime.Tree.IParseTree tree = parser.parse(); // получить дерево 

            resultBox.Text += tree.ToStringTree(parser) + Environment.NewLine + Environment.NewLine; // print LISP-style tree

            // Анализируем результаты разбора. Если были синтаксические ошибки, выдадим лог анализа
            if (parser.NumberOfSyntaxErrors != 0)
            {
                resultBox.Text += "> Parsing Error!" + Environment.NewLine;
            }
            else
            {//строим дерево
                treeView.Nodes.Clear();
                th.LoadNode(null, tree);

                resultBox.Text += "> Parsing Ok!" + Environment.NewLine;
                Visitor visitor = new Visitor(this);
                //запускаем Визитор
                // он проходит по дереву, определяет SQL-оператор и выполняет действие в зависимости(см. файлVisitor)
                visitor.Visit(tree); 
            }

        }

  
        //открыть файл БД
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = db.OpenDB(openFileDialog1.FileName);
                if (s == "")
                {
                    dbLabel.Text = openFileDialog1.FileName;
                }
                else
                {
                    MessageBox.Show(s, "Ошибка!");
                    dbLabel.Text = "<Не подключено>";
                }
            }

        }

        //закрыть/отключить БД
        private void отключитьБДToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            db.CloseDB();
            dbLabel.Text = "<Не подключено>";
        }

        //создать новую БД
        private void создатьБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDBForm f = new CreateDBForm();
            f.ShowDialog();
        }

        //сохранитьб БД
        private void отключитьБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.ds.WriteXml(dbLabel.Text, XmlWriteMode.WriteSchema);
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            requestBox.Text = "select * from tab1 where carid>1";
        }

        private void createTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            requestBox.Text = "create table tab1 (col1 integer, col2 char(20), col3 number, col4 datetime)";
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            requestBox.Text = "insert into tab1 (col1,col2,col3, col4) values (1,'2',3.5, '01.02.2015 10:11:12')";
        }

        private void dropTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            requestBox.Text = "drop table";
        }

        //перейти к предыдущему запросу
        private void предыдущийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            requestBox.Text = requestList.Prev();
        }

        //перейти к следующему ранее используемому запросу
        private void пследующийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            requestBox.Text = requestList.Next();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            requestBox.Text = "delete from car where carid=10";
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            requestBox.Text = "update tab1 set col1=2, col2='dddd', col3=2.25, col4='01.01.199 10:05'";
        }

        // о программе
        private void AboutBtn_Click(object sender, EventArgs e)
        {
            AboutForm m_AboutForm = new AboutForm();
            m_AboutForm.StartPosition = FormStartPosition.CenterScreen;
            m_AboutForm.Show();
            m_AboutForm.BringToFront();
            m_AboutForm.TopMost = true;
        }
    }

    //вспомогательный класс для списка выполненных запросов с указателем
    public class RequestList : List<string>
    {
        public int ptr;
        public RequestList()
        {
            ptr = -1;
        }
        public void AddStr(string str)
        {
            if (Count > 0) RemoveRange(ptr + 1, Count - ptr - 1);
            Add(str);
            ptr = Count - 1;
        }
        //получить пред. строку
        public string Prev()
        {
            if (ptr > 0) ptr--;
            return base[ptr];
        }
        //получить след. строку
        public string Next()
        {
            if (ptr < Count - 1) ptr++;
            return base[ptr];
        }
    }

}
