using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Form1;

namespace PreSQL
{
    public partial class CreateDBForm : Form
    {
        public CreateDBForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                textBox2.Text = saveFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm f = (MainForm)Application.OpenForms[0];
            f.db.CreateDB(textBox1.Text);
            string s=f.db.SaveDB(textBox2.Text);
            if (s != "")
            {
                MessageBox.Show(s, "Ошибка!");
            }
            else
            {
                f.dbLabel.Text = textBox2.Text;

            }

        }
    }
}
