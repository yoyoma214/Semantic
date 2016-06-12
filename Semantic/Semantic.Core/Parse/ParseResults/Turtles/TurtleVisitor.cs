using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;

namespace CodeHelper.Core.Parse.ParseResults.Turtles
{
    class TurtleVisitor : TurtleBaseVisitor<int> 
    {
        StackUtil stack = new StackUtil();

        public TurtleDoc Root = new TurtleDoc();

        public override int VisitPrefixedName([NotNull] TurtleParser.PrefixedNameContext context) {

            var prefixedName = this.stack.PeekCtx<PrefixedName>();
            prefixedName.Parse(context);

            var txt = context.PNAME_NS();
            if (txt != null)
            {
                prefixedName.PNAME_NS = context.PNAME_NS().GetText();
            }

            txt = context.PNAME_LN();

            if (txt != null)
            {
                prefixedName.PNAME_LN = context.PNAME_LN().GetText();
            }
            
            return 0;                        
        }

        public override int VisitSparqlBase([NotNull] TurtleParser.SparqlBaseContext context) {

            var sparqlBase = this.stack.PeekCtx<SparqlBase>();
            sparqlBase.Parse(context);

            var txt = context.IRIREF();
            if (txt != null)
            {
                sparqlBase.IRIREF = context.IRIREF().GetText();
            }
            return 0;
        }

        public override int VisitPrefixID([NotNull] TurtleParser.PrefixIDContext context) {

            var prefixID = this.stack.PeekCtx<PrefixID>();
            prefixID.Parse(context);

            var txt = context.PNAME_NS();
            if (txt != null)
            {
                prefixID.PNAME_NS = context.PNAME_NS().GetText();
            }

            txt = context.IRIREF();
            if (txt != null)
            {
                prefixID.IRIREF = context.IRIREF().GetText();
            }

            return 0;
        }

        public override int VisitSubject([NotNull] TurtleParser.SubjectContext context) {
            try
            {
                var subject = this.stack.PeekCtx<Subject>();
                subject.Parse(context);

                var iriCtx = context.iRI();
                if (iriCtx != null)
                {
                    var iri = new IRI();
                    subject.IRI = iri;
                    this.stack.Push(iri);
                    this.Visit(iriCtx);
                    this.stack.Pop();
                }

                var blankNodeCtx = context.blankNode();
                if (blankNodeCtx != null)
                {
                    var blankNode = new BlankNode();
                    subject.BlankNode = blankNode;
                    this.stack.Push(blankNode);
                    this.Visit(blankNodeCtx);
                    this.stack.Pop();
                }

                var collectionCtx = context.collection();
                if (collectionCtx != null)
                {
                    var collection = new Collection();
                    subject.Collection = collection;
                    this.stack.Push(collection);
                    if (iriCtx == null)
                    {
                    }
                    this.Visit(iriCtx);
                    this.stack.Pop();
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
            return 0;
        }

        public override int VisitPredicate([NotNull] TurtleParser.PredicateContext context) {

            var predicate = this.stack.PeekCtx<Predicate>();
            predicate.Parse(context);

            var iriCtx = context.iRI();
            if (iriCtx != null)
            {
                var iri = new IRI();
                predicate.IRI = iri;
                this.stack.Push(iri);
                this.Visit(iriCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitCollection([NotNull] TurtleParser.CollectionContext context) {
            var collection = this.stack.PeekCtx<Collection>();
            collection.Parse(context);

            var objectCtxs = context.@object();
            foreach(var ctx in objectCtxs )
            {
                var obj = new Object();
                collection.Objects.Add(obj);
                this.stack.Push(obj);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObject([NotNull] TurtleParser.ObjectContext context) {
            var _object = this.stack.PeekCtx<Object>();
            _object.Parse(context);

            var iriCtx = context.iRI();
            if (iriCtx != null)
            {
                var iri = new IRI();
                _object.IRI = iri;
                this.stack.Push(iri);
                this.Visit(iriCtx);
                this.stack.Pop();
            }
            var blankNodeCtx = context.blankNode();
            if (blankNodeCtx != null)
            {
                var blankNode = new BlankNode();
                _object.BlankNode = blankNode;
                this.stack.Push(blankNode);
                this.Visit(blankNodeCtx);
                this.stack.Pop();
            }
            var collectionCtx = context.collection();
            if (collectionCtx != null)
            {
                var collection = new Collection();
                _object.Collection = collection;
                this.stack.Push(collection);
                this.Visit(collectionCtx);
                this.stack.Pop();
            }
            var blankNodePropertyListCtx = context.blankNodePropertyList();
            if (blankNodePropertyListCtx != null)
            {
                var blankNodePropertyList = new BlankNodePropertyList();
                _object.BlankNodePropertyList = blankNodePropertyList;
                this.stack.Push(blankNodePropertyList);
                this.Visit(blankNodePropertyListCtx);
                this.stack.Pop();
            }
            var literalCtx = context.literal();
            if (literalCtx != null)
            {
                var literal = new Literal();
                _object.Literal = literal;
                this.stack.Push(literal);
                this.Visit(literalCtx);
                this.stack.Pop();
            }
            return 0;
        }

        public override int VisitObjectList([NotNull] TurtleParser.ObjectListContext context) {

            var objectList = this.stack.PeekCtx<ObjectList>();
            objectList.Parse(context);

            var ss = context.@object();

            foreach (var s in ss)
            {
                var obj = new Object();
                this.stack.Push(obj);
                objectList.Objects.Add(obj);
                this.Visit(s);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitTurtleDoc([NotNull] TurtleParser.TurtleDocContext context) {

            Root.Parse(context);
            this.stack.Push(Root);
            var ss = context.GetRuleContexts<TurtleParser.StatementContext>();
            foreach (var s in ss)
            {
                var statement = new Statement();
                this.stack.Push(statement);
                Root.Statements.Add(statement);
                this.VisitStatement(s);
                this.stack.Pop();
            }

            return 0;
            //return VisitChildren(context); 
        }

        public override int VisitStatement([NotNull] TurtleParser.StatementContext context) {

            var statement = this.stack.PeekCtx<Statement>();
            statement.Parse(context);
            
            var directiveCtx = context.directive();
            if (directiveCtx != null)
            {
                var directive = new Directive();
                statement.Directive = directive;
                this.stack.Push(directive);
                this.Visit(directiveCtx);
                this.stack.Pop();
            }

            var triplesCtx = context.triples();
            if (triplesCtx != null)
            {
                var triples = new Triples();
                statement.Triples = triples;
                this.stack.Push(triples);
                this.Visit(triplesCtx);
                this.stack.Pop();
            }
            
            return 0;
        
        }

        public override int VisitVerb([NotNull] TurtleParser.VerbContext context) {
            var verb = this.stack.PeekCtx<Verb>();
            verb.Parse(context);

            var predicateCtx = context.predicate();
            if (predicateCtx != null)
            {
                var predicate = new Predicate();
                verb.Predicate = predicate;
                this.stack.Push(predicate);
                this.Visit(predicateCtx);
                this.stack.Pop();
            }

            if ( context.GetText() == "a")
            {
                verb.IsA = true;
            }

            return 0;
        }

        public override int VisitIRI([NotNull] TurtleParser.IRIContext context) {
            var iri = this.stack.PeekCtx<IRI>();
            iri.Parse(context);

            var prefixedNameCtx = context.prefixedName();
            if (prefixedNameCtx != null)
            {
                var prefixedName = new PrefixedName();
                iri.PrefixedName = prefixedName;
                this.stack.Push(prefixedName);
                this.Visit(prefixedNameCtx);
                this.stack.Pop();
            }

            if (context.IRIREF() != null)
            {
                iri.IRIREF = context.IRIREF().ToString();
            }
            return 0;
        }

        public override int VisitBlankNodePropertyList([NotNull] TurtleParser.BlankNodePropertyListContext context) {

            var blankNodePropertyList = this.stack.PeekCtx<BlankNodePropertyList>();
            blankNodePropertyList.Parse(context);

            var predicateObjectListCtx = context.predicateObjectList();
            if ( predicateObjectListCtx != null)
            {
                var predicateObjectList = new PredicateObjectList();
                blankNodePropertyList.PredicateObjectList = predicateObjectList;
                this.stack.Push(predicateObjectList);
                this.Visit(predicateObjectListCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitBase([NotNull] TurtleParser.BaseContext context) {
            var _base = this.stack.PeekCtx<Base>();
            _base.Parse(context);

            _base.IRIREF = context.IRIREF().GetText();

            return 0;
        }

        public override int VisitTriples([NotNull] TurtleParser.TriplesContext context) {
            var triples = this.stack.PeekCtx<Triples>();
            triples.Parse(context);

            var subjectCtx = context.subject();
            if (subjectCtx != null)
            {
                var subject = new Subject();
                triples.Subject = subject;
                this.stack.Push(subject);
                this.Visit(subjectCtx);
                this.stack.Pop();
            }

            var predicateObjectListCtx = context.predicateObjectList();
            if (predicateObjectListCtx != null)
            {
                var predicateObjectList = new PredicateObjectList();
                triples.PredicateObjectList = predicateObjectList;
                this.stack.Push(predicateObjectList);
                this.Visit(predicateObjectListCtx);
                this.stack.Pop();
            }

            var blankNodePropertyListCtx = context.blankNodePropertyList();
            if (blankNodePropertyListCtx != null)
            {
                var blankNodePropertyList = new BlankNodePropertyList();
                triples.BlankNodePropertyList = blankNodePropertyList;
                this.stack.Push(blankNodePropertyList);
                this.Visit(blankNodePropertyListCtx);
                this.stack.Pop();
            }


            return 0;
        }

        public override int VisitPredicateObjectList([NotNull] TurtleParser.PredicateObjectListContext context) {
            var predicateObjectList = this.stack.PeekCtx<PredicateObjectList>();
            predicateObjectList.Parse(context);

            var verbObjectListCtxs = context.verbObjectList();
            foreach (var ctx in verbObjectListCtxs)
            {
                var verbObjectList = new VerbObjectList();
                predicateObjectList.VerbObjectLists.Add(verbObjectList);
                this.stack.Push(verbObjectList);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitVerbObjectList([NotNull] TurtleParser.VerbObjectListContext context)
        {
            var verbObjectList = this.stack.PeekCtx<VerbObjectList>();
            verbObjectList.Parse(context);

            var verbCtx = context.verb();
            if (verbCtx != null)
            {
                verbObjectList.Verb = new Verb();
                this.stack.Push(verbObjectList.Verb);
                this.Visit(verbCtx);
                this.stack.Pop();
            }

            var objectListCtx = context.objectList();
            if (objectListCtx != null)
            {
                verbObjectList.ObjectList = new ObjectList();
                this.stack.Push(verbObjectList.ObjectList);
                this.Visit(objectListCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDirective([NotNull] TurtleParser.DirectiveContext context) {

            var directive = this.stack.PeekCtx<Directive>();
            directive.Parse(context);

            var prefixIDCtx = context.prefixID();
            if (prefixIDCtx != null)
            {
                var prefixID = new PrefixID();
                directive.PrefixID = prefixID;
                this.stack.Push(prefixID);
                this.Visit(prefixIDCtx);
                this.stack.Pop();
            }

            var baseCtx = context.@base();
            if (baseCtx != null)
            {
                var _base = new Base();
                directive.Base = _base;
                this.stack.Push(_base);
                this.Visit(baseCtx);
                this.stack.Pop();
            }

            var sparqlPrefixCtx = context.sparqlPrefix();
            if (sparqlPrefixCtx != null)
            {
                var sparqlPrefix = new SparqlPrefix();
                directive.SparqlPrefix = sparqlPrefix;
                this.stack.Push(sparqlPrefix);
                this.Visit(sparqlPrefixCtx);
                this.stack.Pop();
            }

            var sparqlBaseCtx = context.sparqlBase();
            if (sparqlBaseCtx != null)
            {
                var sparqlBase = new SparqlBase();
                directive.SparqlBase = sparqlBase;
                this.stack.Push(sparqlBase);
                this.Visit(sparqlBaseCtx);
                this.stack.Pop();
            }
            return 0;
        
        }

        public override int VisitSparqlPrefix([NotNull] TurtleParser.SparqlPrefixContext context) {

            var sparqlPrefix = this.stack.PeekCtx<SparqlPrefix>();
            sparqlPrefix.Parse(context);

            var txt = context.PNAME_NS();
            if (txt != null)
            {
                sparqlPrefix.PNAME_NS = txt.GetText();
            }
                      
            txt = context.IRIREF();
            if (txt != null)
            {
                sparqlPrefix.IRIREF = txt.GetText();
            }
            return 0;
        }

        public override int VisitLiteral([NotNull] TurtleParser.LiteralContext context) {

            var literal = this.stack.PeekCtx<Literal>();
            literal.Parse(context);

            if (context.RDFLiteral() != null)
                literal.RDFLiteral = context.RDFLiteral().GetText();

            if (context.NumericLiteral() != null)
                literal.NumericLiteral = context.NumericLiteral().GetText();

            if (context.BooleanLiteral() != null)
                literal.BooleanLiteral = context.BooleanLiteral().GetText();

            return 0;
        }
    }
}
