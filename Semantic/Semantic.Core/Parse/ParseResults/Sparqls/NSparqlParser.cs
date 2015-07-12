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
