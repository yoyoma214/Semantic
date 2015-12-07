using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;
using CodeHelper.Core.Parse.ParseResults.Swrl;
using CodeHelper.Core.Parse.ParseResults.Swrls;
using CodeHelper.Core.Error;

namespace CodeHelper.Core.Parse.ParseResults.HermitRules
{
    class HermitRuleVisitor : HermitRuleBaseVisitor<int>
    {
        public Axioms Root = new Axioms();
        StackUtil stack = new StackUtil();
        public override int VisitAxioms([NotNull] HermitRuleParser.AxiomsContext context)
        {
            var axioms = this.Root;// this.stack.PeekCtx<Axioms>();
            axioms.Parse(context);

            var axiomCtxs = context.axiom();
            foreach (var ctx in axiomCtxs)
            {
                var axiom = new Axiom();
                axioms.AxiomList.Add(axiom);
                this.stack.Push(axiom);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var ruleNCtxs = context.ruleN();
            foreach (var ctx in ruleNCtxs)
            {
                var ruleN = new RuleN();
                axioms.RuleNs.Add(ruleN);
                this.stack.Push(ruleN);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var dGAxiomCtxs = context.dGAxiom();
            foreach (var ctx in dGAxiomCtxs)
            {
                var dGAxiom = new DGAxiom();
                axioms.DGAxioms.Add(dGAxiom);
                this.stack.Push(dGAxiom);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitRuleN([NotNull] HermitRuleParser.RuleNContext context)
        {
            var ruleN = this.stack.PeekCtx<RuleN>();
            ruleN.Parse(context);

            var dLSafeRuleCtx = context.dLSafeRule();
            if (dLSafeRuleCtx != null)
            {
                ruleN.DLSafeRule = new DLSafeRule();
                this.stack.Push(ruleN.DLSafeRule);
                this.Visit(dLSafeRuleCtx);
                this.stack.Pop();
            }

            var dGRuleCtx = context.dGRule();
            if (dGRuleCtx != null)
            {
                ruleN.DGRule = new DGRule();
                this.stack.Push(ruleN.DGRule);
                this.Visit(dGRuleCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDLSafeRule([NotNull] HermitRuleParser.DLSafeRuleContext context)
        {
            var dLSafeRule = this.stack.PeekCtx<DLSafeRule>();
            dLSafeRule.Parse(context);

            var DL_SAFE_RULECtx = context.DL_SAFE_RULE();
            if (DL_SAFE_RULECtx != null)
            {
                dLSafeRule.DLSAFERULE = DL_SAFE_RULECtx.GetText();
            }

            var annotationCtxs = context.annotation();
            foreach (var ctx in annotationCtxs)
            {
                var annotation = new Annotation();
                dLSafeRule.Annotations.Add(annotation);
                this.stack.Push(annotation);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var BODYCtx = context.BODY();
            if (BODYCtx != null)
            {
                dLSafeRule.BODY = BODYCtx.GetText();
            }

            var atomCtxs = context.atom();
            foreach (var ctx in atomCtxs)
            {
                var atom = new Atom();
                dLSafeRule.Atoms.Add(atom);
                this.stack.Push(atom);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var HEADCtx = context.HEAD();
            if (HEADCtx != null)
            {
                dLSafeRule.HEAD = HEADCtx.GetText();
            }

            return 0;
        }

        public override int VisitAxiom([NotNull] HermitRuleParser.AxiomContext context)
        {
            var axiom = this.stack.PeekCtx<Axiom>();
            axiom.Parse(context);

            var declarationCtx = context.declaration();
            if (declarationCtx != null)
            {
                axiom.Declaration = new Declaration();
                this.stack.Push(axiom.Declaration);
                this.Visit(declarationCtx);
                this.stack.Pop();
            }

            var classAxiomCtx = context.classAxiom();
            if (classAxiomCtx != null)
            {
                axiom.ClassAxiom = new ClassAxiom();
                this.stack.Push(axiom.ClassAxiom);
                this.Visit(classAxiomCtx);
                this.stack.Pop();
            }

            var objectPropertyAxiomCtx = context.objectPropertyAxiom();
            if (objectPropertyAxiomCtx != null)
            {
                axiom.ObjectPropertyAxiom = new ObjectPropertyAxiom();
                this.stack.Push(axiom.ObjectPropertyAxiom);
                this.Visit(objectPropertyAxiomCtx);
                this.stack.Pop();
            }

            var dataPropertyAxiomCtx = context.dataPropertyAxiom();
            if (dataPropertyAxiomCtx != null)
            {
                axiom.DataPropertyAxiom = new DataPropertyAxiom();
                this.stack.Push(axiom.DataPropertyAxiom);
                this.Visit(dataPropertyAxiomCtx);
                this.stack.Pop();
            }

            var datatypeDefinitionCtx = context.datatypeDefinition();
            if (datatypeDefinitionCtx != null)
            {
                axiom.DatatypeDefinition = new DatatypeDefinition();
                this.stack.Push(axiom.DatatypeDefinition);
                this.Visit(datatypeDefinitionCtx);
                this.stack.Pop();
            }

            var hasKeyCtx = context.hasKey();
            if (hasKeyCtx != null)
            {
                axiom.HasKey = new HasKey();
                this.stack.Push(axiom.HasKey);
                this.Visit(hasKeyCtx);
                this.stack.Pop();
            }

            var assertionCtx = context.assertion();
            if (assertionCtx != null)
            {
                axiom.Assertion = new Assertion();
                this.stack.Push(axiom.Assertion);
                this.Visit(assertionCtx);
                this.stack.Pop();
            }

            var annotationAxiomCtx = context.annotationAxiom();
            if (annotationAxiomCtx != null)
            {
                axiom.AnnotationAxiom = new AnnotationAxiom();
                this.stack.Push(axiom.AnnotationAxiom);
                this.Visit(annotationAxiomCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDeclaration([NotNull] HermitRuleParser.DeclarationContext context)
        {
            var declaration = this.stack.PeekCtx<Declaration>();
            declaration.Parse(context);

            var DECLARATIONCtx = context.DECLARATION();
            if (DECLARATIONCtx != null)
            {
                declaration.DECLARATION = DECLARATIONCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                declaration.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(declaration.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var entityCtx = context.entity();
            if (entityCtx != null)
            {
                declaration.Entity = new Entity();
                this.stack.Push(declaration.Entity);
                this.Visit(entityCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitEntity([NotNull] HermitRuleParser.EntityContext context)
        {
            var entity = this.stack.PeekCtx<Entity>();
            entity.Parse(context);

            var CLASSCtx = context.CLASS();
            if (CLASSCtx != null)
            {
                entity.CLASS = CLASSCtx.GetText();
            }

            var classNCtx = context.classN();
            if (classNCtx != null)
            {
                entity.ClassN = new ClassN();
                this.stack.Push(entity.ClassN);
                this.Visit(classNCtx);
                this.stack.Pop();
            }

            var DATA_TYPECtx = context.DATA_TYPE();
            if (DATA_TYPECtx != null)
            {
                entity.DATATYPE = DATA_TYPECtx.GetText();
            }

            var datatypeCtx = context.datatype();
            if (datatypeCtx != null)
            {
                entity.Datatype = new Datatype();
                this.stack.Push(entity.Datatype);
                this.Visit(datatypeCtx);
                this.stack.Pop();
            }

            var OBJECT_PROPERTYCtx = context.OBJECT_PROPERTY();
            if (OBJECT_PROPERTYCtx != null)
            {
                entity.OBJECTPROPERTY = OBJECT_PROPERTYCtx.GetText();
            }

            var objectPropertyCtx = context.objectProperty();
            if (objectPropertyCtx != null)
            {
                entity.ObjectProperty = new ObjectProperty();
                this.stack.Push(entity.ObjectProperty);
                this.Visit(objectPropertyCtx);
                this.stack.Pop();
            }

            var DATA_PROPERTYCtx = context.DATA_PROPERTY();
            if (DATA_PROPERTYCtx != null)
            {
                entity.DATAPROPERTY = DATA_PROPERTYCtx.GetText();
            }

            var dataPropertyCtx = context.dataProperty();
            if (dataPropertyCtx != null)
            {
                entity.DataProperty = new DataProperty();
                this.stack.Push(entity.DataProperty);
                this.Visit(dataPropertyCtx);
                this.stack.Pop();
            }

            var ANNOTATION_PROPERTYCtx = context.ANNOTATION_PROPERTY();
            if (ANNOTATION_PROPERTYCtx != null)
            {
                entity.ANNOTATIONPROPERTY = ANNOTATION_PROPERTYCtx.GetText();
            }

            var annotationPropertyCtx = context.annotationProperty();
            if (annotationPropertyCtx != null)
            {
                entity.AnnotationProperty = new AnnotationProperty();
                this.stack.Push(entity.AnnotationProperty);
                this.Visit(annotationPropertyCtx);
                this.stack.Pop();
            }

            var NAMED_INDIVIDUALCtx = context.NAMED_INDIVIDUAL();
            if (NAMED_INDIVIDUALCtx != null)
            {
                entity.NAMEDINDIVIDUAL = NAMED_INDIVIDUALCtx.GetText();
            }

            var namedIndividualCtx = context.namedIndividual();
            if (namedIndividualCtx != null)
            {
                entity.NamedIndividual = new NamedIndividual();
                this.stack.Push(entity.NamedIndividual);
                this.Visit(namedIndividualCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitClassAxiom([NotNull] HermitRuleParser.ClassAxiomContext context)
        {
            var classAxiom = this.stack.PeekCtx<ClassAxiom>();
            classAxiom.Parse(context);

            var subClassOfCtx = context.subClassOf();
            if (subClassOfCtx != null)
            {
                classAxiom.SubClassOf = new SubClassOf();
                this.stack.Push(classAxiom.SubClassOf);
                this.Visit(subClassOfCtx);
                this.stack.Pop();
            }

            var equivalentClassesCtx = context.equivalentClasses();
            if (equivalentClassesCtx != null)
            {
                classAxiom.EquivalentClasses = new EquivalentClasses();
                this.stack.Push(classAxiom.EquivalentClasses);
                this.Visit(equivalentClassesCtx);
                this.stack.Pop();
            }

            var disjointClassesCtx = context.disjointClasses();
            if (disjointClassesCtx != null)
            {
                classAxiom.DisjointClasses = new DisjointClasses();
                this.stack.Push(classAxiom.DisjointClasses);
                this.Visit(disjointClassesCtx);
                this.stack.Pop();
            }

            var disjointUnionCtx = context.disjointUnion();
            if (disjointUnionCtx != null)
            {
                classAxiom.DisjointUnion = new DisjointUnion();
                this.stack.Push(classAxiom.DisjointUnion);
                this.Visit(disjointUnionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSubClassOf([NotNull] HermitRuleParser.SubClassOfContext context)
        {
            var subClassOf = this.stack.PeekCtx<SubClassOf>();
            subClassOf.Parse(context);

            var SUB_CLASS_OFCtx = context.SUB_CLASS_OF();
            if (SUB_CLASS_OFCtx != null)
            {
                subClassOf.SUBCLASSOF = SUB_CLASS_OFCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                subClassOf.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(subClassOf.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var subClassExpressionCtx = context.subClassExpression();
            if (subClassExpressionCtx != null)
            {
                subClassOf.SubClassExpression = new SubClassExpression();
                this.stack.Push(subClassOf.SubClassExpression);
                this.Visit(subClassExpressionCtx);
                this.stack.Pop();
            }

            var superClassExpressionCtx = context.superClassExpression();
            if (superClassExpressionCtx != null)
            {
                subClassOf.SuperClassExpression = new SuperClassExpression();
                this.stack.Push(subClassOf.SuperClassExpression);
                this.Visit(superClassExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitEquivalentClasses([NotNull] HermitRuleParser.EquivalentClassesContext context)
        {
            var equivalentClasses = this.stack.PeekCtx<EquivalentClasses>();
            equivalentClasses.Parse(context);

            var EQUIVALENT_CLASSESCtx = context.EQUIVALENT_CLASSES();
            if (EQUIVALENT_CLASSESCtx != null)
            {
                equivalentClasses.EQUIVALENTCLASSES = EQUIVALENT_CLASSESCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                equivalentClasses.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(equivalentClasses.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var classExpressionCtxs = context.classExpression();
            foreach (var ctx in classExpressionCtxs)
            {
                var classExpression = new ClassExpression();
                equivalentClasses.ClassExpressions.Add(classExpression);
                this.stack.Push(classExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSubClassExpression([NotNull] HermitRuleParser.SubClassExpressionContext context)
        {
            var subClassExpression = this.stack.PeekCtx<SubClassExpression>();
            subClassExpression.Parse(context);

            var classExpressionCtx = context.classExpression();
            if (classExpressionCtx != null)
            {
                subClassExpression.ClassExpression = new ClassExpression();
                this.stack.Push(subClassExpression.ClassExpression);
                this.Visit(classExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSuperClassExpression([NotNull] HermitRuleParser.SuperClassExpressionContext context)
        {
            var superClassExpression = this.stack.PeekCtx<SuperClassExpression>();
            superClassExpression.Parse(context);

            var classExpressionCtx = context.classExpression();
            if (classExpressionCtx != null)
            {
                superClassExpression.ClassExpression = new ClassExpression();
                this.stack.Push(superClassExpression.ClassExpression);
                this.Visit(classExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDisjointClasses([NotNull] HermitRuleParser.DisjointClassesContext context)
        {
            var disjointClasses = this.stack.PeekCtx<DisjointClasses>();
            disjointClasses.Parse(context);

            var DISJOINT_CLASSESCtx = context.DISJOINT_CLASSES();
            if (DISJOINT_CLASSESCtx != null)
            {
                disjointClasses.DISJOINTCLASSES = DISJOINT_CLASSESCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                disjointClasses.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(disjointClasses.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var classExpressionCtxs = context.classExpression();
            foreach (var ctx in classExpressionCtxs)
            {
                var classExpression = new ClassExpression();
                disjointClasses.ClassExpressions.Add(classExpression);
                this.stack.Push(classExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDisjointUnion([NotNull] HermitRuleParser.DisjointUnionContext context)
        {
            var disjointUnion = this.stack.PeekCtx<DisjointUnion>();
            disjointUnion.Parse(context);

            var DISJOINT_UNIONCtx = context.DISJOINT_UNION();
            if (DISJOINT_UNIONCtx != null)
            {
                disjointUnion.DISJOINTUNION = DISJOINT_UNIONCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                disjointUnion.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(disjointUnion.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var classNCtx = context.classN();
            if (classNCtx != null)
            {
                disjointUnion.ClassN = new ClassN();
                this.stack.Push(disjointUnion.ClassN);
                this.Visit(classNCtx);
                this.stack.Pop();
            }

            var disjointClassExpressionsCtx = context.disjointClassExpressions();
            if (disjointClassExpressionsCtx != null)
            {
                disjointUnion.DisjointClassExpressions = new DisjointClassExpressions();
                this.stack.Push(disjointUnion.DisjointClassExpressions);
                this.Visit(disjointClassExpressionsCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDisjointClassExpressions([NotNull] HermitRuleParser.DisjointClassExpressionsContext context)
        {
            var disjointClassExpressions = this.stack.PeekCtx<DisjointClassExpressions>();
            disjointClassExpressions.Parse(context);

            var classExpressionCtxs = context.classExpression();
            foreach (var ctx in classExpressionCtxs)
            {
                var classExpression = new ClassExpression();
                disjointClassExpressions.ClassExpressions.Add(classExpression);
                this.stack.Push(classExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectPropertyAxiom([NotNull] HermitRuleParser.ObjectPropertyAxiomContext context)
        {
            var objectPropertyAxiom = this.stack.PeekCtx<ObjectPropertyAxiom>();
            objectPropertyAxiom.Parse(context);

            var subObjectPropertyOfCtx = context.subObjectPropertyOf();
            if (subObjectPropertyOfCtx != null)
            {
                objectPropertyAxiom.SubObjectPropertyOf = new SubObjectPropertyOf();
                this.stack.Push(objectPropertyAxiom.SubObjectPropertyOf);
                this.Visit(subObjectPropertyOfCtx);
                this.stack.Pop();
            }

            var equivalentObjectPropertiesCtx = context.equivalentObjectProperties();
            if (equivalentObjectPropertiesCtx != null)
            {
                objectPropertyAxiom.EquivalentObjectProperties = new EquivalentObjectProperties();
                this.stack.Push(objectPropertyAxiom.EquivalentObjectProperties);
                this.Visit(equivalentObjectPropertiesCtx);
                this.stack.Pop();
            }

            var disjointObjectPropertiesCtx = context.disjointObjectProperties();
            if (disjointObjectPropertiesCtx != null)
            {
                objectPropertyAxiom.DisjointObjectProperties = new DisjointObjectProperties();
                this.stack.Push(objectPropertyAxiom.DisjointObjectProperties);
                this.Visit(disjointObjectPropertiesCtx);
                this.stack.Pop();
            }

            var inverseObjectPropertiesCtx = context.inverseObjectProperties();
            if (inverseObjectPropertiesCtx != null)
            {
                objectPropertyAxiom.InverseObjectProperties = new InverseObjectProperties();
                this.stack.Push(objectPropertyAxiom.InverseObjectProperties);
                this.Visit(inverseObjectPropertiesCtx);
                this.stack.Pop();
            }

            var objectPropertyDomainCtx = context.objectPropertyDomain();
            if (objectPropertyDomainCtx != null)
            {
                objectPropertyAxiom.ObjectPropertyDomain = new ObjectPropertyDomain();
                this.stack.Push(objectPropertyAxiom.ObjectPropertyDomain);
                this.Visit(objectPropertyDomainCtx);
                this.stack.Pop();
            }

            var objectPropertyRangeCtx = context.objectPropertyRange();
            if (objectPropertyRangeCtx != null)
            {
                objectPropertyAxiom.ObjectPropertyRange = new ObjectPropertyRange();
                this.stack.Push(objectPropertyAxiom.ObjectPropertyRange);
                this.Visit(objectPropertyRangeCtx);
                this.stack.Pop();
            }

            var functionalObjectPropertyCtx = context.functionalObjectProperty();
            if (functionalObjectPropertyCtx != null)
            {
                objectPropertyAxiom.FunctionalObjectProperty = new FunctionalObjectProperty();
                this.stack.Push(objectPropertyAxiom.FunctionalObjectProperty);
                this.Visit(functionalObjectPropertyCtx);
                this.stack.Pop();
            }

            var inverseFunctionalObjectPropertyCtx = context.inverseFunctionalObjectProperty();
            if (inverseFunctionalObjectPropertyCtx != null)
            {
                objectPropertyAxiom.InverseFunctionalObjectProperty = new InverseFunctionalObjectProperty();
                this.stack.Push(objectPropertyAxiom.InverseFunctionalObjectProperty);
                this.Visit(inverseFunctionalObjectPropertyCtx);
                this.stack.Pop();
            }

            var reflexiveObjectPropertyCtx = context.reflexiveObjectProperty();
            if (reflexiveObjectPropertyCtx != null)
            {
                objectPropertyAxiom.ReflexiveObjectProperty = new ReflexiveObjectProperty();
                this.stack.Push(objectPropertyAxiom.ReflexiveObjectProperty);
                this.Visit(reflexiveObjectPropertyCtx);
                this.stack.Pop();
            }

            var irreflexiveObjectPropertyCtx = context.irreflexiveObjectProperty();
            if (irreflexiveObjectPropertyCtx != null)
            {
                objectPropertyAxiom.IrreflexiveObjectProperty = new IrreflexiveObjectProperty();
                this.stack.Push(objectPropertyAxiom.IrreflexiveObjectProperty);
                this.Visit(irreflexiveObjectPropertyCtx);
                this.stack.Pop();
            }

            var symmetricObjectPropertyCtx = context.symmetricObjectProperty();
            if (symmetricObjectPropertyCtx != null)
            {
                objectPropertyAxiom.SymmetricObjectProperty = new SymmetricObjectProperty();
                this.stack.Push(objectPropertyAxiom.SymmetricObjectProperty);
                this.Visit(symmetricObjectPropertyCtx);
                this.stack.Pop();
            }

            var asymmetricObjectPropertyCtx = context.asymmetricObjectProperty();
            if (asymmetricObjectPropertyCtx != null)
            {
                objectPropertyAxiom.AsymmetricObjectProperty = new AsymmetricObjectProperty();
                this.stack.Push(objectPropertyAxiom.AsymmetricObjectProperty);
                this.Visit(asymmetricObjectPropertyCtx);
                this.stack.Pop();
            }

            var transitiveObjectPropertyCtx = context.transitiveObjectProperty();
            if (transitiveObjectPropertyCtx != null)
            {
                objectPropertyAxiom.TransitiveObjectProperty = new TransitiveObjectProperty();
                this.stack.Push(objectPropertyAxiom.TransitiveObjectProperty);
                this.Visit(transitiveObjectPropertyCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSubObjectPropertyOf([NotNull] HermitRuleParser.SubObjectPropertyOfContext context)
        {
            var subObjectPropertyOf = this.stack.PeekCtx<SubObjectPropertyOf>();
            subObjectPropertyOf.Parse(context);

            var SUB_OBJECT_PROPERTY_OFCtx = context.SUB_OBJECT_PROPERTY_OF();
            if (SUB_OBJECT_PROPERTY_OFCtx != null)
            {
                subObjectPropertyOf.SUBOBJECTPROPERTYOF = SUB_OBJECT_PROPERTY_OFCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                subObjectPropertyOf.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(subObjectPropertyOf.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var subObjectPropertyExpressionCtx = context.subObjectPropertyExpression();
            if (subObjectPropertyExpressionCtx != null)
            {
                subObjectPropertyOf.SubObjectPropertyExpression = new SubObjectPropertyExpression();
                this.stack.Push(subObjectPropertyOf.SubObjectPropertyExpression);
                this.Visit(subObjectPropertyExpressionCtx);
                this.stack.Pop();
            }

            var superObjectPropertyExpressionCtx = context.superObjectPropertyExpression();
            if (superObjectPropertyExpressionCtx != null)
            {
                subObjectPropertyOf.SuperObjectPropertyExpression = new SuperObjectPropertyExpression();
                this.stack.Push(subObjectPropertyOf.SuperObjectPropertyExpression);
                this.Visit(superObjectPropertyExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSubObjectPropertyExpression([NotNull] HermitRuleParser.SubObjectPropertyExpressionContext context)
        {
            var subObjectPropertyExpression = this.stack.PeekCtx<SubObjectPropertyExpression>();
            subObjectPropertyExpression.Parse(context);

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                subObjectPropertyExpression.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(subObjectPropertyExpression.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            var propertyExpressionChainCtx = context.propertyExpressionChain();
            if (propertyExpressionChainCtx != null)
            {
                subObjectPropertyExpression.PropertyExpressionChain = new PropertyExpressionChain();
                this.stack.Push(subObjectPropertyExpression.PropertyExpressionChain);
                this.Visit(propertyExpressionChainCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitPropertyExpressionChain([NotNull] HermitRuleParser.PropertyExpressionChainContext context)
        {
            var propertyExpressionChain = this.stack.PeekCtx<PropertyExpressionChain>();
            propertyExpressionChain.Parse(context);

            var OBJECT_PROPERTY_CHAINCtx = context.OBJECT_PROPERTY_CHAIN();
            if (OBJECT_PROPERTY_CHAINCtx != null)
            {
                propertyExpressionChain.OBJECTPROPERTYCHAIN = OBJECT_PROPERTY_CHAINCtx.GetText();
            }

            var objectPropertyExpressionCtxs = context.objectPropertyExpression();
            foreach (var ctx in objectPropertyExpressionCtxs)
            {
                var objectPropertyExpression = new ObjectPropertyExpression();
                propertyExpressionChain.ObjectPropertyExpressions.Add(objectPropertyExpression);
                this.stack.Push(objectPropertyExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSuperObjectPropertyExpression([NotNull] HermitRuleParser.SuperObjectPropertyExpressionContext context)
        {
            var superObjectPropertyExpression = this.stack.PeekCtx<SuperObjectPropertyExpression>();
            superObjectPropertyExpression.Parse(context);

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                superObjectPropertyExpression.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(superObjectPropertyExpression.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitEquivalentObjectProperties([NotNull] HermitRuleParser.EquivalentObjectPropertiesContext context)
        {
            var equivalentObjectProperties = this.stack.PeekCtx<EquivalentObjectProperties>();
            equivalentObjectProperties.Parse(context);

            var EQUIVALENT_OBJECT_PROPERTIESCtx = context.EQUIVALENT_OBJECT_PROPERTIES();
            if (EQUIVALENT_OBJECT_PROPERTIESCtx != null)
            {
                equivalentObjectProperties.EQUIVALENTOBJECTPROPERTIES = EQUIVALENT_OBJECT_PROPERTIESCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                equivalentObjectProperties.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(equivalentObjectProperties.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var objectPropertyExpressionCtxs = context.objectPropertyExpression();
            foreach (var ctx in objectPropertyExpressionCtxs)
            {
                var objectPropertyExpression = new ObjectPropertyExpression();
                equivalentObjectProperties.ObjectPropertyExpressions.Add(objectPropertyExpression);
                this.stack.Push(objectPropertyExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDisjointObjectProperties([NotNull] HermitRuleParser.DisjointObjectPropertiesContext context)
        {
            var disjointObjectProperties = this.stack.PeekCtx<DisjointObjectProperties>();
            disjointObjectProperties.Parse(context);

            var DISJOINT_OBJECT_PROPERTIESCtx = context.DISJOINT_OBJECT_PROPERTIES();
            if (DISJOINT_OBJECT_PROPERTIESCtx != null)
            {
                disjointObjectProperties.DISJOINTOBJECTPROPERTIES = DISJOINT_OBJECT_PROPERTIESCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                disjointObjectProperties.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(disjointObjectProperties.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var objectPropertyExpressionCtxs = context.objectPropertyExpression();
            foreach (var ctx in objectPropertyExpressionCtxs)
            {
                var objectPropertyExpression = new ObjectPropertyExpression();
                disjointObjectProperties.ObjectPropertyExpressions.Add(objectPropertyExpression);
                this.stack.Push(objectPropertyExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectPropertyDomain([NotNull] HermitRuleParser.ObjectPropertyDomainContext context)
        {
            var objectPropertyDomain = this.stack.PeekCtx<ObjectPropertyDomain>();
            objectPropertyDomain.Parse(context);

            var OBJECT_PROPERTY_DOMAINCtx = context.OBJECT_PROPERTY_DOMAIN();
            if (OBJECT_PROPERTY_DOMAINCtx != null)
            {
                objectPropertyDomain.OBJECTPROPERTYDOMAIN = OBJECT_PROPERTY_DOMAINCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                objectPropertyDomain.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(objectPropertyDomain.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                objectPropertyDomain.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(objectPropertyDomain.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            var classExpressionCtx = context.classExpression();
            if (classExpressionCtx != null)
            {
                objectPropertyDomain.ClassExpression = new ClassExpression();
                this.stack.Push(objectPropertyDomain.ClassExpression);
                this.Visit(classExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectPropertyRange([NotNull] HermitRuleParser.ObjectPropertyRangeContext context)
        {
            var objectPropertyRange = this.stack.PeekCtx<ObjectPropertyRange>();
            objectPropertyRange.Parse(context);

            var OBJECT_PROPERTY_RANGECtx = context.OBJECT_PROPERTY_RANGE();
            if (OBJECT_PROPERTY_RANGECtx != null)
            {
                objectPropertyRange.OBJECTPROPERTYRANGE = OBJECT_PROPERTY_RANGECtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                objectPropertyRange.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(objectPropertyRange.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                objectPropertyRange.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(objectPropertyRange.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            var classExpressionCtx = context.classExpression();
            if (classExpressionCtx != null)
            {
                objectPropertyRange.ClassExpression = new ClassExpression();
                this.stack.Push(objectPropertyRange.ClassExpression);
                this.Visit(classExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitInverseObjectProperties([NotNull] HermitRuleParser.InverseObjectPropertiesContext context)
        {
            var inverseObjectProperties = this.stack.PeekCtx<InverseObjectProperties>();
            inverseObjectProperties.Parse(context);

            var INVERSE_OBJECT_PROPERTIESCtx = context.INVERSE_OBJECT_PROPERTIES();
            if (INVERSE_OBJECT_PROPERTIESCtx != null)
            {
                inverseObjectProperties.INVERSEOBJECTPROPERTIES = INVERSE_OBJECT_PROPERTIESCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                inverseObjectProperties.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(inverseObjectProperties.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var objectPropertyExpressionCtxs = context.objectPropertyExpression();
            foreach (var ctx in objectPropertyExpressionCtxs)
            {
                var objectPropertyExpression = new ObjectPropertyExpression();
                inverseObjectProperties.ObjectPropertyExpressions.Add(objectPropertyExpression);
                this.stack.Push(objectPropertyExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitFunctionalObjectProperty([NotNull] HermitRuleParser.FunctionalObjectPropertyContext context)
        {
            var functionalObjectProperty = this.stack.PeekCtx<FunctionalObjectProperty>();
            functionalObjectProperty.Parse(context);

            var FUNCTIONAL_OBJECT_PROPERTYCtx = context.FUNCTIONAL_OBJECT_PROPERTY();
            if (FUNCTIONAL_OBJECT_PROPERTYCtx != null)
            {
                functionalObjectProperty.FUNCTIONALOBJECTPROPERTY = FUNCTIONAL_OBJECT_PROPERTYCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                functionalObjectProperty.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(functionalObjectProperty.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                functionalObjectProperty.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(functionalObjectProperty.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitInverseFunctionalObjectProperty([NotNull] HermitRuleParser.InverseFunctionalObjectPropertyContext context)
        {
            var inverseFunctionalObjectProperty = this.stack.PeekCtx<InverseFunctionalObjectProperty>();
            inverseFunctionalObjectProperty.Parse(context);

            var INVERSE_FUNCTIONAL_OBJECT_PROPERTYCtx = context.INVERSE_FUNCTIONAL_OBJECT_PROPERTY();
            if (INVERSE_FUNCTIONAL_OBJECT_PROPERTYCtx != null)
            {
                inverseFunctionalObjectProperty.INVERSEFUNCTIONALOBJECTPROPERTY = INVERSE_FUNCTIONAL_OBJECT_PROPERTYCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                inverseFunctionalObjectProperty.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(inverseFunctionalObjectProperty.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                inverseFunctionalObjectProperty.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(inverseFunctionalObjectProperty.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitReflexiveObjectProperty([NotNull] HermitRuleParser.ReflexiveObjectPropertyContext context)
        {
            var reflexiveObjectProperty = this.stack.PeekCtx<ReflexiveObjectProperty>();
            reflexiveObjectProperty.Parse(context);

            var REFLEXIVE_OBJECT_PROPERTYCtx = context.REFLEXIVE_OBJECT_PROPERTY();
            if (REFLEXIVE_OBJECT_PROPERTYCtx != null)
            {
                reflexiveObjectProperty.REFLEXIVEOBJECTPROPERTY = REFLEXIVE_OBJECT_PROPERTYCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                reflexiveObjectProperty.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(reflexiveObjectProperty.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                reflexiveObjectProperty.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(reflexiveObjectProperty.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitIrreflexiveObjectProperty([NotNull] HermitRuleParser.IrreflexiveObjectPropertyContext context)
        {
            var irreflexiveObjectProperty = this.stack.PeekCtx<IrreflexiveObjectProperty>();
            irreflexiveObjectProperty.Parse(context);

            var IRREFLEXIVE_OBJECT_PROPERTYCtx = context.IRREFLEXIVE_OBJECT_PROPERTY();
            if (IRREFLEXIVE_OBJECT_PROPERTYCtx != null)
            {
                irreflexiveObjectProperty.IRREFLEXIVEOBJECTPROPERTY = IRREFLEXIVE_OBJECT_PROPERTYCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                irreflexiveObjectProperty.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(irreflexiveObjectProperty.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                irreflexiveObjectProperty.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(irreflexiveObjectProperty.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSymmetricObjectProperty([NotNull] HermitRuleParser.SymmetricObjectPropertyContext context)
        {
            var symmetricObjectProperty = this.stack.PeekCtx<SymmetricObjectProperty>();
            symmetricObjectProperty.Parse(context);

            var SYMMETRIC_OBJECT_PROPERTYCtx = context.SYMMETRIC_OBJECT_PROPERTY();
            if (SYMMETRIC_OBJECT_PROPERTYCtx != null)
            {
                symmetricObjectProperty.SYMMETRICOBJECTPROPERTY = SYMMETRIC_OBJECT_PROPERTYCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                symmetricObjectProperty.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(symmetricObjectProperty.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                symmetricObjectProperty.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(symmetricObjectProperty.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAsymmetricObjectProperty([NotNull] HermitRuleParser.AsymmetricObjectPropertyContext context)
        {
            var asymmetricObjectProperty = this.stack.PeekCtx<AsymmetricObjectProperty>();
            asymmetricObjectProperty.Parse(context);

            var ASYMMETRIC_OBJECT_PROPERTYCtx = context.ASYMMETRIC_OBJECT_PROPERTY();
            if (ASYMMETRIC_OBJECT_PROPERTYCtx != null)
            {
                asymmetricObjectProperty.ASYMMETRICOBJECTPROPERTY = ASYMMETRIC_OBJECT_PROPERTYCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                asymmetricObjectProperty.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(asymmetricObjectProperty.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                asymmetricObjectProperty.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(asymmetricObjectProperty.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitTransitiveObjectProperty([NotNull] HermitRuleParser.TransitiveObjectPropertyContext context)
        {
            var transitiveObjectProperty = this.stack.PeekCtx<TransitiveObjectProperty>();
            transitiveObjectProperty.Parse(context);

            var TRANSITIVE_OBJECT_PROPERTYCtx = context.TRANSITIVE_OBJECT_PROPERTY();
            if (TRANSITIVE_OBJECT_PROPERTYCtx != null)
            {
                transitiveObjectProperty.TRANSITIVEOBJECTPROPERTY = TRANSITIVE_OBJECT_PROPERTYCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                transitiveObjectProperty.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(transitiveObjectProperty.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                transitiveObjectProperty.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(transitiveObjectProperty.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDataPropertyAxiom([NotNull] HermitRuleParser.DataPropertyAxiomContext context)
        {
            var dataPropertyAxiom = this.stack.PeekCtx<DataPropertyAxiom>();
            dataPropertyAxiom.Parse(context);

            var subDataPropertyOfCtx = context.subDataPropertyOf();
            if (subDataPropertyOfCtx != null)
            {
                dataPropertyAxiom.SubDataPropertyOf = new SubDataPropertyOf();
                this.stack.Push(dataPropertyAxiom.SubDataPropertyOf);
                this.Visit(subDataPropertyOfCtx);
                this.stack.Pop();
            }

            var equivalentDataPropertiesCtx = context.equivalentDataProperties();
            if (equivalentDataPropertiesCtx != null)
            {
                dataPropertyAxiom.EquivalentDataProperties = new EquivalentDataProperties();
                this.stack.Push(dataPropertyAxiom.EquivalentDataProperties);
                this.Visit(equivalentDataPropertiesCtx);
                this.stack.Pop();
            }

            var disjointDataPropertiesCtx = context.disjointDataProperties();
            if (disjointDataPropertiesCtx != null)
            {
                dataPropertyAxiom.DisjointDataProperties = new DisjointDataProperties();
                this.stack.Push(dataPropertyAxiom.DisjointDataProperties);
                this.Visit(disjointDataPropertiesCtx);
                this.stack.Pop();
            }

            var dataPropertyDomainCtx = context.dataPropertyDomain();
            if (dataPropertyDomainCtx != null)
            {
                dataPropertyAxiom.DataPropertyDomain = new DataPropertyDomain();
                this.stack.Push(dataPropertyAxiom.DataPropertyDomain);
                this.Visit(dataPropertyDomainCtx);
                this.stack.Pop();
            }

            var dataPropertyRangeCtx = context.dataPropertyRange();
            if (dataPropertyRangeCtx != null)
            {
                dataPropertyAxiom.DataPropertyRange = new DataPropertyRange();
                this.stack.Push(dataPropertyAxiom.DataPropertyRange);
                this.Visit(dataPropertyRangeCtx);
                this.stack.Pop();
            }

            var functionalDataPropertyCtx = context.functionalDataProperty();
            if (functionalDataPropertyCtx != null)
            {
                dataPropertyAxiom.FunctionalDataProperty = new FunctionalDataProperty();
                this.stack.Push(dataPropertyAxiom.FunctionalDataProperty);
                this.Visit(functionalDataPropertyCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSubDataPropertyOf([NotNull] HermitRuleParser.SubDataPropertyOfContext context)
        {
            var subDataPropertyOf = this.stack.PeekCtx<SubDataPropertyOf>();
            subDataPropertyOf.Parse(context);

            var SUB_DATA_PROPERTY_OFCtx = context.SUB_DATA_PROPERTY_OF();
            if (SUB_DATA_PROPERTY_OFCtx != null)
            {
                subDataPropertyOf.SUBDATAPROPERTYOF = SUB_DATA_PROPERTY_OFCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                subDataPropertyOf.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(subDataPropertyOf.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var subDataPropertyExpressionCtx = context.subDataPropertyExpression();
            if (subDataPropertyExpressionCtx != null)
            {
                subDataPropertyOf.SubDataPropertyExpression = new SubDataPropertyExpression();
                this.stack.Push(subDataPropertyOf.SubDataPropertyExpression);
                this.Visit(subDataPropertyExpressionCtx);
                this.stack.Pop();
            }

            var superDataPropertyExpressionCtx = context.superDataPropertyExpression();
            if (superDataPropertyExpressionCtx != null)
            {
                subDataPropertyOf.SuperDataPropertyExpression = new SuperDataPropertyExpression();
                this.stack.Push(subDataPropertyOf.SuperDataPropertyExpression);
                this.Visit(superDataPropertyExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSubDataPropertyExpression([NotNull] HermitRuleParser.SubDataPropertyExpressionContext context)
        {
            var subDataPropertyExpression = this.stack.PeekCtx<SubDataPropertyExpression>();
            subDataPropertyExpression.Parse(context);

            var dataPropertyExpressionCtx = context.dataPropertyExpression();
            if (dataPropertyExpressionCtx != null)
            {
                subDataPropertyExpression.DataPropertyExpression = new DataPropertyExpression();
                this.stack.Push(subDataPropertyExpression.DataPropertyExpression);
                this.Visit(dataPropertyExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSuperDataPropertyExpression([NotNull] HermitRuleParser.SuperDataPropertyExpressionContext context)
        {
            var superDataPropertyExpression = this.stack.PeekCtx<SuperDataPropertyExpression>();
            superDataPropertyExpression.Parse(context);

            var dataPropertyExpressionCtx = context.dataPropertyExpression();
            if (dataPropertyExpressionCtx != null)
            {
                superDataPropertyExpression.DataPropertyExpression = new DataPropertyExpression();
                this.stack.Push(superDataPropertyExpression.DataPropertyExpression);
                this.Visit(dataPropertyExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitEquivalentDataProperties([NotNull] HermitRuleParser.EquivalentDataPropertiesContext context)
        {
            var equivalentDataProperties = this.stack.PeekCtx<EquivalentDataProperties>();
            equivalentDataProperties.Parse(context);

            var EQUIVALENT_DATA_PROPERTIESCtx = context.EQUIVALENT_DATA_PROPERTIES();
            if (EQUIVALENT_DATA_PROPERTIESCtx != null)
            {
                equivalentDataProperties.EQUIVALENTDATAPROPERTIES = EQUIVALENT_DATA_PROPERTIESCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                equivalentDataProperties.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(equivalentDataProperties.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var dataPropertyExpressionCtxs = context.dataPropertyExpression();
            foreach (var ctx in dataPropertyExpressionCtxs)
            {
                var dataPropertyExpression = new DataPropertyExpression();
                equivalentDataProperties.DataPropertyExpressions.Add(dataPropertyExpression);
                this.stack.Push(dataPropertyExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDisjointDataProperties([NotNull] HermitRuleParser.DisjointDataPropertiesContext context)
        {
            var disjointDataProperties = this.stack.PeekCtx<DisjointDataProperties>();
            disjointDataProperties.Parse(context);

            var DISJOINT_DATA_PROPERTIESCtx = context.DISJOINT_DATA_PROPERTIES();
            if (DISJOINT_DATA_PROPERTIESCtx != null)
            {
                disjointDataProperties.DISJOINTDATAPROPERTIES = DISJOINT_DATA_PROPERTIESCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                disjointDataProperties.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(disjointDataProperties.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var dataPropertyExpressionCtxs = context.dataPropertyExpression();
            foreach (var ctx in dataPropertyExpressionCtxs)
            {
                var dataPropertyExpression = new DataPropertyExpression();
                disjointDataProperties.DataPropertyExpressions.Add(dataPropertyExpression);
                this.stack.Push(dataPropertyExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDataPropertyDomain([NotNull] HermitRuleParser.DataPropertyDomainContext context)
        {
            var dataPropertyDomain = this.stack.PeekCtx<DataPropertyDomain>();
            dataPropertyDomain.Parse(context);

            var DATA_PROPERTY_DOMAINCtx = context.DATA_PROPERTY_DOMAIN();
            if (DATA_PROPERTY_DOMAINCtx != null)
            {
                dataPropertyDomain.DATAPROPERTYDOMAIN = DATA_PROPERTY_DOMAINCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                dataPropertyDomain.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(dataPropertyDomain.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var dataPropertyExpressionCtx = context.dataPropertyExpression();
            if (dataPropertyExpressionCtx != null)
            {
                dataPropertyDomain.DataPropertyExpression = new DataPropertyExpression();
                this.stack.Push(dataPropertyDomain.DataPropertyExpression);
                this.Visit(dataPropertyExpressionCtx);
                this.stack.Pop();
            }

            var classExpressionCtx = context.classExpression();
            if (classExpressionCtx != null)
            {
                dataPropertyDomain.ClassExpression = new ClassExpression();
                this.stack.Push(dataPropertyDomain.ClassExpression);
                this.Visit(classExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDataPropertyRange([NotNull] HermitRuleParser.DataPropertyRangeContext context)
        {
            var dataPropertyRange = this.stack.PeekCtx<DataPropertyRange>();
            dataPropertyRange.Parse(context);

            var DATA_PROPERTY_RANGECtx = context.DATA_PROPERTY_RANGE();
            if (DATA_PROPERTY_RANGECtx != null)
            {
                dataPropertyRange.DATAPROPERTYRANGE = DATA_PROPERTY_RANGECtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                dataPropertyRange.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(dataPropertyRange.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var dataPropertyExpressionCtx = context.dataPropertyExpression();
            if (dataPropertyExpressionCtx != null)
            {
                dataPropertyRange.DataPropertyExpression = new DataPropertyExpression();
                this.stack.Push(dataPropertyRange.DataPropertyExpression);
                this.Visit(dataPropertyExpressionCtx);
                this.stack.Pop();
            }

            var dataRangeCtx = context.dataRange();
            if (dataRangeCtx != null)
            {
                dataPropertyRange.DataRange = new DataRange();
                this.stack.Push(dataPropertyRange.DataRange);
                this.Visit(dataRangeCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitFunctionalDataProperty([NotNull] HermitRuleParser.FunctionalDataPropertyContext context)
        {
            var functionalDataProperty = this.stack.PeekCtx<FunctionalDataProperty>();
            functionalDataProperty.Parse(context);

            var FUNCTIONAL_DATA_PROPERTYCtx = context.FUNCTIONAL_DATA_PROPERTY();
            if (FUNCTIONAL_DATA_PROPERTYCtx != null)
            {
                functionalDataProperty.FUNCTIONALDATAPROPERTY = FUNCTIONAL_DATA_PROPERTYCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                functionalDataProperty.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(functionalDataProperty.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var dataPropertyExpressionCtx = context.dataPropertyExpression();
            if (dataPropertyExpressionCtx != null)
            {
                functionalDataProperty.DataPropertyExpression = new DataPropertyExpression();
                this.stack.Push(functionalDataProperty.DataPropertyExpression);
                this.Visit(dataPropertyExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDatatypeDefinition([NotNull] HermitRuleParser.DatatypeDefinitionContext context)
        {
            var datatypeDefinition = this.stack.PeekCtx<DatatypeDefinition>();
            datatypeDefinition.Parse(context);

            var DATATYPE_DEFINITIONCtx = context.DATATYPE_DEFINITION();
            if (DATATYPE_DEFINITIONCtx != null)
            {
                datatypeDefinition.DATATYPEDEFINITION = DATATYPE_DEFINITIONCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                datatypeDefinition.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(datatypeDefinition.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var datatypeCtx = context.datatype();
            if (datatypeCtx != null)
            {
                datatypeDefinition.Datatype = new Datatype();
                this.stack.Push(datatypeDefinition.Datatype);
                this.Visit(datatypeCtx);
                this.stack.Pop();
            }

            var dataRangeCtx = context.dataRange();
            if (dataRangeCtx != null)
            {
                datatypeDefinition.DataRange = new DataRange();
                this.stack.Push(datatypeDefinition.DataRange);
                this.Visit(dataRangeCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitHasKey([NotNull] HermitRuleParser.HasKeyContext context)
        {
            var hasKey = this.stack.PeekCtx<HasKey>();
            hasKey.Parse(context);

            var HAS_KEYCtx = context.HAS_KEY();
            if (HAS_KEYCtx != null)
            {
                hasKey.HASKEY = HAS_KEYCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                hasKey.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(hasKey.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var classExpressionCtx = context.classExpression();
            if (classExpressionCtx != null)
            {
                hasKey.ClassExpression = new ClassExpression();
                this.stack.Push(hasKey.ClassExpression);
                this.Visit(classExpressionCtx);
                this.stack.Pop();
            }

            var objectPropertyExpressionCtxs = context.objectPropertyExpression();
            foreach (var ctx in objectPropertyExpressionCtxs)
            {
                var objectPropertyExpression = new ObjectPropertyExpression();
                hasKey.ObjectPropertyExpressions.Add(objectPropertyExpression);
                this.stack.Push(objectPropertyExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var dataPropertyExpressionCtxs = context.dataPropertyExpression();
            foreach (var ctx in dataPropertyExpressionCtxs)
            {
                var dataPropertyExpression = new DataPropertyExpression();
                hasKey.DataPropertyExpressions.Add(dataPropertyExpression);
                this.stack.Push(dataPropertyExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAtom([NotNull] HermitRuleParser.AtomContext context)
        {
            var atom = this.stack.PeekCtx<Atom>();
            atom.Parse(context);

            var CLASS_ATOMCtx = context.CLASS_ATOM();
            if (CLASS_ATOMCtx != null)
            {
                atom.CLASSATOM = CLASS_ATOMCtx.GetText();
            }

            var classExpressionCtx = context.classExpression();
            if (classExpressionCtx != null)
            {
                atom.ClassExpression = new ClassExpression();
                this.stack.Push(atom.ClassExpression);
                this.Visit(classExpressionCtx);
                this.stack.Pop();
            }

            var iArgCtxs = context.iArg();
            foreach (var ctx in iArgCtxs)
            {
                var iArg = new IArg();
                atom.IArgs.Add(iArg);
                this.stack.Push(iArg);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var DATA_RANGE_ATOMCtx = context.DATA_RANGE_ATOM();
            if (DATA_RANGE_ATOMCtx != null)
            {
                atom.DATARANGEATOM = DATA_RANGE_ATOMCtx.GetText();
            }

            var dataRangeCtx = context.dataRange();
            if (dataRangeCtx != null)
            {
                atom.DataRange = new DataRange();
                this.stack.Push(atom.DataRange);
                this.Visit(dataRangeCtx);
                this.stack.Pop();
            }

            var dArgCtxs = context.dArg();
            foreach (var ctx in dArgCtxs)
            {
                var dArg = new DArg();
                atom.DArgs.Add(dArg);
                this.stack.Push(dArg);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var OBJECT_PROPERTY_ATOMCtx = context.OBJECT_PROPERTY_ATOM();
            if (OBJECT_PROPERTY_ATOMCtx != null)
            {
                atom.OBJECTPROPERTYATOM = OBJECT_PROPERTY_ATOMCtx.GetText();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                atom.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(atom.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            var DATA_PROPERTY_ATOMCtx = context.DATA_PROPERTY_ATOM();
            if (DATA_PROPERTY_ATOMCtx != null)
            {
                atom.DATAPROPERTYATOM = DATA_PROPERTY_ATOMCtx.GetText();
            }

            var dataPropertyCtx = context.dataProperty();
            if (dataPropertyCtx != null)
            {
                atom.DataProperty = new DataProperty();
                this.stack.Push(atom.DataProperty);
                this.Visit(dataPropertyCtx);
                this.stack.Pop();
            }

            var BUILT_IN_ATOMCtx = context.BUILT_IN_ATOM();
            if (BUILT_IN_ATOMCtx != null)
            {
                atom.BUILTINATOM = BUILT_IN_ATOMCtx.GetText();
            }

            var iRICtx = context.iRI();
            if (iRICtx != null)
            {
                atom.IRI = new IRI();
                this.stack.Push(atom.IRI);
                this.Visit(iRICtx);
                this.stack.Pop();
            }

            var SAME_INDIVIDUAL_ATOMCtx = context.SAME_INDIVIDUAL_ATOM();
            if (SAME_INDIVIDUAL_ATOMCtx != null)
            {
                atom.SAMEINDIVIDUALATOM = SAME_INDIVIDUAL_ATOMCtx.GetText();
            }

            var DIFFERENT_INDIVIDUALS_ATOMCtx = context.DIFFERENT_INDIVIDUALS_ATOM();
            if (DIFFERENT_INDIVIDUALS_ATOMCtx != null)
            {
                atom.DIFFERENTINDIVIDUALSATOM = DIFFERENT_INDIVIDUALS_ATOMCtx.GetText();
            }

            return 0;
        }

        public override int VisitIArg([NotNull] HermitRuleParser.IArgContext context)
        {
            var iArg = this.stack.PeekCtx<IArg>();
            iArg.Parse(context);

            var VARIABLECtx = context.VARIABLE();
            if (VARIABLECtx != null)
            {
                iArg.VARIABLE = VARIABLECtx.GetText();
            }

            var iRICtx = context.iRI();
            if (iRICtx != null)
            {
                iArg.IRI = new IRI();
                this.stack.Push(iArg.IRI);
                this.Visit(iRICtx);
                this.stack.Pop();
            }

            var individualCtx = context.individual();
            if (individualCtx != null)
            {
                iArg.Individual = new Individual();
                this.stack.Push(iArg.Individual);
                this.Visit(individualCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDArg([NotNull] HermitRuleParser.DArgContext context)
        {
            var dArg = this.stack.PeekCtx<DArg>();
            dArg.Parse(context);

            var VARIABLECtx = context.VARIABLE();
            if (VARIABLECtx != null)
            {
                dArg.VARIABLE = VARIABLECtx.GetText();
            }

            var iRICtx = context.iRI();
            if (iRICtx != null)
            {
                dArg.IRI = new IRI();
                this.stack.Push(dArg.IRI);
                this.Visit(iRICtx);
                this.stack.Pop();
            }

            var literalCtx = context.literal();
            if (literalCtx != null)
            {
                dArg.Literal = new Literal();
                this.stack.Push(dArg.Literal);
                this.Visit(literalCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDGRule([NotNull] HermitRuleParser.DGRuleContext context)
        {
            var dGRule = this.stack.PeekCtx<DGRule>();
            dGRule.Parse(context);

            var DESCRIPTION_GRAPH_RULECtx = context.DESCRIPTION_GRAPH_RULE();
            if (DESCRIPTION_GRAPH_RULECtx != null)
            {
                dGRule.DESCRIPTIONGRAPHRULE = DESCRIPTION_GRAPH_RULECtx.GetText();
            }

            var annotationCtxs = context.annotation();
            foreach (var ctx in annotationCtxs)
            {
                var annotation = new Annotation();
                dGRule.Annotations.Add(annotation);
                this.stack.Push(annotation);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var BODYCtx = context.BODY();
            if (BODYCtx != null)
            {
                dGRule.BODY = BODYCtx.GetText();
            }

            var dGAtomCtxs = context.dGAtom();
            foreach (var ctx in dGAtomCtxs)
            {
                var dGAtom = new DGAtom();
                dGRule.DGAtoms.Add(dGAtom);
                this.stack.Push(dGAtom);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var HEADCtx = context.HEAD();
            if (HEADCtx != null)
            {
                dGRule.HEAD = HEADCtx.GetText();
            }

            return 0;
        }

        public override int VisitDGAtom([NotNull] HermitRuleParser.DGAtomContext context)
        {
            var dGAtom = this.stack.PeekCtx<DGAtom>();
            dGAtom.Parse(context);

            var CLASS_ATOMCtx = context.CLASS_ATOM();
            if (CLASS_ATOMCtx != null)
            {
                dGAtom.CLASSATOM = CLASS_ATOMCtx.GetText();
            }

            var classExpressionCtx = context.classExpression();
            if (classExpressionCtx != null)
            {
                dGAtom.ClassExpression = new ClassExpression();
                this.stack.Push(dGAtom.ClassExpression);
                this.Visit(classExpressionCtx);
                this.stack.Pop();
            }

            var iArgCtxs = context.iArg();
            foreach (var ctx in iArgCtxs)
            {
                var iArg = new IArg();
                dGAtom.IArgs.Add(iArg);
                this.stack.Push(iArg);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var OBJECT_PROPERTY_ATOMCtx = context.OBJECT_PROPERTY_ATOM();
            if (OBJECT_PROPERTY_ATOMCtx != null)
            {
                dGAtom.OBJECTPROPERTYATOM = OBJECT_PROPERTY_ATOMCtx.GetText();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                dGAtom.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(dGAtom.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDGAxiom([NotNull] HermitRuleParser.DGAxiomContext context)
        {
            var dGAxiom = this.stack.PeekCtx<DGAxiom>();
            dGAxiom.Parse(context);

            var DESCRIPTION_GRAPHCtx = context.DESCRIPTION_GRAPH();
            if (DESCRIPTION_GRAPHCtx != null)
            {
                dGAxiom.DESCRIPTIONGRAPH = DESCRIPTION_GRAPHCtx.GetText();
            }

            var annotationCtxs = context.annotation();
            foreach (var ctx in annotationCtxs)
            {
                var annotation = new Annotation();
                dGAxiom.Annotations.Add(annotation);
                this.stack.Push(annotation);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var dGNodesCtx = context.dGNodes();
            if (dGNodesCtx != null)
            {
                dGAxiom.DGNodes = new DGNodes();
                this.stack.Push(dGAxiom.DGNodes);
                this.Visit(dGNodesCtx);
                this.stack.Pop();
            }

            var dGEdgesCtx = context.dGEdges();
            if (dGEdgesCtx != null)
            {
                dGAxiom.DGEdges = new DGEdges();
                this.stack.Push(dGAxiom.DGEdges);
                this.Visit(dGEdgesCtx);
                this.stack.Pop();
            }

            var mainClassesCtx = context.mainClasses();
            if (mainClassesCtx != null)
            {
                dGAxiom.MainClasses = new MainClasses();
                this.stack.Push(dGAxiom.MainClasses);
                this.Visit(mainClassesCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDGNodes([NotNull] HermitRuleParser.DGNodesContext context)
        {
            var dGNodes = this.stack.PeekCtx<DGNodes>();
            dGNodes.Parse(context);

            var NODESCtx = context.NODES();
            if (NODESCtx != null)
            {
                dGNodes.NODES = NODESCtx.GetText();
            }

            var nodeAssertionCtxs = context.nodeAssertion();
            foreach (var ctx in nodeAssertionCtxs)
            {
                var nodeAssertion = new NodeAssertion();
                dGNodes.NodeAssertions.Add(nodeAssertion);
                this.stack.Push(nodeAssertion);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitNodeAssertion([NotNull] HermitRuleParser.NodeAssertionContext context)
        {
            var nodeAssertion = this.stack.PeekCtx<NodeAssertion>();
            nodeAssertion.Parse(context);

            var NODE_ASSERTIONCtx = context.NODE_ASSERTION();
            if (NODE_ASSERTIONCtx != null)
            {
                nodeAssertion.NODEASSERTION = NODE_ASSERTIONCtx.GetText();
            }

            var classNCtx = context.classN();
            if (classNCtx != null)
            {
                nodeAssertion.ClassN = new ClassN();
                this.stack.Push(nodeAssertion.ClassN);
                this.Visit(classNCtx);
                this.stack.Pop();
            }

            var dGNodeCtx = context.dGNode();
            if (dGNodeCtx != null)
            {
                nodeAssertion.DGNode = new DGNode();
                this.stack.Push(nodeAssertion.DGNode);
                this.Visit(dGNodeCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDGNode([NotNull] HermitRuleParser.DGNodeContext context)
        {
            var dGNode = this.stack.PeekCtx<DGNode>();
            dGNode.Parse(context);

            var iRICtx = context.iRI();
            if (iRICtx != null)
            {
                dGNode.IRI = new IRI();
                this.stack.Push(dGNode.IRI);
                this.Visit(iRICtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDGEdges([NotNull] HermitRuleParser.DGEdgesContext context)
        {
            var dGEdges = this.stack.PeekCtx<DGEdges>();
            dGEdges.Parse(context);

            var EDGESCtx = context.EDGES();
            if (EDGESCtx != null)
            {
                dGEdges.EDGES = EDGESCtx.GetText();
            }

            var edgeAssertionCtxs = context.edgeAssertion();
            foreach (var ctx in edgeAssertionCtxs)
            {
                var edgeAssertion = new EdgeAssertion();
                dGEdges.EdgeAssertions.Add(edgeAssertion);
                this.stack.Push(edgeAssertion);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitEdgeAssertion([NotNull] HermitRuleParser.EdgeAssertionContext context)
        {
            var edgeAssertion = this.stack.PeekCtx<EdgeAssertion>();
            edgeAssertion.Parse(context);

            var EDGE_ASSERTIONCtx = context.EDGE_ASSERTION();
            if (EDGE_ASSERTIONCtx != null)
            {
                edgeAssertion.EDGEASSERTION = EDGE_ASSERTIONCtx.GetText();
            }

            var objectPropertyCtx = context.objectProperty();
            if (objectPropertyCtx != null)
            {
                edgeAssertion.ObjectProperty = new ObjectProperty();
                this.stack.Push(edgeAssertion.ObjectProperty);
                this.Visit(objectPropertyCtx);
                this.stack.Pop();
            }

            var dGNodeCtxs = context.dGNode();
            foreach (var ctx in dGNodeCtxs)
            {
                var dGNode = new DGNode();
                edgeAssertion.DGNodes.Add(dGNode);
                this.stack.Push(dGNode);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitMainClasses([NotNull] HermitRuleParser.MainClassesContext context)
        {
            var mainClasses = this.stack.PeekCtx<MainClasses>();
            mainClasses.Parse(context);

            var MAIN_CLASSESCtx = context.MAIN_CLASSES();
            if (MAIN_CLASSESCtx != null)
            {
                mainClasses.MAINCLASSES = MAIN_CLASSESCtx.GetText();
            }

            var classNCtxs = context.classN();
            foreach (var ctx in classNCtxs)
            {
                var classN = new ClassN();
                mainClasses.ClassNs.Add(classN);
                this.stack.Push(classN);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAnnotationSubject([NotNull] HermitRuleParser.AnnotationSubjectContext context)
        {
            var annotationSubject = this.stack.PeekCtx<AnnotationSubject>();
            annotationSubject.Parse(context);

            var iRICtx = context.iRI();
            if (iRICtx != null)
            {
                annotationSubject.IRI = new IRI();
                this.stack.Push(annotationSubject.IRI);
                this.Visit(iRICtx);
                this.stack.Pop();
            }

            var anonymousIndividualCtx = context.anonymousIndividual();
            if (anonymousIndividualCtx != null)
            {
                annotationSubject.AnonymousIndividual = new AnonymousIndividual();
                this.stack.Push(annotationSubject.AnonymousIndividual);
                this.Visit(anonymousIndividualCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAnnotationValue([NotNull] HermitRuleParser.AnnotationValueContext context)
        {
            var annotationValue = this.stack.PeekCtx<AnnotationValue>();
            annotationValue.Parse(context);

            var anonymousIndividualCtx = context.anonymousIndividual();
            if (anonymousIndividualCtx != null)
            {
                annotationValue.AnonymousIndividual = new AnonymousIndividual();
                this.stack.Push(annotationValue.AnonymousIndividual);
                this.Visit(anonymousIndividualCtx);
                this.stack.Pop();
            }

            var iRICtx = context.iRI();
            if (iRICtx != null)
            {
                annotationValue.IRI = new IRI();
                this.stack.Push(annotationValue.IRI);
                this.Visit(iRICtx);
                this.stack.Pop();
            }

            var literalCtx = context.literal();
            if (literalCtx != null)
            {
                annotationValue.Literal = new Literal();
                this.stack.Push(annotationValue.Literal);
                this.Visit(literalCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAxiomAnnotations([NotNull] HermitRuleParser.AxiomAnnotationsContext context)
        {
            var axiomAnnotations = this.stack.PeekCtx<AxiomAnnotations>();
            axiomAnnotations.Parse(context);

            var annotationCtxs = context.annotation();
            foreach (var ctx in annotationCtxs)
            {
                var annotation = new Annotation();
                axiomAnnotations.Annotations.Add(annotation);
                this.stack.Push(annotation);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAnnotation([NotNull] HermitRuleParser.AnnotationContext context)
        {
            var annotation = this.stack.PeekCtx<Annotation>();
            annotation.Parse(context);

            var ANNOTATIONCtx = context.ANNOTATION();
            if (ANNOTATIONCtx != null)
            {
                annotation.ANNOTATION = ANNOTATIONCtx.GetText();
            }

            var annotationAnnotationsCtx = context.annotationAnnotations();
            if (annotationAnnotationsCtx != null)
            {
                annotation.AnnotationAnnotations = new AnnotationAnnotations();
                this.stack.Push(annotation.AnnotationAnnotations);
                this.Visit(annotationAnnotationsCtx);
                this.stack.Pop();
            }

            var annotationPropertyCtx = context.annotationProperty();
            if (annotationPropertyCtx != null)
            {
                annotation.AnnotationProperty = new AnnotationProperty();
                this.stack.Push(annotation.AnnotationProperty);
                this.Visit(annotationPropertyCtx);
                this.stack.Pop();
            }

            var annotationValueCtx = context.annotationValue();
            if (annotationValueCtx != null)
            {
                annotation.AnnotationValue = new AnnotationValue();
                this.stack.Push(annotation.AnnotationValue);
                this.Visit(annotationValueCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAnnotationAnnotations([NotNull] HermitRuleParser.AnnotationAnnotationsContext context)
        {
            var annotationAnnotations = this.stack.PeekCtx<AnnotationAnnotations>();
            annotationAnnotations.Parse(context);

            var annotationCtxs = context.annotation();
            foreach (var ctx in annotationCtxs)
            {
                var annotation = new Annotation();
                annotationAnnotations.Annotations.Add(annotation);
                this.stack.Push(annotation);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAnnotationProperty([NotNull] HermitRuleParser.AnnotationPropertyContext context)
        {
            var annotationProperty = this.stack.PeekCtx<AnnotationProperty>();
            annotationProperty.Parse(context);

            var iRICtx = context.iRI();
            if (iRICtx != null)
            {
                annotationProperty.IRI = new IRI();
                this.stack.Push(annotationProperty.IRI);
                this.Visit(iRICtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAnnotationAxiom([NotNull] HermitRuleParser.AnnotationAxiomContext context)
        {
            var annotationAxiom = this.stack.PeekCtx<AnnotationAxiom>();
            annotationAxiom.Parse(context);

            var annotationAssertionCtx = context.annotationAssertion();
            if (annotationAssertionCtx != null)
            {
                annotationAxiom.AnnotationAssertion = new AnnotationAssertion();
                this.stack.Push(annotationAxiom.AnnotationAssertion);
                this.Visit(annotationAssertionCtx);
                this.stack.Pop();
            }

            var subAnnotationPropertyOfCtx = context.subAnnotationPropertyOf();
            if (subAnnotationPropertyOfCtx != null)
            {
                annotationAxiom.SubAnnotationPropertyOf = new SubAnnotationPropertyOf();
                this.stack.Push(annotationAxiom.SubAnnotationPropertyOf);
                this.Visit(subAnnotationPropertyOfCtx);
                this.stack.Pop();
            }

            var annotationPropertyDomainCtx = context.annotationPropertyDomain();
            if (annotationPropertyDomainCtx != null)
            {
                annotationAxiom.AnnotationPropertyDomain = new AnnotationPropertyDomain();
                this.stack.Push(annotationAxiom.AnnotationPropertyDomain);
                this.Visit(annotationPropertyDomainCtx);
                this.stack.Pop();
            }

            var annotationPropertyRangeCtx = context.annotationPropertyRange();
            if (annotationPropertyRangeCtx != null)
            {
                annotationAxiom.AnnotationPropertyRange = new AnnotationPropertyRange();
                this.stack.Push(annotationAxiom.AnnotationPropertyRange);
                this.Visit(annotationPropertyRangeCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAnnotationAssertion([NotNull] HermitRuleParser.AnnotationAssertionContext context)
        {
            var annotationAssertion = this.stack.PeekCtx<AnnotationAssertion>();
            annotationAssertion.Parse(context);

            var ANNOTATION_ASSERTIONCtx = context.ANNOTATION_ASSERTION();
            if (ANNOTATION_ASSERTIONCtx != null)
            {
                annotationAssertion.ANNOTATIONASSERTION = ANNOTATION_ASSERTIONCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                annotationAssertion.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(annotationAssertion.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var annotationPropertyCtx = context.annotationProperty();
            if (annotationPropertyCtx != null)
            {
                annotationAssertion.AnnotationProperty = new AnnotationProperty();
                this.stack.Push(annotationAssertion.AnnotationProperty);
                this.Visit(annotationPropertyCtx);
                this.stack.Pop();
            }

            var annotationSubjectCtx = context.annotationSubject();
            if (annotationSubjectCtx != null)
            {
                annotationAssertion.AnnotationSubject = new AnnotationSubject();
                this.stack.Push(annotationAssertion.AnnotationSubject);
                this.Visit(annotationSubjectCtx);
                this.stack.Pop();
            }

            var annotationValueCtx = context.annotationValue();
            if (annotationValueCtx != null)
            {
                annotationAssertion.AnnotationValue = new AnnotationValue();
                this.stack.Push(annotationAssertion.AnnotationValue);
                this.Visit(annotationValueCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSubAnnotationPropertyOf([NotNull] HermitRuleParser.SubAnnotationPropertyOfContext context)
        {
            var subAnnotationPropertyOf = this.stack.PeekCtx<SubAnnotationPropertyOf>();
            subAnnotationPropertyOf.Parse(context);

            var SUB_ANNOTATION_PROPERTY_OFCtx = context.SUB_ANNOTATION_PROPERTY_OF();
            if (SUB_ANNOTATION_PROPERTY_OFCtx != null)
            {
                subAnnotationPropertyOf.SUBANNOTATIONPROPERTYOF = SUB_ANNOTATION_PROPERTY_OFCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                subAnnotationPropertyOf.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(subAnnotationPropertyOf.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var subAnnotationPropertyCtx = context.subAnnotationProperty();
            if (subAnnotationPropertyCtx != null)
            {
                subAnnotationPropertyOf.SubAnnotationProperty = new SubAnnotationProperty();
                this.stack.Push(subAnnotationPropertyOf.SubAnnotationProperty);
                this.Visit(subAnnotationPropertyCtx);
                this.stack.Pop();
            }

            var superAnnotationPropertyCtx = context.superAnnotationProperty();
            if (superAnnotationPropertyCtx != null)
            {
                subAnnotationPropertyOf.SuperAnnotationProperty = new SuperAnnotationProperty();
                this.stack.Push(subAnnotationPropertyOf.SuperAnnotationProperty);
                this.Visit(superAnnotationPropertyCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSubAnnotationProperty([NotNull] HermitRuleParser.SubAnnotationPropertyContext context)
        {
            var subAnnotationProperty = this.stack.PeekCtx<SubAnnotationProperty>();
            subAnnotationProperty.Parse(context);

            var annotationPropertyCtx = context.annotationProperty();
            if (annotationPropertyCtx != null)
            {
                subAnnotationProperty.AnnotationProperty = new AnnotationProperty();
                this.stack.Push(subAnnotationProperty.AnnotationProperty);
                this.Visit(annotationPropertyCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSuperAnnotationProperty([NotNull] HermitRuleParser.SuperAnnotationPropertyContext context)
        {
            var superAnnotationProperty = this.stack.PeekCtx<SuperAnnotationProperty>();
            superAnnotationProperty.Parse(context);

            var annotationPropertyCtx = context.annotationProperty();
            if (annotationPropertyCtx != null)
            {
                superAnnotationProperty.AnnotationProperty = new AnnotationProperty();
                this.stack.Push(superAnnotationProperty.AnnotationProperty);
                this.Visit(annotationPropertyCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAnnotationPropertyDomain([NotNull] HermitRuleParser.AnnotationPropertyDomainContext context)
        {
            var annotationPropertyDomain = this.stack.PeekCtx<AnnotationPropertyDomain>();
            annotationPropertyDomain.Parse(context);

            var ANNOTATION_PROPERTY_DOMAINCtx = context.ANNOTATION_PROPERTY_DOMAIN();
            if (ANNOTATION_PROPERTY_DOMAINCtx != null)
            {
                annotationPropertyDomain.ANNOTATIONPROPERTYDOMAIN = ANNOTATION_PROPERTY_DOMAINCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                annotationPropertyDomain.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(annotationPropertyDomain.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var annotationPropertyCtx = context.annotationProperty();
            if (annotationPropertyCtx != null)
            {
                annotationPropertyDomain.AnnotationProperty = new AnnotationProperty();
                this.stack.Push(annotationPropertyDomain.AnnotationProperty);
                this.Visit(annotationPropertyCtx);
                this.stack.Pop();
            }

            var iRICtx = context.iRI();
            if (iRICtx != null)
            {
                annotationPropertyDomain.IRI = new IRI();
                this.stack.Push(annotationPropertyDomain.IRI);
                this.Visit(iRICtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAnnotationPropertyRange([NotNull] HermitRuleParser.AnnotationPropertyRangeContext context)
        {
            var annotationPropertyRange = this.stack.PeekCtx<AnnotationPropertyRange>();
            annotationPropertyRange.Parse(context);

            var ANNOTATION_PROPERTY_RANGECtx = context.ANNOTATION_PROPERTY_RANGE();
            if (ANNOTATION_PROPERTY_RANGECtx != null)
            {
                annotationPropertyRange.ANNOTATIONPROPERTYRANGE = ANNOTATION_PROPERTY_RANGECtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                annotationPropertyRange.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(annotationPropertyRange.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var annotationPropertyCtx = context.annotationProperty();
            if (annotationPropertyCtx != null)
            {
                annotationPropertyRange.AnnotationProperty = new AnnotationProperty();
                this.stack.Push(annotationPropertyRange.AnnotationProperty);
                this.Visit(annotationPropertyCtx);
                this.stack.Pop();
            }

            var iRICtx = context.iRI();
            if (iRICtx != null)
            {
                annotationPropertyRange.IRI = new IRI();
                this.stack.Push(annotationPropertyRange.IRI);
                this.Visit(iRICtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitClassExpression([NotNull] HermitRuleParser.ClassExpressionContext context)
        {
            var classExpression = this.stack.PeekCtx<ClassExpression>();
            classExpression.Parse(context);

            var classNCtx = context.classN();
            if (classNCtx != null)
            {
                classExpression.ClassN = new ClassN();
                this.stack.Push(classExpression.ClassN);
                this.Visit(classNCtx);
                this.stack.Pop();
            }

            var objectIntersectionOfCtx = context.objectIntersectionOf();
            if (objectIntersectionOfCtx != null)
            {
                classExpression.ObjectIntersectionOf = new ObjectIntersectionOf();
                this.stack.Push(classExpression.ObjectIntersectionOf);
                this.Visit(objectIntersectionOfCtx);
                this.stack.Pop();
            }

            var objectUnionOfCtx = context.objectUnionOf();
            if (objectUnionOfCtx != null)
            {
                classExpression.ObjectUnionOf = new ObjectUnionOf();
                this.stack.Push(classExpression.ObjectUnionOf);
                this.Visit(objectUnionOfCtx);
                this.stack.Pop();
            }

            var objectComplementOfCtx = context.objectComplementOf();
            if (objectComplementOfCtx != null)
            {
                classExpression.ObjectComplementOf = new ObjectComplementOf();
                this.stack.Push(classExpression.ObjectComplementOf);
                this.Visit(objectComplementOfCtx);
                this.stack.Pop();
            }

            var objectOneOfCtx = context.objectOneOf();
            if (objectOneOfCtx != null)
            {
                classExpression.ObjectOneOf = new ObjectOneOf();
                this.stack.Push(classExpression.ObjectOneOf);
                this.Visit(objectOneOfCtx);
                this.stack.Pop();
            }

            var objectSomeValuesFromCtx = context.objectSomeValuesFrom();
            if (objectSomeValuesFromCtx != null)
            {
                classExpression.ObjectSomeValuesFrom = new ObjectSomeValuesFrom();
                this.stack.Push(classExpression.ObjectSomeValuesFrom);
                this.Visit(objectSomeValuesFromCtx);
                this.stack.Pop();
            }

            var objectAllValuesFromCtx = context.objectAllValuesFrom();
            if (objectAllValuesFromCtx != null)
            {
                classExpression.ObjectAllValuesFrom = new ObjectAllValuesFrom();
                this.stack.Push(classExpression.ObjectAllValuesFrom);
                this.Visit(objectAllValuesFromCtx);
                this.stack.Pop();
            }

            var objectHasValueCtx = context.objectHasValue();
            if (objectHasValueCtx != null)
            {
                classExpression.ObjectHasValue = new ObjectHasValue();
                this.stack.Push(classExpression.ObjectHasValue);
                this.Visit(objectHasValueCtx);
                this.stack.Pop();
            }

            var objectHasSelfCtx = context.objectHasSelf();
            if (objectHasSelfCtx != null)
            {
                classExpression.ObjectHasSelf = new ObjectHasSelf();
                this.stack.Push(classExpression.ObjectHasSelf);
                this.Visit(objectHasSelfCtx);
                this.stack.Pop();
            }

            var objectMinCardinalityCtx = context.objectMinCardinality();
            if (objectMinCardinalityCtx != null)
            {
                classExpression.ObjectMinCardinality = new ObjectMinCardinality();
                this.stack.Push(classExpression.ObjectMinCardinality);
                this.Visit(objectMinCardinalityCtx);
                this.stack.Pop();
            }

            var objectMaxCardinalityCtx = context.objectMaxCardinality();
            if (objectMaxCardinalityCtx != null)
            {
                classExpression.ObjectMaxCardinality = new ObjectMaxCardinality();
                this.stack.Push(classExpression.ObjectMaxCardinality);
                this.Visit(objectMaxCardinalityCtx);
                this.stack.Pop();
            }

            var objectExactCardinalityCtx = context.objectExactCardinality();
            if (objectExactCardinalityCtx != null)
            {
                classExpression.ObjectExactCardinality = new ObjectExactCardinality();
                this.stack.Push(classExpression.ObjectExactCardinality);
                this.Visit(objectExactCardinalityCtx);
                this.stack.Pop();
            }

            var dataSomeValuesFromCtx = context.dataSomeValuesFrom();
            if (dataSomeValuesFromCtx != null)
            {
                classExpression.DataSomeValuesFrom = new DataSomeValuesFrom();
                this.stack.Push(classExpression.DataSomeValuesFrom);
                this.Visit(dataSomeValuesFromCtx);
                this.stack.Pop();
            }

            var dataAllValuesFromCtx = context.dataAllValuesFrom();
            if (dataAllValuesFromCtx != null)
            {
                classExpression.DataAllValuesFrom = new DataAllValuesFrom();
                this.stack.Push(classExpression.DataAllValuesFrom);
                this.Visit(dataAllValuesFromCtx);
                this.stack.Pop();
            }

            var dataHasValueCtx = context.dataHasValue();
            if (dataHasValueCtx != null)
            {
                classExpression.DataHasValue = new DataHasValue();
                this.stack.Push(classExpression.DataHasValue);
                this.Visit(dataHasValueCtx);
                this.stack.Pop();
            }

            var dataMinCardinalityCtx = context.dataMinCardinality();
            if (dataMinCardinalityCtx != null)
            {
                classExpression.DataMinCardinality = new DataMinCardinality();
                this.stack.Push(classExpression.DataMinCardinality);
                this.Visit(dataMinCardinalityCtx);
                this.stack.Pop();
            }

            var dataMaxCardinalityCtx = context.dataMaxCardinality();
            if (dataMaxCardinalityCtx != null)
            {
                classExpression.DataMaxCardinality = new DataMaxCardinality();
                this.stack.Push(classExpression.DataMaxCardinality);
                this.Visit(dataMaxCardinalityCtx);
                this.stack.Pop();
            }

            var dataExactCardinalityCtx = context.dataExactCardinality();
            if (dataExactCardinalityCtx != null)
            {
                classExpression.DataExactCardinality = new DataExactCardinality();
                this.stack.Push(classExpression.DataExactCardinality);
                this.Visit(dataExactCardinalityCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectIntersectionOf([NotNull] HermitRuleParser.ObjectIntersectionOfContext context)
        {
            var objectIntersectionOf = this.stack.PeekCtx<ObjectIntersectionOf>();
            objectIntersectionOf.Parse(context);

            var OBJECT_INTERSECTION_OFCtx = context.OBJECT_INTERSECTION_OF();
            if (OBJECT_INTERSECTION_OFCtx != null)
            {
                objectIntersectionOf.OBJECTINTERSECTIONOF = OBJECT_INTERSECTION_OFCtx.GetText();
            }

            var classExpressionCtxs = context.classExpression();
            foreach (var ctx in classExpressionCtxs)
            {
                var classExpression = new ClassExpression();
                objectIntersectionOf.ClassExpressions.Add(classExpression);
                this.stack.Push(classExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectUnionOf([NotNull] HermitRuleParser.ObjectUnionOfContext context)
        {
            var objectUnionOf = this.stack.PeekCtx<ObjectUnionOf>();
            objectUnionOf.Parse(context);

            var OBJECT_UNION_OFCtx = context.OBJECT_UNION_OF();
            if (OBJECT_UNION_OFCtx != null)
            {
                objectUnionOf.OBJECTUNIONOF = OBJECT_UNION_OFCtx.GetText();
            }

            var classExpressionCtxs = context.classExpression();
            foreach (var ctx in classExpressionCtxs)
            {
                var classExpression = new ClassExpression();
                objectUnionOf.ClassExpressions.Add(classExpression);
                this.stack.Push(classExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectComplementOf([NotNull] HermitRuleParser.ObjectComplementOfContext context)
        {
            var objectComplementOf = this.stack.PeekCtx<ObjectComplementOf>();
            objectComplementOf.Parse(context);

            var OBJECT_COMPLEMENT_OFCtx = context.OBJECT_COMPLEMENT_OF();
            if (OBJECT_COMPLEMENT_OFCtx != null)
            {
                objectComplementOf.OBJECTCOMPLEMENTOF = OBJECT_COMPLEMENT_OFCtx.GetText();
            }

            var classExpressionCtx = context.classExpression();
            if (classExpressionCtx != null)
            {
                objectComplementOf.ClassExpression = new ClassExpression();
                this.stack.Push(objectComplementOf.ClassExpression);
                this.Visit(classExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectOneOf([NotNull] HermitRuleParser.ObjectOneOfContext context)
        {
            var objectOneOf = this.stack.PeekCtx<ObjectOneOf>();
            objectOneOf.Parse(context);

            var OBJECT_ONE_OFCtx = context.OBJECT_ONE_OF();
            if (OBJECT_ONE_OFCtx != null)
            {
                objectOneOf.OBJECTONEOF = OBJECT_ONE_OFCtx.GetText();
            }

            var individualCtxs = context.individual();
            foreach (var ctx in individualCtxs)
            {
                var individual = new Individual();
                objectOneOf.Individuals.Add(individual);
                this.stack.Push(individual);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectSomeValuesFrom([NotNull] HermitRuleParser.ObjectSomeValuesFromContext context)
        {
            var objectSomeValuesFrom = this.stack.PeekCtx<ObjectSomeValuesFrom>();
            objectSomeValuesFrom.Parse(context);

            var OBJECT_SOME_VALUES_FROMCtx = context.OBJECT_SOME_VALUES_FROM();
            if (OBJECT_SOME_VALUES_FROMCtx != null)
            {
                objectSomeValuesFrom.OBJECTSOMEVALUESFROM = OBJECT_SOME_VALUES_FROMCtx.GetText();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                objectSomeValuesFrom.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(objectSomeValuesFrom.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            var classExpressionCtx = context.classExpression();
            if (classExpressionCtx != null)
            {
                objectSomeValuesFrom.ClassExpression = new ClassExpression();
                this.stack.Push(objectSomeValuesFrom.ClassExpression);
                this.Visit(classExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectAllValuesFrom([NotNull] HermitRuleParser.ObjectAllValuesFromContext context)
        {
            var objectAllValuesFrom = this.stack.PeekCtx<ObjectAllValuesFrom>();
            objectAllValuesFrom.Parse(context);

            var OBJECT_ALL_VALUES_FROMCtx = context.OBJECT_ALL_VALUES_FROM();
            if (OBJECT_ALL_VALUES_FROMCtx != null)
            {
                objectAllValuesFrom.OBJECTALLVALUESFROM = OBJECT_ALL_VALUES_FROMCtx.GetText();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                objectAllValuesFrom.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(objectAllValuesFrom.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            var classExpressionCtx = context.classExpression();
            if (classExpressionCtx != null)
            {
                objectAllValuesFrom.ClassExpression = new ClassExpression();
                this.stack.Push(objectAllValuesFrom.ClassExpression);
                this.Visit(classExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectHasValue([NotNull] HermitRuleParser.ObjectHasValueContext context)
        {
            var objectHasValue = this.stack.PeekCtx<ObjectHasValue>();
            objectHasValue.Parse(context);

            var OBJECT_HAS_VALUECtx = context.OBJECT_HAS_VALUE();
            if (OBJECT_HAS_VALUECtx != null)
            {
                objectHasValue.OBJECTHASVALUE = OBJECT_HAS_VALUECtx.GetText();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                objectHasValue.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(objectHasValue.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            var individualCtx = context.individual();
            if (individualCtx != null)
            {
                objectHasValue.Individual = new Individual();
                this.stack.Push(objectHasValue.Individual);
                this.Visit(individualCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectHasSelf([NotNull] HermitRuleParser.ObjectHasSelfContext context)
        {
            var objectHasSelf = this.stack.PeekCtx<ObjectHasSelf>();
            objectHasSelf.Parse(context);

            var OBJECT_HAS_SELFCtx = context.OBJECT_HAS_SELF();
            if (OBJECT_HAS_SELFCtx != null)
            {
                objectHasSelf.OBJECTHASSELF = OBJECT_HAS_SELFCtx.GetText();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                objectHasSelf.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(objectHasSelf.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectMinCardinality([NotNull] HermitRuleParser.ObjectMinCardinalityContext context)
        {
            var objectMinCardinality = this.stack.PeekCtx<ObjectMinCardinality>();
            objectMinCardinality.Parse(context);

            var OBJECT_MIN_CARDINALITYCtx = context.OBJECT_MIN_CARDINALITY();
            if (OBJECT_MIN_CARDINALITYCtx != null)
            {
                objectMinCardinality.OBJECTMINCARDINALITY = OBJECT_MIN_CARDINALITYCtx.GetText();
            }

            var INTEGERCtx = context.INTEGER();
            if (INTEGERCtx != null)
            {
                objectMinCardinality.INTEGER = INTEGERCtx.GetText();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                objectMinCardinality.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(objectMinCardinality.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            var classExpressionCtx = context.classExpression();
            if (classExpressionCtx != null)
            {
                objectMinCardinality.ClassExpression = new ClassExpression();
                this.stack.Push(objectMinCardinality.ClassExpression);
                this.Visit(classExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectMaxCardinality([NotNull] HermitRuleParser.ObjectMaxCardinalityContext context)
        {
            var objectMaxCardinality = this.stack.PeekCtx<ObjectMaxCardinality>();
            objectMaxCardinality.Parse(context);

            var OBJECT_MAX_CARDINALITYCtx = context.OBJECT_MAX_CARDINALITY();
            if (OBJECT_MAX_CARDINALITYCtx != null)
            {
                objectMaxCardinality.OBJECTMAXCARDINALITY = OBJECT_MAX_CARDINALITYCtx.GetText();
            }

            var INTEGERCtx = context.INTEGER();
            if (INTEGERCtx != null)
            {
                objectMaxCardinality.INTEGER = INTEGERCtx.GetText();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                objectMaxCardinality.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(objectMaxCardinality.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            var classExpressionCtx = context.classExpression();
            if (classExpressionCtx != null)
            {
                objectMaxCardinality.ClassExpression = new ClassExpression();
                this.stack.Push(objectMaxCardinality.ClassExpression);
                this.Visit(classExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectExactCardinality([NotNull] HermitRuleParser.ObjectExactCardinalityContext context)
        {
            var objectExactCardinality = this.stack.PeekCtx<ObjectExactCardinality>();
            objectExactCardinality.Parse(context);

            var OBJECT_EXACT_CARDINALITYCtx = context.OBJECT_EXACT_CARDINALITY();
            if (OBJECT_EXACT_CARDINALITYCtx != null)
            {
                objectExactCardinality.OBJECTEXACTCARDINALITY = OBJECT_EXACT_CARDINALITYCtx.GetText();
            }

            var INTEGERCtx = context.INTEGER();
            if (INTEGERCtx != null)
            {
                objectExactCardinality.INTEGER = INTEGERCtx.GetText();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                objectExactCardinality.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(objectExactCardinality.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            var classExpressionCtx = context.classExpression();
            if (classExpressionCtx != null)
            {
                objectExactCardinality.ClassExpression = new ClassExpression();
                this.stack.Push(objectExactCardinality.ClassExpression);
                this.Visit(classExpressionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDataSomeValuesFrom([NotNull] HermitRuleParser.DataSomeValuesFromContext context)
        {
            var dataSomeValuesFrom = this.stack.PeekCtx<DataSomeValuesFrom>();
            dataSomeValuesFrom.Parse(context);

            var DATA_SOME_VALUES_FROMCtx = context.DATA_SOME_VALUES_FROM();
            if (DATA_SOME_VALUES_FROMCtx != null)
            {
                dataSomeValuesFrom.DATASOMEVALUESFROM = DATA_SOME_VALUES_FROMCtx.GetText();
            }

            var dataPropertyExpressionCtxs = context.dataPropertyExpression();
            foreach (var ctx in dataPropertyExpressionCtxs)
            {
                var dataPropertyExpression = new DataPropertyExpression();
                dataSomeValuesFrom.DataPropertyExpressions.Add(dataPropertyExpression);
                this.stack.Push(dataPropertyExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var dataRangeCtx = context.dataRange();
            if (dataRangeCtx != null)
            {
                dataSomeValuesFrom.DataRange = new DataRange();
                this.stack.Push(dataSomeValuesFrom.DataRange);
                this.Visit(dataRangeCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDataAllValuesFrom([NotNull] HermitRuleParser.DataAllValuesFromContext context)
        {
            var dataAllValuesFrom = this.stack.PeekCtx<DataAllValuesFrom>();
            dataAllValuesFrom.Parse(context);

            var DATA_ALL_VALUES_FROMCtx = context.DATA_ALL_VALUES_FROM();
            if (DATA_ALL_VALUES_FROMCtx != null)
            {
                dataAllValuesFrom.DATAALLVALUESFROM = DATA_ALL_VALUES_FROMCtx.GetText();
            }

            var dataPropertyExpressionCtxs = context.dataPropertyExpression();
            foreach (var ctx in dataPropertyExpressionCtxs)
            {
                var dataPropertyExpression = new DataPropertyExpression();
                dataAllValuesFrom.DataPropertyExpressions.Add(dataPropertyExpression);
                this.stack.Push(dataPropertyExpression);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var dataRangeCtx = context.dataRange();
            if (dataRangeCtx != null)
            {
                dataAllValuesFrom.DataRange = new DataRange();
                this.stack.Push(dataAllValuesFrom.DataRange);
                this.Visit(dataRangeCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDataHasValue([NotNull] HermitRuleParser.DataHasValueContext context)
        {
            var dataHasValue = this.stack.PeekCtx<DataHasValue>();
            dataHasValue.Parse(context);

            var DATA_HAS_VALUECtx = context.DATA_HAS_VALUE();
            if (DATA_HAS_VALUECtx != null)
            {
                dataHasValue.DATAHASVALUE = DATA_HAS_VALUECtx.GetText();
            }

            var dataPropertyExpressionCtx = context.dataPropertyExpression();
            if (dataPropertyExpressionCtx != null)
            {
                dataHasValue.DataPropertyExpression = new DataPropertyExpression();
                this.stack.Push(dataHasValue.DataPropertyExpression);
                this.Visit(dataPropertyExpressionCtx);
                this.stack.Pop();
            }

            var literalCtx = context.literal();
            if (literalCtx != null)
            {
                dataHasValue.Literal = new Literal();
                this.stack.Push(dataHasValue.Literal);
                this.Visit(literalCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDataMinCardinality([NotNull] HermitRuleParser.DataMinCardinalityContext context)
        {
            var dataMinCardinality = this.stack.PeekCtx<DataMinCardinality>();
            dataMinCardinality.Parse(context);

            var DATA_MIN_CARDINALITYCtx = context.DATA_MIN_CARDINALITY();
            if (DATA_MIN_CARDINALITYCtx != null)
            {
                dataMinCardinality.DATAMINCARDINALITY = DATA_MIN_CARDINALITYCtx.GetText();
            }

            var INTEGERCtx = context.INTEGER();
            if (INTEGERCtx != null)
            {
                dataMinCardinality.INTEGER = INTEGERCtx.GetText();
            }

            var dataPropertyExpressionCtx = context.dataPropertyExpression();
            if (dataPropertyExpressionCtx != null)
            {
                dataMinCardinality.DataPropertyExpression = new DataPropertyExpression();
                this.stack.Push(dataMinCardinality.DataPropertyExpression);
                this.Visit(dataPropertyExpressionCtx);
                this.stack.Pop();
            }

            var dataRangeCtx = context.dataRange();
            if (dataRangeCtx != null)
            {
                dataMinCardinality.DataRange = new DataRange();
                this.stack.Push(dataMinCardinality.DataRange);
                this.Visit(dataRangeCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDataMaxCardinality([NotNull] HermitRuleParser.DataMaxCardinalityContext context)
        {
            var dataMaxCardinality = this.stack.PeekCtx<DataMaxCardinality>();
            dataMaxCardinality.Parse(context);

            var DATA_MAX_CARDINALITYCtx = context.DATA_MAX_CARDINALITY();
            if (DATA_MAX_CARDINALITYCtx != null)
            {
                dataMaxCardinality.DATAMAXCARDINALITY = DATA_MAX_CARDINALITYCtx.GetText();
            }

            var INTEGERCtx = context.INTEGER();
            if (INTEGERCtx != null)
            {
                dataMaxCardinality.INTEGER = INTEGERCtx.GetText();
            }

            var dataPropertyExpressionCtx = context.dataPropertyExpression();
            if (dataPropertyExpressionCtx != null)
            {
                dataMaxCardinality.DataPropertyExpression = new DataPropertyExpression();
                this.stack.Push(dataMaxCardinality.DataPropertyExpression);
                this.Visit(dataPropertyExpressionCtx);
                this.stack.Pop();
            }

            var dataRangeCtx = context.dataRange();
            if (dataRangeCtx != null)
            {
                dataMaxCardinality.DataRange = new DataRange();
                this.stack.Push(dataMaxCardinality.DataRange);
                this.Visit(dataRangeCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDataExactCardinality([NotNull] HermitRuleParser.DataExactCardinalityContext context)
        {
            var dataExactCardinality = this.stack.PeekCtx<DataExactCardinality>();
            dataExactCardinality.Parse(context);

            var DATA_EXACT_CARDINALITYCtx = context.DATA_EXACT_CARDINALITY();
            if (DATA_EXACT_CARDINALITYCtx != null)
            {
                dataExactCardinality.DATAEXACTCARDINALITY = DATA_EXACT_CARDINALITYCtx.GetText();
            }

            var INTEGERCtx = context.INTEGER();
            if (INTEGERCtx != null)
            {
                dataExactCardinality.INTEGER = INTEGERCtx.GetText();
            }

            var dataPropertyExpressionCtx = context.dataPropertyExpression();
            if (dataPropertyExpressionCtx != null)
            {
                dataExactCardinality.DataPropertyExpression = new DataPropertyExpression();
                this.stack.Push(dataExactCardinality.DataPropertyExpression);
                this.Visit(dataPropertyExpressionCtx);
                this.stack.Pop();
            }

            var dataRangeCtx = context.dataRange();
            if (dataRangeCtx != null)
            {
                dataExactCardinality.DataRange = new DataRange();
                this.stack.Push(dataExactCardinality.DataRange);
                this.Visit(dataRangeCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDataPropertyExpression([NotNull] HermitRuleParser.DataPropertyExpressionContext context)
        {
            var dataPropertyExpression = this.stack.PeekCtx<DataPropertyExpression>();
            dataPropertyExpression.Parse(context);

            var dataPropertyCtx = context.dataProperty();
            if (dataPropertyCtx != null)
            {
                dataPropertyExpression.DataProperty = new DataProperty();
                this.stack.Push(dataPropertyExpression.DataProperty);
                this.Visit(dataPropertyCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAssertion([NotNull] HermitRuleParser.AssertionContext context)
        {
            var assertion = this.stack.PeekCtx<Assertion>();
            assertion.Parse(context);

            var sameIndividualCtx = context.sameIndividual();
            if (sameIndividualCtx != null)
            {
                assertion.SameIndividual = new SameIndividual();
                this.stack.Push(assertion.SameIndividual);
                this.Visit(sameIndividualCtx);
                this.stack.Pop();
            }

            var differentIndividualsCtx = context.differentIndividuals();
            if (differentIndividualsCtx != null)
            {
                assertion.DifferentIndividuals = new DifferentIndividuals();
                this.stack.Push(assertion.DifferentIndividuals);
                this.Visit(differentIndividualsCtx);
                this.stack.Pop();
            }

            var classAssertionCtx = context.classAssertion();
            if (classAssertionCtx != null)
            {
                assertion.ClassAssertion = new ClassAssertion();
                this.stack.Push(assertion.ClassAssertion);
                this.Visit(classAssertionCtx);
                this.stack.Pop();
            }

            var objectPropertyAssertionCtx = context.objectPropertyAssertion();
            if (objectPropertyAssertionCtx != null)
            {
                assertion.ObjectPropertyAssertion = new ObjectPropertyAssertion();
                this.stack.Push(assertion.ObjectPropertyAssertion);
                this.Visit(objectPropertyAssertionCtx);
                this.stack.Pop();
            }

            var negativeObjectPropertyAssertionCtx = context.negativeObjectPropertyAssertion();
            if (negativeObjectPropertyAssertionCtx != null)
            {
                assertion.NegativeObjectPropertyAssertion = new NegativeObjectPropertyAssertion();
                this.stack.Push(assertion.NegativeObjectPropertyAssertion);
                this.Visit(negativeObjectPropertyAssertionCtx);
                this.stack.Pop();
            }

            var dataPropertyAssertionCtx = context.dataPropertyAssertion();
            if (dataPropertyAssertionCtx != null)
            {
                assertion.DataPropertyAssertion = new DataPropertyAssertion();
                this.stack.Push(assertion.DataPropertyAssertion);
                this.Visit(dataPropertyAssertionCtx);
                this.stack.Pop();
            }

            var negativeDataPropertyAssertionCtx = context.negativeDataPropertyAssertion();
            if (negativeDataPropertyAssertionCtx != null)
            {
                assertion.NegativeDataPropertyAssertion = new NegativeDataPropertyAssertion();
                this.stack.Push(assertion.NegativeDataPropertyAssertion);
                this.Visit(negativeDataPropertyAssertionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSourceIndividual([NotNull] HermitRuleParser.SourceIndividualContext context)
        {
            var sourceIndividual = this.stack.PeekCtx<SourceIndividual>();
            sourceIndividual.Parse(context);

            var individualCtx = context.individual();
            if (individualCtx != null)
            {
                sourceIndividual.Individual = new Individual();
                this.stack.Push(sourceIndividual.Individual);
                this.Visit(individualCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitTargetIndividual([NotNull] HermitRuleParser.TargetIndividualContext context)
        {
            var targetIndividual = this.stack.PeekCtx<TargetIndividual>();
            targetIndividual.Parse(context);

            var individualCtx = context.individual();
            if (individualCtx != null)
            {
                targetIndividual.Individual = new Individual();
                this.stack.Push(targetIndividual.Individual);
                this.Visit(individualCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitTargetValue([NotNull] HermitRuleParser.TargetValueContext context)
        {
            var targetValue = this.stack.PeekCtx<TargetValue>();
            targetValue.Parse(context);

            var literalCtx = context.literal();
            if (literalCtx != null)
            {
                targetValue.Literal = new Literal();
                this.stack.Push(targetValue.Literal);
                this.Visit(literalCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitSameIndividual([NotNull] HermitRuleParser.SameIndividualContext context)
        {
            var sameIndividual = this.stack.PeekCtx<SameIndividual>();
            sameIndividual.Parse(context);

            var SAME_INDIVIDUALCtx = context.SAME_INDIVIDUAL();
            if (SAME_INDIVIDUALCtx != null)
            {
                sameIndividual.SAMEINDIVIDUAL = SAME_INDIVIDUALCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                sameIndividual.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(sameIndividual.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var individualCtxs = context.individual();
            foreach (var ctx in individualCtxs)
            {
                var individual = new Individual();
                sameIndividual.Individuals.Add(individual);
                this.stack.Push(individual);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDifferentIndividuals([NotNull] HermitRuleParser.DifferentIndividualsContext context)
        {
            var differentIndividuals = this.stack.PeekCtx<DifferentIndividuals>();
            differentIndividuals.Parse(context);

            var DIFFERENT_INDIVIDUALSCtx = context.DIFFERENT_INDIVIDUALS();
            if (DIFFERENT_INDIVIDUALSCtx != null)
            {
                differentIndividuals.DIFFERENTINDIVIDUALS = DIFFERENT_INDIVIDUALSCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                differentIndividuals.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(differentIndividuals.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var individualCtxs = context.individual();
            foreach (var ctx in individualCtxs)
            {
                var individual = new Individual();
                differentIndividuals.Individuals.Add(individual);
                this.stack.Push(individual);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitClassAssertion([NotNull] HermitRuleParser.ClassAssertionContext context)
        {
            var classAssertion = this.stack.PeekCtx<ClassAssertion>();
            classAssertion.Parse(context);

            var CLASS_ASSERTIONCtx = context.CLASS_ASSERTION();
            if (CLASS_ASSERTIONCtx != null)
            {
                classAssertion.CLASSASSERTION = CLASS_ASSERTIONCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                classAssertion.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(classAssertion.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var classExpressionCtx = context.classExpression();
            if (classExpressionCtx != null)
            {
                classAssertion.ClassExpression = new ClassExpression();
                this.stack.Push(classAssertion.ClassExpression);
                this.Visit(classExpressionCtx);
                this.stack.Pop();
            }

            var individualCtx = context.individual();
            if (individualCtx != null)
            {
                classAssertion.Individual = new Individual();
                this.stack.Push(classAssertion.Individual);
                this.Visit(individualCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectPropertyAssertion([NotNull] HermitRuleParser.ObjectPropertyAssertionContext context)
        {
            var objectPropertyAssertion = this.stack.PeekCtx<ObjectPropertyAssertion>();
            objectPropertyAssertion.Parse(context);

            var OBJECT_PROPERTY_ASSERTIONCtx = context.OBJECT_PROPERTY_ASSERTION();
            if (OBJECT_PROPERTY_ASSERTIONCtx != null)
            {
                objectPropertyAssertion.OBJECTPROPERTYASSERTION = OBJECT_PROPERTY_ASSERTIONCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                objectPropertyAssertion.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(objectPropertyAssertion.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                objectPropertyAssertion.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(objectPropertyAssertion.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            var sourceIndividualCtx = context.sourceIndividual();
            if (sourceIndividualCtx != null)
            {
                objectPropertyAssertion.SourceIndividual = new SourceIndividual();
                this.stack.Push(objectPropertyAssertion.SourceIndividual);
                this.Visit(sourceIndividualCtx);
                this.stack.Pop();
            }

            var targetIndividualCtx = context.targetIndividual();
            if (targetIndividualCtx != null)
            {
                objectPropertyAssertion.TargetIndividual = new TargetIndividual();
                this.stack.Push(objectPropertyAssertion.TargetIndividual);
                this.Visit(targetIndividualCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitNegativeObjectPropertyAssertion([NotNull] HermitRuleParser.NegativeObjectPropertyAssertionContext context)
        {
            var negativeObjectPropertyAssertion = this.stack.PeekCtx<NegativeObjectPropertyAssertion>();
            negativeObjectPropertyAssertion.Parse(context);

            var NEGATIVE_OBJECT_PROPERTY_ASSERTIONCtx = context.NEGATIVE_OBJECT_PROPERTY_ASSERTION();
            if (NEGATIVE_OBJECT_PROPERTY_ASSERTIONCtx != null)
            {
                negativeObjectPropertyAssertion.NEGATIVEOBJECTPROPERTYASSERTION = NEGATIVE_OBJECT_PROPERTY_ASSERTIONCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                negativeObjectPropertyAssertion.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(negativeObjectPropertyAssertion.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var objectPropertyExpressionCtx = context.objectPropertyExpression();
            if (objectPropertyExpressionCtx != null)
            {
                negativeObjectPropertyAssertion.ObjectPropertyExpression = new ObjectPropertyExpression();
                this.stack.Push(negativeObjectPropertyAssertion.ObjectPropertyExpression);
                this.Visit(objectPropertyExpressionCtx);
                this.stack.Pop();
            }

            var sourceIndividualCtx = context.sourceIndividual();
            if (sourceIndividualCtx != null)
            {
                negativeObjectPropertyAssertion.SourceIndividual = new SourceIndividual();
                this.stack.Push(negativeObjectPropertyAssertion.SourceIndividual);
                this.Visit(sourceIndividualCtx);
                this.stack.Pop();
            }

            var targetIndividualCtx = context.targetIndividual();
            if (targetIndividualCtx != null)
            {
                negativeObjectPropertyAssertion.TargetIndividual = new TargetIndividual();
                this.stack.Push(negativeObjectPropertyAssertion.TargetIndividual);
                this.Visit(targetIndividualCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDataPropertyAssertion([NotNull] HermitRuleParser.DataPropertyAssertionContext context)
        {
            var dataPropertyAssertion = this.stack.PeekCtx<DataPropertyAssertion>();
            dataPropertyAssertion.Parse(context);

            var DATA_PROPERTY_ASSERTIONCtx = context.DATA_PROPERTY_ASSERTION();
            if (DATA_PROPERTY_ASSERTIONCtx != null)
            {
                dataPropertyAssertion.DATAPROPERTYASSERTION = DATA_PROPERTY_ASSERTIONCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                dataPropertyAssertion.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(dataPropertyAssertion.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var dataPropertyExpressionCtx = context.dataPropertyExpression();
            if (dataPropertyExpressionCtx != null)
            {
                dataPropertyAssertion.DataPropertyExpression = new DataPropertyExpression();
                this.stack.Push(dataPropertyAssertion.DataPropertyExpression);
                this.Visit(dataPropertyExpressionCtx);
                this.stack.Pop();
            }

            var sourceIndividualCtx = context.sourceIndividual();
            if (sourceIndividualCtx != null)
            {
                dataPropertyAssertion.SourceIndividual = new SourceIndividual();
                this.stack.Push(dataPropertyAssertion.SourceIndividual);
                this.Visit(sourceIndividualCtx);
                this.stack.Pop();
            }

            var targetValueCtx = context.targetValue();
            if (targetValueCtx != null)
            {
                dataPropertyAssertion.TargetValue = new TargetValue();
                this.stack.Push(dataPropertyAssertion.TargetValue);
                this.Visit(targetValueCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitNegativeDataPropertyAssertion([NotNull] HermitRuleParser.NegativeDataPropertyAssertionContext context)
        {
            var negativeDataPropertyAssertion = this.stack.PeekCtx<NegativeDataPropertyAssertion>();
            negativeDataPropertyAssertion.Parse(context);

            var NEGATIVE_DATA_PROPERTY_ASSERTIONCtx = context.NEGATIVE_DATA_PROPERTY_ASSERTION();
            if (NEGATIVE_DATA_PROPERTY_ASSERTIONCtx != null)
            {
                negativeDataPropertyAssertion.NEGATIVEDATAPROPERTYASSERTION = NEGATIVE_DATA_PROPERTY_ASSERTIONCtx.GetText();
            }

            var axiomAnnotationsCtx = context.axiomAnnotations();
            if (axiomAnnotationsCtx != null)
            {
                negativeDataPropertyAssertion.AxiomAnnotations = new AxiomAnnotations();
                this.stack.Push(negativeDataPropertyAssertion.AxiomAnnotations);
                this.Visit(axiomAnnotationsCtx);
                this.stack.Pop();
            }

            var dataPropertyExpressionCtx = context.dataPropertyExpression();
            if (dataPropertyExpressionCtx != null)
            {
                negativeDataPropertyAssertion.DataPropertyExpression = new DataPropertyExpression();
                this.stack.Push(negativeDataPropertyAssertion.DataPropertyExpression);
                this.Visit(dataPropertyExpressionCtx);
                this.stack.Pop();
            }

            var sourceIndividualCtx = context.sourceIndividual();
            if (sourceIndividualCtx != null)
            {
                negativeDataPropertyAssertion.SourceIndividual = new SourceIndividual();
                this.stack.Push(negativeDataPropertyAssertion.SourceIndividual);
                this.Visit(sourceIndividualCtx);
                this.stack.Pop();
            }

            var targetValueCtx = context.targetValue();
            if (targetValueCtx != null)
            {
                negativeDataPropertyAssertion.TargetValue = new TargetValue();
                this.stack.Push(negativeDataPropertyAssertion.TargetValue);
                this.Visit(targetValueCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDataRange([NotNull] HermitRuleParser.DataRangeContext context)
        {
            var dataRange = this.stack.PeekCtx<DataRange>();
            dataRange.Parse(context);

            var datatypeCtx = context.datatype();
            if (datatypeCtx != null)
            {
                dataRange.Datatype = new Datatype();
                this.stack.Push(dataRange.Datatype);
                this.Visit(datatypeCtx);
                this.stack.Pop();
            }

            var dataIntersectionOfCtx = context.dataIntersectionOf();
            if (dataIntersectionOfCtx != null)
            {
                dataRange.DataIntersectionOf = new DataIntersectionOf();
                this.stack.Push(dataRange.DataIntersectionOf);
                this.Visit(dataIntersectionOfCtx);
                this.stack.Pop();
            }

            var dataUnionOfCtx = context.dataUnionOf();
            if (dataUnionOfCtx != null)
            {
                dataRange.DataUnionOf = new DataUnionOf();
                this.stack.Push(dataRange.DataUnionOf);
                this.Visit(dataUnionOfCtx);
                this.stack.Pop();
            }

            var dataComplementOfCtx = context.dataComplementOf();
            if (dataComplementOfCtx != null)
            {
                dataRange.DataComplementOf = new DataComplementOf();
                this.stack.Push(dataRange.DataComplementOf);
                this.Visit(dataComplementOfCtx);
                this.stack.Pop();
            }

            var dataOneOfCtx = context.dataOneOf();
            if (dataOneOfCtx != null)
            {
                dataRange.DataOneOf = new DataOneOf();
                this.stack.Push(dataRange.DataOneOf);
                this.Visit(dataOneOfCtx);
                this.stack.Pop();
            }

            var datatypeRestrictionCtx = context.datatypeRestriction();
            if (datatypeRestrictionCtx != null)
            {
                dataRange.DatatypeRestriction = new DatatypeRestriction();
                this.stack.Push(dataRange.DatatypeRestriction);
                this.Visit(datatypeRestrictionCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDataIntersectionOf([NotNull] HermitRuleParser.DataIntersectionOfContext context)
        {
            var dataIntersectionOf = this.stack.PeekCtx<DataIntersectionOf>();
            dataIntersectionOf.Parse(context);

            var DATA_INTERSECTION_OFCtx = context.DATA_INTERSECTION_OF();
            if (DATA_INTERSECTION_OFCtx != null)
            {
                dataIntersectionOf.DATAINTERSECTIONOF = DATA_INTERSECTION_OFCtx.GetText();
            }

            var dataRangeCtxs = context.dataRange();
            foreach (var ctx in dataRangeCtxs)
            {
                var dataRange = new DataRange();
                dataIntersectionOf.DataRanges.Add(dataRange);
                this.stack.Push(dataRange);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDataUnionOf([NotNull] HermitRuleParser.DataUnionOfContext context)
        {
            var dataUnionOf = this.stack.PeekCtx<DataUnionOf>();
            dataUnionOf.Parse(context);

            var DATA_UNION_OFCtx = context.DATA_UNION_OF();
            if (DATA_UNION_OFCtx != null)
            {
                dataUnionOf.DATAUNIONOF = DATA_UNION_OFCtx.GetText();
            }

            var dataRangeCtxs = context.dataRange();
            foreach (var ctx in dataRangeCtxs)
            {
                var dataRange = new DataRange();
                dataUnionOf.DataRanges.Add(dataRange);
                this.stack.Push(dataRange);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDataComplementOf([NotNull] HermitRuleParser.DataComplementOfContext context)
        {
            var dataComplementOf = this.stack.PeekCtx<DataComplementOf>();
            dataComplementOf.Parse(context);

            var DATA_COMPLEMENT_OFCtx = context.DATA_COMPLEMENT_OF();
            if (DATA_COMPLEMENT_OFCtx != null)
            {
                dataComplementOf.DATACOMPLEMENTOF = DATA_COMPLEMENT_OFCtx.GetText();
            }

            var dataRangeCtx = context.dataRange();
            if (dataRangeCtx != null)
            {
                dataComplementOf.DataRange = new DataRange();
                this.stack.Push(dataComplementOf.DataRange);
                this.Visit(dataRangeCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDataOneOf([NotNull] HermitRuleParser.DataOneOfContext context)
        {
            var dataOneOf = this.stack.PeekCtx<DataOneOf>();
            dataOneOf.Parse(context);

            var DATA_ONE_OFCtx = context.DATA_ONE_OF();
            if (DATA_ONE_OFCtx != null)
            {
                dataOneOf.DATAONEOF = DATA_ONE_OFCtx.GetText();
            }

            var literalCtxs = context.literal();
            foreach (var ctx in literalCtxs)
            {
                var literal = new Literal();
                dataOneOf.Literals.Add(literal);
                this.stack.Push(literal);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDatatype([NotNull] HermitRuleParser.DatatypeContext context)
        {
            var datatype = this.stack.PeekCtx<Datatype>();
            datatype.Parse(context);

            var iRICtx = context.iRI();
            if (iRICtx != null)
            {
                datatype.IRI = new IRI();
                this.stack.Push(datatype.IRI);
                this.Visit(iRICtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectPropertyExpression([NotNull] HermitRuleParser.ObjectPropertyExpressionContext context)
        {
            var objectPropertyExpression = this.stack.PeekCtx<ObjectPropertyExpression>();
            objectPropertyExpression.Parse(context);

            var objectPropertyCtx = context.objectProperty();
            if (objectPropertyCtx != null)
            {
                objectPropertyExpression.ObjectProperty = new ObjectProperty();
                this.stack.Push(objectPropertyExpression.ObjectProperty);
                this.Visit(objectPropertyCtx);
                this.stack.Pop();
            }

            var inverseObjectPropertyCtx = context.inverseObjectProperty();
            if (inverseObjectPropertyCtx != null)
            {
                objectPropertyExpression.InverseObjectProperty = new InverseObjectProperty();
                this.stack.Push(objectPropertyExpression.InverseObjectProperty);
                this.Visit(inverseObjectPropertyCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitInverseObjectProperty([NotNull] HermitRuleParser.InverseObjectPropertyContext context)
        {
            var inverseObjectProperty = this.stack.PeekCtx<InverseObjectProperty>();
            inverseObjectProperty.Parse(context);

            var OBJECT_INVERSE_OFCtx = context.OBJECT_INVERSE_OF();
            if (OBJECT_INVERSE_OFCtx != null)
            {
                inverseObjectProperty.OBJECTINVERSEOF = OBJECT_INVERSE_OFCtx.GetText();
            }

            var objectPropertyCtx = context.objectProperty();
            if (objectPropertyCtx != null)
            {
                inverseObjectProperty.ObjectProperty = new ObjectProperty();
                this.stack.Push(inverseObjectProperty.ObjectProperty);
                this.Visit(objectPropertyCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDatatypeRestriction([NotNull] HermitRuleParser.DatatypeRestrictionContext context)
        {
            var datatypeRestriction = this.stack.PeekCtx<DatatypeRestriction>();
            datatypeRestriction.Parse(context);

            var DATATYPE_RESTRICTIONCtx = context.DATATYPE_RESTRICTION();
            if (DATATYPE_RESTRICTIONCtx != null)
            {
                datatypeRestriction.DATATYPERESTRICTION = DATATYPE_RESTRICTIONCtx.GetText();
            }

            var datatypeCtx = context.datatype();
            if (datatypeCtx != null)
            {
                datatypeRestriction.Datatype = new Datatype();
                this.stack.Push(datatypeRestriction.Datatype);
                this.Visit(datatypeCtx);
                this.stack.Pop();
            }

            var constrainingFacetCtxs = context.constrainingFacet();
            foreach (var ctx in constrainingFacetCtxs)
            {
                var constrainingFacet = new ConstrainingFacet();
                datatypeRestriction.ConstrainingFacets.Add(constrainingFacet);
                this.stack.Push(constrainingFacet);
                this.Visit(ctx);
                this.stack.Pop();
            }

            var restrictionValueCtxs = context.restrictionValue();
            foreach (var ctx in restrictionValueCtxs)
            {
                var restrictionValue = new RestrictionValue();
                datatypeRestriction.RestrictionValues.Add(restrictionValue);
                this.stack.Push(restrictionValue);
                this.Visit(ctx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitConstrainingFacet([NotNull] HermitRuleParser.ConstrainingFacetContext context)
        {
            var constrainingFacet = this.stack.PeekCtx<ConstrainingFacet>();
            constrainingFacet.Parse(context);

            var iRICtx = context.iRI();
            if (iRICtx != null)
            {
                constrainingFacet.IRI = new IRI();
                this.stack.Push(constrainingFacet.IRI);
                this.Visit(iRICtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitRestrictionValue([NotNull] HermitRuleParser.RestrictionValueContext context)
        {
            var restrictionValue = this.stack.PeekCtx<RestrictionValue>();
            restrictionValue.Parse(context);

            var literalCtx = context.literal();
            if (literalCtx != null)
            {
                restrictionValue.Literal = new Literal();
                this.stack.Push(restrictionValue.Literal);
                this.Visit(literalCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitDataProperty([NotNull] HermitRuleParser.DataPropertyContext context)
        {
            var dataProperty = this.stack.PeekCtx<DataProperty>();
            dataProperty.Parse(context);

            var iRICtx = context.iRI();
            if (iRICtx != null)
            {
                dataProperty.IRI = new IRI();
                this.stack.Push(dataProperty.IRI);
                this.Visit(iRICtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitIndividual([NotNull] HermitRuleParser.IndividualContext context)
        {
            var individual = this.stack.PeekCtx<Individual>();
            individual.Parse(context);

            var namedIndividualCtx = context.namedIndividual();
            if (namedIndividualCtx != null)
            {
                individual.NamedIndividual = new NamedIndividual();
                this.stack.Push(individual.NamedIndividual);
                this.Visit(namedIndividualCtx);
                this.stack.Pop();
            }

            var anonymousIndividualCtx = context.anonymousIndividual();
            if (anonymousIndividualCtx != null)
            {
                individual.AnonymousIndividual = new AnonymousIndividual();
                this.stack.Push(individual.AnonymousIndividual);
                this.Visit(anonymousIndividualCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitNamedIndividual([NotNull] HermitRuleParser.NamedIndividualContext context)
        {
            var namedIndividual = this.stack.PeekCtx<NamedIndividual>();
            namedIndividual.Parse(context);

            var iRICtx = context.iRI();
            if (iRICtx != null)
            {
                namedIndividual.IRI = new IRI();
                this.stack.Push(namedIndividual.IRI);
                this.Visit(iRICtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitAnonymousIndividual([NotNull] HermitRuleParser.AnonymousIndividualContext context)
        {
            var anonymousIndividual = this.stack.PeekCtx<AnonymousIndividual>();
            anonymousIndividual.Parse(context);

            var BLANK_NODE_LABELCtx = context.BLANK_NODE_LABEL();
            if (BLANK_NODE_LABELCtx != null)
            {
                anonymousIndividual.BLANKNODELABEL = BLANK_NODE_LABELCtx.GetText();
            }

            return 0;
        }

        public override int VisitLiteral([NotNull] HermitRuleParser.LiteralContext context)
        {
            var literal = this.stack.PeekCtx<Literal>();
            literal.Parse(context);

            var StringCtx = context.String();
            if (StringCtx != null)
            {
                literal.@string = StringCtx.GetText();
            }

            var LANGTAGCtx = context.LANGTAG();
            if (LANGTAGCtx != null)
            {
                literal.LANGTAG = LANGTAGCtx.GetText();
            }

            var xsdIriCtx = context.xsdIri();
            if (xsdIriCtx != null)
            {
                literal.XsdIri = new XsdIri();
                this.stack.Push(literal.XsdIri);
                this.Visit(xsdIriCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitClassN([NotNull] HermitRuleParser.ClassNContext context)
        {
            var classN = this.stack.PeekCtx<ClassN>();
            classN.Parse(context);

            var iRICtx = context.iRI();
            if (iRICtx != null)
            {
                classN.IRI = new IRI();
                this.stack.Push(classN.IRI);
                this.Visit(iRICtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitObjectProperty([NotNull] HermitRuleParser.ObjectPropertyContext context)
        {
            var objectProperty = this.stack.PeekCtx<ObjectProperty>();
            objectProperty.Parse(context);

            var iRICtx = context.iRI();
            if (iRICtx != null)
            {
                objectProperty.IRI = new IRI();
                this.stack.Push(objectProperty.IRI);
                this.Visit(iRICtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitIRI([NotNull] HermitRuleParser.IRIContext context)
        {
            var iRI = this.stack.PeekCtx<IRI>();
            iRI.Parse(context);

            var IRIREFCtx = context.IRIREF();
            if (IRIREFCtx != null)
            {
                iRI.IRIREF = IRIREFCtx.GetText();
            }

            var prefixedNameCtx = context.prefixedName();
            if (prefixedNameCtx != null)
            {
                iRI.PrefixedName = new PrefixedName();
                this.stack.Push(iRI.PrefixedName);
                this.Visit(prefixedNameCtx);
                this.stack.Pop();
            }

            return 0;
        }

        public override int VisitPrefixedName([NotNull] HermitRuleParser.PrefixedNameContext context)
        {
            var prefixedName = this.stack.PeekCtx<PrefixedName>();
            prefixedName.Parse(context);

            var PNAME_LNCtx = context.PNAME_LN();
            if (PNAME_LNCtx != null)
            {
                prefixedName.PNAMELN = PNAME_LNCtx.GetText();
            }

            var PNAME_NSCtx = context.PNAME_NS();
            if (PNAME_NSCtx != null)
            {
                prefixedName.PNAMENS = PNAME_NSCtx.GetText();
            }

            return 0;
        }

        public override int VisitBlankNode([NotNull] HermitRuleParser.BlankNodeContext context)
        {
            var blankNode = this.stack.PeekCtx<BlankNode>();
            blankNode.Parse(context);

            var BLANK_NODE_LABELCtx = context.BLANK_NODE_LABEL();
            if (BLANK_NODE_LABELCtx != null)
            {
                blankNode.BLANKNODELABEL = BLANK_NODE_LABELCtx.GetText();
            }

            var ANONCtx = context.ANON();
            if (ANONCtx != null)
            {
                blankNode.ANON = ANONCtx.GetText();
            }

            return 0;
        }

        public override int VisitXsdIri([NotNull] HermitRuleParser.XsdIriContext context)
        {
            var xsdIri = this.stack.PeekCtx<XsdIri>();
            xsdIri.Parse(context);

            var IRIREFCtx = context.IRIREF();
            if (IRIREFCtx != null)
            {
                xsdIri.IRIREF = IRIREFCtx.GetText();
            }

            var prefixedNameCtx = context.prefixedName();
            if (prefixedNameCtx != null)
            {
                xsdIri.PrefixedName = new PrefixedName();
                this.stack.Push(xsdIri.PrefixedName);
                this.Visit(prefixedNameCtx);
                this.stack.Pop();
            }

            return 0;
        }

    }
}
