using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Error;
using CodeHelper.Core.Parser;
using CodeHelper.Core.Editor;

namespace CodeHelper.Core.Parse.ParseResults.Sparqls
{
    public class Prefix
    {
        public String Name { get; set; }
        public String Value { get; set; }

        public bool EqualWith(Prefix other)
        {
            return this.Name == other.Name;
        }
    }

    public class BaseUrl
    {
        public String Value { get; set; }
    }

    public enum VisitType
    {
        Unkonw,
        Subject,
        Verb,
        Object
    }

    public class SparqlContext
    {

        private List<string> CurrentSubjects { get; set; }

        private Dictionary<string, List<string>> CurrentVerbObjects { get; set; }

        private string CurrentVerb { get; set; }

        /// <summary>
        /// 用户输入所在主语
        /// </summary>        
        public string Subject { get; set; }

        /// <summary>
        /// 用户输入所在谓语
        /// </summary>
        public string Verb { get; set; }

        /// <summary>
        /// 用户输入所在宾语
        /// </summary>
        public string Object { get; set; }

        /// <summary>
        /// 前面一个语句的主语
        /// </summary>
        public string PrevSubject { get; set; }

        //public List<string> PrevVerbs { get; set; }

        /// <summary>
        /// 前面一个语句的谓语宾语集合
        /// </summary>
        public Dictionary<string, List<string>> PrevVerbObjects { get; set; }

        /// <summary>
        /// 是否在访问主语，否则在访问谓语和宾语
        /// </summary>
        public VisitType Visit { get; set; }

        public MyCaret Caret { get; set; }
        public Boolean MatchByFake { get; set; }

        public BaseUrl Base{get;set;}
        public List<Prefix> Prefixs { get; set; }
        public List<String> Variables { get; set; }
        public List<ParseErrorInfo> Errors { get; set; }
        public Guid? FileId { get; set; }
        public String File { get; set; }

        public void AddError(TokenPair token, String msg)
        {
            this.Errors.Add(new ParseErrorInfo()
                {
                    CharPositionInLine = token.BeginToken.CharPositionInLine,
                    Line = token.BeginToken.Line,
                    ErrorType = ErrorType.Error,
                    FileId = this.FileId,
                    File = File,
                    Message = msg
                });
        }

        public OWLName? ResloveName(String name)
        {
            if (name.StartsWith("<"))
                return null;

            var ss = name.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            var ns = ss.Length == 1 ? ":" : ss[0];
            if (ns != ":")
                ns += ":";

            var var = ss.Length == 1 ? ss[0] : ss[1];
            foreach (var pre in this.Prefixs)
            {
                if (pre.Name == ns)
                {
                    return new OWLName() { LocalName = var, NameSpace = pre.Value };
                }
            }

            return null;
        }        

        public void AddVariable(String variable, TokenPair token)
        {
            if (this.Variables.Contains(variable))
                return;

            this.Variables.Add(variable);
        }

        public SparqlContext()
        {
            this.Prefixs = new List<Prefix>();
            this.Variables = new List<string>();
            this.Errors = new List<ParseErrorInfo>();
            this.CurrentSubjects = new List<string>();

            this.CurrentVerbObjects = new Dictionary<string, List<string>>();

            //this.PrevVerbs = new List<string>();

            this.PrevVerbObjects = new Dictionary<string, List<string>>();
            
        }

        /// <summary>
        /// false表示还未匹配，true表示正匹配处理中，null表示匹配处理后
        /// </summary>
        bool? m_matchCaret = false;

        public void AddTriple(string part, TokenPair tokenPair)
        {
            if (this.Caret != null)
            {
                if (tokenPair.BeginToken != null)
                {
                    if (tokenPair.BeginToken.Line == this.Caret.Line + 1)
                    {
                        if (tokenPair.EndToken.CharPositionInLine <= this.Caret.Column &&
                            tokenPair.EndToken.EndCharPositionInLine >= this.Caret.Column)
                        {
                            m_matchCaret = true;
                            Console.WriteLine("matched");
                        }
                        else if (tokenPair.EndToken.CharPositionInLine <= this.Caret.FakeColumn &&
                            tokenPair.EndToken.EndCharPositionInLine >= this.Caret.FakeColumn)
                        {
                            m_matchCaret = true;
                            MatchByFake = true;
                            Console.WriteLine("matched");
                        }
                    }
                }
            }

            if (this.Visit == VisitType.Subject)
            {
                CurrentSubjects.Add(part);

                if (m_matchCaret != null)
                {
                    this.Subject = part;
                }
                if (m_matchCaret == true)
                {
                    this.Verb = this.Object = null;                    
                }

            }
            else if (this.Visit == VisitType.Verb)
            {
 				CurrentVerb = part;
                if (!CurrentVerbObjects.ContainsKey(CurrentVerb))
                {
                    CurrentVerbObjects.Add(CurrentVerb, new List<string>());
                }
                else
                {
                }

                if (m_matchCaret != null)
                {
                    this.Verb = part;
                }

                if (m_matchCaret == true)
                {                    
                    this.Object = null;
                }
            }
            else if (this.Visit == VisitType.Object)
            {
                if (this.CurrentVerbObjects.Count == 0 || this.CurrentVerb == null)
                {
                    return;
                }

                this.CurrentVerbObjects[this.CurrentVerb].Add(part);

                if (m_matchCaret == true)
                    this.Object = part;
            }

            if (m_matchCaret == true)
                m_matchCaret = null;

            if (this.Caret == null)
            {
                this.Subject = this.Verb = this.Object = null;
            }
        }

        public void FlushTriple(TokenPair pair)
        {
            foreach (var vo in this.CurrentVerbObjects)
            {
            }

            if (m_matchCaret == false)
            {
                this.PrevSubject = this.Subject;
                this.PrevVerbObjects.Clear();
                foreach (var kv in this.CurrentVerbObjects)
                {
                    this.PrevVerbObjects.Add(kv.Key, kv.Value);
                }

                this.Subject = null;
                this.Verb = null;
                this.CurrentVerb = null;
            }

            this.CurrentVerbObjects.Clear();
            this.CurrentSubjects.Clear();
            this.Visit = VisitType.Unkonw;
        }
    }
}