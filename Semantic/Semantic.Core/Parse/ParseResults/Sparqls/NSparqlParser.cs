using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime;

namespace CodeHelper.Core.Parse.ParseResults.Sparqls
{
    public class ErrorStrategy : DefaultErrorStrategy
    {
        public override void ReportError(Antlr4.Runtime.Parser recognizer, RecognitionException e)
        {
            base.ReportError(recognizer, e);
        }

        protected override void NotifyErrorListeners(Antlr4.Runtime.Parser recognizer, string message, RecognitionException e)
        {
            base.NotifyErrorListeners(recognizer, message, e);
        }

        protected override void EndErrorCondition(Antlr4.Runtime.Parser recognizer)
        {
            base.EndErrorCondition(recognizer);

            if (recognizer.NumberOfSyntaxErrors > 1)
            {
            }
        }

        protected override void BeginErrorCondition(Antlr4.Runtime.Parser recognizer)
        {
            base.BeginErrorCondition(recognizer);
            if (recognizer.NumberOfSyntaxErrors > 0)
            {
            }

        }

        protected override void ReportMissingToken(Antlr4.Runtime.Parser recognizer)
        {
            base.ReportMissingToken(recognizer);
        }

        protected override void ReportNoViableAlternative(Antlr4.Runtime.Parser recognizer, NoViableAltException e)
        {
            base.ReportNoViableAlternative(recognizer, e);
        }

        protected override void ReportInputMismatch(Antlr4.Runtime.Parser recognizer, InputMismatchException e)
        {
            base.ReportInputMismatch(recognizer, e);
        }
    }

    class NSparqlParser : SparqlParser
    {
        public NSparqlParser(ITokenStream input):base(input)
        {
            this._errHandler = new ErrorStrategy();
        }

        public object GetMsg()
        {
            var s = this._errHandler as Antlr4.Runtime.DefaultErrorStrategy;
            
            return null;
        }
    }
}
