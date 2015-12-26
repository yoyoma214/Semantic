using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Error;

namespace CodeHelper.Core.Parse.ParseResults.Swrls
{
    public class SwrlContext
    {
        public List<ParseErrorInfo> Errors { get; set; }
        public Guid? FileId { get; set; }
        public String File { get; set; }
        public List<String> Variables { get; set; }

        public SwrlContext()
        {
            this.Errors = new List<ParseErrorInfo>();
            this.Variables = new List<string>();
        }

        public void AddError(TokenPair token, String msg)
        {
            this.Errors.Add(new ParseErrorInfo()
            {
                CharPositionInLine = token.BeginToken.CharPositionInLine,
                Line = token.BeginToken.Line,
                ErrorType = ErrorType.Wise,
                FileId = this.FileId,
                File = File,
                Message = msg
            });
        }

        public void AddVariable(string variable)
        {
            if (this.Variables.Contains(variable))
                return;

            this.Variables.Add(variable);
        }
    }
}