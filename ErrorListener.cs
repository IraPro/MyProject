using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;
using Antlr4.Runtime;

namespace PreSQL
{
    public class ErrorListener : Antlr4.Runtime.BaseErrorListener
    {
        public override void SyntaxError(IRecognizer recognizer,
            IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            MainForm f = (MainForm)Application.OpenForms[0];
            TextBox tx = f.resultBox;
            tx.Text += Environment.NewLine + Environment.NewLine + "> line " + line.ToString() + ":" + charPositionInLine.ToString() + " at " + offendingSymbol.ToString() + ": " + msg;
               
        }

    }
}
