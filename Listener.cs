using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;

namespace PreSQL
{
    class Listener : PreSQLBaseListener
    {
        int i;
        public override void ExitFunction_name(PreSQLParser.Function_nameContext context) 
        {
            string s=context.GetText();
        }

        public override void EnterFunction_name(PreSQLParser.Function_nameContext context)
        {
            string s = context.GetText();
        }

        public override void VisitTerminal(ITerminalNode node) { }

    }
}
