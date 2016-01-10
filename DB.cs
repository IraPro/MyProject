using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq.Dynamic;
using System.Globalization;

namespace PreSQL
{
    // класс по работе с Бд на основе DataSet
    public class DB
    {
        MainForm f;
        public DataSet ds;
        TreeHelper th;

        public DB(MainForm fm)
        {
            f = fm;
            ds = new DataSet();
            th = f.th;
            //ds.ReadXml("db.xml");
            //f.dbLabel.Text="db.xml";
        }

        //открыть БД
        public string OpenDB(String dbFileName)
        {
            try
            {
                ds = new DataSet();
                ds.ReadXml(dbFileName);
                int i = ds.Tables.Count;
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // закрыть БД
        public void CloseDB()
        {
            ds.Reset();
            ds.Dispose();
        }

        // создать новую пустую БД
        public void CreateDB(string dbname)
        {
            ds = new DataSet();
            ds.DataSetName = dbname;
        }

        //сохранить в файле 
        public string SaveDB(string dbFileName)
        {
            try
            {
                ds.WriteXml(dbFileName, XmlWriteMode.WriteSchema);
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // Заполнить DataSet из внешней БД
        public void FillDS()
        {
            ds = new DataSet();
            ds.DataSetName = "DB";
            string s = "Data Source=" + "..\\..\\PreSQL.sdf";
            SqlCeDataAdapter da = new SqlCeDataAdapter("select *  from car", s);
            da.Fill(ds, "car");
            string s1 = "select *  from \"order\"";
            da = new SqlCeDataAdapter(s1, s);
            da.Fill(ds, "order");
            da = new SqlCeDataAdapter("select *  from orders", s);
            da.Fill(ds, "orders");
            da = new SqlCeDataAdapter("select *  from carType", s);
            da.Fill(ds, "carType");
            da = new SqlCeDataAdapter("select *  from customer", s);
            da.Fill(ds, "customer");

            ds.WriteXml(ds.DataSetName + ".xml", XmlWriteMode.WriteSchema);
        }


        //выполнить select
        public void Select()
        {
            try
            {
                //находим  имя таблицы, из которой делаем выборку даных
                List<string> tables = th.FindSelectTable();

                // таблица в БД
                DataTable dt = ds.Tables[tables[0]];

                // представление данных после выполнения запроса select
                DataTable rsltDt = dt.Copy();

                //выражение where
                string expression = th.FindWhere();

                // выражение orderby
                string orderby = th.FindSelectOrderBy();

                // список столбцов в запросе
                List<SelectColumn> clmns = TreeHelper.FindSelectColumns(f.treeView.Nodes[0]);

                //добавляем функции и выражения в таблицу - определяем новые столбцы,
                //у уоторыйх Expression определяет функцию и выражение
                for (int i = 0; i < clmns.Count; i++)
                {
                    SelectColumn tc = clmns[i];
                    if (tc.ColumnType != SelectColumnType._column)
                    {
                        DataColumn newColumn = new DataColumn();
                        //newColumn.DataType = String;
                        newColumn.ColumnName = tc.Column_name;
                        if (tc.Column_alias != "") newColumn.Caption = tc.Column_alias; else newColumn.Caption = tc.Column_name;
                        newColumn.Expression = tc.Expr;
                        rsltDt.Columns.Add(newColumn);
                    }
                    else
                    {
                        if (tc.Column_alias != "") rsltDt.Columns[tc.Column_name].Caption = tc.Column_alias;
                    }
                }

                //!!!!!здесь происходит select и упорядочивани штатными соедствамии класса DataTable!!!!!!
                DataRow[] foundRows = rsltDt.Select(expression, orderby);

                //  если запрос ничего не вернул
                if (foundRows.Length == 0)
                {
                    f.resultBox.Text += ">Запрос вернул пустое множество" + Environment.NewLine;
                    return;
                }

                //создаем структуру выходных полей: 
                //добавляем поля,функции и выражения, которые есть в запросе, в таблицу
                DataTable rsltTable = new DataTable();
                for (int i = 0; i < clmns.Count; i++)
                {
                    DataColumn newColumn = new DataColumn();
                    SelectColumn tc = clmns[i];
                    if (tc.Column_name != "*")
                    {
                        newColumn = foundRows[0].Table.Columns[tc.Column_name];
                        if (newColumn != null)
                        {

                            DataColumn cl = new DataColumn();
                            cl.ColumnName = newColumn.ColumnName;
                            cl.Caption = newColumn.Caption;
                            cl.DataType = newColumn.DataType;
                            rsltTable.Columns.Add(cl);
                        }
                        else
                        {
                            f.resultBox.Text += ">Набор данных не содержит поле \"" + tc.Column_name + "\"" + Environment.NewLine;
                            return;
                        }
                    }
                    else
                    {// если в запросе звездочки
                        for (int k = 0; k < foundRows[0].Table.Columns.Count; k++)
                        {
                            newColumn = foundRows[0].Table.Columns[k];
                            DataColumn cl = new DataColumn();
                            cl.ColumnName = newColumn.ColumnName;
                            cl.Caption = newColumn.Caption;
                            cl.DataType = newColumn.DataType;
                            rsltTable.Columns.Add(cl);
                        }
                    }
                }

                //копируем строки в rsltTable
                for (int i = 0; i < foundRows.Length; i++)
                {
                    DataRow row = rsltTable.NewRow();
                    for (int j = 0; j < rsltTable.Columns.Count; j++)
                    {
                        string colName = rsltTable.Columns[j].ColumnName;
                        row[colName] = foundRows[i][colName];
                    }
                    rsltTable.Rows.Add(row);
                }

                //выводим результат
                // печатаем шапку
                for (int i = 0; i < rsltTable.Columns.Count; i++)
                {
                    f.resultBox.Text += "<" + rsltTable.Columns[i].Caption + ">\t";
                }
                f.resultBox.Text += Environment.NewLine;

                // Печатаем результирующаю таблицу
                for (int i = 0; i < rsltTable.Rows.Count; i++)
                {
                    for (int j = 0; j < rsltTable.Rows[i].ItemArray.Length; j++)
                    {
                        f.resultBox.Text += rsltTable.Rows[i][j] + "\t";
                    }
                    f.resultBox.Text += Environment.NewLine;
                }
            }
            catch (Exception e)
            {
                f.resultBox.Text += ">" + e.Message + Environment.NewLine;
            }
        }

        //выполнить Create table
        public void CreateTable()
        {
            try
            {
                //находим  имя таблицы, из которой делаем выборку даных
                String table = TreeHelper.FindCreateTableName(f.treeView.Nodes[0]);

                //находим столбцы
                List<CreateTableColumn> columns = TreeHelper.FindCreateTableColumns(f.treeView.Nodes[0]);

                //создаем DataTable
                DataTable newTable = new DataTable();
                newTable.TableName = table;

                //создаем поля
                for (int i = 0; i < columns.Count; i++)
                {
                    CreateTableColumn cl = columns[i];
                    DataColumn newColumn = new DataColumn();
                    newColumn.ColumnName = cl.Column_name;
                    switch (cl.ColumnType)
                    {
                        case "int": newColumn.DataType = System.Type.GetType("System.Int32"); break;
                        case "integer": newColumn.DataType = System.Type.GetType("System.Int32"); break;
                        case "char": newColumn.DataType = System.Type.GetType("System.String"); break;
                        case "number": newColumn.DataType = System.Type.GetType("System.Decimal"); break;
                        case "datetime": newColumn.DataType = System.Type.GetType("System.DateTime"); break;
                        default: newColumn.DataType = System.Type.GetType("System.String"); break;
                    }
                    newTable.Columns.Add(newColumn);
                }

                ds.Tables.Add(newTable);
                f.resultBox.Text += ">Ок";
            }
            catch (Exception e)
            {
                f.resultBox.Text += ">" + e.Message + Environment.NewLine;
            }
        }

        //выполнить Drop table
        public void DropTable()
        {
            try
            {
                //находим  имя таблицы, из которой делаем выборку даных
                String table = TreeHelper.FindCreateTableName(f.treeView.Nodes[0]);

                ds.Tables.Remove(table);
                f.resultBox.Text += ">Ок";
            }
            catch (Exception e)
            {
                f.resultBox.Text += ">" + e.Message + Environment.NewLine;
            }
        }

        //выполнить Insert
        public void Insert()
        {
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;

                //находим  имя таблицу, из которой делаем выборку даных
                String tableName = TreeHelper.FindCreateTableName(f.treeView.Nodes[0]);
                DataTable tbl = ds.Tables[tableName];

                //находим столбцы
                List<string> columns = TreeHelper.FindInsertColumns(f.treeView.Nodes[0]);
                //значения столбцов
                List<string> values = TreeHelper.FindInsertValues(f.treeView.Nodes[0]);

                // вставляем строку                {
                DataRow row = tbl.NewRow();
                for (int i = 0; i < columns.Count; i++)
                {
                    if (tbl.Columns[i].DataType == System.Type.GetType("System.String"))
                    {
                        row[columns[i]] = values[i].Replace("'", ""); //удаляем лишние одинарные кавычки
                    }
                    else
                        if (tbl.Columns[i].DataType == System.Type.GetType("System.DateTime"))
                        {
                            try
                            {
                                row[columns[i]] = DateTime.ParseExact(values[i].Replace("'", ""), "dd.MM.yyyy HH:mm:ss", provider); //преобразуем строку в дату
                            }
                            catch
                            {
                                try
                                {
                                    row[columns[i]] = DateTime.ParseExact(values[i].Replace("'", ""), "dd.MM.yyyy HH:mm", provider); //преобразуем строку в дату
                                }
                                catch
                                {
                                    try
                                    {
                                        row[columns[i]] = DateTime.ParseExact(values[i].Replace("'", ""), "dd.MM.yyyy HH", provider); //преобразуем строку в дату
                                    }
                                    catch
                                    {
                                        row[columns[i]] = DateTime.ParseExact(values[i].Replace("'", ""), "dd.MM.yyyy", provider); //преобразуем строку в дату
                                    }
                                }

                            }

                        }
                        else
                        {
                            if (tbl.Columns[i].DataType == System.Type.GetType("System.Decimal"))
                            {
                                row[columns[i]] = Convert.ToDecimal(values[i], new CultureInfo("en-US"));
                            }
                            else
                            row[columns[i]] = values[i];
                        }
                }
                tbl.Rows.Add(row);

                f.resultBox.Text += ">Ок";
            }
            catch (Exception e)
            {
                f.resultBox.Text += ">" + e.Message + Environment.NewLine;
            }
        }

        //выполнить Delete
        public void Delete()
        {
            try
            {
                //находим  имя таблицу, из которой делаем выборку даных
                String tableName = TreeHelper.FindCreateTableName(f.treeView.Nodes[0]);
                DataTable tbl = ds.Tables[tableName];

                //условие отбора строk для удаления
                string where = th.FindWhere();

                DataRow[] foundRows = tbl.Select(where);

                for (int i = 0; i < foundRows.Length; i++)
                {
                    foundRows[i].Delete();
                }
                f.resultBox.Text += ">Ок";
            }
            catch (Exception e)
            {
                f.resultBox.Text += ">" + e.Message + Environment.NewLine;
            }
        }

        //выполнить Update
        public void Update()
        {
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;

                //находим  имя таблицу, из которой делаем выборку даных
                String tableName = TreeHelper.FindCreateTableName(f.treeView.Nodes[0]);
                DataTable tbl = ds.Tables[tableName];

                //условие отбора стро для удаления
                string where = th.FindWhere();

                //находим столбцы
                List<string> columns = TreeHelper.FindUpdateColumns(f.treeView.Nodes[0]);
                //значения столбцов
                List<string> values = TreeHelper.FindUpdateValues(f.treeView.Nodes[0]);

                DataRow[] foundRows = tbl.Select(where);

                //Обновляем отобранные строки
                for (int i = 0; i < foundRows.Length; i++)
                {
                    for (int j=0; j < columns.Count; j++) // цикл по обновляемым полям
                    {
                        if (tbl.Columns[columns[j]].DataType == System.Type.GetType("System.String"))
                        {
                            foundRows[i][columns[j]] = values[j].Replace("'", ""); //удаляем лишние одинарные кавычки
                        }
                        else
                            if (tbl.Columns[columns[j]].DataType == System.Type.GetType("System.DateTime"))
                            {
                                try
                                {
                                    foundRows[i][columns[j]] = DateTime.ParseExact(values[j].Replace("'", ""), "dd.MM.yyyy HH:mm", provider); //преобразуем строку в дату
                                }
                                catch
                                {
                                    try
                                    {
                                        foundRows[i][columns[j]] = DateTime.ParseExact(values[j].Replace("'", ""), "dd.MM.yyyy HH", provider); //преобразуем строку в дату
                                    }
                                    catch
                                    {
                                        foundRows[i][columns[j]] = DateTime.ParseExact(values[j].Replace("'", ""), "dd.MM.yyyy", provider); //преобразуем строку в дату
                                    }
                                }

                            }
                            else
                            {
                                if (tbl.Columns[columns[j]].DataType == System.Type.GetType("System.Decimal"))
                                {
                                    foundRows[i][columns[j]] =Convert.ToDecimal(values[j],new CultureInfo("en-US"));
                                }
                                else
                                    foundRows[i][columns[j]] = values[j];
                            }
                    }
                }
                f.resultBox.Text += ">Ок";
            }
            catch (Exception e)
            {
                f.resultBox.Text += ">" + e.Message + Environment.NewLine;
            }
        }

    }
}
