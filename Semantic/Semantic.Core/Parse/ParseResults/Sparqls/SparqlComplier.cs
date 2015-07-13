using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime;
using CodeHelper.Core.Parse.ParseResults.Sparqls;

namespace CodeHelper.Core.Parse.ParseResults.Sparqls
{
    public class SparqlComplier
    {
        public QueryUnit Parse(string input)
        {
            //var s = System.IO.File.ReadAllText(input);

            var stream = new AntlrInputStream(input);

            var lexer = new SparqlLexer(stream);

            var listener_symbol = new ErrorListenerSymbol();
            lexer.ErrorListeners.Clear();
            //lexer.AddErrorListener(listener_symbol);
            //lexer.AddErrorListener(new AntlrErrorListener<int>());
            

            var tokens = new CommonTokenStream(lexer);

            var parser = new NSparqlParser(tokens);
            
            parser.BuildParseTree = true;

            //parser.AddErrorListener(new ErrorListener());

            var listener = new ParseTreeListener();
            //parser.AddParseListener(listener);
            //var aa = parser.GetExpectedTokens();
            //parser.AddErrorListener(new ErrorListener());

            var tree = parser.queryUnit();

            var vis = new SparqlVisitor();

            vis.Visit(tree);

            //vis.Root.Errors.AddRange(listener_symbol.Errors);
            //vis.Root.Errors.AddRange(listener.Errors);

            var oo  = parser.GetMsg();
            return vis.Root;
        }

    }
}
