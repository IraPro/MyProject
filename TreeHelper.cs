using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace PreSQL
{

    public enum SelectColumnType
    {
        _column,
        _function,
        _expr
    }

    //класс-помощник для разбора полей запроса оператора Select
    public class SelectColumn
    {
        public string Name;
        public SelectColumnType ColumnType;
        public string Column_name;
        public string Column_alias="";
        public string Function_name;
        public string Expr;

        public SelectColumn(TreeNode node)
        {
            TreeNode nd;
            string s;
            Name = TreeHelper.GetValue(node);
            if (Name == "*")
            {
                Column_name = "*";
                ColumnType = SelectColumnType._column;
                return;
            }
            nd = node.Nodes[0];
            nd = nd.Nodes[0];
            //while (nd != null)
            {
                s = (TreeHelper.GetRuleName(nd));
                switch (s)
                {
                    case "Column_name": Column_name = TreeHelper.GetValue(nd); ColumnType = SelectColumnType._column; break;
                    case "Function_name":
                        {
                            string ss = TreeHelper.GetValue(nd.Parent);
                            ss = ss.Substring(0, ss.IndexOf("("));
                            Function_name = ss;
                            ColumnType = SelectColumnType._function;
                            Column_name = ss + GetHashCode();
                            Expr=TreeHelper.GetValue(nd.Parent);
                            break;
                        }
                    case "Expr":
                        {
                            Expr = TreeHelper.GetValue(nd.Parent); ColumnType = SelectColumnType._expr;
                            Column_name = "Expr" + GetHashCode();
                            break;
                        }
                    default: break;
                }
                //nd = nd.NextNode;
            }
            nd = node.Nodes[0].NextNode;
            while (nd != null)
            {
                s = (TreeHelper.GetRuleName(nd));
                switch (s)
                {
                    case "Column_alias": Column_alias = TreeHelper.GetValue(nd); break;
                    default: break;
                }
                nd = nd.NextNode;
            }

        }

        public string GetColType()
        {
            return ColumnType.ToString();
        }

        public string GetValue()
        {
            switch (ColumnType)
            {
                case SelectColumnType._column: return Column_name;
                case SelectColumnType._function: return Name;
                case SelectColumnType._expr: return Expr;
                default: return "";
            }
        }
    }

  
    //класс-помощник для разбора полей в CreateSelect
    public class CreateTableColumn
    {
        public string Name;
        public string ColumnType;
        public string Column_name;

        public CreateTableColumn(TreeNode node)
        {
            TreeNode nd;
            string s;
            Name = TreeHelper.GetValue(node);
            nd = node.Nodes[0];
            Column_name = TreeHelper.GetValue(nd);            
            nd = nd.NextNode;
            ColumnType = TreeHelper.GetValue(nd).ToLower();
        }

    }

    // класс-помощник по работе с деревом
    public class TreeHelper
    {
        private TreeView tv;
        public TreeHelper(TreeView trv)
        {
            this.tv = trv;
        }

        public static bool IsRule(TreeNode nd)
        {
            return nd.Text.IndexOf("Rule") == 0;
        }

        public static bool IsTerminal(TreeNode nd)
        {
            return nd.Text.IndexOf("Terminal") == 0;
        }

        public static string GetRuleName(TreeNode nd)
        {
            if (IsRule(nd))
            {
                string s = nd.Text;
                return s.Substring(5, s.IndexOf("#") - 6);
            }
            else return "";
        }

        public static string GetTerminalName(TreeNode nd)
        {
            if (IsTerminal(nd))
            {
                string s = nd.Text;
                return s.Substring(11);
            }
            else return "";
        }

        public static string GetValue(TreeNode nd)
        {
            return nd.Text.Substring(nd.Text.IndexOf("#") + 1).Trim();
        }

        // для поиска ноды по строке
        public static bool EqualStr(TreeNode nd, string str)
        {
            return IsRule(nd) && GetRuleName(nd) == str || IsTerminal(nd) && GetTerminalName(nd) == str;
        }

        // загрузить дерево в TreeView по дереву парсинга
        public void LoadNode(TreeNode node, IParseTree tree)
        {
            string s;
            if (node == null)
            {// если дерева в TreeView еще нет
                {
                    s = tree.GetType().ToString();
                    if (s.Contains("+")) s = tree.GetType().ToString().Split('+')[1];
                    if (s.Contains(".")) s = tree.GetType().ToString().Split('.')[3];
                    if (s.Contains("Context")) s = "Rule:" + s.Substring(0, s.IndexOf("Context"));
                    if (s.Contains("Terminal")) s = s.Substring(0, 8);
                    node = tv.Nodes.Add(s + " # " + tree.GetText());
                }
            }
            else
            {
                {
                    s = tree.GetType().ToString();
                    if (s.Contains("+")) s = tree.GetType().ToString().Split('+')[1];
                    if (s.Contains(".")) s = tree.GetType().ToString().Split('.')[3];
                    if (s.Contains("Context")) s = "Rule:" + s.Substring(0, s.IndexOf("Context"));
                    if (s.Contains("Terminal")) s = s.Substring(0, 8);
                    node = node.Nodes.Add(s + " # " + tree.GetText());
                }
            }
            // загрузить дочерние ноды
            for (int i = 0; i < tree.ChildCount; i++)
            {
                LoadNode(node, tree.GetChild(i));
            }
        }

        //найти ноду в дереве по строке
        public static TreeNode FindNode(TreeNode node, string str)
        {
            TreeNode nd = null;
            TreeNode node1 = null;
            //if (node == null) node = tv.Nodes[0];

            for (int i = 0; i < node.Nodes.Count; i++)
            {
                nd = node.Nodes[i];
                if (EqualStr(nd, str))
                {
                    node1 = node.Nodes[i]; ;
                    return node1;
                    //                    return node;
                }
                nd = FindNode(node.Nodes[i], str);
                //                nd = FindNode(node, str); 
                if (nd != null) return nd;
            }
            return node1;
        }

        //найти терминальную строку (терминал) в дереве под правилом (RULE), соответствующим node
        public TreeNode FindTerminal(TreeNode node)
        {
            TreeNode nd = null;
            //TreeNode node1 = null;
            //if (node == null) node = tv.Nodes[0];

            for (int i = 0; i < node.Nodes.Count; i++)
            {
                nd = node.Nodes[i];
                if (IsTerminal(nd))
                {
                    return nd;
                }
                else
                {
                    nd = FindTerminal(nd);
                    if (nd != null) return nd;
                }
            }
            return null;
        }

        public List<string> GetTerminals(TreeNode node)
        {
            List<string> result = new List<string>();
            List<string> ls = new List<string>();
            if (IsTerminal(node))
            {
                result.Add(GetTerminalName(node));
                return result;
            }
            TreeNode nd = node.Nodes[0];
            while (nd != null)
            {
                if (IsTerminal(nd))
                {
                    result.Add(GetTerminalName(nd));
                }
                else
                {
                    ls = GetTerminals(nd);
                    for (int i = 0; i < ls.Count; i++)
                    {
                        result.Add(ls.ElementAt<string>(i));
                    }
                }
                nd = nd.NextNode;
            }
            return result;
        }


        //найти список терминалов между терминалами after и before (исключая) на даном уровне 
        public List<string> FindTerminals(TreeNode after, TreeNode before)
        {
            TreeNode nd = null;
            List<string> result = new List<string>();
            List<string> ls = new List<string>();

            nd = after.NextNode;
            while (nd != null && nd != before)
            {
                ls = GetTerminals(nd);
                for (int i = 0; i < ls.Count; i++)
                {
                    result.Add(ls.ElementAt<string>(i));
                }
                nd = nd.NextNode;
            }

            return result;
        }

        public List<string> FindSelectTable()
        {
            TreeNode after = FindNode(tv.Nodes[0], "from");
            TreeNode before = FindNode(tv.Nodes[0], "where");
            List<string> ls = FindTerminals(after, before);
            return ls;
        }

        public List<string> FindSelect_Where()
        {
            TreeNode nd = FindNode(tv.Nodes[0], "where");
            if (nd != null)
            {
                List<string> ls = GetTerminals(nd.NextNode);
                return ls;
            }
            else return null;
        }

        public string FindWhere()
        {
            TreeNode nd = FindNode(tv.Nodes[0], "where");
            if (nd != null)
            {
                List<string> ls = GetTerminals(nd.NextNode);
                string s = "";
                foreach (string ss in ls)
                {
                    s = s + " " + ss;
                }
                return s;
            }
            else return null;
        }

        public string FindSelectOrderBy()
        {
            TreeNode nd = FindNode(tv.Nodes[0], "order");
            if (nd != null)
            {
                TreeNode after = nd.NextNode; //by
                List<string> orderby = FindTerminals(after, null);
                string orderex = "";
                foreach (string ss in orderby)
                {
                    orderex = orderex + " " + ss;
                }

                return orderex;
            }
            else return null;
        }

         //найти список столбцов (полей) в запросе 
        public static List<SelectColumn> FindSelectColumns(TreeNode after)
        {
            TreeNode nd = null;
            List<SelectColumn> result = new List<SelectColumn>();
            //List<TreeColumn> ls = new List<TreeColumn>();

            nd = FindNode(after, "Select_or_values");
            nd = nd.Nodes[0];
            while (nd != null)
            {
                if (EqualStr(nd, "Result_column") ) result.Add(new SelectColumn(nd));
                nd = nd.NextNode;
            }
            return result;
        }

        //найти имя табл. в операторе CreateTable
        public static string FindCreateTableName(TreeNode after)
        {
            TreeNode nd = null;
            nd = FindNode(after, "Table_name");
            return GetValue(nd);
        }

        public static List<CreateTableColumn> FindCreateTableColumns(TreeNode after)
        {
            List<CreateTableColumn> result=new List<CreateTableColumn>();
            TreeNode nd = null;
            nd = FindNode(after, "Table_name");
            while (nd != null)
            {
                if (EqualStr(nd, "Column_def")) result.Add(new CreateTableColumn(nd));
                nd = nd.NextNode;
            }

            return result;
        }

        //найти список столбцов (полей) в запросе 
        public static List<string> FindInsertColumns(TreeNode after)
        {
            TreeNode nd = null;
            List<string> result = new List<string>();

            nd = FindNode(after, "Insert_stmt");
            nd = nd.Nodes[0];
            while (nd != null)
            {
                if (EqualStr(nd, "Column_name")) result.Add(GetValue(nd));
                nd = nd.NextNode;
            }
            return result;
        }

        //найти список столбцов (полей) в запросе 
        public static List<string> FindInsertValues(TreeNode after)
        {
            TreeNode nd = null;
            List<string> result = new List<string>();

            nd = FindNode(after, "Insert_stmt");
            nd = nd.Nodes[0];
            while (nd != null)
            {
                if (EqualStr(nd, "Expr")) result.Add(GetValue(nd));
                nd = nd.NextNode;
            }
            return result;
        }

        //найти список столбцов (полей) в запросе 
        public static List<string> FindUpdateColumns(TreeNode after)
        {
            TreeNode nd = null;
            List<string> result = new List<string>();

            nd = FindNode(after, "Update_stmt");
            nd = nd.Nodes[0];
            while (nd != null)
            {
                if (EqualStr(nd, "Column_name")) result.Add(GetValue(nd));
                nd = nd.NextNode;
            }
            return result;
        }

        //найти список столбцов (полей) в запросе 
        public static List<string> FindUpdateValues(TreeNode after)
        {
            TreeNode nd = null;
            //TreeNode before = null;
            List<string> result = new List<string>();

            nd = FindNode(after, "Update_stmt");
            //before = FindNode(after, "where");
            nd = nd.Nodes[0];
            while (nd != null)
            {
                if (EqualStr(nd, "where")) break;
                if (EqualStr(nd, "Expr")) result.Add(GetValue(nd));
                nd = nd.NextNode;
            }
            return result;
        }
    
    }

}

