using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Error;
using CodeHelper.Core.Parser;

namespace CodeHelper.Core.Parse.ParseResults.Turtles
{
    public class TurtleDoc : TokenPair
    {
        public TurtleDoc()
        {
            this.Statements = new List<Statement>();
            this.Errors = new List<ParseErrorInfo>();
        }

        public List<Statement> Statements { get; set; }

        public List<ParseErrorInfo> Errors { get; set; }

        internal void Parse(TurtleContext context)
        {
            foreach (var s in Statements)
            {
                s.Parse(context);

                context.FlushTriple(s);
            }
        }

        public void Wise(TurtleContext context)
        {
            foreach (var s in Statements)
            {
                s.Wise(context);                
            }
        }
    }

    public class Statement : TokenPair
    {
        public Directive Directive { get; set; }
        public Triples Triples { get; set; }

        internal void Parse(TurtleContext context)
        {
            if (this.Directive != null)
                this.Directive.Parse(context);
            if (this.Triples != null)
                this.Triples.Parse(context);
        }

        internal void Wise(TurtleContext context)
        {
            if (this.Directive != null)
                this.Directive.Wise(context);
            if (this.Triples != null)
                this.Triples.Wise(context);
        }
    }

    public class Directive : TokenPair
    {
        public PrefixID PrefixID { get; set; }
        public Base Base { get; set; }
        public SparqlPrefix SparqlPrefix { get; set; }
        public SparqlBase SparqlBase { get; set; }

        internal void Parse(TurtleContext context)
        {
            if (this.PrefixID != null)
                this.PrefixID.Parse(context);
            if (this.Base != null)
                this.Base.Parse(context);
            if (this.SparqlBase != null)
                this.SparqlBase.Parse(context);
            if (this.SparqlPrefix != null)
                this.SparqlPrefix.Parse(context);
        }

        internal void Wise(TurtleContext context)
        {
            if (this.PrefixID != null)
                this.PrefixID.Wise(context);
            if (this.Base != null)
                this.Base.Wise(context);
            if (this.SparqlBase != null)
                this.SparqlBase.Wise(context);
            if (this.SparqlPrefix != null)
                this.SparqlPrefix.Wise(context); 
        }
    }

    public class Triples : TokenPair
    {
        /// <summary>
        /// 与BlankNodePropertyList互斥存在
        /// </summary>
        public Subject Subject { get; set; }

        /// <summary>
        /// 与Subject互斥存在
        /// </summary>
        public BlankNodePropertyList BlankNodePropertyList { get; set; }

        public PredicateObjectList PredicateObjectList { get; set; }

        internal void Parse(TurtleContext context)
        {
            if (this.Subject != null)
                this.Subject.Parse(context);
            if (this.BlankNodePropertyList != null)
                this.BlankNodePropertyList.Parse(context);
            if (this.PredicateObjectList != null)
                this.PredicateObjectList.Parse(context);

            context.SubjectStack.Pop();
        }

        internal void Wise(TurtleContext context)
        {
            if (this.Subject != null)
                this.Subject.Wise(context);
            if (this.BlankNodePropertyList != null)
                this.BlankNodePropertyList.Wise(context);
            if (this.PredicateObjectList != null)
                this.PredicateObjectList.Wise(context);
        }
    }

    public class PrefixID : TokenPair
    {
        public string PNAME_NS { get; set; }
        public string IRIREF { get; set; }

        internal void Parse(TurtleContext context)
        {
            if (context.Imports.ContainsKey(this.PNAME_NS))
            {
                context.Errors.Add(new ParseErrorInfo() { 
                 ErrorType = ErrorType.Wise, Line = this.BeginToken.Line, CharPositionInLine = this.BeginToken.CharPositionInLine,
                  Message = "名字重复"
                });
                return;
            }
            context.Imports.Add(this.PNAME_NS, this.IRIREF);
        }

        internal void Wise(TurtleContext context)
        {
           
        }
    }

    public class Base : TokenPair
    {
        public string IRIREF { get; set; }

        internal void Parse(TurtleContext context)        
        {           
            //context.Imports.Add(":", this.IRIREF);
        }

        internal void Wise(TurtleContext context)
        {
            
        }
    }

    public class SparqlPrefix : TokenPair
    {
        public string PNAME_NS { get; set; }
        public string IRIREF { get; set; }

        internal void Parse(TurtleContext context)
        {
            context.Imports.Add(this.PNAME_NS, this.IRIREF);
        }

        internal void Wise(TurtleContext context)
        {
            
        }
    }

    public class SparqlBase : TokenPair
    {
        public string IRIREF { get; set; }

        internal void Parse(TurtleContext context)
        {
            //context.Imports.Add(":", this.IRIREF);
        }

        internal void Wise(TurtleContext context)
        {
            
        }
    }

    public class Subject : TokenPair
    {
        /// <summary>
        /// 与其他互斥
        /// </summary>
        public IRI IRI { get; set; }

        /// <summary>
        /// 与其他互斥
        /// </summary>
        public BlankNode BlankNode { get; set; }

        /// <summary>
        /// 与其他互斥
        /// </summary>
        public Collection Collection { get; set; }

        internal void Parse(TurtleContext context)
        {
            //context.FlushTriple();

            context.Visit = TurtleContext.VisitType.Subject;

            if (this.IRI != null)
            {
                this.IRI.Parse(context);
                context.SubjectStack.Push(new SubjectItem(context.CurrentSubjects.Last(),this));
            }
            else if (this.BlankNode != null)
            {
                this.BlankNode.Parse(context);
                context.SubjectStack.Push(new SubjectItem(context.CurrentSubjects.Last(), this));
            }
            else if (this.Collection != null)
            {
                context.SubjectStack.Push(new SubjectItem(context.CurrentSubjects.Last(), this));
                this.Collection.Parse(context);
            }

        }

        internal void Wise(TurtleContext context)
        {
            if (this.IRI != null)
            {
                this.IRI.Wise(context);
            }
            else if (this.BlankNode != null)
            {
                this.BlankNode.Wise(context);
            }
            else if (this.Collection != null)
            {
                this.Collection.Wise(context);
            }     
        }
    }

    public class PredicateObjectList : TokenPair
    {
        public PredicateObjectList()
        {
            //this.Verbs = new List<Verb>();
            //this.ObjectLists = new List<ObjectList>();
            this.VerbObjectLists = new List<VerbObjectList>();
        }

        //public List<Verb> Verbs { get; set; }
        //public List<ObjectList> ObjectLists { get; set; }

        public List<VerbObjectList> VerbObjectLists
        { get; set; }

        internal void Parse(TurtleContext context)
        {
            //if (this.Verbs[0].EndToken.Text == "owl:propertyChainAxiom")
            //{
            //}

            var newClz = false;
            TypeInfoBase clzCtx = null;

            for (var i = 0; i < this.VerbObjectLists.Count; i++)
            {
                context.Visit = TurtleContext.VisitType.Verb;
                this.VerbObjectLists[i].Parse(context);
                var verb = this.VerbObjectLists[i].Verb.VerbStr;

                if (verb == "rdf:type" || verb== "a")
                {
                    context.Visit = TurtleContext.VisitType.Object;
                    //this.ObjectLists[i].Parse(context);
                    var obj = context.CurrentVerbObjects.Last().Value.First();
                    if (obj == "owl:Class"
                         || obj == "rdfs:Datatype")
                    {
                        var clz = new TypeInfoBase();
                        //clz.Name = context.CurrentSubjects;
                        context.TypeStack.Push(clz);
                        clz.Name = OWLName.ParseLocalName(context.CurrentSubjects.First());
                        clz.FullName = context.CurrentSubjects.First();
                        clz.NameSpace = ":";
                        clz.TokenPair = this.VerbObjectLists[i];
                        context.Types.Add(clz.FullName, clz);
                        newClz = true;
                    }
                    else if (obj == "owl:ObjectProperty")
                    {
                        OWLProperty p = new OWLProperty();
                        p.Name = OWLName.ParseLocalName(context.CurrentSubjects.First());
                        p.FullName = context.CurrentSubjects.First();
                        p.NameSpace = ":";
                        p.IsObject = true;
                        p.TokenPair = context.SubjectStack.First().Data as TokenPair;
                        context.Properties.Add(p.FullName, p);
                    }
                    else if (obj == "owl:DatatypeProperty")
                    {
                        OWLProperty p = new OWLProperty();
                        p.Name = OWLName.ParseLocalName(context.CurrentSubjects.First());
                        p.FullName = context.CurrentSubjects.First();
                        p.NameSpace = ":";
                        p.IsObject = false;
                        p.TokenPair = context.SubjectStack.First().Data as TokenPair;
                        context.Properties.Add(p.FullName, p);
                    }
                    continue;
                }
                else if (verb == "owl:equivalentClass")
                {
                    var clz = new TypeInfoBase();
                    clz.Name = verb;
                    context.TypeStack.Push(clz);
                    newClz = true;
                }
                else if (verb == "rdfs:subClassOf")
                {
                    var clz = new TypeInfoBase();
                    clz.Name = verb;
                    context.TypeStack.Push(clz);
                    newClz = true;
                }
                else if (verb == "owl:intersectionOf")
                {
                    var clz = new TypeInfoBase();
                    clz.Name = verb;
                    context.TypeStack.Push(clz);
                    newClz = true;
                }

                //context.Visit = TurtleContext.VisitType.Object;
                //this.ObjectLists[i].Parse(context);

                foreach (var vo in context.CurrentVerbObjects)
                {
                    if ((vo.Key == "rdf:type" || vo.Key == "a") && vo.Value.First() == "owl:Restriction")
                    {
                        clzCtx = context.TypeStack.First() as TypeInfoBase;
                        break;
                    }
                }

                if (verb == "owl:equivalentClass")
                {
                    if (context.TypeStack.Count > 1 && clzCtx != null)
                    {
                        var parentClz = context.TypeStack.ElementAt(1) as TypeInfoBase;
                        parentClz.PropertyInfos.AddRange(clzCtx.PropertyInfos);
                    }
                }
                else if (verb == "rdfs:subClassOf")
                {
                    if (context.TypeStack.Count > 1)
                    {
                        if (context.CurrentSubjects.Count > 0)
                        {
                            var parentClz = context.TypeStack.ElementAt(1) as TypeInfoBase;
                            var child = context.CurrentSubjects[0];
                            var parent = context.CurrentVerbObjects.Values.ElementAt(0).ElementAt(0);
                            foreach (var t in context.Types)
                            {
                                if (t.Key == parent)
                                {
                                    foreach (var t2 in context.Types)
                                    {
                                        if (t2.Key != child)
                                            continue;

                                        t2.Value.Super = t.Value;
                                        t.Value.Children.Add(t2.Value);
                                    }
                                }
                            }
                        }
                        //parentClz.PropertyInfos.AddRange(clzCtx.PropertyInfos);
                    }
                }
                else if (verb == "rdfs:subPropertyOf")
                {

                    //var parentClz = context.TypeStack.ElementAt(1) as TypeInfoBase;
                    var child = context.CurrentSubjects[0];
                    var parent = context.CurrentVerbObjects.Values.ElementAt(0).ElementAt(0);
                    foreach (var t in context.Properties)
                    {
                        if (t.Key == parent)
                        {
                            foreach (var t2 in context.Properties)
                            {
                                if (t2.Key != child)
                                    continue;

                                t2.Value.Parent = t.Value;
                                t.Value.Children.Add(t2.Value);
                            }
                        }
                    }
                    //parentClz.PropertyInfos.AddRange(clzCtx.PropertyInfos);

                }
                //else if (verb == "owl:intersectionOf")
                //{
                //    if (context.TypeStack.Count > 1)
                //    {
                //        var parentClz = context.TypeStack.ElementAt(1) as TypeInfoBase;
                //        parentClz.PropertyInfos.AddRange(clzCtx.PropertyInfos);
                //    }
                //}
            }

            if (clzCtx != null)
            {
                foreach (var vo in context.CurrentVerbObjects)
                {
                    if (vo.Key == "owl:onProperty")
                    {
                        var p = new RestrictProperty();
                        p.Name = vo.Value.First();
                        p.TokenPair = this.VerbObjectLists[0];
                        //p.NameSpace = 
                        clzCtx.PropertyInfos.Add(p);
                    }
                }
            }

            if (newClz)
                context.TypeStack.Pop();
            //}

            //for (var i = 0; i < this.VerbObjectLists.Count; i++)
            //{
            //    //context.Visit = TurtleContext.VisitType.Verb;
            //    this.VerbObjectLists[i].Parse(context);
            //}

        }

        internal void Wise(TurtleContext context)
        {

            foreach (var vo in VerbObjectLists)
                vo.wise(context);
            //for (var i = 0; i < this.Verbs.Count; i++)
            //{
            //    context.Visit = TurtleContext.VisitType.Verb;
            //    this.Verbs[i].Wise(context);

            //    context.Visit = TurtleContext.VisitType.Object;
            //    this.ObjectLists[i].Wise(context);
            //}
        }
    }

    public class VerbObjectList : TokenPair
    {
        public VerbObjectList()
        {
        }
        public Verb Verb
        { get; set; }
        public ObjectList ObjectList
        { get; set; }

        internal void Parse(TurtleContext context)
        {
            var newClz = false;
            TypeInfoBase clzCtx = null;
            context.Visit = TurtleContext.VisitType.Verb;
            context.VerbStack.Push(new VerbItem());
            context.ObjectStack.Push(new ObjectItem());

            this.Verb.Parse(context);
            var verb = context.CurrentVerb;

            context.Visit = TurtleContext.VisitType.Object;
            this.ObjectList.Parse(context);

            //foreach (var vo in context.CurrentVerbObjects)
            //{
            //    if (vo.Key == "rdf:type" && vo.Value.First() == "owl:Restriction")
            //    {
            //        clzCtx = context.TypeStack.First() as TypeInfoBase;
            //        break;
            //    }
            //}

            //if (verb == "owl:equivalentClass")
            //{
            //    if (context.TypeStack.Count > 1 && clzCtx != null)
            //    {
            //        var parentClz = context.TypeStack.ElementAt(1) as TypeInfoBase;
            //        parentClz.PropertyInfos.AddRange(clzCtx.PropertyInfos);
            //    }
            //}
            //else if (verb == "rdfs:subClassOf")
            //{
            //    if (context.TypeStack.Count > 1 && clzCtx != null)
            //    {
            //        var parentClz = context.TypeStack.ElementAt(1) as TypeInfoBase;
            //        parentClz.PropertyInfos.AddRange(clzCtx.PropertyInfos);
            //    }
            //}
            //else if (verb == "owl:intersectionOf")
            //{
            //    if (context.TypeStack.Count > 1 && clzCtx != null)
            //    {
            //        var parentClz = context.TypeStack.ElementAt(1) as TypeInfoBase;
            //        parentClz.PropertyInfos.AddRange(clzCtx.PropertyInfos);
            //    }
            //}

            //if (clzCtx != null)
            //{
            //    foreach (var vo in context.CurrentVerbObjects)
            //    {
            //        if (vo.Key == "owl:onProperty")
            //        {
            //            var p = new RestrictProperty();
            //            p.Name = vo.Value.First();
            //            p.TokenPair = this.Verb;
            //            //p.NameSpace = 
            //            clzCtx.PropertyInfos.Add(p);
            //        }
            //    }
            //}

            //context.VerbStack.Pop();
            ////context.ObjectStack.Pop();

            //if (newClz)
            //    context.TypeStack.Pop();
        }

        internal void wise(TurtleContext context)
        {
            if (this.Verb != null)
                this.Verb.Wise(context);
            if (this.ObjectList != null)
                this.ObjectList.Wise(context);
        }
    }

    public class BlankNodePropertyList : TokenPair
    {
        public PredicateObjectList PredicateObjectList { get; set; }

        internal void Parse(TurtleContext context)
        {            

            if (this.PredicateObjectList != null)
            {
                context.FlushTriple(this);
                this.PredicateObjectList.Parse(context);
            }
        }

        internal void Wise(TurtleContext context)
        {
            if (this.PredicateObjectList != null)
            {
                this.PredicateObjectList.Wise(context);
            }
        }
    }

    public class Verb : TokenPair
    {
        /// <summary>
        /// 二者互斥存在
        /// </summary>
        public Predicate Predicate { get; set; }

        /// <summary>
        /// 二者互斥存在
        /// </summary>
        public bool IsA { get; set; }

        public string VerbStr
        {
            get;
            set;
        }

        internal void Parse(TurtleContext context)
        {
            context.Visit = TurtleContext.VisitType.Verb;

            if (this.Predicate != null)
                this.Predicate.Parse(context);

            if (this.IsA)
                context.AddTriple("a", this);

            //var verb = context.CurrentVerb;

            //if (verb == "rdf:type")
            //{               
            //    //var type = context.CurrentVerbObjects.Last().Value.First();
            //    //if (type == "owl:Class"
            //    //     || type == "rdfs:Datatype")
            //    //{
            //    //    var clz = new TypeInfoBase();
            //    //    context.TypeStack.Push(clz);
            //    //    clz.Name = OWLName.ParseLocalName(context.CurrentSubjects.First());
            //    //    clz.FullName = context.CurrentSubjects.First();
            //    //    clz.NameSpace = ":";
            //    //    clz.TokenPair = this.ObjectList;
            //    //    context.Types.Add(clz.FullName, clz);
            //    //}
            //}
            //else if (verb == "owl:equivalentClass")
            //{
            //    var clz = new TypeInfoBase();
            //    clz.Name = verb;
            //    context.TypeStack.Push(clz);
            //}
            //else if (verb == "rdfs:subClassOf")
            //{
            //    var clz = new TypeInfoBase();
            //    clz.Name = verb;
            //    context.TypeStack.Push(clz);
            //}
            //else if (verb == "owl:intersectionOf")
            //{
            //    var clz = new TypeInfoBase();
            //    clz.Name = verb;
            //    context.TypeStack.Push(clz);
            //}

            VerbStr = context.CurrentVerb;
        }

        internal void Wise(TurtleContext context)
        {
            if (this.Predicate != null)
                this.Predicate.Wise(context);

        }
    }

    public class ObjectList : TokenPair
    {
        public ObjectList()
        {
            this.Objects = new List<Object>();
        }

        public List<Object> Objects { get; set; }

        internal void Parse(TurtleContext context)
        {
            context.Visit = TurtleContext.VisitType.Object;

            TypeInfoBase clz = null;
            foreach (var obj in this.Objects)
            {
                obj.Parse(context);

                foreach (var vo in context.CurrentVerbObjects)
                {
                    if ((vo.Key == "rdf:type" || vo.Key=="a") && vo.Value.First() == "owl:Restriction")
                    {
                        clz = context.TypeStack.First() as TypeInfoBase;
                        break;
                    }
                }


            }
        }

        internal void Wise(TurtleContext context)
        {
            foreach (var obj in this.Objects)
                obj.Wise(context);
        }
    }

    public class Predicate : TokenPair
    {
        public IRI IRI { get; set; }

        internal void Parse(TurtleContext context)
        {
            context.Visit = TurtleContext.VisitType.Verb;

            if (this.IRI != null)
                this.IRI.Parse(context);
        }

        internal void Wise(TurtleContext context)
        {
            if (this.IRI != null)
                this.IRI.Wise(context);
        }
    }

    public class IRI : TokenPair
    {
        /// <summary>
        /// 二者互斥存在
        /// </summary>
        public string IRIREF { get; set; }

        /// <summary>
        /// 二者互斥存在
        /// </summary>
        public PrefixedName PrefixedName { get; set; }

        internal void Parse(TurtleContext context)
        {
            if (this.PrefixedName != null)
                this.PrefixedName.Parse(context);
            else
            {

                context.AddTriple(this.IRIREF, this);
            }

        }

        internal void Wise(TurtleContext context)
        {
            if (this.PrefixedName != null)
                this.PrefixedName.Wise(context);
        }
    }

    public class Collection : TokenPair
    {
        public Collection()
        {
            this.Objects = new List<Object>();
        }

        public List<Object> Objects { get; set; }

        internal void Parse(TurtleContext context)
        {
            foreach (var obj in this.Objects)
                obj.Parse(context);
        }

        internal void Wise(TurtleContext context)
        {
            foreach (var obj in this.Objects)
                obj.Wise(context);
        }
    }

    public class Object : TokenPair
    {
        public IRI IRI { get; set; }

        public BlankNode BlankNode { get; set; }

        public Collection Collection { get; set; }

        public BlankNodePropertyList BlankNodePropertyList { get; set; }

        public Literal Literal { get; set; }

        internal void Parse(TurtleContext context)
        {
            //context.ObjectStack.Push(new ObjectItem());

            if (this.IRI != null)
                 this.IRI.Parse(context);
            if (this.BlankNode != null)
                 this.BlankNode.Parse(context);
            if (this.Collection != null)
                 this.Collection.Parse(context);
            if (this.BlankNodePropertyList != null)
            {
                context.SubjectStack.Push(new SubjectItem("BlankNodePropertyList", this));
                this.BlankNodePropertyList.Parse(context);                
            }
            if (this.Literal != null)
                this.Literal.Parse(context);
        }

        internal void Wise(TurtleContext context)
        {
            if (this.IRI != null)
                this.IRI.Wise(context);
            if (this.BlankNode != null)
                this.BlankNode.Wise(context);
            if (this.Collection != null)
                this.Collection.Wise(context);
            if (this.BlankNodePropertyList != null)
                this.BlankNodePropertyList.Wise(context);
            if (this.Literal != null)
                this.Literal.Wise(context);
        }
    }

    public class PrefixedName : TokenPair
    {
        /// <summary>
        /// 排他存在
        /// </summary>
        public string PNAME_LN { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public string PNAME_NS { get; set; }

        internal void Parse(TurtleContext context)
        {
            if (this.PNAME_LN != null)
            {
                context.AddTriple(this.PNAME_LN, this);
            }
            if( this.PNAME_NS != null)
            {
                context.AddTriple(this.PNAME_NS, this);
            }
        }

        internal void Wise(TurtleContext context)
        {
            
        }
    }

    public class BlankNode : TokenPair
    {
        public string BLANK_NODE_LABEL { get; set; }

        public string ANON { get; set; }

        internal void Parse(TurtleContext context)
        {
            if (BLANK_NODE_LABEL != null)
            {
                context.AddTriple(this.BLANK_NODE_LABEL, this);
            }
            if (ANON != null)
            {
                context.AddTriple(this.ANON, this);
            }
        }

        internal void Wise(TurtleContext context)
        {
            
        }
    }

    public class Literal : TokenPair
    {
        /// <summary>
        /// 排他存在
        /// </summary>
        public string RDFLiteral { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public string NumericLiteral{get;set;}

        /// <summary>
        /// 排他存在
        /// </summary>
        public string BooleanLiteral{get;set;}


        internal void Parse(TurtleContext context)
        {
            if (this.RDFLiteral != null)
                context.AddTriple(this.RDFLiteral, this);
            if (this.NumericLiteral != null)
                context.AddTriple(this.NumericLiteral, this);
            if (this.BooleanLiteral != null)
                context.AddTriple(this.BooleanLiteral, this);
        }

        internal void Wise(TurtleContext context)
        {

        }
    }
}
