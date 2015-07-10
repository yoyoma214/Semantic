using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime;

namespace CodeHelper.Core.Parse.ParseResults.Antlrs
{
    public class SparqlComplier
    {
        public GrammarSpec Parse(string input)
        {
            //var s = System.IO.File.ReadAllText(input);

            var stream = new AntlrInputStream(input);

            var lexer = new ANTLRv4Lexer(stream);

            var listener_symbol = new ErrorListenerSymbol();
            lexer.AddErrorListener(listener_symbol);

            var tokens = new CommonTokenStream(lexer);

            var parser = new ANTLRv4Parser(tokens);

            parser.BuildParseTree = true;

            //parser.AddErrorListener(new AntlrErrorListener<IToken>());

            var listener = new ParseTreeListener();
            parser.AddParseListener(listener);

            var tree = parser.grammarSpec();

            var vis = new Antlr4Visitor();

            vis.Visit(tree);

            vis.Root.Errors.AddRange(listener_symbol.Errors);
            vis.Root.Errors.AddRange(listener.Errors);
            return vis.Root;
        }

    }
}
