using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

namespace PreSQL
{

    public class Visitor : PreSQLBaseVisitor<int>
    {
        private MainForm f;
        private TreeHelper th;
        private DB db;
        public bool noExec=true;

        public Visitor(Form fm)
        {
            f = fm as MainForm;
            th = f.th;
            db = f.db;
            noExec = f.noExecCheckBox.Checked;
        }

        //override public PreSQLParser.ErrorContext VisitSelect_stmt([NotNull] PreSQLParser.Select_stmtContext context)
        override public int VisitSelect_stmt([NotNull] PreSQLParser.Select_stmtContext context)
        {
            if (!noExec) db.Select();
            return 1;
        }


        override public int VisitInsert_stmt([NotNull] PreSQLParser.Insert_stmtContext context)
        {
            if (!noExec) db.Insert();
            return 1;
        }

        public override int VisitCreate_table_stmt([NotNull] PreSQLParser.Create_table_stmtContext context) 
        {
            if (!noExec) db.CreateTable();
            return 1; 
        }

        public override int VisitDrop_table_stmt([NotNull] PreSQLParser.Drop_table_stmtContext context) 
        {
            if (!noExec) db.DropTable();
            return 1;
        }

        public override int VisitDelete_stmt([NotNull] PreSQLParser.Delete_stmtContext context)
        {
            if (!noExec) db.Delete();
            return 1; 
        }

        public override int VisitUpdate_stmt([NotNull] PreSQLParser.Update_stmtContext context) 
        {
            if (!noExec) db.Update();
            return 1; 
        }

    }
}