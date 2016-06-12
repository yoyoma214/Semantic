using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Error;
using ICSharpCode.TextEditor;
using CodeHelper.Core.Parser;
using CodeHelper.Core.Editor;

namespace CodeHelper.Core.Parse.ParseResults.Turtles
{
    public enum ParseItemType
    {
         Unknown,Clazz,Property,Instance
    }

    public class SubjectItem : ParseItem
    {
        public SubjectItem()
            : base()
        {
        }

        public SubjectItem(string name)
            : base(name)
        {
        }

        public SubjectItem(string name, object data)
            : base(name,data)
        {
        }

        public SubjectItem(string name, object data, ParseItemType type)
            : base(name, data, type)
        {
        }
    }

    public class VerbItem : ParseItem
    { public VerbItem()
            : base()
        {
        }

        public VerbItem(string name)
            : base(name)
        {
        }

        public VerbItem(string name, object data)
            : base(name,data)
        {
        }

        public VerbItem(string name, object data, ParseItemType type)
            : base(name, data, type)
        {
        }
    }

    public class ObjectItem : ParseItem
    {
        public ObjectItem()
            : base()
        {
        }

        public ObjectItem(string name)
            : base(name)
        {
        }

        public ObjectItem(string name, object data)
            : base(name,data)
        {
        }

        public ObjectItem(string name, object data, ParseItemType type)
            : base(name, data, type)
        {
        }
    }

    public class ParseItem
    {
        public ParseItem()
        {
        }

        public ParseItem(string name):this()
        {
            this.Name = name;
        }

        public ParseItem(string name,object data):this(name)
        {            
            this.Data = data;
        }

        public ParseItem(string name, object data,ParseItemType type):this(name,data)
        {            
            this.ParseItemType = type;
        }
        public TokenPair TokenPair { get; set; }
        public string Name{get;set;}
        public object Data{get;set;}
        public ParseItemType ParseItemType{get;set;}
    }

    public class TurtleContext
    {
        public enum VisitType
        {
            Unkonw,
            Subject,
            Verb,
            Object
        }

        public string NameSpace { get; set; }

        public Dictionary<string, TypeInfoBase> Types { get; set; }

        public Dictionary<string, OWLProperty> Properties { get; set; }

        public Dictionary<string, OWLInstance> Instances { get; set; }

        public Dictionary<string,string> Imports { get; set; }

        public List<ParseErrorInfo> Errors { get; set; }

        internal List<string> CurrentSubjects { get; set; }

        internal Dictionary<string, List<string>> CurrentVerbObjects { get; set; }

        internal string CurrentVerb { get; set; }

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

        internal Stack<object> TypeStack { get; set; }
        internal Stack<object> PropertyStack { get; set; }

        /// <summary>
        /// 主语堆栈
        /// </summary>
        internal Stack<SubjectItem> SubjectStack { get; set; }
        /// <summary>
        /// 谓语堆栈
        /// </summary>
        internal Stack<VerbItem> VerbStack { get; set; }
        /// <summary>
        /// 宾语堆栈
        /// </summary>
        internal Stack<ObjectItem> ObjectStack { get; set; }

        public TurtleDoc Root { get; set; }

        /// <summary>
        /// 是否在访问主语，否则在访问谓语和宾语
        /// </summary>
        public VisitType Visit { get; set; }

        public MyCaret Caret { get; set; }

        public TurtleContext()
        {
            this.Types = new Dictionary<string, TypeInfoBase>();

            this.Imports = new Dictionary<string, string>();

            this.Instances = new Dictionary<string, OWLInstance>();

            this.Properties = new Dictionary<string, OWLProperty>();

            this.Errors = new List<ParseErrorInfo>();

            this.CurrentSubjects = new List<string>();

            this.CurrentVerbObjects = new Dictionary<string, List<string>>();

            //this.PrevVerbs = new List<string>();

            this.PrevVerbObjects = new Dictionary<string, List<string>>();

            this.TypeStack = new Stack<object>();

            this.SubjectStack = new Stack<SubjectItem>();
            this.VerbStack = new Stack<VerbItem>();
            this.ObjectStack = new Stack<ObjectItem>();
            this.PropertyStack = new Stack<object>();
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
                        //if (tokenPair.EndToken.EndCharPositionInLine == this.Caret.Column)
                        if (tokenPair.EndToken.CharPositionInLine <= this.Caret.Column &&
                            tokenPair.EndToken.EndCharPositionInLine >= this.Caret.Column)
                        {
                            m_matchCaret = true;
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
                #region type
                if (vo.Key == "rdf:type" || vo.Key == "a")
                {
                    foreach (var obj in vo.Value)
                    {
                        if (obj == "owl:Ontology")
                        {
                            this.NameSpace = this.Imports[this.CurrentSubjects[0]];
                            break;
                        }

                        if (obj == "owl:Class" || obj == "rdfs:Datatype")//|| obj == "rdfs:subClassOf" || obj == "owl:equivalentClass")
                        {

                            //foreach (var subject in this.CurrentSubjects)
                            //{
                            //    if (!this.Types.ContainsKey(subject))
                            //    {
                            //        var t = new TypeInfoBase();
                            //        t.Name = OWLName.ParseLocalName(subject);
                            //        t.FullName = subject;
                            //        t.NameSpace = ":";
                            //        t.TokenPair = pair;
                            //        t.IsPrimitive = obj == "rdfs:Datatype";
                            //        this.Types.Add(t.FullName, t);
                            //    }
                            //}
                        }
                        else if (obj == "owl:ObjectProperty")
                        {
                            //foreach (var subject in this.CurrentSubjects)
                            //{
                            //    if (!this.Properties.ContainsKey(subject))
                            //    {
                            //        OWLProperty p = new OWLProperty();
                            //        p.Name = OWLName.ParseLocalName(subject);
                            //        p.FullName = subject;
                            //        p.NameSpace = this.NameSpace;
                            //        p.IsObject = true;
                            //        p.TokenPair = pair;
                            //        this.Properties.Add(p.FullName, p);
                            //    }
                            //}
                        }
                        else if (obj == "owl:DatatypeProperty")
                        {
                            //foreach (var subject in this.CurrentSubjects)
                            //{
                            //    if (!this.Properties.ContainsKey(subject))
                            //    {
                            //        OWLProperty p = new OWLProperty();
                            //        p.Name = OWLName.ParseLocalName(subject);
                            //        p.IsObject = false;
                            //        p.NameSpace = this.NameSpace;
                            //        p.FullName = subject;
                            //        p.TokenPair = pair;
                            //        this.Properties.Add(p.FullName, p);
                            //    }
                            //}
                        }
                        else if (obj == "owl:Restriction")
                        {
                        }                     
                        else
                        {
                            foreach (var subject in this.CurrentSubjects)
                            {
                                if (!this.Instances.ContainsKey(subject))
                                {
                                    OWLInstance p = new OWLInstance();
                                    p.Name = OWLName.ParseLocalName(subject);
                                    p.FullName = subject;
                                    p.NameSpace = this.NameSpace;
                                    p.Type = this.Parse(obj);
                                    p.TokenPair = pair;
                                    this.Instances.Add(p.FullName, p);
                                }
                            }
                        }
                    }
                }
                #endregion
                #region
                else if (vo.Key == "owl:intersectionOf")
                {                    
                }
                else if (vo.Key == "owl:onProperty")
                {
                }
                #endregion
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

        private TypeInfoBase Parse(string type)
        {
            if (this.Types.ContainsKey(type))
                return this.Types[type];

            return null;
        }
    }
}