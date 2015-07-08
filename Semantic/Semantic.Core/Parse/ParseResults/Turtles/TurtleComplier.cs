using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime;

namespace CodeHelper.Core.Parse.ParseResults.Turtles
{
    public class TurtleComplier
    {
        public TurtleDoc Parse(string input)
        {
            //var s = System.IO.File.ReadAllText(input);

            var stream = new AntlrInputStream(input);

            var lexer = new TurtleLexer(stream);

            var listener_symbol = new ErrorListenerSymbol();
            lexer.AddErrorListener(listener_symbol);

            var tokens = new CommonTokenStream(lexer);

            var parser = new TurtleParser(tokens);

            parser.BuildParseTree = true;

            //parser.AddErrorListener(new AntlrErrorListener<IToken>());

            var listener = new ParseTreeListener();
            parser.AddParseListener(listener);

            var tree = parser.turtleDoc();

            var vis = new TurtleVisitor();

            vis.Visit(tree);

            vis.Root.Errors.AddRange(listener_symbol.Errors);
            vis.Root.Errors.AddRange(listener.Errors);
            return vis.Root;
        }
    }
}
