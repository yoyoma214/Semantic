using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime;
//using CodeHelper.Core.Parse.ParseResults.DataViews;

namespace CodeHelper.Core.Parse.ParseResults
{
    public class Token:IToken
    {

        public Token() { }

        public Token(int line, int charPosiotiohInLine)
        {
            this.Line = line;
            this.CharPositionInLine = charPosiotiohInLine;
        }

        public int Line
        {
            get;
            set;
        }

        public int CharPositionInLine
        {
            get;
            set;
        }

        public int EndCharPositionInLine
        {
            get
            {
                return this.CharPositionInLine + this.Length;
            }
        }

        public int Length
        {
            get
            {
                return this.Text.Length;
            }
        }

        public string Text { get; set; }
        
    }

    public class TokenPair
    {
        public Token BeginToken { get; set; }
        public Token EndToken { get; set; }
        public TokenPair Parent { get; set; }
        public List<TokenPair> Children { get; set; }

        public TokenPair()
        {
            this.Children = new List<TokenPair>();
        }

        //public virtual SelectAtomContext Parse(SelectAtomContext ctx)
        //{
        //    return null;
        //}

        public void Parse(ParserRuleContext ctx)
        {
            if (ctx.Start != null)
            {
                this.BeginToken = new Token(ctx.Start.Line, ctx.Start.Column);
                this.BeginToken.Text = ctx.Start.Text;
            }
            if (ctx.Stop != null)
            {
                this.EndToken = new Token(ctx.Stop.Line, ctx.stop.Column);
                this.EndToken.Text = ctx.Stop.Text;
            }
        }
    }
}
