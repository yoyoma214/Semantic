﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Error;
using ICSharpCode.TextEditor;
using CodeHelper.Core.Parser;

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

        public Dictionary<string, TypeInfoBase> Types { get; set; }

        public Dictionary<string, OWLProperty> Properties { get; set; }

        public Dictionary<string, OWLInstance> Instances { get; set; }

        public Dictionary<string,string> Imports { get; set; }

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

            this.Imports = new Dictionary<string, string>();

            this.Instances = new Dictionary<string, OWLInstance>();

            this.Properties = new Dictionary<string, OWLProperty>();

            this.Errors = new List<ParseErrorInfo>();

            this.CurrentSubjects = new List<string>();

            this.CurrentVerbObjects = new Dictionary<string, List<string>>();
        }

        bool? m_matchCaret = false;

        public void AddTriple(string part, TokenPair tokenPair)
        {
            if (this.Caret != null)
            {
                if (tokenPair.BeginToken != null)
                {
                    if (tokenPair.BeginToken.Line == this.Caret.Line + 1)
                    {
                        if (tokenPair.EndToken.EndCharPositionInLine == this.Caret.Column)
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
                
                if ( m_matchCaret == false)
                    this.Subject = part;

                if (m_matchCaret== true)
                    this.Verb = this.Object = null;
            }
            else if (this.Visit == VisitType.Verb)
            {
                CurrentVerbObjects.Add(part, new List<string>());
                CurrentVerb = part;

                if (m_matchCaret == false)
                    this.Verb = part;
                if (m_matchCaret == true)
                    this.Object = null;                    
            }
            else if (this.Visit == VisitType.Object)
            {
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
                if (vo.Key == "rdf:type")
                {                    
                    foreach (var obj in vo.Value)
                    {
                        if (obj == "owl:Ontology")
                        {
                            this.NameSpace = this.CurrentSubjects[0];
                            break;
                        }

                        if (obj == "owl:Class" )//|| obj == "rdfs:subClassOf" || obj == "owl:equivalentClass")
                        {

                            foreach (var subject in this.CurrentSubjects)
                            {
                                if (!this.Types.ContainsKey(subject))
                                {
                                    var t = new TypeInfoBase();
                                    t.Name = OWLName.ParseLocalName(subject);
                                    t.FullName = subject;
                                    t.NameSpace = this.NameSpace;
                                    t.TokenPair = pair;
                                    this.Types.Add(t.FullName, t);
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
                                    p.Name = OWLName.ParseLocalName(subject);
                                    p.FullName = subject;
                                    p.NameSpace = this.NameSpace;
                                    p.IsObject = true;
                                    p.TokenPair = pair;
                                    this.Properties.Add(p.FullName, p);
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
                                    p.Name = OWLName.ParseLocalName(subject);                                    
                                    p.IsObject = false;
                                    p.NameSpace = this.NameSpace;
                                    p.FullName = subject;
                                    p.TokenPair = pair;
                                    this.Properties.Add(p.FullName, p);
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