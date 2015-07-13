using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime;
using CodeHelper.Core.Error;
using Antlr4.Runtime.Tree;

namespace CodeHelper.Core.Parse.ParseResults
{
    public class ErrorListener : BaseErrorListener
    {
        private List<ParseErrorInfo> errors = new List<ParseErrorInfo>();

        public List<ParseErrorInfo> Errors
        {
            get
            {
                return errors;
            }
        }

        public void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)

        //public void syntaxError(Recognizer<?, ?> recognizer,
        //    Object offendingSymbol,
        //    int line, int charPositionInLine,
        //    String msg,
        //    RecognitionException e)
        {
            if (recognizer is Antlr4.Runtime.Parser)
            {
                var stack = ((Antlr4.Runtime.Parser)recognizer).GetRuleInvocationStack();
                stack.Reverse();
                //System.err.println("rule stack: "+stack);
            }
            //System.err.println("line "+line+":"+charPositionInLine+" at "+
            //offendingSymbol+": "+msg);

            ParseErrorInfo errorInfo = new ParseErrorInfo();
            errorInfo.Line = line;
            errorInfo.CharPositionInLine = charPositionInLine;
            errorInfo.Message = msg;

            this.errors.Add(errorInfo);
            //base.SyntaxError(recognizer, offendingSymbol, line, charPositionInLine, msg, e);
        }

        /**
         * @return the errors
         */
        public List<ParseErrorInfo> getErrors()
        {
            return errors;
        }

        /**
         * @param errors the errors to set
         */
        public void setErrors(List<ParseErrorInfo> errors)
        {
            this.errors = errors;
        }

        public override void ReportAmbiguity(Antlr4.Runtime.Parser recognizer, Antlr4.Runtime.Dfa.DFA dfa, int startIndex, int stopIndex, bool exact, Antlr4.Runtime.Sharpen.BitSet ambigAlts, Antlr4.Runtime.Atn.ATNConfigSet configs)
        {
            // <editor-fold defaultstate="collapsed" desc="Compiled Code">
            /* 0: return
             *  */
            // </editor-fold>
            base.ReportAmbiguity(recognizer, dfa, startIndex, stopIndex, exact, ambigAlts, configs);
        }

        public override void ReportAttemptingFullContext(Antlr4.Runtime.Parser recognizer, Antlr4.Runtime.Dfa.DFA dfa, int startIndex, int stopIndex, Antlr4.Runtime.Sharpen.BitSet conflictingAlts, Antlr4.Runtime.Atn.SimulatorState conflictState)
        {
            // <editor-fold defaultstate="collapsed" desc="Compiled Code">
            /* 0: return
             *  */
            // </editor-fold>
            base.ReportAttemptingFullContext(recognizer, dfa, startIndex, stopIndex, conflictingAlts, conflictState);
        }

        public override void ReportContextSensitivity(Antlr4.Runtime.Parser recognizer, Antlr4.Runtime.Dfa.DFA dfa, int startIndex, int stopIndex, int prediction, Antlr4.Runtime.Atn.SimulatorState acceptState)
        {
            // <editor-fold defaultstate="collapsed" desc="Compiled Code">
            /* 0: return
             *  */
            // </editor-fold>
            base.ReportContextSensitivity(recognizer, dfa, startIndex, stopIndex, prediction, acceptState);
        }
    }

    public class ErrorListenerSymbol : IAntlrErrorListener<int>
    {
        private List<ParseErrorInfo> errors = new List<ParseErrorInfo>();

        public List<ParseErrorInfo> Errors
        {
            get
            {
                return errors;
            }
        }

        public void SyntaxError(IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            if (recognizer is Antlr4.Runtime.Parser)
            {
                var stack = ((Antlr4.Runtime.Parser)recognizer).GetRuleInvocationStack();
                stack.Reverse();
                //System.err.println("rule stack: "+stack);
            }
            //System.err.println("line "+line+":"+charPositionInLine+" at "+
            //offendingSymbol+": "+msg);

            ParseErrorInfo errorInfo = new ParseErrorInfo();
            errorInfo.Line = line;
            errorInfo.CharPositionInLine = charPositionInLine;
            errorInfo.Message = msg;

            this.errors.Add(errorInfo);
        }
    }

    public class AntlrErrorListener<Token> : IAntlrErrorListener<Token>
    {
        public void SyntaxError(IRecognizer recognizer, Token offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {

        }
    }

    public class ParseTreeListener : IParseTreeListener
    {
        private List<ParseErrorInfo> errors = new List<ParseErrorInfo>();

        public List<ParseErrorInfo> Errors
        {
            get
            {
                return errors;
            }
        }

        public void EnterEveryRule(ParserRuleContext ctx)
        {
            //errors.Add(new ParseErrorInfo() {
            //    Line = ctx.Start.Line, CharPositionInLine = ctx.Start.StartIndex,
            //     ErrorType = ErrorType.Error
            //});

            if (ctx.exception != null)
            {

            }
        }

        public void ExitEveryRule(ParserRuleContext ctx)
        {
            //errors.Add(new ParseErrorInfo()
            //{
            //    Line = ctx.Start.Line,
            //    CharPositionInLine = ctx.Start.StartIndex,
            //    ErrorType = ErrorType.Error
            //});
        }

        public void VisitErrorNode(IErrorNode node)
        {
            errors.Add(new ParseErrorInfo()
            {
                Line = node.Symbol.Line,
                CharPositionInLine = node.Symbol.StartIndex,
                ErrorType = ErrorType.Error,
                 Message = "无法识别:" + node.GetText()
            });            
        }

        public void VisitTerminal(ITerminalNode node)
        {
            //errors.Add(new ParseErrorInfo()
            //{
            //    Line = node.Symbol.Line,
            //    CharPositionInLine = node.Symbol.StartIndex,
            //    ErrorType = ErrorType.Error
            //});
        }
    }
}