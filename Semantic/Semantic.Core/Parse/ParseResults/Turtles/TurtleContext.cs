using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Error;
using ICSharpCode.TextEditor;

namespace CodeHelper.Core.Parse.ParseResults.Turtles
{
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

        public Dictionary<string,TypeInfoBase> Types { get; set; }

        public Dictionary<string,OWLProperty> Properties { get; set; }

        public Dictionary<string,OWLInstance> Instances { get; set; }

        public List<string> Imports { get; set; }

        public List<ParseErrorInfo> Errors { get; set; }

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

        public TurtleDoc Root { get; set; }

        /// <summary>
        /// 是否在访问主语，否则在访问谓语和宾语
        /// </summary>
        public VisitType Visit { get; set; }

        public Caret Caret { get; set; }

        public TurtleContext()
        {
            this.Types = new Dictionary<string, TypeInfoBase>();

            this.Imports = new List<string>();

            this.Instances = new Dictionary<string, OWLInstance>();

            this.Properties = new Dictionary<string, OWLProperty>();

            this.Errors = new List<ParseErrorInfo>();

            this.CurrentSubjects = new List<string>();

            this.CurrentVerbObjects = new Dictionary<string, List<string>>();
        }

        public void AddTriple(string part , TokenPair tokenPair)
        {
            if (part == "owl:equivalentClass")
            {
            }

            bool match = false;

            if (this.Caret != null)
            {
                if (tokenPair.BeginToken != null)
                {
                    if (tokenPair.BeginToken.Line == this.Caret.Line + 1)
                    {                        
                        if (tokenPair.EndToken.EndCharPositionInLine  == this.Caret.Column)
                        {
                            match = true;                            
                            Console.WriteLine("matched");
                        }
                    }
                }
            }

            if (this.Visit == VisitType.Subject)
            {
                CurrentSubjects.Add(part);

                if (match)
                    this.Subject = part;
            }
            else if ( this.Visit == VisitType.Verb)
            {
                CurrentVerbObjects.Add(part, new List<string>());
                CurrentVerb = part;

                if (match)
                    this.Verb = part;
            }
            else if (this.Visit == VisitType.Object)
            {
                this.CurrentVerbObjects[this.CurrentVerb].Add(part);

                if (match)
                    this.Object = part;
            }
        }

        public void FlushTriple()
        {
            foreach (var vo in this.CurrentVerbObjects)
            {
                if (vo.Key == "rdf:type")
                {
                    foreach (var obj in vo.Value)
                    {
                        if (obj == "rdf:Class" || obj == "rdfs:subClassOf" || obj == "owl:equivalentClass")
                        {
                            foreach (var subject in this.CurrentSubjects)
                            {
                                if (!this.Types.ContainsKey(subject))
                                {
                                    var t = new TypeInfoBase();
                                    t.Name = subject;
                                    t.NameSpace = null;
                                    this.Types.Add(t.Name, t);
                                }
                            }
                        }
                        else if (obj == "owl:ObjectProperty")
                        {
                            foreach (var subject in this.CurrentSubjects)
                            {
                                if (!this.Properties.ContainsKey(subject))
                                {
                                    OWLProperty p = new OWLProperty();
                                    p.Name = subject;
                                    p.IsObject = true;
                                    this.Properties.Add(p.Name, p);
                                }
                            }
                        }
                        else if (obj == "owl:DatatypeProperty")
                        {
                            foreach (var subject in this.CurrentSubjects)
                            {
                                if (!this.Properties.ContainsKey(subject))
                                {
                                    OWLProperty p = new OWLProperty();
                                    p.Name = subject;
                                    p.IsObject = false;
                                    this.Properties.Add(p.Name, p);
                                }
                            }
                        }
                        else
                        {
                            foreach (var subject in this.CurrentSubjects)
                            {
                                if (!this.Instances.ContainsKey(subject))
                                {
                                    OWLInstance p = new OWLInstance();
                                    p.Name = subject;
                                    p.Type = this.Parse(obj);
                                    this.Instances.Add(p.Name, p);
                                }
                            }
                        }
                    }
                }
            }

            this.CurrentSubjects.Clear();
            this.CurrentVerb = null;
            this.CurrentVerbObjects.Clear();
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
