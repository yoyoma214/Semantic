using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Error;

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
    }

    public class Statement : TokenPair
    {
        public Directive Directive { get; set; }
        public Triples Triples { get; set; }
    }

    public class Directive : TokenPair
    {
        public PrefixID PrefixID { get; set; }
        public Base Base { get; set; }
        public SparqlPrefix SparqlPrefix { get; set; }
        public SparqlBase SparqlBase { get; set; }
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
    }

    public class PrefixID : TokenPair
    {
        public string PNAME_NS { get; set; }
        public string IRIREF { get; set; }
    }

    public class Base : TokenPair
    {
        public string IRIREF { get; set; }
    }

    public class SparqlPrefix : TokenPair
    {
        public string PNAME_NS { get; set; }
        public string IRIREF { get; set; }
    }

    public class SparqlBase : TokenPair
    {
        public string IRIREF { get; set; }
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
    }

    public class PredicateObjectList : TokenPair
    {
        public PredicateObjectList()
        {
            this.Verbs = new List<Verb>();
            this.ObjectLists = new List<ObjectList>();
        }

        public List<Verb> Verbs { get; set; }
        public List<ObjectList> ObjectLists { get; set; }
    }

    public class BlankNodePropertyList : TokenPair
    {
        public PredicateObjectList PredicateObjectList { get; set; }
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
    }

    public class ObjectList : TokenPair
    {
        public ObjectList()
        {
            this.Objects = new List<Object>();
        }

        public List<Object> Objects { get; set; }
    }

    public class Predicate : TokenPair
    {
        public IRI IRI { get; set; }
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
    }

    public class Collection : TokenPair
    {
        public Collection()
        {
            this.Objects = new List<Object>();
        }

        public List<Object> Objects { get; set; }
    }

    public class Object : TokenPair
    {
        public IRI IRI { get; set; }

        public BlankNode BlankNode { get; set; }

        public Collection Collection { get; set; }

        public BlankNodePropertyList BlankNodePropertyList { get; set; }

        public Literal Literal { get; set; }
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
    }

    public class BlankNode : TokenPair
    {
        public string BLANK_NODE_LABEL { get; set; }

        public string ANON { get; set; }
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

    }
}
