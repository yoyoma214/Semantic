using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Common;

namespace CodeHelper.Core.Parse.ParseResults.Swrls
{
    public class Axioms : TokenPair
    {
        public Axioms()
        {
            this.AxiomList = new List<Axiom>();
            this.RuleNs = new List<RuleN>();
            this.DGAxioms = new List<DGAxiom>();
        }
        public List<Axiom> AxiomList
        { get; set; }
        public List<RuleN> RuleNs
        { get; set; }
        public List<DGAxiom> DGAxioms
        { get; set; }

        public void Parse(SwrlContext context)
        {

            for (int i = 0; i < this.AxiomList.Count(); i++)
            {
                this.AxiomList[i].Parse(context);
            }

            for (int i = 0; i < this.RuleNs.Count(); i++)
            {
                this.RuleNs[i].Parse(context);
            }

            for (int i = 0; i < this.DGAxioms.Count(); i++)
            {
                this.DGAxioms[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            for (int i = 0; i < this.AxiomList.Count(); i++)
            {
                this.AxiomList[i].Wise(context);
            }

            for (int i = 0; i < this.RuleNs.Count(); i++)
            {
                this.RuleNs[i].Wise(context);
            }

            for (int i = 0; i < this.DGAxioms.Count(); i++)
            {
                this.DGAxioms[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.AxiomList.Count(); i++)
            {
                this.AxiomList[i].Format(context, builder);
            }

            for (int i = 0; i < this.RuleNs.Count(); i++)
            {
                this.RuleNs[i].Format(context, builder);
            }

            for (int i = 0; i < this.DGAxioms.Count(); i++)
            {
                this.DGAxioms[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.AxiomList.Count(); i++)
            {
                this.AxiomList[i].BuildQuery(context, builder);
            }

            for (int i = 0; i < this.RuleNs.Count(); i++)
            {
                this.RuleNs[i].BuildQuery(context, builder);
            }

            for (int i = 0; i < this.DGAxioms.Count(); i++)
            {
                this.DGAxioms[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.AxiomList.Count(); i++)
            {
                this.AxiomList[i].BuildMock(context, builder);
            }

            for (int i = 0; i < this.RuleNs.Count(); i++)
            {
                this.RuleNs[i].BuildMock(context, builder);
            }

            for (int i = 0; i < this.DGAxioms.Count(); i++)
            {
                this.DGAxioms[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.AxiomList.Count(); i++)
            {
                this.AxiomList[i].BuildOther(context, builder);
            }

            for (int i = 0; i < this.RuleNs.Count(); i++)
            {
                this.RuleNs[i].BuildOther(context, builder);
            }

            for (int i = 0; i < this.DGAxioms.Count(); i++)
            {
                this.DGAxioms[i].BuildOther(context, builder);
            }

        }
    }

    public class RuleN : TokenPair
    {
        public RuleN()
        {
        }
        public DLSafeRule DLSafeRule
        { get; set; }
        public DGRule DGRule
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.DLSafeRule != null)
            {
                this.DLSafeRule.Parse(context);
            }

            if (this.DGRule != null)
            {
                this.DGRule.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.DLSafeRule != null)
            {
                this.DLSafeRule.Wise(context);
            }

            if (this.DGRule != null)
            {
                this.DGRule.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DLSafeRule != null)
            {
                this.DLSafeRule.Format(context, builder);
            }

            if (this.DGRule != null)
            {
                this.DGRule.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DLSafeRule != null)
            {
                this.DLSafeRule.BuildQuery(context, builder);
            }

            if (this.DGRule != null)
            {
                this.DGRule.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DLSafeRule != null)
            {
                this.DLSafeRule.BuildMock(context, builder);
            }

            if (this.DGRule != null)
            {
                this.DGRule.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DLSafeRule != null)
            {
                this.DLSafeRule.BuildOther(context, builder);
            }

            if (this.DGRule != null)
            {
                this.DGRule.BuildOther(context, builder);
            }

        }
    }

    public class DLSafeRule : TokenPair
    {
        public DLSafeRule()
        {
            this.Annotations = new List<Annotation>();
            this.Atoms = new List<Atom>();
        }
        public String DLSAFERULE
        { get; set; }
        public List<Annotation> Annotations
        { get; set; }
        public String BODY
        { get; set; }
        public List<Atom> Atoms
        { get; set; }
        public String HEAD
        { get; set; }

        public void Parse(SwrlContext context)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].Parse(context);
            }

            for (int i = 0; i < this.Atoms.Count(); i++)
            {
                this.Atoms[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].Wise(context);
            }

            for (int i = 0; i < this.Atoms.Count(); i++)
            {
                this.Atoms[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].Format(context, builder);
            }

            for (int i = 0; i < this.Atoms.Count(); i++)
            {
                this.Atoms[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].BuildQuery(context, builder);
            }

            for (int i = 0; i < this.Atoms.Count(); i++)
            {
                this.Atoms[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].BuildMock(context, builder);
            }

            for (int i = 0; i < this.Atoms.Count(); i++)
            {
                this.Atoms[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].BuildOther(context, builder);
            }

            for (int i = 0; i < this.Atoms.Count(); i++)
            {
                this.Atoms[i].BuildOther(context, builder);
            }

        }
    }

    public class Axiom : TokenPair
    {
        public Axiom()
        {
        }
        public Declaration Declaration
        { get; set; }
        public ClassAxiom ClassAxiom
        { get; set; }
        public ObjectPropertyAxiom ObjectPropertyAxiom
        { get; set; }
        public DataPropertyAxiom DataPropertyAxiom
        { get; set; }
        public DatatypeDefinition DatatypeDefinition
        { get; set; }
        public HasKey HasKey
        { get; set; }
        public Assertion Assertion
        { get; set; }
        public AnnotationAxiom AnnotationAxiom
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.Declaration != null)
            {
                this.Declaration.Parse(context);
            }

            if (this.ClassAxiom != null)
            {
                this.ClassAxiom.Parse(context);
            }

            if (this.ObjectPropertyAxiom != null)
            {
                this.ObjectPropertyAxiom.Parse(context);
            }

            if (this.DataPropertyAxiom != null)
            {
                this.DataPropertyAxiom.Parse(context);
            }

            if (this.DatatypeDefinition != null)
            {
                this.DatatypeDefinition.Parse(context);
            }

            if (this.HasKey != null)
            {
                this.HasKey.Parse(context);
            }

            if (this.Assertion != null)
            {
                this.Assertion.Parse(context);
            }

            if (this.AnnotationAxiom != null)
            {
                this.AnnotationAxiom.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.Declaration != null)
            {
                this.Declaration.Wise(context);
            }

            if (this.ClassAxiom != null)
            {
                this.ClassAxiom.Wise(context);
            }

            if (this.ObjectPropertyAxiom != null)
            {
                this.ObjectPropertyAxiom.Wise(context);
            }

            if (this.DataPropertyAxiom != null)
            {
                this.DataPropertyAxiom.Wise(context);
            }

            if (this.DatatypeDefinition != null)
            {
                this.DatatypeDefinition.Wise(context);
            }

            if (this.HasKey != null)
            {
                this.HasKey.Wise(context);
            }

            if (this.Assertion != null)
            {
                this.Assertion.Wise(context);
            }

            if (this.AnnotationAxiom != null)
            {
                this.AnnotationAxiom.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Declaration != null)
            {
                this.Declaration.Format(context, builder);
            }

            if (this.ClassAxiom != null)
            {
                this.ClassAxiom.Format(context, builder);
            }

            if (this.ObjectPropertyAxiom != null)
            {
                this.ObjectPropertyAxiom.Format(context, builder);
            }

            if (this.DataPropertyAxiom != null)
            {
                this.DataPropertyAxiom.Format(context, builder);
            }

            if (this.DatatypeDefinition != null)
            {
                this.DatatypeDefinition.Format(context, builder);
            }

            if (this.HasKey != null)
            {
                this.HasKey.Format(context, builder);
            }

            if (this.Assertion != null)
            {
                this.Assertion.Format(context, builder);
            }

            if (this.AnnotationAxiom != null)
            {
                this.AnnotationAxiom.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Declaration != null)
            {
                this.Declaration.BuildQuery(context, builder);
            }

            if (this.ClassAxiom != null)
            {
                this.ClassAxiom.BuildQuery(context, builder);
            }

            if (this.ObjectPropertyAxiom != null)
            {
                this.ObjectPropertyAxiom.BuildQuery(context, builder);
            }

            if (this.DataPropertyAxiom != null)
            {
                this.DataPropertyAxiom.BuildQuery(context, builder);
            }

            if (this.DatatypeDefinition != null)
            {
                this.DatatypeDefinition.BuildQuery(context, builder);
            }

            if (this.HasKey != null)
            {
                this.HasKey.BuildQuery(context, builder);
            }

            if (this.Assertion != null)
            {
                this.Assertion.BuildQuery(context, builder);
            }

            if (this.AnnotationAxiom != null)
            {
                this.AnnotationAxiom.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Declaration != null)
            {
                this.Declaration.BuildMock(context, builder);
            }

            if (this.ClassAxiom != null)
            {
                this.ClassAxiom.BuildMock(context, builder);
            }

            if (this.ObjectPropertyAxiom != null)
            {
                this.ObjectPropertyAxiom.BuildMock(context, builder);
            }

            if (this.DataPropertyAxiom != null)
            {
                this.DataPropertyAxiom.BuildMock(context, builder);
            }

            if (this.DatatypeDefinition != null)
            {
                this.DatatypeDefinition.BuildMock(context, builder);
            }

            if (this.HasKey != null)
            {
                this.HasKey.BuildMock(context, builder);
            }

            if (this.Assertion != null)
            {
                this.Assertion.BuildMock(context, builder);
            }

            if (this.AnnotationAxiom != null)
            {
                this.AnnotationAxiom.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Declaration != null)
            {
                this.Declaration.BuildOther(context, builder);
            }

            if (this.ClassAxiom != null)
            {
                this.ClassAxiom.BuildOther(context, builder);
            }

            if (this.ObjectPropertyAxiom != null)
            {
                this.ObjectPropertyAxiom.BuildOther(context, builder);
            }

            if (this.DataPropertyAxiom != null)
            {
                this.DataPropertyAxiom.BuildOther(context, builder);
            }

            if (this.DatatypeDefinition != null)
            {
                this.DatatypeDefinition.BuildOther(context, builder);
            }

            if (this.HasKey != null)
            {
                this.HasKey.BuildOther(context, builder);
            }

            if (this.Assertion != null)
            {
                this.Assertion.BuildOther(context, builder);
            }

            if (this.AnnotationAxiom != null)
            {
                this.AnnotationAxiom.BuildOther(context, builder);
            }

        }
    }

    public class Declaration : TokenPair
    {
        public Declaration()
        {
        }
        public String DECLARATION
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public Entity Entity
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.Entity != null)
            {
                this.Entity.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.Entity != null)
            {
                this.Entity.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.Entity != null)
            {
                this.Entity.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.Entity != null)
            {
                this.Entity.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.Entity != null)
            {
                this.Entity.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.Entity != null)
            {
                this.Entity.BuildOther(context, builder);
            }

        }
    }

    public class Entity : TokenPair
    {
        public Entity()
        {
        }
        public String CLASS
        { get; set; }
        public ClassN ClassN
        { get; set; }
        public String DATATYPE
        { get; set; }
        public Datatype Datatype
        { get; set; }
        public String OBJECTPROPERTY
        { get; set; }
        public ObjectProperty ObjectProperty
        { get; set; }
        public String DATAPROPERTY
        { get; set; }
        public DataProperty DataProperty
        { get; set; }
        public String ANNOTATIONPROPERTY
        { get; set; }
        public AnnotationProperty AnnotationProperty
        { get; set; }
        public String NAMEDINDIVIDUAL
        { get; set; }
        public NamedIndividual NamedIndividual
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ClassN != null)
            {
                this.ClassN.Parse(context);
            }

            if (this.Datatype != null)
            {
                this.Datatype.Parse(context);
            }

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.Parse(context);
            }

            if (this.DataProperty != null)
            {
                this.DataProperty.Parse(context);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Parse(context);
            }

            if (this.NamedIndividual != null)
            {
                this.NamedIndividual.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ClassN != null)
            {
                this.ClassN.Wise(context);
            }

            if (this.Datatype != null)
            {
                this.Datatype.Wise(context);
            }

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.Wise(context);
            }

            if (this.DataProperty != null)
            {
                this.DataProperty.Wise(context);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Wise(context);
            }

            if (this.NamedIndividual != null)
            {
                this.NamedIndividual.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassN != null)
            {
                this.ClassN.Format(context, builder);
            }

            if (this.Datatype != null)
            {
                this.Datatype.Format(context, builder);
            }

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.Format(context, builder);
            }

            if (this.DataProperty != null)
            {
                this.DataProperty.Format(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Format(context, builder);
            }

            if (this.NamedIndividual != null)
            {
                this.NamedIndividual.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassN != null)
            {
                this.ClassN.BuildQuery(context, builder);
            }

            if (this.Datatype != null)
            {
                this.Datatype.BuildQuery(context, builder);
            }

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.BuildQuery(context, builder);
            }

            if (this.DataProperty != null)
            {
                this.DataProperty.BuildQuery(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildQuery(context, builder);
            }

            if (this.NamedIndividual != null)
            {
                this.NamedIndividual.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassN != null)
            {
                this.ClassN.BuildMock(context, builder);
            }

            if (this.Datatype != null)
            {
                this.Datatype.BuildMock(context, builder);
            }

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.BuildMock(context, builder);
            }

            if (this.DataProperty != null)
            {
                this.DataProperty.BuildMock(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildMock(context, builder);
            }

            if (this.NamedIndividual != null)
            {
                this.NamedIndividual.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassN != null)
            {
                this.ClassN.BuildOther(context, builder);
            }

            if (this.Datatype != null)
            {
                this.Datatype.BuildOther(context, builder);
            }

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.BuildOther(context, builder);
            }

            if (this.DataProperty != null)
            {
                this.DataProperty.BuildOther(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildOther(context, builder);
            }

            if (this.NamedIndividual != null)
            {
                this.NamedIndividual.BuildOther(context, builder);
            }

        }
    }

    public class ClassAxiom : TokenPair
    {
        public ClassAxiom()
        {
        }
        public SubClassOf SubClassOf
        { get; set; }
        public EquivalentClasses EquivalentClasses
        { get; set; }
        public DisjointClasses DisjointClasses
        { get; set; }
        public DisjointUnion DisjointUnion
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.SubClassOf != null)
            {
                this.SubClassOf.Parse(context);
            }

            if (this.EquivalentClasses != null)
            {
                this.EquivalentClasses.Parse(context);
            }

            if (this.DisjointClasses != null)
            {
                this.DisjointClasses.Parse(context);
            }

            if (this.DisjointUnion != null)
            {
                this.DisjointUnion.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.SubClassOf != null)
            {
                this.SubClassOf.Wise(context);
            }

            if (this.EquivalentClasses != null)
            {
                this.EquivalentClasses.Wise(context);
            }

            if (this.DisjointClasses != null)
            {
                this.DisjointClasses.Wise(context);
            }

            if (this.DisjointUnion != null)
            {
                this.DisjointUnion.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.SubClassOf != null)
            {
                this.SubClassOf.Format(context, builder);
            }

            if (this.EquivalentClasses != null)
            {
                this.EquivalentClasses.Format(context, builder);
            }

            if (this.DisjointClasses != null)
            {
                this.DisjointClasses.Format(context, builder);
            }

            if (this.DisjointUnion != null)
            {
                this.DisjointUnion.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.SubClassOf != null)
            {
                this.SubClassOf.BuildQuery(context, builder);
            }

            if (this.EquivalentClasses != null)
            {
                this.EquivalentClasses.BuildQuery(context, builder);
            }

            if (this.DisjointClasses != null)
            {
                this.DisjointClasses.BuildQuery(context, builder);
            }

            if (this.DisjointUnion != null)
            {
                this.DisjointUnion.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.SubClassOf != null)
            {
                this.SubClassOf.BuildMock(context, builder);
            }

            if (this.EquivalentClasses != null)
            {
                this.EquivalentClasses.BuildMock(context, builder);
            }

            if (this.DisjointClasses != null)
            {
                this.DisjointClasses.BuildMock(context, builder);
            }

            if (this.DisjointUnion != null)
            {
                this.DisjointUnion.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.SubClassOf != null)
            {
                this.SubClassOf.BuildOther(context, builder);
            }

            if (this.EquivalentClasses != null)
            {
                this.EquivalentClasses.BuildOther(context, builder);
            }

            if (this.DisjointClasses != null)
            {
                this.DisjointClasses.BuildOther(context, builder);
            }

            if (this.DisjointUnion != null)
            {
                this.DisjointUnion.BuildOther(context, builder);
            }

        }
    }

    public class SubClassOf : TokenPair
    {
        public SubClassOf()
        {
        }
        public String SUBCLASSOF
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public SubClassExpression SubClassExpression
        { get; set; }
        public SuperClassExpression SuperClassExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.SubClassExpression != null)
            {
                this.SubClassExpression.Parse(context);
            }

            if (this.SuperClassExpression != null)
            {
                this.SuperClassExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.SubClassExpression != null)
            {
                this.SubClassExpression.Wise(context);
            }

            if (this.SuperClassExpression != null)
            {
                this.SuperClassExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.SubClassExpression != null)
            {
                this.SubClassExpression.Format(context, builder);
            }

            if (this.SuperClassExpression != null)
            {
                this.SuperClassExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.SubClassExpression != null)
            {
                this.SubClassExpression.BuildQuery(context, builder);
            }

            if (this.SuperClassExpression != null)
            {
                this.SuperClassExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.SubClassExpression != null)
            {
                this.SubClassExpression.BuildMock(context, builder);
            }

            if (this.SuperClassExpression != null)
            {
                this.SuperClassExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.SubClassExpression != null)
            {
                this.SubClassExpression.BuildOther(context, builder);
            }

            if (this.SuperClassExpression != null)
            {
                this.SuperClassExpression.BuildOther(context, builder);
            }

        }
    }

    public class EquivalentClasses : TokenPair
    {
        public EquivalentClasses()
        {
            this.ClassExpressions = new List<ClassExpression>();
        }
        public String EQUIVALENTCLASSES
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public List<ClassExpression> ClassExpressions
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].BuildOther(context, builder);
            }

        }
    }

    public class SubClassExpression : TokenPair
    {
        public SubClassExpression()
        {
        }
        public ClassExpression ClassExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildOther(context, builder);
            }

        }
    }

    public class SuperClassExpression : TokenPair
    {
        public SuperClassExpression()
        {
        }
        public ClassExpression ClassExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildOther(context, builder);
            }

        }
    }

    public class DisjointClasses : TokenPair
    {
        public DisjointClasses()
        {
            this.ClassExpressions = new List<ClassExpression>();
        }
        public String DISJOINTCLASSES
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public List<ClassExpression> ClassExpressions
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].BuildOther(context, builder);
            }

        }
    }

    public class DisjointUnion : TokenPair
    {
        public DisjointUnion()
        {
        }
        public String DISJOINTUNION
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public ClassN ClassN
        { get; set; }
        public DisjointClassExpressions DisjointClassExpressions
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.ClassN != null)
            {
                this.ClassN.Parse(context);
            }

            if (this.DisjointClassExpressions != null)
            {
                this.DisjointClassExpressions.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.ClassN != null)
            {
                this.ClassN.Wise(context);
            }

            if (this.DisjointClassExpressions != null)
            {
                this.DisjointClassExpressions.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.ClassN != null)
            {
                this.ClassN.Format(context, builder);
            }

            if (this.DisjointClassExpressions != null)
            {
                this.DisjointClassExpressions.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.ClassN != null)
            {
                this.ClassN.BuildQuery(context, builder);
            }

            if (this.DisjointClassExpressions != null)
            {
                this.DisjointClassExpressions.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.ClassN != null)
            {
                this.ClassN.BuildMock(context, builder);
            }

            if (this.DisjointClassExpressions != null)
            {
                this.DisjointClassExpressions.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.ClassN != null)
            {
                this.ClassN.BuildOther(context, builder);
            }

            if (this.DisjointClassExpressions != null)
            {
                this.DisjointClassExpressions.BuildOther(context, builder);
            }

        }
    }

    public class DisjointClassExpressions : TokenPair
    {
        public DisjointClassExpressions()
        {
            this.ClassExpressions = new List<ClassExpression>();
        }
        public List<ClassExpression> ClassExpressions
        { get; set; }

        public void Parse(SwrlContext context)
        {

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].BuildOther(context, builder);
            }

        }
    }

    public class ObjectPropertyAxiom : TokenPair
    {
        public ObjectPropertyAxiom()
        {
        }
        public SubObjectPropertyOf SubObjectPropertyOf
        { get; set; }
        public EquivalentObjectProperties EquivalentObjectProperties
        { get; set; }
        public DisjointObjectProperties DisjointObjectProperties
        { get; set; }
        public InverseObjectProperties InverseObjectProperties
        { get; set; }
        public ObjectPropertyDomain ObjectPropertyDomain
        { get; set; }
        public ObjectPropertyRange ObjectPropertyRange
        { get; set; }
        public FunctionalObjectProperty FunctionalObjectProperty
        { get; set; }
        public InverseFunctionalObjectProperty InverseFunctionalObjectProperty
        { get; set; }
        public ReflexiveObjectProperty ReflexiveObjectProperty
        { get; set; }
        public IrreflexiveObjectProperty IrreflexiveObjectProperty
        { get; set; }
        public SymmetricObjectProperty SymmetricObjectProperty
        { get; set; }
        public AsymmetricObjectProperty AsymmetricObjectProperty
        { get; set; }
        public TransitiveObjectProperty TransitiveObjectProperty
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.SubObjectPropertyOf != null)
            {
                this.SubObjectPropertyOf.Parse(context);
            }

            if (this.EquivalentObjectProperties != null)
            {
                this.EquivalentObjectProperties.Parse(context);
            }

            if (this.DisjointObjectProperties != null)
            {
                this.DisjointObjectProperties.Parse(context);
            }

            if (this.InverseObjectProperties != null)
            {
                this.InverseObjectProperties.Parse(context);
            }

            if (this.ObjectPropertyDomain != null)
            {
                this.ObjectPropertyDomain.Parse(context);
            }

            if (this.ObjectPropertyRange != null)
            {
                this.ObjectPropertyRange.Parse(context);
            }

            if (this.FunctionalObjectProperty != null)
            {
                this.FunctionalObjectProperty.Parse(context);
            }

            if (this.InverseFunctionalObjectProperty != null)
            {
                this.InverseFunctionalObjectProperty.Parse(context);
            }

            if (this.ReflexiveObjectProperty != null)
            {
                this.ReflexiveObjectProperty.Parse(context);
            }

            if (this.IrreflexiveObjectProperty != null)
            {
                this.IrreflexiveObjectProperty.Parse(context);
            }

            if (this.SymmetricObjectProperty != null)
            {
                this.SymmetricObjectProperty.Parse(context);
            }

            if (this.AsymmetricObjectProperty != null)
            {
                this.AsymmetricObjectProperty.Parse(context);
            }

            if (this.TransitiveObjectProperty != null)
            {
                this.TransitiveObjectProperty.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.SubObjectPropertyOf != null)
            {
                this.SubObjectPropertyOf.Wise(context);
            }

            if (this.EquivalentObjectProperties != null)
            {
                this.EquivalentObjectProperties.Wise(context);
            }

            if (this.DisjointObjectProperties != null)
            {
                this.DisjointObjectProperties.Wise(context);
            }

            if (this.InverseObjectProperties != null)
            {
                this.InverseObjectProperties.Wise(context);
            }

            if (this.ObjectPropertyDomain != null)
            {
                this.ObjectPropertyDomain.Wise(context);
            }

            if (this.ObjectPropertyRange != null)
            {
                this.ObjectPropertyRange.Wise(context);
            }

            if (this.FunctionalObjectProperty != null)
            {
                this.FunctionalObjectProperty.Wise(context);
            }

            if (this.InverseFunctionalObjectProperty != null)
            {
                this.InverseFunctionalObjectProperty.Wise(context);
            }

            if (this.ReflexiveObjectProperty != null)
            {
                this.ReflexiveObjectProperty.Wise(context);
            }

            if (this.IrreflexiveObjectProperty != null)
            {
                this.IrreflexiveObjectProperty.Wise(context);
            }

            if (this.SymmetricObjectProperty != null)
            {
                this.SymmetricObjectProperty.Wise(context);
            }

            if (this.AsymmetricObjectProperty != null)
            {
                this.AsymmetricObjectProperty.Wise(context);
            }

            if (this.TransitiveObjectProperty != null)
            {
                this.TransitiveObjectProperty.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.SubObjectPropertyOf != null)
            {
                this.SubObjectPropertyOf.Format(context, builder);
            }

            if (this.EquivalentObjectProperties != null)
            {
                this.EquivalentObjectProperties.Format(context, builder);
            }

            if (this.DisjointObjectProperties != null)
            {
                this.DisjointObjectProperties.Format(context, builder);
            }

            if (this.InverseObjectProperties != null)
            {
                this.InverseObjectProperties.Format(context, builder);
            }

            if (this.ObjectPropertyDomain != null)
            {
                this.ObjectPropertyDomain.Format(context, builder);
            }

            if (this.ObjectPropertyRange != null)
            {
                this.ObjectPropertyRange.Format(context, builder);
            }

            if (this.FunctionalObjectProperty != null)
            {
                this.FunctionalObjectProperty.Format(context, builder);
            }

            if (this.InverseFunctionalObjectProperty != null)
            {
                this.InverseFunctionalObjectProperty.Format(context, builder);
            }

            if (this.ReflexiveObjectProperty != null)
            {
                this.ReflexiveObjectProperty.Format(context, builder);
            }

            if (this.IrreflexiveObjectProperty != null)
            {
                this.IrreflexiveObjectProperty.Format(context, builder);
            }

            if (this.SymmetricObjectProperty != null)
            {
                this.SymmetricObjectProperty.Format(context, builder);
            }

            if (this.AsymmetricObjectProperty != null)
            {
                this.AsymmetricObjectProperty.Format(context, builder);
            }

            if (this.TransitiveObjectProperty != null)
            {
                this.TransitiveObjectProperty.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.SubObjectPropertyOf != null)
            {
                this.SubObjectPropertyOf.BuildQuery(context, builder);
            }

            if (this.EquivalentObjectProperties != null)
            {
                this.EquivalentObjectProperties.BuildQuery(context, builder);
            }

            if (this.DisjointObjectProperties != null)
            {
                this.DisjointObjectProperties.BuildQuery(context, builder);
            }

            if (this.InverseObjectProperties != null)
            {
                this.InverseObjectProperties.BuildQuery(context, builder);
            }

            if (this.ObjectPropertyDomain != null)
            {
                this.ObjectPropertyDomain.BuildQuery(context, builder);
            }

            if (this.ObjectPropertyRange != null)
            {
                this.ObjectPropertyRange.BuildQuery(context, builder);
            }

            if (this.FunctionalObjectProperty != null)
            {
                this.FunctionalObjectProperty.BuildQuery(context, builder);
            }

            if (this.InverseFunctionalObjectProperty != null)
            {
                this.InverseFunctionalObjectProperty.BuildQuery(context, builder);
            }

            if (this.ReflexiveObjectProperty != null)
            {
                this.ReflexiveObjectProperty.BuildQuery(context, builder);
            }

            if (this.IrreflexiveObjectProperty != null)
            {
                this.IrreflexiveObjectProperty.BuildQuery(context, builder);
            }

            if (this.SymmetricObjectProperty != null)
            {
                this.SymmetricObjectProperty.BuildQuery(context, builder);
            }

            if (this.AsymmetricObjectProperty != null)
            {
                this.AsymmetricObjectProperty.BuildQuery(context, builder);
            }

            if (this.TransitiveObjectProperty != null)
            {
                this.TransitiveObjectProperty.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.SubObjectPropertyOf != null)
            {
                this.SubObjectPropertyOf.BuildMock(context, builder);
            }

            if (this.EquivalentObjectProperties != null)
            {
                this.EquivalentObjectProperties.BuildMock(context, builder);
            }

            if (this.DisjointObjectProperties != null)
            {
                this.DisjointObjectProperties.BuildMock(context, builder);
            }

            if (this.InverseObjectProperties != null)
            {
                this.InverseObjectProperties.BuildMock(context, builder);
            }

            if (this.ObjectPropertyDomain != null)
            {
                this.ObjectPropertyDomain.BuildMock(context, builder);
            }

            if (this.ObjectPropertyRange != null)
            {
                this.ObjectPropertyRange.BuildMock(context, builder);
            }

            if (this.FunctionalObjectProperty != null)
            {
                this.FunctionalObjectProperty.BuildMock(context, builder);
            }

            if (this.InverseFunctionalObjectProperty != null)
            {
                this.InverseFunctionalObjectProperty.BuildMock(context, builder);
            }

            if (this.ReflexiveObjectProperty != null)
            {
                this.ReflexiveObjectProperty.BuildMock(context, builder);
            }

            if (this.IrreflexiveObjectProperty != null)
            {
                this.IrreflexiveObjectProperty.BuildMock(context, builder);
            }

            if (this.SymmetricObjectProperty != null)
            {
                this.SymmetricObjectProperty.BuildMock(context, builder);
            }

            if (this.AsymmetricObjectProperty != null)
            {
                this.AsymmetricObjectProperty.BuildMock(context, builder);
            }

            if (this.TransitiveObjectProperty != null)
            {
                this.TransitiveObjectProperty.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.SubObjectPropertyOf != null)
            {
                this.SubObjectPropertyOf.BuildOther(context, builder);
            }

            if (this.EquivalentObjectProperties != null)
            {
                this.EquivalentObjectProperties.BuildOther(context, builder);
            }

            if (this.DisjointObjectProperties != null)
            {
                this.DisjointObjectProperties.BuildOther(context, builder);
            }

            if (this.InverseObjectProperties != null)
            {
                this.InverseObjectProperties.BuildOther(context, builder);
            }

            if (this.ObjectPropertyDomain != null)
            {
                this.ObjectPropertyDomain.BuildOther(context, builder);
            }

            if (this.ObjectPropertyRange != null)
            {
                this.ObjectPropertyRange.BuildOther(context, builder);
            }

            if (this.FunctionalObjectProperty != null)
            {
                this.FunctionalObjectProperty.BuildOther(context, builder);
            }

            if (this.InverseFunctionalObjectProperty != null)
            {
                this.InverseFunctionalObjectProperty.BuildOther(context, builder);
            }

            if (this.ReflexiveObjectProperty != null)
            {
                this.ReflexiveObjectProperty.BuildOther(context, builder);
            }

            if (this.IrreflexiveObjectProperty != null)
            {
                this.IrreflexiveObjectProperty.BuildOther(context, builder);
            }

            if (this.SymmetricObjectProperty != null)
            {
                this.SymmetricObjectProperty.BuildOther(context, builder);
            }

            if (this.AsymmetricObjectProperty != null)
            {
                this.AsymmetricObjectProperty.BuildOther(context, builder);
            }

            if (this.TransitiveObjectProperty != null)
            {
                this.TransitiveObjectProperty.BuildOther(context, builder);
            }

        }
    }

    public class SubObjectPropertyOf : TokenPair
    {
        public SubObjectPropertyOf()
        {
        }
        public String SUBOBJECTPROPERTYOF
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public SubObjectPropertyExpression SubObjectPropertyExpression
        { get; set; }
        public SuperObjectPropertyExpression SuperObjectPropertyExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.SubObjectPropertyExpression != null)
            {
                this.SubObjectPropertyExpression.Parse(context);
            }

            if (this.SuperObjectPropertyExpression != null)
            {
                this.SuperObjectPropertyExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.SubObjectPropertyExpression != null)
            {
                this.SubObjectPropertyExpression.Wise(context);
            }

            if (this.SuperObjectPropertyExpression != null)
            {
                this.SuperObjectPropertyExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.SubObjectPropertyExpression != null)
            {
                this.SubObjectPropertyExpression.Format(context, builder);
            }

            if (this.SuperObjectPropertyExpression != null)
            {
                this.SuperObjectPropertyExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.SubObjectPropertyExpression != null)
            {
                this.SubObjectPropertyExpression.BuildQuery(context, builder);
            }

            if (this.SuperObjectPropertyExpression != null)
            {
                this.SuperObjectPropertyExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.SubObjectPropertyExpression != null)
            {
                this.SubObjectPropertyExpression.BuildMock(context, builder);
            }

            if (this.SuperObjectPropertyExpression != null)
            {
                this.SuperObjectPropertyExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.SubObjectPropertyExpression != null)
            {
                this.SubObjectPropertyExpression.BuildOther(context, builder);
            }

            if (this.SuperObjectPropertyExpression != null)
            {
                this.SuperObjectPropertyExpression.BuildOther(context, builder);
            }

        }
    }

    public class SubObjectPropertyExpression : TokenPair
    {
        public SubObjectPropertyExpression()
        {
        }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }
        public PropertyExpressionChain PropertyExpressionChain
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

            if (this.PropertyExpressionChain != null)
            {
                this.PropertyExpressionChain.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

            if (this.PropertyExpressionChain != null)
            {
                this.PropertyExpressionChain.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

            if (this.PropertyExpressionChain != null)
            {
                this.PropertyExpressionChain.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

            if (this.PropertyExpressionChain != null)
            {
                this.PropertyExpressionChain.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

            if (this.PropertyExpressionChain != null)
            {
                this.PropertyExpressionChain.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

            if (this.PropertyExpressionChain != null)
            {
                this.PropertyExpressionChain.BuildOther(context, builder);
            }

        }
    }

    public class PropertyExpressionChain : TokenPair
    {
        public PropertyExpressionChain()
        {
            this.ObjectPropertyExpressions = new List<ObjectPropertyExpression>();
        }
        public String OBJECTPROPERTYCHAIN
        { get; set; }
        public List<ObjectPropertyExpression> ObjectPropertyExpressions
        { get; set; }

        public void Parse(SwrlContext context)
        {

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].BuildOther(context, builder);
            }

        }
    }

    public class SuperObjectPropertyExpression : TokenPair
    {
        public SuperObjectPropertyExpression()
        {
        }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

        }
    }

    public class EquivalentObjectProperties : TokenPair
    {
        public EquivalentObjectProperties()
        {
            this.ObjectPropertyExpressions = new List<ObjectPropertyExpression>();
        }
        public String EQUIVALENTOBJECTPROPERTIES
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public List<ObjectPropertyExpression> ObjectPropertyExpressions
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].BuildOther(context, builder);
            }

        }
    }

    public class DisjointObjectProperties : TokenPair
    {
        public DisjointObjectProperties()
        {
            this.ObjectPropertyExpressions = new List<ObjectPropertyExpression>();
        }
        public String DISJOINTOBJECTPROPERTIES
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public List<ObjectPropertyExpression> ObjectPropertyExpressions
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].BuildOther(context, builder);
            }

        }
    }

    public class ObjectPropertyDomain : TokenPair
    {
        public ObjectPropertyDomain()
        {
        }
        public String OBJECTPROPERTYDOMAIN
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }
        public ClassExpression ClassExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildOther(context, builder);
            }

        }
    }

    public class ObjectPropertyRange : TokenPair
    {
        public ObjectPropertyRange()
        {
        }
        public String OBJECTPROPERTYRANGE
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }
        public ClassExpression ClassExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildOther(context, builder);
            }

        }
    }

    public class InverseObjectProperties : TokenPair
    {
        public InverseObjectProperties()
        {
            this.ObjectPropertyExpressions = new List<ObjectPropertyExpression>();
        }
        public String INVERSEOBJECTPROPERTIES
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public List<ObjectPropertyExpression> ObjectPropertyExpressions
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].BuildOther(context, builder);
            }

        }
    }

    public class FunctionalObjectProperty : TokenPair
    {
        public FunctionalObjectProperty()
        {
        }
        public String FUNCTIONALOBJECTPROPERTY
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

        }
    }

    public class InverseFunctionalObjectProperty : TokenPair
    {
        public InverseFunctionalObjectProperty()
        {
        }
        public String INVERSEFUNCTIONALOBJECTPROPERTY
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

        }
    }

    public class ReflexiveObjectProperty : TokenPair
    {
        public ReflexiveObjectProperty()
        {
        }
        public String REFLEXIVEOBJECTPROPERTY
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

        }
    }

    public class IrreflexiveObjectProperty : TokenPair
    {
        public IrreflexiveObjectProperty()
        {
        }
        public String IRREFLEXIVEOBJECTPROPERTY
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

        }
    }

    public class SymmetricObjectProperty : TokenPair
    {
        public SymmetricObjectProperty()
        {
        }
        public String SYMMETRICOBJECTPROPERTY
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

        }
    }

    public class AsymmetricObjectProperty : TokenPair
    {
        public AsymmetricObjectProperty()
        {
        }
        public String ASYMMETRICOBJECTPROPERTY
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

        }
    }

    public class TransitiveObjectProperty : TokenPair
    {
        public TransitiveObjectProperty()
        {
        }
        public String TRANSITIVEOBJECTPROPERTY
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

        }
    }

    public class DataPropertyAxiom : TokenPair
    {
        public DataPropertyAxiom()
        {
        }
        public SubDataPropertyOf SubDataPropertyOf
        { get; set; }
        public EquivalentDataProperties EquivalentDataProperties
        { get; set; }
        public DisjointDataProperties DisjointDataProperties
        { get; set; }
        public DataPropertyDomain DataPropertyDomain
        { get; set; }
        public DataPropertyRange DataPropertyRange
        { get; set; }
        public FunctionalDataProperty FunctionalDataProperty
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.SubDataPropertyOf != null)
            {
                this.SubDataPropertyOf.Parse(context);
            }

            if (this.EquivalentDataProperties != null)
            {
                this.EquivalentDataProperties.Parse(context);
            }

            if (this.DisjointDataProperties != null)
            {
                this.DisjointDataProperties.Parse(context);
            }

            if (this.DataPropertyDomain != null)
            {
                this.DataPropertyDomain.Parse(context);
            }

            if (this.DataPropertyRange != null)
            {
                this.DataPropertyRange.Parse(context);
            }

            if (this.FunctionalDataProperty != null)
            {
                this.FunctionalDataProperty.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.SubDataPropertyOf != null)
            {
                this.SubDataPropertyOf.Wise(context);
            }

            if (this.EquivalentDataProperties != null)
            {
                this.EquivalentDataProperties.Wise(context);
            }

            if (this.DisjointDataProperties != null)
            {
                this.DisjointDataProperties.Wise(context);
            }

            if (this.DataPropertyDomain != null)
            {
                this.DataPropertyDomain.Wise(context);
            }

            if (this.DataPropertyRange != null)
            {
                this.DataPropertyRange.Wise(context);
            }

            if (this.FunctionalDataProperty != null)
            {
                this.FunctionalDataProperty.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.SubDataPropertyOf != null)
            {
                this.SubDataPropertyOf.Format(context, builder);
            }

            if (this.EquivalentDataProperties != null)
            {
                this.EquivalentDataProperties.Format(context, builder);
            }

            if (this.DisjointDataProperties != null)
            {
                this.DisjointDataProperties.Format(context, builder);
            }

            if (this.DataPropertyDomain != null)
            {
                this.DataPropertyDomain.Format(context, builder);
            }

            if (this.DataPropertyRange != null)
            {
                this.DataPropertyRange.Format(context, builder);
            }

            if (this.FunctionalDataProperty != null)
            {
                this.FunctionalDataProperty.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.SubDataPropertyOf != null)
            {
                this.SubDataPropertyOf.BuildQuery(context, builder);
            }

            if (this.EquivalentDataProperties != null)
            {
                this.EquivalentDataProperties.BuildQuery(context, builder);
            }

            if (this.DisjointDataProperties != null)
            {
                this.DisjointDataProperties.BuildQuery(context, builder);
            }

            if (this.DataPropertyDomain != null)
            {
                this.DataPropertyDomain.BuildQuery(context, builder);
            }

            if (this.DataPropertyRange != null)
            {
                this.DataPropertyRange.BuildQuery(context, builder);
            }

            if (this.FunctionalDataProperty != null)
            {
                this.FunctionalDataProperty.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.SubDataPropertyOf != null)
            {
                this.SubDataPropertyOf.BuildMock(context, builder);
            }

            if (this.EquivalentDataProperties != null)
            {
                this.EquivalentDataProperties.BuildMock(context, builder);
            }

            if (this.DisjointDataProperties != null)
            {
                this.DisjointDataProperties.BuildMock(context, builder);
            }

            if (this.DataPropertyDomain != null)
            {
                this.DataPropertyDomain.BuildMock(context, builder);
            }

            if (this.DataPropertyRange != null)
            {
                this.DataPropertyRange.BuildMock(context, builder);
            }

            if (this.FunctionalDataProperty != null)
            {
                this.FunctionalDataProperty.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.SubDataPropertyOf != null)
            {
                this.SubDataPropertyOf.BuildOther(context, builder);
            }

            if (this.EquivalentDataProperties != null)
            {
                this.EquivalentDataProperties.BuildOther(context, builder);
            }

            if (this.DisjointDataProperties != null)
            {
                this.DisjointDataProperties.BuildOther(context, builder);
            }

            if (this.DataPropertyDomain != null)
            {
                this.DataPropertyDomain.BuildOther(context, builder);
            }

            if (this.DataPropertyRange != null)
            {
                this.DataPropertyRange.BuildOther(context, builder);
            }

            if (this.FunctionalDataProperty != null)
            {
                this.FunctionalDataProperty.BuildOther(context, builder);
            }

        }
    }

    public class SubDataPropertyOf : TokenPair
    {
        public SubDataPropertyOf()
        {
        }
        public String SUBDATAPROPERTYOF
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public SubDataPropertyExpression SubDataPropertyExpression
        { get; set; }
        public SuperDataPropertyExpression SuperDataPropertyExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.SubDataPropertyExpression != null)
            {
                this.SubDataPropertyExpression.Parse(context);
            }

            if (this.SuperDataPropertyExpression != null)
            {
                this.SuperDataPropertyExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.SubDataPropertyExpression != null)
            {
                this.SubDataPropertyExpression.Wise(context);
            }

            if (this.SuperDataPropertyExpression != null)
            {
                this.SuperDataPropertyExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.SubDataPropertyExpression != null)
            {
                this.SubDataPropertyExpression.Format(context, builder);
            }

            if (this.SuperDataPropertyExpression != null)
            {
                this.SuperDataPropertyExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.SubDataPropertyExpression != null)
            {
                this.SubDataPropertyExpression.BuildQuery(context, builder);
            }

            if (this.SuperDataPropertyExpression != null)
            {
                this.SuperDataPropertyExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.SubDataPropertyExpression != null)
            {
                this.SubDataPropertyExpression.BuildMock(context, builder);
            }

            if (this.SuperDataPropertyExpression != null)
            {
                this.SuperDataPropertyExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.SubDataPropertyExpression != null)
            {
                this.SubDataPropertyExpression.BuildOther(context, builder);
            }

            if (this.SuperDataPropertyExpression != null)
            {
                this.SuperDataPropertyExpression.BuildOther(context, builder);
            }

        }
    }

    public class SubDataPropertyExpression : TokenPair
    {
        public SubDataPropertyExpression()
        {
        }
        public DataPropertyExpression DataPropertyExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildOther(context, builder);
            }

        }
    }

    public class SuperDataPropertyExpression : TokenPair
    {
        public SuperDataPropertyExpression()
        {
        }
        public DataPropertyExpression DataPropertyExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildOther(context, builder);
            }

        }
    }

    public class EquivalentDataProperties : TokenPair
    {
        public EquivalentDataProperties()
        {
            this.DataPropertyExpressions = new List<DataPropertyExpression>();
        }
        public String EQUIVALENTDATAPROPERTIES
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public List<DataPropertyExpression> DataPropertyExpressions
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].BuildOther(context, builder);
            }

        }
    }

    public class DisjointDataProperties : TokenPair
    {
        public DisjointDataProperties()
        {
            this.DataPropertyExpressions = new List<DataPropertyExpression>();
        }
        public String DISJOINTDATAPROPERTIES
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public List<DataPropertyExpression> DataPropertyExpressions
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].BuildOther(context, builder);
            }

        }
    }

    public class DataPropertyDomain : TokenPair
    {
        public DataPropertyDomain()
        {
        }
        public String DATAPROPERTYDOMAIN
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public DataPropertyExpression DataPropertyExpression
        { get; set; }
        public ClassExpression ClassExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Parse(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Wise(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Format(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildQuery(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildMock(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildOther(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildOther(context, builder);
            }

        }
    }

    public class DataPropertyRange : TokenPair
    {
        public DataPropertyRange()
        {
        }
        public String DATAPROPERTYRANGE
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public DataPropertyExpression DataPropertyExpression
        { get; set; }
        public DataRange DataRange
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Parse(context);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Wise(context);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Format(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildQuery(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildMock(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildOther(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildOther(context, builder);
            }

        }
    }

    public class FunctionalDataProperty : TokenPair
    {
        public FunctionalDataProperty()
        {
        }
        public String FUNCTIONALDATAPROPERTY
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public DataPropertyExpression DataPropertyExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildOther(context, builder);
            }

        }
    }

    public class DatatypeDefinition : TokenPair
    {
        public DatatypeDefinition()
        {
        }
        public String DATATYPEDEFINITION
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public Datatype Datatype
        { get; set; }
        public DataRange DataRange
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.Datatype != null)
            {
                this.Datatype.Parse(context);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.Datatype != null)
            {
                this.Datatype.Wise(context);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.Datatype != null)
            {
                this.Datatype.Format(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.Datatype != null)
            {
                this.Datatype.BuildQuery(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.Datatype != null)
            {
                this.Datatype.BuildMock(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.Datatype != null)
            {
                this.Datatype.BuildOther(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildOther(context, builder);
            }

        }
    }

    public class HasKey : TokenPair
    {
        public HasKey()
        {
            this.ObjectPropertyExpressions = new List<ObjectPropertyExpression>();
            this.DataPropertyExpressions = new List<DataPropertyExpression>();
        }
        public String HASKEY
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public ClassExpression ClassExpression
        { get; set; }
        public List<ObjectPropertyExpression> ObjectPropertyExpressions
        { get; set; }
        public List<DataPropertyExpression> DataPropertyExpressions
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Parse(context);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].Parse(context);
            }

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Wise(context);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].Wise(context);
            }

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Format(context, builder);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].Format(context, builder);
            }

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].BuildQuery(context, builder);
            }

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildMock(context, builder);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].BuildMock(context, builder);
            }

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildOther(context, builder);
            }

            for (int i = 0; i < this.ObjectPropertyExpressions.Count(); i++)
            {
                this.ObjectPropertyExpressions[i].BuildOther(context, builder);
            }

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].BuildOther(context, builder);
            }

        }
    }

    public class Atom : TokenPair
    {
        public Atom()
        {
            this.IArgs = new List<IArg>();
            this.DArgs = new List<DArg>();
        }
        public String CLASSATOM
        { get; set; }
        public ClassExpression ClassExpression
        { get; set; }
        public List<IArg> IArgs
        { get; set; }
        public String DATARANGEATOM
        { get; set; }
        public DataRange DataRange
        { get; set; }
        public List<DArg> DArgs
        { get; set; }
        public String OBJECTPROPERTYATOM
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }
        public String DATAPROPERTYATOM
        { get; set; }
        public DataProperty DataProperty
        { get; set; }
        public String BUILTINATOM
        { get; set; }
        public IRI IRI
        { get; set; }
        public String SAMEINDIVIDUALATOM
        { get; set; }
        public String DIFFERENTINDIVIDUALSATOM
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Parse(context);
            }

            for (int i = 0; i < this.IArgs.Count(); i++)
            {
                this.IArgs[i].Parse(context);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Parse(context);
            }

            for (int i = 0; i < this.DArgs.Count(); i++)
            {
                this.DArgs[i].Parse(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

            if (this.DataProperty != null)
            {
                this.DataProperty.Parse(context);
            }

            if (this.IRI != null)
            {
                this.IRI.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Wise(context);
            }

            for (int i = 0; i < this.IArgs.Count(); i++)
            {
                this.IArgs[i].Wise(context);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Wise(context);
            }

            for (int i = 0; i < this.DArgs.Count(); i++)
            {
                this.DArgs[i].Wise(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

            if (this.DataProperty != null)
            {
                this.DataProperty.Wise(context);
            }

            if (this.IRI != null)
            {
                this.IRI.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Format(context, builder);
            }

            for (int i = 0; i < this.IArgs.Count(); i++)
            {
                this.IArgs[i].Format(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Format(context, builder);
            }

            for (int i = 0; i < this.DArgs.Count(); i++)
            {
                this.DArgs[i].Format(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

            if (this.DataProperty != null)
            {
                this.DataProperty.Format(context, builder);
            }

            if (this.IRI != null)
            {
                this.IRI.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.IArgs.Count(); i++)
            {
                this.IArgs[i].BuildQuery(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.DArgs.Count(); i++)
            {
                this.DArgs[i].BuildQuery(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

            if (this.DataProperty != null)
            {
                this.DataProperty.BuildQuery(context, builder);
            }

            if (this.IRI != null)
            {
                this.IRI.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildMock(context, builder);
            }

            for (int i = 0; i < this.IArgs.Count(); i++)
            {
                this.IArgs[i].BuildMock(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildMock(context, builder);
            }

            for (int i = 0; i < this.DArgs.Count(); i++)
            {
                this.DArgs[i].BuildMock(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

            if (this.DataProperty != null)
            {
                this.DataProperty.BuildMock(context, builder);
            }

            if (this.IRI != null)
            {
                this.IRI.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildOther(context, builder);
            }

            for (int i = 0; i < this.IArgs.Count(); i++)
            {
                this.IArgs[i].BuildOther(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildOther(context, builder);
            }

            for (int i = 0; i < this.DArgs.Count(); i++)
            {
                this.DArgs[i].BuildOther(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

            if (this.DataProperty != null)
            {
                this.DataProperty.BuildOther(context, builder);
            }

            if (this.IRI != null)
            {
                this.IRI.BuildOther(context, builder);
            }

        }
    }

    public class IArg : TokenPair
    {
        public IArg()
        {
        }
        public String VARIABLE
        { get; set; }
        public IRI IRI
        { get; set; }
        public Individual Individual
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Parse(context);
            }

            if (this.Individual != null)
            {
                this.Individual.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Wise(context);
            }

            if (this.Individual != null)
            {
                this.Individual.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.Format(context, builder);
            }

            if (this.Individual != null)
            {
                this.Individual.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildQuery(context, builder);
            }

            if (this.Individual != null)
            {
                this.Individual.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildMock(context, builder);
            }

            if (this.Individual != null)
            {
                this.Individual.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildOther(context, builder);
            }

            if (this.Individual != null)
            {
                this.Individual.BuildOther(context, builder);
            }

        }
    }

    public class DArg : TokenPair
    {
        public DArg()
        {
        }
        public String VARIABLE
        { get; set; }
        public IRI IRI
        { get; set; }
        public Literal Literal
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Parse(context);
            }

            if (this.Literal != null)
            {
                this.Literal.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Wise(context);
            }

            if (this.Literal != null)
            {
                this.Literal.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.Format(context, builder);
            }

            if (this.Literal != null)
            {
                this.Literal.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildQuery(context, builder);
            }

            if (this.Literal != null)
            {
                this.Literal.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildMock(context, builder);
            }

            if (this.Literal != null)
            {
                this.Literal.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildOther(context, builder);
            }

            if (this.Literal != null)
            {
                this.Literal.BuildOther(context, builder);
            }

        }
    }

    public class DGRule : TokenPair
    {
        public DGRule()
        {
            this.Annotations = new List<Annotation>();
            this.DGAtoms = new List<DGAtom>();
        }
        public String DESCRIPTIONGRAPHRULE
        { get; set; }
        public List<Annotation> Annotations
        { get; set; }
        public String BODY
        { get; set; }
        public List<DGAtom> DGAtoms
        { get; set; }
        public String HEAD
        { get; set; }

        public void Parse(SwrlContext context)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].Parse(context);
            }

            for (int i = 0; i < this.DGAtoms.Count(); i++)
            {
                this.DGAtoms[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].Wise(context);
            }

            for (int i = 0; i < this.DGAtoms.Count(); i++)
            {
                this.DGAtoms[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].Format(context, builder);
            }

            for (int i = 0; i < this.DGAtoms.Count(); i++)
            {
                this.DGAtoms[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].BuildQuery(context, builder);
            }

            for (int i = 0; i < this.DGAtoms.Count(); i++)
            {
                this.DGAtoms[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].BuildMock(context, builder);
            }

            for (int i = 0; i < this.DGAtoms.Count(); i++)
            {
                this.DGAtoms[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].BuildOther(context, builder);
            }

            for (int i = 0; i < this.DGAtoms.Count(); i++)
            {
                this.DGAtoms[i].BuildOther(context, builder);
            }

        }
    }

    public class DGAtom : TokenPair
    {
        public DGAtom()
        {
            this.IArgs = new List<IArg>();
        }
        public String CLASSATOM
        { get; set; }
        public ClassExpression ClassExpression
        { get; set; }
        public List<IArg> IArgs
        { get; set; }
        public String OBJECTPROPERTYATOM
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Parse(context);
            }

            for (int i = 0; i < this.IArgs.Count(); i++)
            {
                this.IArgs[i].Parse(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Wise(context);
            }

            for (int i = 0; i < this.IArgs.Count(); i++)
            {
                this.IArgs[i].Wise(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Format(context, builder);
            }

            for (int i = 0; i < this.IArgs.Count(); i++)
            {
                this.IArgs[i].Format(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.IArgs.Count(); i++)
            {
                this.IArgs[i].BuildQuery(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildMock(context, builder);
            }

            for (int i = 0; i < this.IArgs.Count(); i++)
            {
                this.IArgs[i].BuildMock(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildOther(context, builder);
            }

            for (int i = 0; i < this.IArgs.Count(); i++)
            {
                this.IArgs[i].BuildOther(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

        }
    }

    public class DGAxiom : TokenPair
    {
        public DGAxiom()
        {
            this.Annotations = new List<Annotation>();
        }
        public String DESCRIPTIONGRAPH
        { get; set; }
        public List<Annotation> Annotations
        { get; set; }
        public DGNodes DGNodes
        { get; set; }
        public DGEdges DGEdges
        { get; set; }
        public MainClasses MainClasses
        { get; set; }

        public void Parse(SwrlContext context)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].Parse(context);
            }

            if (this.DGNodes != null)
            {
                this.DGNodes.Parse(context);
            }

            if (this.DGEdges != null)
            {
                this.DGEdges.Parse(context);
            }

            if (this.MainClasses != null)
            {
                this.MainClasses.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].Wise(context);
            }

            if (this.DGNodes != null)
            {
                this.DGNodes.Wise(context);
            }

            if (this.DGEdges != null)
            {
                this.DGEdges.Wise(context);
            }

            if (this.MainClasses != null)
            {
                this.MainClasses.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].Format(context, builder);
            }

            if (this.DGNodes != null)
            {
                this.DGNodes.Format(context, builder);
            }

            if (this.DGEdges != null)
            {
                this.DGEdges.Format(context, builder);
            }

            if (this.MainClasses != null)
            {
                this.MainClasses.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].BuildQuery(context, builder);
            }

            if (this.DGNodes != null)
            {
                this.DGNodes.BuildQuery(context, builder);
            }

            if (this.DGEdges != null)
            {
                this.DGEdges.BuildQuery(context, builder);
            }

            if (this.MainClasses != null)
            {
                this.MainClasses.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].BuildMock(context, builder);
            }

            if (this.DGNodes != null)
            {
                this.DGNodes.BuildMock(context, builder);
            }

            if (this.DGEdges != null)
            {
                this.DGEdges.BuildMock(context, builder);
            }

            if (this.MainClasses != null)
            {
                this.MainClasses.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].BuildOther(context, builder);
            }

            if (this.DGNodes != null)
            {
                this.DGNodes.BuildOther(context, builder);
            }

            if (this.DGEdges != null)
            {
                this.DGEdges.BuildOther(context, builder);
            }

            if (this.MainClasses != null)
            {
                this.MainClasses.BuildOther(context, builder);
            }

        }
    }

    public class DGNodes : TokenPair
    {
        public DGNodes()
        {
            this.NodeAssertions = new List<NodeAssertion>();
        }
        public String NODES
        { get; set; }
        public List<NodeAssertion> NodeAssertions
        { get; set; }

        public void Parse(SwrlContext context)
        {

            for (int i = 0; i < this.NodeAssertions.Count(); i++)
            {
                this.NodeAssertions[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            for (int i = 0; i < this.NodeAssertions.Count(); i++)
            {
                this.NodeAssertions[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.NodeAssertions.Count(); i++)
            {
                this.NodeAssertions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.NodeAssertions.Count(); i++)
            {
                this.NodeAssertions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.NodeAssertions.Count(); i++)
            {
                this.NodeAssertions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.NodeAssertions.Count(); i++)
            {
                this.NodeAssertions[i].BuildOther(context, builder);
            }

        }
    }

    public class NodeAssertion : TokenPair
    {
        public NodeAssertion()
        {
        }
        public String NODEASSERTION
        { get; set; }
        public ClassN ClassN
        { get; set; }
        public DGNode DGNode
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ClassN != null)
            {
                this.ClassN.Parse(context);
            }

            if (this.DGNode != null)
            {
                this.DGNode.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ClassN != null)
            {
                this.ClassN.Wise(context);
            }

            if (this.DGNode != null)
            {
                this.DGNode.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassN != null)
            {
                this.ClassN.Format(context, builder);
            }

            if (this.DGNode != null)
            {
                this.DGNode.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassN != null)
            {
                this.ClassN.BuildQuery(context, builder);
            }

            if (this.DGNode != null)
            {
                this.DGNode.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassN != null)
            {
                this.ClassN.BuildMock(context, builder);
            }

            if (this.DGNode != null)
            {
                this.DGNode.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassN != null)
            {
                this.ClassN.BuildOther(context, builder);
            }

            if (this.DGNode != null)
            {
                this.DGNode.BuildOther(context, builder);
            }

        }
    }

    public class DGNode : TokenPair
    {
        public DGNode()
        {
        }
        public IRI IRI
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildOther(context, builder);
            }

        }
    }

    public class DGEdges : TokenPair
    {
        public DGEdges()
        {
            this.EdgeAssertions = new List<EdgeAssertion>();
        }
        public String EDGES
        { get; set; }
        public List<EdgeAssertion> EdgeAssertions
        { get; set; }

        public void Parse(SwrlContext context)
        {

            for (int i = 0; i < this.EdgeAssertions.Count(); i++)
            {
                this.EdgeAssertions[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            for (int i = 0; i < this.EdgeAssertions.Count(); i++)
            {
                this.EdgeAssertions[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.EdgeAssertions.Count(); i++)
            {
                this.EdgeAssertions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.EdgeAssertions.Count(); i++)
            {
                this.EdgeAssertions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.EdgeAssertions.Count(); i++)
            {
                this.EdgeAssertions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.EdgeAssertions.Count(); i++)
            {
                this.EdgeAssertions[i].BuildOther(context, builder);
            }

        }
    }

    public class EdgeAssertion : TokenPair
    {
        public EdgeAssertion()
        {
            this.DGNodes = new List<DGNode>();
        }
        public String EDGEASSERTION
        { get; set; }
        public ObjectProperty ObjectProperty
        { get; set; }
        public List<DGNode> DGNodes
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.Parse(context);
            }

            for (int i = 0; i < this.DGNodes.Count(); i++)
            {
                this.DGNodes[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.Wise(context);
            }

            for (int i = 0; i < this.DGNodes.Count(); i++)
            {
                this.DGNodes[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.Format(context, builder);
            }

            for (int i = 0; i < this.DGNodes.Count(); i++)
            {
                this.DGNodes[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.DGNodes.Count(); i++)
            {
                this.DGNodes[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.BuildMock(context, builder);
            }

            for (int i = 0; i < this.DGNodes.Count(); i++)
            {
                this.DGNodes[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.BuildOther(context, builder);
            }

            for (int i = 0; i < this.DGNodes.Count(); i++)
            {
                this.DGNodes[i].BuildOther(context, builder);
            }

        }
    }

    public class MainClasses : TokenPair
    {
        public MainClasses()
        {
            this.ClassNs = new List<ClassN>();
        }
        public String MAINCLASSES
        { get; set; }
        public List<ClassN> ClassNs
        { get; set; }

        public void Parse(SwrlContext context)
        {

            for (int i = 0; i < this.ClassNs.Count(); i++)
            {
                this.ClassNs[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            for (int i = 0; i < this.ClassNs.Count(); i++)
            {
                this.ClassNs[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ClassNs.Count(); i++)
            {
                this.ClassNs[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ClassNs.Count(); i++)
            {
                this.ClassNs[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ClassNs.Count(); i++)
            {
                this.ClassNs[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ClassNs.Count(); i++)
            {
                this.ClassNs[i].BuildOther(context, builder);
            }

        }
    }

    public class AnnotationSubject : TokenPair
    {
        public AnnotationSubject()
        {
        }
        public IRI IRI
        { get; set; }
        public AnonymousIndividual AnonymousIndividual
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Parse(context);
            }

            if (this.AnonymousIndividual != null)
            {
                this.AnonymousIndividual.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Wise(context);
            }

            if (this.AnonymousIndividual != null)
            {
                this.AnonymousIndividual.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.Format(context, builder);
            }

            if (this.AnonymousIndividual != null)
            {
                this.AnonymousIndividual.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildQuery(context, builder);
            }

            if (this.AnonymousIndividual != null)
            {
                this.AnonymousIndividual.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildMock(context, builder);
            }

            if (this.AnonymousIndividual != null)
            {
                this.AnonymousIndividual.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildOther(context, builder);
            }

            if (this.AnonymousIndividual != null)
            {
                this.AnonymousIndividual.BuildOther(context, builder);
            }

        }
    }

    public class AnnotationValue : TokenPair
    {
        public AnnotationValue()
        {
        }
        public AnonymousIndividual AnonymousIndividual
        { get; set; }
        public IRI IRI
        { get; set; }
        public Literal Literal
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AnonymousIndividual != null)
            {
                this.AnonymousIndividual.Parse(context);
            }

            if (this.IRI != null)
            {
                this.IRI.Parse(context);
            }

            if (this.Literal != null)
            {
                this.Literal.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AnonymousIndividual != null)
            {
                this.AnonymousIndividual.Wise(context);
            }

            if (this.IRI != null)
            {
                this.IRI.Wise(context);
            }

            if (this.Literal != null)
            {
                this.Literal.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnonymousIndividual != null)
            {
                this.AnonymousIndividual.Format(context, builder);
            }

            if (this.IRI != null)
            {
                this.IRI.Format(context, builder);
            }

            if (this.Literal != null)
            {
                this.Literal.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnonymousIndividual != null)
            {
                this.AnonymousIndividual.BuildQuery(context, builder);
            }

            if (this.IRI != null)
            {
                this.IRI.BuildQuery(context, builder);
            }

            if (this.Literal != null)
            {
                this.Literal.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnonymousIndividual != null)
            {
                this.AnonymousIndividual.BuildMock(context, builder);
            }

            if (this.IRI != null)
            {
                this.IRI.BuildMock(context, builder);
            }

            if (this.Literal != null)
            {
                this.Literal.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnonymousIndividual != null)
            {
                this.AnonymousIndividual.BuildOther(context, builder);
            }

            if (this.IRI != null)
            {
                this.IRI.BuildOther(context, builder);
            }

            if (this.Literal != null)
            {
                this.Literal.BuildOther(context, builder);
            }

        }
    }

    public class AxiomAnnotations : TokenPair
    {
        public AxiomAnnotations()
        {
            this.Annotations = new List<Annotation>();
        }
        public List<Annotation> Annotations
        { get; set; }

        public void Parse(SwrlContext context)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].BuildOther(context, builder);
            }

        }
    }

    public class Annotation : TokenPair
    {
        public Annotation()
        {
        }
        public String ANNOTATION
        { get; set; }
        public AnnotationAnnotations AnnotationAnnotations
        { get; set; }
        public AnnotationProperty AnnotationProperty
        { get; set; }
        public AnnotationValue AnnotationValue
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AnnotationAnnotations != null)
            {
                this.AnnotationAnnotations.Parse(context);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Parse(context);
            }

            if (this.AnnotationValue != null)
            {
                this.AnnotationValue.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AnnotationAnnotations != null)
            {
                this.AnnotationAnnotations.Wise(context);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Wise(context);
            }

            if (this.AnnotationValue != null)
            {
                this.AnnotationValue.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnnotationAnnotations != null)
            {
                this.AnnotationAnnotations.Format(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Format(context, builder);
            }

            if (this.AnnotationValue != null)
            {
                this.AnnotationValue.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnnotationAnnotations != null)
            {
                this.AnnotationAnnotations.BuildQuery(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildQuery(context, builder);
            }

            if (this.AnnotationValue != null)
            {
                this.AnnotationValue.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnnotationAnnotations != null)
            {
                this.AnnotationAnnotations.BuildMock(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildMock(context, builder);
            }

            if (this.AnnotationValue != null)
            {
                this.AnnotationValue.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnnotationAnnotations != null)
            {
                this.AnnotationAnnotations.BuildOther(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildOther(context, builder);
            }

            if (this.AnnotationValue != null)
            {
                this.AnnotationValue.BuildOther(context, builder);
            }

        }
    }

    public class AnnotationAnnotations : TokenPair
    {
        public AnnotationAnnotations()
        {
            this.Annotations = new List<Annotation>();
        }
        public List<Annotation> Annotations
        { get; set; }

        public void Parse(SwrlContext context)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Annotations.Count(); i++)
            {
                this.Annotations[i].BuildOther(context, builder);
            }

        }
    }

    public class AnnotationProperty : TokenPair
    {
        public AnnotationProperty()
        {
        }
        public IRI IRI
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildOther(context, builder);
            }

        }
    }

    public class AnnotationAxiom : TokenPair
    {
        public AnnotationAxiom()
        {
        }
        public AnnotationAssertion AnnotationAssertion
        { get; set; }
        public SubAnnotationPropertyOf SubAnnotationPropertyOf
        { get; set; }
        public AnnotationPropertyDomain AnnotationPropertyDomain
        { get; set; }
        public AnnotationPropertyRange AnnotationPropertyRange
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AnnotationAssertion != null)
            {
                this.AnnotationAssertion.Parse(context);
            }

            if (this.SubAnnotationPropertyOf != null)
            {
                this.SubAnnotationPropertyOf.Parse(context);
            }

            if (this.AnnotationPropertyDomain != null)
            {
                this.AnnotationPropertyDomain.Parse(context);
            }

            if (this.AnnotationPropertyRange != null)
            {
                this.AnnotationPropertyRange.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AnnotationAssertion != null)
            {
                this.AnnotationAssertion.Wise(context);
            }

            if (this.SubAnnotationPropertyOf != null)
            {
                this.SubAnnotationPropertyOf.Wise(context);
            }

            if (this.AnnotationPropertyDomain != null)
            {
                this.AnnotationPropertyDomain.Wise(context);
            }

            if (this.AnnotationPropertyRange != null)
            {
                this.AnnotationPropertyRange.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnnotationAssertion != null)
            {
                this.AnnotationAssertion.Format(context, builder);
            }

            if (this.SubAnnotationPropertyOf != null)
            {
                this.SubAnnotationPropertyOf.Format(context, builder);
            }

            if (this.AnnotationPropertyDomain != null)
            {
                this.AnnotationPropertyDomain.Format(context, builder);
            }

            if (this.AnnotationPropertyRange != null)
            {
                this.AnnotationPropertyRange.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnnotationAssertion != null)
            {
                this.AnnotationAssertion.BuildQuery(context, builder);
            }

            if (this.SubAnnotationPropertyOf != null)
            {
                this.SubAnnotationPropertyOf.BuildQuery(context, builder);
            }

            if (this.AnnotationPropertyDomain != null)
            {
                this.AnnotationPropertyDomain.BuildQuery(context, builder);
            }

            if (this.AnnotationPropertyRange != null)
            {
                this.AnnotationPropertyRange.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnnotationAssertion != null)
            {
                this.AnnotationAssertion.BuildMock(context, builder);
            }

            if (this.SubAnnotationPropertyOf != null)
            {
                this.SubAnnotationPropertyOf.BuildMock(context, builder);
            }

            if (this.AnnotationPropertyDomain != null)
            {
                this.AnnotationPropertyDomain.BuildMock(context, builder);
            }

            if (this.AnnotationPropertyRange != null)
            {
                this.AnnotationPropertyRange.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnnotationAssertion != null)
            {
                this.AnnotationAssertion.BuildOther(context, builder);
            }

            if (this.SubAnnotationPropertyOf != null)
            {
                this.SubAnnotationPropertyOf.BuildOther(context, builder);
            }

            if (this.AnnotationPropertyDomain != null)
            {
                this.AnnotationPropertyDomain.BuildOther(context, builder);
            }

            if (this.AnnotationPropertyRange != null)
            {
                this.AnnotationPropertyRange.BuildOther(context, builder);
            }

        }
    }

    public class AnnotationAssertion : TokenPair
    {
        public AnnotationAssertion()
        {
        }
        public String ANNOTATIONASSERTION
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public AnnotationProperty AnnotationProperty
        { get; set; }
        public AnnotationSubject AnnotationSubject
        { get; set; }
        public AnnotationValue AnnotationValue
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Parse(context);
            }

            if (this.AnnotationSubject != null)
            {
                this.AnnotationSubject.Parse(context);
            }

            if (this.AnnotationValue != null)
            {
                this.AnnotationValue.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Wise(context);
            }

            if (this.AnnotationSubject != null)
            {
                this.AnnotationSubject.Wise(context);
            }

            if (this.AnnotationValue != null)
            {
                this.AnnotationValue.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Format(context, builder);
            }

            if (this.AnnotationSubject != null)
            {
                this.AnnotationSubject.Format(context, builder);
            }

            if (this.AnnotationValue != null)
            {
                this.AnnotationValue.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildQuery(context, builder);
            }

            if (this.AnnotationSubject != null)
            {
                this.AnnotationSubject.BuildQuery(context, builder);
            }

            if (this.AnnotationValue != null)
            {
                this.AnnotationValue.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildMock(context, builder);
            }

            if (this.AnnotationSubject != null)
            {
                this.AnnotationSubject.BuildMock(context, builder);
            }

            if (this.AnnotationValue != null)
            {
                this.AnnotationValue.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildOther(context, builder);
            }

            if (this.AnnotationSubject != null)
            {
                this.AnnotationSubject.BuildOther(context, builder);
            }

            if (this.AnnotationValue != null)
            {
                this.AnnotationValue.BuildOther(context, builder);
            }

        }
    }

    public class SubAnnotationPropertyOf : TokenPair
    {
        public SubAnnotationPropertyOf()
        {
        }
        public String SUBANNOTATIONPROPERTYOF
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public SubAnnotationProperty SubAnnotationProperty
        { get; set; }
        public SuperAnnotationProperty SuperAnnotationProperty
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.SubAnnotationProperty != null)
            {
                this.SubAnnotationProperty.Parse(context);
            }

            if (this.SuperAnnotationProperty != null)
            {
                this.SuperAnnotationProperty.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.SubAnnotationProperty != null)
            {
                this.SubAnnotationProperty.Wise(context);
            }

            if (this.SuperAnnotationProperty != null)
            {
                this.SuperAnnotationProperty.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.SubAnnotationProperty != null)
            {
                this.SubAnnotationProperty.Format(context, builder);
            }

            if (this.SuperAnnotationProperty != null)
            {
                this.SuperAnnotationProperty.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.SubAnnotationProperty != null)
            {
                this.SubAnnotationProperty.BuildQuery(context, builder);
            }

            if (this.SuperAnnotationProperty != null)
            {
                this.SuperAnnotationProperty.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.SubAnnotationProperty != null)
            {
                this.SubAnnotationProperty.BuildMock(context, builder);
            }

            if (this.SuperAnnotationProperty != null)
            {
                this.SuperAnnotationProperty.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.SubAnnotationProperty != null)
            {
                this.SubAnnotationProperty.BuildOther(context, builder);
            }

            if (this.SuperAnnotationProperty != null)
            {
                this.SuperAnnotationProperty.BuildOther(context, builder);
            }

        }
    }

    public class SubAnnotationProperty : TokenPair
    {
        public SubAnnotationProperty()
        {
        }
        public AnnotationProperty AnnotationProperty
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildOther(context, builder);
            }

        }
    }

    public class SuperAnnotationProperty : TokenPair
    {
        public SuperAnnotationProperty()
        {
        }
        public AnnotationProperty AnnotationProperty
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildOther(context, builder);
            }

        }
    }

    public class AnnotationPropertyDomain : TokenPair
    {
        public AnnotationPropertyDomain()
        {
        }
        public String ANNOTATIONPROPERTYDOMAIN
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public AnnotationProperty AnnotationProperty
        { get; set; }
        public IRI IRI
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Parse(context);
            }

            if (this.IRI != null)
            {
                this.IRI.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Wise(context);
            }

            if (this.IRI != null)
            {
                this.IRI.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Format(context, builder);
            }

            if (this.IRI != null)
            {
                this.IRI.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildQuery(context, builder);
            }

            if (this.IRI != null)
            {
                this.IRI.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildMock(context, builder);
            }

            if (this.IRI != null)
            {
                this.IRI.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildOther(context, builder);
            }

            if (this.IRI != null)
            {
                this.IRI.BuildOther(context, builder);
            }

        }
    }

    public class AnnotationPropertyRange : TokenPair
    {
        public AnnotationPropertyRange()
        {
        }
        public String ANNOTATIONPROPERTYRANGE
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public AnnotationProperty AnnotationProperty
        { get; set; }
        public IRI IRI
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Parse(context);
            }

            if (this.IRI != null)
            {
                this.IRI.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Wise(context);
            }

            if (this.IRI != null)
            {
                this.IRI.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.Format(context, builder);
            }

            if (this.IRI != null)
            {
                this.IRI.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildQuery(context, builder);
            }

            if (this.IRI != null)
            {
                this.IRI.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildMock(context, builder);
            }

            if (this.IRI != null)
            {
                this.IRI.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.AnnotationProperty != null)
            {
                this.AnnotationProperty.BuildOther(context, builder);
            }

            if (this.IRI != null)
            {
                this.IRI.BuildOther(context, builder);
            }

        }
    }

    public class ClassExpression : TokenPair
    {
        public ClassExpression()
        {
        }
        public ClassN ClassN
        { get; set; }
        public ObjectIntersectionOf ObjectIntersectionOf
        { get; set; }
        public ObjectUnionOf ObjectUnionOf
        { get; set; }
        public ObjectComplementOf ObjectComplementOf
        { get; set; }
        public ObjectOneOf ObjectOneOf
        { get; set; }
        public ObjectSomeValuesFrom ObjectSomeValuesFrom
        { get; set; }
        public ObjectAllValuesFrom ObjectAllValuesFrom
        { get; set; }
        public ObjectHasValue ObjectHasValue
        { get; set; }
        public ObjectHasSelf ObjectHasSelf
        { get; set; }
        public ObjectMinCardinality ObjectMinCardinality
        { get; set; }
        public ObjectMaxCardinality ObjectMaxCardinality
        { get; set; }
        public ObjectExactCardinality ObjectExactCardinality
        { get; set; }
        public DataSomeValuesFrom DataSomeValuesFrom
        { get; set; }
        public DataAllValuesFrom DataAllValuesFrom
        { get; set; }
        public DataHasValue DataHasValue
        { get; set; }
        public DataMinCardinality DataMinCardinality
        { get; set; }
        public DataMaxCardinality DataMaxCardinality
        { get; set; }
        public DataExactCardinality DataExactCardinality
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ClassN != null)
            {
                this.ClassN.Parse(context);
            }

            if (this.ObjectIntersectionOf != null)
            {
                this.ObjectIntersectionOf.Parse(context);
            }

            if (this.ObjectUnionOf != null)
            {
                this.ObjectUnionOf.Parse(context);
            }

            if (this.ObjectComplementOf != null)
            {
                this.ObjectComplementOf.Parse(context);
            }

            if (this.ObjectOneOf != null)
            {
                this.ObjectOneOf.Parse(context);
            }

            if (this.ObjectSomeValuesFrom != null)
            {
                this.ObjectSomeValuesFrom.Parse(context);
            }

            if (this.ObjectAllValuesFrom != null)
            {
                this.ObjectAllValuesFrom.Parse(context);
            }

            if (this.ObjectHasValue != null)
            {
                this.ObjectHasValue.Parse(context);
            }

            if (this.ObjectHasSelf != null)
            {
                this.ObjectHasSelf.Parse(context);
            }

            if (this.ObjectMinCardinality != null)
            {
                this.ObjectMinCardinality.Parse(context);
            }

            if (this.ObjectMaxCardinality != null)
            {
                this.ObjectMaxCardinality.Parse(context);
            }

            if (this.ObjectExactCardinality != null)
            {
                this.ObjectExactCardinality.Parse(context);
            }

            if (this.DataSomeValuesFrom != null)
            {
                this.DataSomeValuesFrom.Parse(context);
            }

            if (this.DataAllValuesFrom != null)
            {
                this.DataAllValuesFrom.Parse(context);
            }

            if (this.DataHasValue != null)
            {
                this.DataHasValue.Parse(context);
            }

            if (this.DataMinCardinality != null)
            {
                this.DataMinCardinality.Parse(context);
            }

            if (this.DataMaxCardinality != null)
            {
                this.DataMaxCardinality.Parse(context);
            }

            if (this.DataExactCardinality != null)
            {
                this.DataExactCardinality.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ClassN != null)
            {
                this.ClassN.Wise(context);
            }

            if (this.ObjectIntersectionOf != null)
            {
                this.ObjectIntersectionOf.Wise(context);
            }

            if (this.ObjectUnionOf != null)
            {
                this.ObjectUnionOf.Wise(context);
            }

            if (this.ObjectComplementOf != null)
            {
                this.ObjectComplementOf.Wise(context);
            }

            if (this.ObjectOneOf != null)
            {
                this.ObjectOneOf.Wise(context);
            }

            if (this.ObjectSomeValuesFrom != null)
            {
                this.ObjectSomeValuesFrom.Wise(context);
            }

            if (this.ObjectAllValuesFrom != null)
            {
                this.ObjectAllValuesFrom.Wise(context);
            }

            if (this.ObjectHasValue != null)
            {
                this.ObjectHasValue.Wise(context);
            }

            if (this.ObjectHasSelf != null)
            {
                this.ObjectHasSelf.Wise(context);
            }

            if (this.ObjectMinCardinality != null)
            {
                this.ObjectMinCardinality.Wise(context);
            }

            if (this.ObjectMaxCardinality != null)
            {
                this.ObjectMaxCardinality.Wise(context);
            }

            if (this.ObjectExactCardinality != null)
            {
                this.ObjectExactCardinality.Wise(context);
            }

            if (this.DataSomeValuesFrom != null)
            {
                this.DataSomeValuesFrom.Wise(context);
            }

            if (this.DataAllValuesFrom != null)
            {
                this.DataAllValuesFrom.Wise(context);
            }

            if (this.DataHasValue != null)
            {
                this.DataHasValue.Wise(context);
            }

            if (this.DataMinCardinality != null)
            {
                this.DataMinCardinality.Wise(context);
            }

            if (this.DataMaxCardinality != null)
            {
                this.DataMaxCardinality.Wise(context);
            }

            if (this.DataExactCardinality != null)
            {
                this.DataExactCardinality.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassN != null)
            {
                this.ClassN.Format(context, builder);
            }

            if (this.ObjectIntersectionOf != null)
            {
                this.ObjectIntersectionOf.Format(context, builder);
            }

            if (this.ObjectUnionOf != null)
            {
                this.ObjectUnionOf.Format(context, builder);
            }

            if (this.ObjectComplementOf != null)
            {
                this.ObjectComplementOf.Format(context, builder);
            }

            if (this.ObjectOneOf != null)
            {
                this.ObjectOneOf.Format(context, builder);
            }

            if (this.ObjectSomeValuesFrom != null)
            {
                this.ObjectSomeValuesFrom.Format(context, builder);
            }

            if (this.ObjectAllValuesFrom != null)
            {
                this.ObjectAllValuesFrom.Format(context, builder);
            }

            if (this.ObjectHasValue != null)
            {
                this.ObjectHasValue.Format(context, builder);
            }

            if (this.ObjectHasSelf != null)
            {
                this.ObjectHasSelf.Format(context, builder);
            }

            if (this.ObjectMinCardinality != null)
            {
                this.ObjectMinCardinality.Format(context, builder);
            }

            if (this.ObjectMaxCardinality != null)
            {
                this.ObjectMaxCardinality.Format(context, builder);
            }

            if (this.ObjectExactCardinality != null)
            {
                this.ObjectExactCardinality.Format(context, builder);
            }

            if (this.DataSomeValuesFrom != null)
            {
                this.DataSomeValuesFrom.Format(context, builder);
            }

            if (this.DataAllValuesFrom != null)
            {
                this.DataAllValuesFrom.Format(context, builder);
            }

            if (this.DataHasValue != null)
            {
                this.DataHasValue.Format(context, builder);
            }

            if (this.DataMinCardinality != null)
            {
                this.DataMinCardinality.Format(context, builder);
            }

            if (this.DataMaxCardinality != null)
            {
                this.DataMaxCardinality.Format(context, builder);
            }

            if (this.DataExactCardinality != null)
            {
                this.DataExactCardinality.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassN != null)
            {
                this.ClassN.BuildQuery(context, builder);
            }

            if (this.ObjectIntersectionOf != null)
            {
                this.ObjectIntersectionOf.BuildQuery(context, builder);
            }

            if (this.ObjectUnionOf != null)
            {
                this.ObjectUnionOf.BuildQuery(context, builder);
            }

            if (this.ObjectComplementOf != null)
            {
                this.ObjectComplementOf.BuildQuery(context, builder);
            }

            if (this.ObjectOneOf != null)
            {
                this.ObjectOneOf.BuildQuery(context, builder);
            }

            if (this.ObjectSomeValuesFrom != null)
            {
                this.ObjectSomeValuesFrom.BuildQuery(context, builder);
            }

            if (this.ObjectAllValuesFrom != null)
            {
                this.ObjectAllValuesFrom.BuildQuery(context, builder);
            }

            if (this.ObjectHasValue != null)
            {
                this.ObjectHasValue.BuildQuery(context, builder);
            }

            if (this.ObjectHasSelf != null)
            {
                this.ObjectHasSelf.BuildQuery(context, builder);
            }

            if (this.ObjectMinCardinality != null)
            {
                this.ObjectMinCardinality.BuildQuery(context, builder);
            }

            if (this.ObjectMaxCardinality != null)
            {
                this.ObjectMaxCardinality.BuildQuery(context, builder);
            }

            if (this.ObjectExactCardinality != null)
            {
                this.ObjectExactCardinality.BuildQuery(context, builder);
            }

            if (this.DataSomeValuesFrom != null)
            {
                this.DataSomeValuesFrom.BuildQuery(context, builder);
            }

            if (this.DataAllValuesFrom != null)
            {
                this.DataAllValuesFrom.BuildQuery(context, builder);
            }

            if (this.DataHasValue != null)
            {
                this.DataHasValue.BuildQuery(context, builder);
            }

            if (this.DataMinCardinality != null)
            {
                this.DataMinCardinality.BuildQuery(context, builder);
            }

            if (this.DataMaxCardinality != null)
            {
                this.DataMaxCardinality.BuildQuery(context, builder);
            }

            if (this.DataExactCardinality != null)
            {
                this.DataExactCardinality.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassN != null)
            {
                this.ClassN.BuildMock(context, builder);
            }

            if (this.ObjectIntersectionOf != null)
            {
                this.ObjectIntersectionOf.BuildMock(context, builder);
            }

            if (this.ObjectUnionOf != null)
            {
                this.ObjectUnionOf.BuildMock(context, builder);
            }

            if (this.ObjectComplementOf != null)
            {
                this.ObjectComplementOf.BuildMock(context, builder);
            }

            if (this.ObjectOneOf != null)
            {
                this.ObjectOneOf.BuildMock(context, builder);
            }

            if (this.ObjectSomeValuesFrom != null)
            {
                this.ObjectSomeValuesFrom.BuildMock(context, builder);
            }

            if (this.ObjectAllValuesFrom != null)
            {
                this.ObjectAllValuesFrom.BuildMock(context, builder);
            }

            if (this.ObjectHasValue != null)
            {
                this.ObjectHasValue.BuildMock(context, builder);
            }

            if (this.ObjectHasSelf != null)
            {
                this.ObjectHasSelf.BuildMock(context, builder);
            }

            if (this.ObjectMinCardinality != null)
            {
                this.ObjectMinCardinality.BuildMock(context, builder);
            }

            if (this.ObjectMaxCardinality != null)
            {
                this.ObjectMaxCardinality.BuildMock(context, builder);
            }

            if (this.ObjectExactCardinality != null)
            {
                this.ObjectExactCardinality.BuildMock(context, builder);
            }

            if (this.DataSomeValuesFrom != null)
            {
                this.DataSomeValuesFrom.BuildMock(context, builder);
            }

            if (this.DataAllValuesFrom != null)
            {
                this.DataAllValuesFrom.BuildMock(context, builder);
            }

            if (this.DataHasValue != null)
            {
                this.DataHasValue.BuildMock(context, builder);
            }

            if (this.DataMinCardinality != null)
            {
                this.DataMinCardinality.BuildMock(context, builder);
            }

            if (this.DataMaxCardinality != null)
            {
                this.DataMaxCardinality.BuildMock(context, builder);
            }

            if (this.DataExactCardinality != null)
            {
                this.DataExactCardinality.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassN != null)
            {
                this.ClassN.BuildOther(context, builder);
            }

            if (this.ObjectIntersectionOf != null)
            {
                this.ObjectIntersectionOf.BuildOther(context, builder);
            }

            if (this.ObjectUnionOf != null)
            {
                this.ObjectUnionOf.BuildOther(context, builder);
            }

            if (this.ObjectComplementOf != null)
            {
                this.ObjectComplementOf.BuildOther(context, builder);
            }

            if (this.ObjectOneOf != null)
            {
                this.ObjectOneOf.BuildOther(context, builder);
            }

            if (this.ObjectSomeValuesFrom != null)
            {
                this.ObjectSomeValuesFrom.BuildOther(context, builder);
            }

            if (this.ObjectAllValuesFrom != null)
            {
                this.ObjectAllValuesFrom.BuildOther(context, builder);
            }

            if (this.ObjectHasValue != null)
            {
                this.ObjectHasValue.BuildOther(context, builder);
            }

            if (this.ObjectHasSelf != null)
            {
                this.ObjectHasSelf.BuildOther(context, builder);
            }

            if (this.ObjectMinCardinality != null)
            {
                this.ObjectMinCardinality.BuildOther(context, builder);
            }

            if (this.ObjectMaxCardinality != null)
            {
                this.ObjectMaxCardinality.BuildOther(context, builder);
            }

            if (this.ObjectExactCardinality != null)
            {
                this.ObjectExactCardinality.BuildOther(context, builder);
            }

            if (this.DataSomeValuesFrom != null)
            {
                this.DataSomeValuesFrom.BuildOther(context, builder);
            }

            if (this.DataAllValuesFrom != null)
            {
                this.DataAllValuesFrom.BuildOther(context, builder);
            }

            if (this.DataHasValue != null)
            {
                this.DataHasValue.BuildOther(context, builder);
            }

            if (this.DataMinCardinality != null)
            {
                this.DataMinCardinality.BuildOther(context, builder);
            }

            if (this.DataMaxCardinality != null)
            {
                this.DataMaxCardinality.BuildOther(context, builder);
            }

            if (this.DataExactCardinality != null)
            {
                this.DataExactCardinality.BuildOther(context, builder);
            }

        }
    }

    public class ObjectIntersectionOf : TokenPair
    {
        public ObjectIntersectionOf()
        {
            this.ClassExpressions = new List<ClassExpression>();
        }
        public String OBJECTINTERSECTIONOF
        { get; set; }
        public List<ClassExpression> ClassExpressions
        { get; set; }

        public void Parse(SwrlContext context)
        {

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].BuildOther(context, builder);
            }

        }
    }

    public class ObjectUnionOf : TokenPair
    {
        public ObjectUnionOf()
        {
            this.ClassExpressions = new List<ClassExpression>();
        }
        public String OBJECTUNIONOF
        { get; set; }
        public List<ClassExpression> ClassExpressions
        { get; set; }

        public void Parse(SwrlContext context)
        {

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.ClassExpressions.Count(); i++)
            {
                this.ClassExpressions[i].BuildOther(context, builder);
            }

        }
    }

    public class ObjectComplementOf : TokenPair
    {
        public ObjectComplementOf()
        {
        }
        public String OBJECTCOMPLEMENTOF
        { get; set; }
        public ClassExpression ClassExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildOther(context, builder);
            }

        }
    }

    public class ObjectOneOf : TokenPair
    {
        public ObjectOneOf()
        {
            this.Individuals = new List<Individual>();
        }
        public String OBJECTONEOF
        { get; set; }
        public List<Individual> Individuals
        { get; set; }

        public void Parse(SwrlContext context)
        {

            for (int i = 0; i < this.Individuals.Count(); i++)
            {
                this.Individuals[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            for (int i = 0; i < this.Individuals.Count(); i++)
            {
                this.Individuals[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Individuals.Count(); i++)
            {
                this.Individuals[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Individuals.Count(); i++)
            {
                this.Individuals[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Individuals.Count(); i++)
            {
                this.Individuals[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Individuals.Count(); i++)
            {
                this.Individuals[i].BuildOther(context, builder);
            }

        }
    }

    public class ObjectSomeValuesFrom : TokenPair
    {
        public ObjectSomeValuesFrom()
        {
        }
        public String OBJECTSOMEVALUESFROM
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }
        public ClassExpression ClassExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildOther(context, builder);
            }

        }
    }

    public class ObjectAllValuesFrom : TokenPair
    {
        public ObjectAllValuesFrom()
        {
        }
        public String OBJECTALLVALUESFROM
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }
        public ClassExpression ClassExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildOther(context, builder);
            }

        }
    }

    public class ObjectHasValue : TokenPair
    {
        public ObjectHasValue()
        {
        }
        public String OBJECTHASVALUE
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }
        public Individual Individual
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

            if (this.Individual != null)
            {
                this.Individual.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

            if (this.Individual != null)
            {
                this.Individual.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

            if (this.Individual != null)
            {
                this.Individual.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

            if (this.Individual != null)
            {
                this.Individual.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

            if (this.Individual != null)
            {
                this.Individual.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

            if (this.Individual != null)
            {
                this.Individual.BuildOther(context, builder);
            }

        }
    }

    public class ObjectHasSelf : TokenPair
    {
        public ObjectHasSelf()
        {
        }
        public String OBJECTHASSELF
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

        }
    }

    public class ObjectMinCardinality : TokenPair
    {
        public ObjectMinCardinality()
        {
        }
        public String OBJECTMINCARDINALITY
        { get; set; }
        public String INTEGER
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }
        public ClassExpression ClassExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildOther(context, builder);
            }

        }
    }

    public class ObjectMaxCardinality : TokenPair
    {
        public ObjectMaxCardinality()
        {
        }
        public String OBJECTMAXCARDINALITY
        { get; set; }
        public String INTEGER
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }
        public ClassExpression ClassExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildOther(context, builder);
            }

        }
    }

    public class ObjectExactCardinality : TokenPair
    {
        public ObjectExactCardinality()
        {
        }
        public String OBJECTEXACTCARDINALITY
        { get; set; }
        public String INTEGER
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }
        public ClassExpression ClassExpression
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildOther(context, builder);
            }

        }
    }

    public class DataSomeValuesFrom : TokenPair
    {
        public DataSomeValuesFrom()
        {
            this.DataPropertyExpressions = new List<DataPropertyExpression>();
        }
        public String DATASOMEVALUESFROM
        { get; set; }
        public List<DataPropertyExpression> DataPropertyExpressions
        { get; set; }
        public DataRange DataRange
        { get; set; }

        public void Parse(SwrlContext context)
        {

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].Parse(context);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].Wise(context);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].Format(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].BuildQuery(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].BuildMock(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].BuildOther(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildOther(context, builder);
            }

        }
    }

    public class DataAllValuesFrom : TokenPair
    {
        public DataAllValuesFrom()
        {
            this.DataPropertyExpressions = new List<DataPropertyExpression>();
        }
        public String DATAALLVALUESFROM
        { get; set; }
        public List<DataPropertyExpression> DataPropertyExpressions
        { get; set; }
        public DataRange DataRange
        { get; set; }

        public void Parse(SwrlContext context)
        {

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].Parse(context);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].Wise(context);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].Format(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].BuildQuery(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].BuildMock(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DataPropertyExpressions.Count(); i++)
            {
                this.DataPropertyExpressions[i].BuildOther(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildOther(context, builder);
            }

        }
    }

    public class DataHasValue : TokenPair
    {
        public DataHasValue()
        {
        }
        public String DATAHASVALUE
        { get; set; }
        public DataPropertyExpression DataPropertyExpression
        { get; set; }
        public Literal Literal
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Parse(context);
            }

            if (this.Literal != null)
            {
                this.Literal.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Wise(context);
            }

            if (this.Literal != null)
            {
                this.Literal.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Format(context, builder);
            }

            if (this.Literal != null)
            {
                this.Literal.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildQuery(context, builder);
            }

            if (this.Literal != null)
            {
                this.Literal.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildMock(context, builder);
            }

            if (this.Literal != null)
            {
                this.Literal.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildOther(context, builder);
            }

            if (this.Literal != null)
            {
                this.Literal.BuildOther(context, builder);
            }

        }
    }

    public class DataMinCardinality : TokenPair
    {
        public DataMinCardinality()
        {
        }
        public String DATAMINCARDINALITY
        { get; set; }
        public String INTEGER
        { get; set; }
        public DataPropertyExpression DataPropertyExpression
        { get; set; }
        public DataRange DataRange
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Parse(context);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Wise(context);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Format(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildQuery(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildMock(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildOther(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildOther(context, builder);
            }

        }
    }

    public class DataMaxCardinality : TokenPair
    {
        public DataMaxCardinality()
        {
        }
        public String DATAMAXCARDINALITY
        { get; set; }
        public String INTEGER
        { get; set; }
        public DataPropertyExpression DataPropertyExpression
        { get; set; }
        public DataRange DataRange
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Parse(context);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Wise(context);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Format(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildQuery(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildMock(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildOther(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildOther(context, builder);
            }

        }
    }

    public class DataExactCardinality : TokenPair
    {
        public DataExactCardinality()
        {
        }
        public String DATAEXACTCARDINALITY
        { get; set; }
        public String INTEGER
        { get; set; }
        public DataPropertyExpression DataPropertyExpression
        { get; set; }
        public DataRange DataRange
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Parse(context);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Wise(context);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Format(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildQuery(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildMock(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildOther(context, builder);
            }

            if (this.DataRange != null)
            {
                this.DataRange.BuildOther(context, builder);
            }

        }
    }

    public class DataPropertyExpression : TokenPair
    {
        public DataPropertyExpression()
        {
        }
        public DataProperty DataProperty
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.DataProperty != null)
            {
                this.DataProperty.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.DataProperty != null)
            {
                this.DataProperty.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataProperty != null)
            {
                this.DataProperty.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataProperty != null)
            {
                this.DataProperty.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataProperty != null)
            {
                this.DataProperty.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataProperty != null)
            {
                this.DataProperty.BuildOther(context, builder);
            }

        }
    }

    public class Assertion : TokenPair
    {
        public Assertion()
        {
        }
        public SameIndividual SameIndividual
        { get; set; }
        public DifferentIndividuals DifferentIndividuals
        { get; set; }
        public ClassAssertion ClassAssertion
        { get; set; }
        public ObjectPropertyAssertion ObjectPropertyAssertion
        { get; set; }
        public NegativeObjectPropertyAssertion NegativeObjectPropertyAssertion
        { get; set; }
        public DataPropertyAssertion DataPropertyAssertion
        { get; set; }
        public NegativeDataPropertyAssertion NegativeDataPropertyAssertion
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.SameIndividual != null)
            {
                this.SameIndividual.Parse(context);
            }

            if (this.DifferentIndividuals != null)
            {
                this.DifferentIndividuals.Parse(context);
            }

            if (this.ClassAssertion != null)
            {
                this.ClassAssertion.Parse(context);
            }

            if (this.ObjectPropertyAssertion != null)
            {
                this.ObjectPropertyAssertion.Parse(context);
            }

            if (this.NegativeObjectPropertyAssertion != null)
            {
                this.NegativeObjectPropertyAssertion.Parse(context);
            }

            if (this.DataPropertyAssertion != null)
            {
                this.DataPropertyAssertion.Parse(context);
            }

            if (this.NegativeDataPropertyAssertion != null)
            {
                this.NegativeDataPropertyAssertion.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.SameIndividual != null)
            {
                this.SameIndividual.Wise(context);
            }

            if (this.DifferentIndividuals != null)
            {
                this.DifferentIndividuals.Wise(context);
            }

            if (this.ClassAssertion != null)
            {
                this.ClassAssertion.Wise(context);
            }

            if (this.ObjectPropertyAssertion != null)
            {
                this.ObjectPropertyAssertion.Wise(context);
            }

            if (this.NegativeObjectPropertyAssertion != null)
            {
                this.NegativeObjectPropertyAssertion.Wise(context);
            }

            if (this.DataPropertyAssertion != null)
            {
                this.DataPropertyAssertion.Wise(context);
            }

            if (this.NegativeDataPropertyAssertion != null)
            {
                this.NegativeDataPropertyAssertion.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.SameIndividual != null)
            {
                this.SameIndividual.Format(context, builder);
            }

            if (this.DifferentIndividuals != null)
            {
                this.DifferentIndividuals.Format(context, builder);
            }

            if (this.ClassAssertion != null)
            {
                this.ClassAssertion.Format(context, builder);
            }

            if (this.ObjectPropertyAssertion != null)
            {
                this.ObjectPropertyAssertion.Format(context, builder);
            }

            if (this.NegativeObjectPropertyAssertion != null)
            {
                this.NegativeObjectPropertyAssertion.Format(context, builder);
            }

            if (this.DataPropertyAssertion != null)
            {
                this.DataPropertyAssertion.Format(context, builder);
            }

            if (this.NegativeDataPropertyAssertion != null)
            {
                this.NegativeDataPropertyAssertion.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.SameIndividual != null)
            {
                this.SameIndividual.BuildQuery(context, builder);
            }

            if (this.DifferentIndividuals != null)
            {
                this.DifferentIndividuals.BuildQuery(context, builder);
            }

            if (this.ClassAssertion != null)
            {
                this.ClassAssertion.BuildQuery(context, builder);
            }

            if (this.ObjectPropertyAssertion != null)
            {
                this.ObjectPropertyAssertion.BuildQuery(context, builder);
            }

            if (this.NegativeObjectPropertyAssertion != null)
            {
                this.NegativeObjectPropertyAssertion.BuildQuery(context, builder);
            }

            if (this.DataPropertyAssertion != null)
            {
                this.DataPropertyAssertion.BuildQuery(context, builder);
            }

            if (this.NegativeDataPropertyAssertion != null)
            {
                this.NegativeDataPropertyAssertion.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.SameIndividual != null)
            {
                this.SameIndividual.BuildMock(context, builder);
            }

            if (this.DifferentIndividuals != null)
            {
                this.DifferentIndividuals.BuildMock(context, builder);
            }

            if (this.ClassAssertion != null)
            {
                this.ClassAssertion.BuildMock(context, builder);
            }

            if (this.ObjectPropertyAssertion != null)
            {
                this.ObjectPropertyAssertion.BuildMock(context, builder);
            }

            if (this.NegativeObjectPropertyAssertion != null)
            {
                this.NegativeObjectPropertyAssertion.BuildMock(context, builder);
            }

            if (this.DataPropertyAssertion != null)
            {
                this.DataPropertyAssertion.BuildMock(context, builder);
            }

            if (this.NegativeDataPropertyAssertion != null)
            {
                this.NegativeDataPropertyAssertion.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.SameIndividual != null)
            {
                this.SameIndividual.BuildOther(context, builder);
            }

            if (this.DifferentIndividuals != null)
            {
                this.DifferentIndividuals.BuildOther(context, builder);
            }

            if (this.ClassAssertion != null)
            {
                this.ClassAssertion.BuildOther(context, builder);
            }

            if (this.ObjectPropertyAssertion != null)
            {
                this.ObjectPropertyAssertion.BuildOther(context, builder);
            }

            if (this.NegativeObjectPropertyAssertion != null)
            {
                this.NegativeObjectPropertyAssertion.BuildOther(context, builder);
            }

            if (this.DataPropertyAssertion != null)
            {
                this.DataPropertyAssertion.BuildOther(context, builder);
            }

            if (this.NegativeDataPropertyAssertion != null)
            {
                this.NegativeDataPropertyAssertion.BuildOther(context, builder);
            }

        }
    }

    public class SourceIndividual : TokenPair
    {
        public SourceIndividual()
        {
        }
        public Individual Individual
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.Individual != null)
            {
                this.Individual.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.Individual != null)
            {
                this.Individual.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Individual != null)
            {
                this.Individual.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Individual != null)
            {
                this.Individual.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Individual != null)
            {
                this.Individual.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Individual != null)
            {
                this.Individual.BuildOther(context, builder);
            }

        }
    }

    public class TargetIndividual : TokenPair
    {
        public TargetIndividual()
        {
        }
        public Individual Individual
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.Individual != null)
            {
                this.Individual.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.Individual != null)
            {
                this.Individual.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Individual != null)
            {
                this.Individual.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Individual != null)
            {
                this.Individual.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Individual != null)
            {
                this.Individual.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Individual != null)
            {
                this.Individual.BuildOther(context, builder);
            }

        }
    }

    public class TargetValue : TokenPair
    {
        public TargetValue()
        {
        }
        public Literal Literal
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.Literal != null)
            {
                this.Literal.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.Literal != null)
            {
                this.Literal.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Literal != null)
            {
                this.Literal.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Literal != null)
            {
                this.Literal.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Literal != null)
            {
                this.Literal.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Literal != null)
            {
                this.Literal.BuildOther(context, builder);
            }

        }
    }

    public class SameIndividual : TokenPair
    {
        public SameIndividual()
        {
            this.Individuals = new List<Individual>();
        }
        public String SAMEINDIVIDUAL
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public List<Individual> Individuals
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            for (int i = 0; i < this.Individuals.Count(); i++)
            {
                this.Individuals[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            for (int i = 0; i < this.Individuals.Count(); i++)
            {
                this.Individuals[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            for (int i = 0; i < this.Individuals.Count(); i++)
            {
                this.Individuals[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.Individuals.Count(); i++)
            {
                this.Individuals[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            for (int i = 0; i < this.Individuals.Count(); i++)
            {
                this.Individuals[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            for (int i = 0; i < this.Individuals.Count(); i++)
            {
                this.Individuals[i].BuildOther(context, builder);
            }

        }
    }

    public class DifferentIndividuals : TokenPair
    {
        public DifferentIndividuals()
        {
            this.Individuals = new List<Individual>();
        }
        public String DIFFERENTINDIVIDUALS
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public List<Individual> Individuals
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            for (int i = 0; i < this.Individuals.Count(); i++)
            {
                this.Individuals[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            for (int i = 0; i < this.Individuals.Count(); i++)
            {
                this.Individuals[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            for (int i = 0; i < this.Individuals.Count(); i++)
            {
                this.Individuals[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.Individuals.Count(); i++)
            {
                this.Individuals[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            for (int i = 0; i < this.Individuals.Count(); i++)
            {
                this.Individuals[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            for (int i = 0; i < this.Individuals.Count(); i++)
            {
                this.Individuals[i].BuildOther(context, builder);
            }

        }
    }

    public class ClassAssertion : TokenPair
    {
        public ClassAssertion()
        {
        }
        public String CLASSASSERTION
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public ClassExpression ClassExpression
        { get; set; }
        public Individual Individual
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Parse(context);
            }

            if (this.Individual != null)
            {
                this.Individual.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Wise(context);
            }

            if (this.Individual != null)
            {
                this.Individual.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.Format(context, builder);
            }

            if (this.Individual != null)
            {
                this.Individual.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildQuery(context, builder);
            }

            if (this.Individual != null)
            {
                this.Individual.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildMock(context, builder);
            }

            if (this.Individual != null)
            {
                this.Individual.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.ClassExpression != null)
            {
                this.ClassExpression.BuildOther(context, builder);
            }

            if (this.Individual != null)
            {
                this.Individual.BuildOther(context, builder);
            }

        }
    }

    public class ObjectPropertyAssertion : TokenPair
    {
        public ObjectPropertyAssertion()
        {
        }
        public String OBJECTPROPERTYASSERTION
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }
        public SourceIndividual SourceIndividual
        { get; set; }
        public TargetIndividual TargetIndividual
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.Parse(context);
            }

            if (this.TargetIndividual != null)
            {
                this.TargetIndividual.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.Wise(context);
            }

            if (this.TargetIndividual != null)
            {
                this.TargetIndividual.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.Format(context, builder);
            }

            if (this.TargetIndividual != null)
            {
                this.TargetIndividual.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.BuildQuery(context, builder);
            }

            if (this.TargetIndividual != null)
            {
                this.TargetIndividual.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.BuildMock(context, builder);
            }

            if (this.TargetIndividual != null)
            {
                this.TargetIndividual.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.BuildOther(context, builder);
            }

            if (this.TargetIndividual != null)
            {
                this.TargetIndividual.BuildOther(context, builder);
            }

        }
    }

    public class NegativeObjectPropertyAssertion : TokenPair
    {
        public NegativeObjectPropertyAssertion()
        {
        }
        public String NEGATIVEOBJECTPROPERTYASSERTION
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public ObjectPropertyExpression ObjectPropertyExpression
        { get; set; }
        public SourceIndividual SourceIndividual
        { get; set; }
        public TargetIndividual TargetIndividual
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Parse(context);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.Parse(context);
            }

            if (this.TargetIndividual != null)
            {
                this.TargetIndividual.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Wise(context);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.Wise(context);
            }

            if (this.TargetIndividual != null)
            {
                this.TargetIndividual.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.Format(context, builder);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.Format(context, builder);
            }

            if (this.TargetIndividual != null)
            {
                this.TargetIndividual.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildQuery(context, builder);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.BuildQuery(context, builder);
            }

            if (this.TargetIndividual != null)
            {
                this.TargetIndividual.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildMock(context, builder);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.BuildMock(context, builder);
            }

            if (this.TargetIndividual != null)
            {
                this.TargetIndividual.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.ObjectPropertyExpression != null)
            {
                this.ObjectPropertyExpression.BuildOther(context, builder);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.BuildOther(context, builder);
            }

            if (this.TargetIndividual != null)
            {
                this.TargetIndividual.BuildOther(context, builder);
            }

        }
    }

    public class DataPropertyAssertion : TokenPair
    {
        public DataPropertyAssertion()
        {
        }
        public String DATAPROPERTYASSERTION
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public DataPropertyExpression DataPropertyExpression
        { get; set; }
        public SourceIndividual SourceIndividual
        { get; set; }
        public TargetValue TargetValue
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Parse(context);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.Parse(context);
            }

            if (this.TargetValue != null)
            {
                this.TargetValue.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Wise(context);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.Wise(context);
            }

            if (this.TargetValue != null)
            {
                this.TargetValue.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Format(context, builder);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.Format(context, builder);
            }

            if (this.TargetValue != null)
            {
                this.TargetValue.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildQuery(context, builder);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.BuildQuery(context, builder);
            }

            if (this.TargetValue != null)
            {
                this.TargetValue.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildMock(context, builder);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.BuildMock(context, builder);
            }

            if (this.TargetValue != null)
            {
                this.TargetValue.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildOther(context, builder);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.BuildOther(context, builder);
            }

            if (this.TargetValue != null)
            {
                this.TargetValue.BuildOther(context, builder);
            }

        }
    }

    public class NegativeDataPropertyAssertion : TokenPair
    {
        public NegativeDataPropertyAssertion()
        {
        }
        public String NEGATIVEDATAPROPERTYASSERTION
        { get; set; }
        public AxiomAnnotations AxiomAnnotations
        { get; set; }
        public DataPropertyExpression DataPropertyExpression
        { get; set; }
        public SourceIndividual SourceIndividual
        { get; set; }
        public TargetValue TargetValue
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Parse(context);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Parse(context);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.Parse(context);
            }

            if (this.TargetValue != null)
            {
                this.TargetValue.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Wise(context);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Wise(context);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.Wise(context);
            }

            if (this.TargetValue != null)
            {
                this.TargetValue.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.Format(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.Format(context, builder);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.Format(context, builder);
            }

            if (this.TargetValue != null)
            {
                this.TargetValue.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildQuery(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildQuery(context, builder);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.BuildQuery(context, builder);
            }

            if (this.TargetValue != null)
            {
                this.TargetValue.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildMock(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildMock(context, builder);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.BuildMock(context, builder);
            }

            if (this.TargetValue != null)
            {
                this.TargetValue.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.AxiomAnnotations != null)
            {
                this.AxiomAnnotations.BuildOther(context, builder);
            }

            if (this.DataPropertyExpression != null)
            {
                this.DataPropertyExpression.BuildOther(context, builder);
            }

            if (this.SourceIndividual != null)
            {
                this.SourceIndividual.BuildOther(context, builder);
            }

            if (this.TargetValue != null)
            {
                this.TargetValue.BuildOther(context, builder);
            }

        }
    }

    public class DataRange : TokenPair
    {
        public DataRange()
        {
        }
        public Datatype Datatype
        { get; set; }
        public DataIntersectionOf DataIntersectionOf
        { get; set; }
        public DataUnionOf DataUnionOf
        { get; set; }
        public DataComplementOf DataComplementOf
        { get; set; }
        public DataOneOf DataOneOf
        { get; set; }
        public DatatypeRestriction DatatypeRestriction
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.Datatype != null)
            {
                this.Datatype.Parse(context);
            }

            if (this.DataIntersectionOf != null)
            {
                this.DataIntersectionOf.Parse(context);
            }

            if (this.DataUnionOf != null)
            {
                this.DataUnionOf.Parse(context);
            }

            if (this.DataComplementOf != null)
            {
                this.DataComplementOf.Parse(context);
            }

            if (this.DataOneOf != null)
            {
                this.DataOneOf.Parse(context);
            }

            if (this.DatatypeRestriction != null)
            {
                this.DatatypeRestriction.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.Datatype != null)
            {
                this.Datatype.Wise(context);
            }

            if (this.DataIntersectionOf != null)
            {
                this.DataIntersectionOf.Wise(context);
            }

            if (this.DataUnionOf != null)
            {
                this.DataUnionOf.Wise(context);
            }

            if (this.DataComplementOf != null)
            {
                this.DataComplementOf.Wise(context);
            }

            if (this.DataOneOf != null)
            {
                this.DataOneOf.Wise(context);
            }

            if (this.DatatypeRestriction != null)
            {
                this.DatatypeRestriction.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Datatype != null)
            {
                this.Datatype.Format(context, builder);
            }

            if (this.DataIntersectionOf != null)
            {
                this.DataIntersectionOf.Format(context, builder);
            }

            if (this.DataUnionOf != null)
            {
                this.DataUnionOf.Format(context, builder);
            }

            if (this.DataComplementOf != null)
            {
                this.DataComplementOf.Format(context, builder);
            }

            if (this.DataOneOf != null)
            {
                this.DataOneOf.Format(context, builder);
            }

            if (this.DatatypeRestriction != null)
            {
                this.DatatypeRestriction.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Datatype != null)
            {
                this.Datatype.BuildQuery(context, builder);
            }

            if (this.DataIntersectionOf != null)
            {
                this.DataIntersectionOf.BuildQuery(context, builder);
            }

            if (this.DataUnionOf != null)
            {
                this.DataUnionOf.BuildQuery(context, builder);
            }

            if (this.DataComplementOf != null)
            {
                this.DataComplementOf.BuildQuery(context, builder);
            }

            if (this.DataOneOf != null)
            {
                this.DataOneOf.BuildQuery(context, builder);
            }

            if (this.DatatypeRestriction != null)
            {
                this.DatatypeRestriction.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Datatype != null)
            {
                this.Datatype.BuildMock(context, builder);
            }

            if (this.DataIntersectionOf != null)
            {
                this.DataIntersectionOf.BuildMock(context, builder);
            }

            if (this.DataUnionOf != null)
            {
                this.DataUnionOf.BuildMock(context, builder);
            }

            if (this.DataComplementOf != null)
            {
                this.DataComplementOf.BuildMock(context, builder);
            }

            if (this.DataOneOf != null)
            {
                this.DataOneOf.BuildMock(context, builder);
            }

            if (this.DatatypeRestriction != null)
            {
                this.DatatypeRestriction.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Datatype != null)
            {
                this.Datatype.BuildOther(context, builder);
            }

            if (this.DataIntersectionOf != null)
            {
                this.DataIntersectionOf.BuildOther(context, builder);
            }

            if (this.DataUnionOf != null)
            {
                this.DataUnionOf.BuildOther(context, builder);
            }

            if (this.DataComplementOf != null)
            {
                this.DataComplementOf.BuildOther(context, builder);
            }

            if (this.DataOneOf != null)
            {
                this.DataOneOf.BuildOther(context, builder);
            }

            if (this.DatatypeRestriction != null)
            {
                this.DatatypeRestriction.BuildOther(context, builder);
            }

        }
    }

    public class DataIntersectionOf : TokenPair
    {
        public DataIntersectionOf()
        {
            this.DataRanges = new List<DataRange>();
        }
        public String DATAINTERSECTIONOF
        { get; set; }
        public List<DataRange> DataRanges
        { get; set; }

        public void Parse(SwrlContext context)
        {

            for (int i = 0; i < this.DataRanges.Count(); i++)
            {
                this.DataRanges[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            for (int i = 0; i < this.DataRanges.Count(); i++)
            {
                this.DataRanges[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DataRanges.Count(); i++)
            {
                this.DataRanges[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DataRanges.Count(); i++)
            {
                this.DataRanges[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DataRanges.Count(); i++)
            {
                this.DataRanges[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DataRanges.Count(); i++)
            {
                this.DataRanges[i].BuildOther(context, builder);
            }

        }
    }

    public class DataUnionOf : TokenPair
    {
        public DataUnionOf()
        {
            this.DataRanges = new List<DataRange>();
        }
        public String DATAUNIONOF
        { get; set; }
        public List<DataRange> DataRanges
        { get; set; }

        public void Parse(SwrlContext context)
        {

            for (int i = 0; i < this.DataRanges.Count(); i++)
            {
                this.DataRanges[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            for (int i = 0; i < this.DataRanges.Count(); i++)
            {
                this.DataRanges[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DataRanges.Count(); i++)
            {
                this.DataRanges[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DataRanges.Count(); i++)
            {
                this.DataRanges[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DataRanges.Count(); i++)
            {
                this.DataRanges[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.DataRanges.Count(); i++)
            {
                this.DataRanges[i].BuildOther(context, builder);
            }

        }
    }

    public class DataComplementOf : TokenPair
    {
        public DataComplementOf()
        {
        }
        public String DATACOMPLEMENTOF
        { get; set; }
        public DataRange DataRange
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.DataRange != null)
            {
                this.DataRange.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.DataRange != null)
            {
                this.DataRange.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataRange != null)
            {
                this.DataRange.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataRange != null)
            {
                this.DataRange.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataRange != null)
            {
                this.DataRange.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.DataRange != null)
            {
                this.DataRange.BuildOther(context, builder);
            }

        }
    }

    public class DataOneOf : TokenPair
    {
        public DataOneOf()
        {
            this.Literals = new List<Literal>();
        }
        public String DATAONEOF
        { get; set; }
        public List<Literal> Literals
        { get; set; }

        public void Parse(SwrlContext context)
        {

            for (int i = 0; i < this.Literals.Count(); i++)
            {
                this.Literals[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            for (int i = 0; i < this.Literals.Count(); i++)
            {
                this.Literals[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Literals.Count(); i++)
            {
                this.Literals[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Literals.Count(); i++)
            {
                this.Literals[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Literals.Count(); i++)
            {
                this.Literals[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            for (int i = 0; i < this.Literals.Count(); i++)
            {
                this.Literals[i].BuildOther(context, builder);
            }

        }
    }

    public class Datatype : TokenPair
    {
        public Datatype()
        {
        }
        public IRI IRI
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildOther(context, builder);
            }

        }
    }

    public class ObjectPropertyExpression : TokenPair
    {
        public ObjectPropertyExpression()
        {
        }
        public ObjectProperty ObjectProperty
        { get; set; }
        public InverseObjectProperty InverseObjectProperty
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.Parse(context);
            }

            if (this.InverseObjectProperty != null)
            {
                this.InverseObjectProperty.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.Wise(context);
            }

            if (this.InverseObjectProperty != null)
            {
                this.InverseObjectProperty.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.Format(context, builder);
            }

            if (this.InverseObjectProperty != null)
            {
                this.InverseObjectProperty.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.BuildQuery(context, builder);
            }

            if (this.InverseObjectProperty != null)
            {
                this.InverseObjectProperty.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.BuildMock(context, builder);
            }

            if (this.InverseObjectProperty != null)
            {
                this.InverseObjectProperty.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.BuildOther(context, builder);
            }

            if (this.InverseObjectProperty != null)
            {
                this.InverseObjectProperty.BuildOther(context, builder);
            }

        }
    }

    public class InverseObjectProperty : TokenPair
    {
        public InverseObjectProperty()
        {
        }
        public String OBJECTINVERSEOF
        { get; set; }
        public ObjectProperty ObjectProperty
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.ObjectProperty != null)
            {
                this.ObjectProperty.BuildOther(context, builder);
            }

        }
    }

    public class DatatypeRestriction : TokenPair
    {
        public DatatypeRestriction()
        {
            this.ConstrainingFacets = new List<ConstrainingFacet>();
            this.RestrictionValues = new List<RestrictionValue>();
        }
        public String DATATYPERESTRICTION
        { get; set; }
        public Datatype Datatype
        { get; set; }
        public List<ConstrainingFacet> ConstrainingFacets
        { get; set; }
        public List<RestrictionValue> RestrictionValues
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.Datatype != null)
            {
                this.Datatype.Parse(context);
            }

            for (int i = 0; i < this.ConstrainingFacets.Count(); i++)
            {
                this.ConstrainingFacets[i].Parse(context);
            }

            for (int i = 0; i < this.RestrictionValues.Count(); i++)
            {
                this.RestrictionValues[i].Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.Datatype != null)
            {
                this.Datatype.Wise(context);
            }

            for (int i = 0; i < this.ConstrainingFacets.Count(); i++)
            {
                this.ConstrainingFacets[i].Wise(context);
            }

            for (int i = 0; i < this.RestrictionValues.Count(); i++)
            {
                this.RestrictionValues[i].Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Datatype != null)
            {
                this.Datatype.Format(context, builder);
            }

            for (int i = 0; i < this.ConstrainingFacets.Count(); i++)
            {
                this.ConstrainingFacets[i].Format(context, builder);
            }

            for (int i = 0; i < this.RestrictionValues.Count(); i++)
            {
                this.RestrictionValues[i].Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Datatype != null)
            {
                this.Datatype.BuildQuery(context, builder);
            }

            for (int i = 0; i < this.ConstrainingFacets.Count(); i++)
            {
                this.ConstrainingFacets[i].BuildQuery(context, builder);
            }

            for (int i = 0; i < this.RestrictionValues.Count(); i++)
            {
                this.RestrictionValues[i].BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Datatype != null)
            {
                this.Datatype.BuildMock(context, builder);
            }

            for (int i = 0; i < this.ConstrainingFacets.Count(); i++)
            {
                this.ConstrainingFacets[i].BuildMock(context, builder);
            }

            for (int i = 0; i < this.RestrictionValues.Count(); i++)
            {
                this.RestrictionValues[i].BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Datatype != null)
            {
                this.Datatype.BuildOther(context, builder);
            }

            for (int i = 0; i < this.ConstrainingFacets.Count(); i++)
            {
                this.ConstrainingFacets[i].BuildOther(context, builder);
            }

            for (int i = 0; i < this.RestrictionValues.Count(); i++)
            {
                this.RestrictionValues[i].BuildOther(context, builder);
            }

        }
    }

    public class ConstrainingFacet : TokenPair
    {
        public ConstrainingFacet()
        {
        }
        public IRI IRI
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildOther(context, builder);
            }

        }
    }

    public class RestrictionValue : TokenPair
    {
        public RestrictionValue()
        {
        }
        public Literal Literal
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.Literal != null)
            {
                this.Literal.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.Literal != null)
            {
                this.Literal.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Literal != null)
            {
                this.Literal.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Literal != null)
            {
                this.Literal.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Literal != null)
            {
                this.Literal.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.Literal != null)
            {
                this.Literal.BuildOther(context, builder);
            }

        }
    }

    public class DataProperty : TokenPair
    {
        public DataProperty()
        {
        }
        public IRI IRI
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildOther(context, builder);
            }

        }
    }

    public class Individual : TokenPair
    {
        public Individual()
        {
        }
        public NamedIndividual NamedIndividual
        { get; set; }
        public AnonymousIndividual AnonymousIndividual
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.NamedIndividual != null)
            {
                this.NamedIndividual.Parse(context);
            }

            if (this.AnonymousIndividual != null)
            {
                this.AnonymousIndividual.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.NamedIndividual != null)
            {
                this.NamedIndividual.Wise(context);
            }

            if (this.AnonymousIndividual != null)
            {
                this.AnonymousIndividual.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.NamedIndividual != null)
            {
                this.NamedIndividual.Format(context, builder);
            }

            if (this.AnonymousIndividual != null)
            {
                this.AnonymousIndividual.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.NamedIndividual != null)
            {
                this.NamedIndividual.BuildQuery(context, builder);
            }

            if (this.AnonymousIndividual != null)
            {
                this.AnonymousIndividual.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.NamedIndividual != null)
            {
                this.NamedIndividual.BuildMock(context, builder);
            }

            if (this.AnonymousIndividual != null)
            {
                this.AnonymousIndividual.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.NamedIndividual != null)
            {
                this.NamedIndividual.BuildOther(context, builder);
            }

            if (this.AnonymousIndividual != null)
            {
                this.AnonymousIndividual.BuildOther(context, builder);
            }

        }
    }

    public class NamedIndividual : TokenPair
    {
        public NamedIndividual()
        {
        }
        public IRI IRI
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildOther(context, builder);
            }

        }
    }

    public class AnonymousIndividual : TokenPair
    {
        public AnonymousIndividual()
        {
        }
        public String BLANKNODELABEL
        { get; set; }

        public void Parse(SwrlContext context)
        {

        }

        public void Wise(SwrlContext context)
        {

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

        }
    }

    public class Literal : TokenPair
    {
        public Literal()
        {
        }
        public String @string
        { get; set; }
        public String LANGTAG
        { get; set; }
        public XsdIri XsdIri
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.XsdIri != null)
            {
                this.XsdIri.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.XsdIri != null)
            {
                this.XsdIri.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.XsdIri != null)
            {
                this.XsdIri.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.XsdIri != null)
            {
                this.XsdIri.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.XsdIri != null)
            {
                this.XsdIri.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.XsdIri != null)
            {
                this.XsdIri.BuildOther(context, builder);
            }

        }
    }

    public class ClassN : TokenPair
    {
        public ClassN()
        {
        }
        public IRI IRI
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildOther(context, builder);
            }

        }
    }

    public class ObjectProperty : TokenPair
    {
        public ObjectProperty()
        {
        }
        public IRI IRI
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.IRI != null)
            {
                this.IRI.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.IRI != null)
            {
                this.IRI.BuildOther(context, builder);
            }

        }
    }

    public class IRI : TokenPair
    {
        public IRI()
        {
        }
        public String IRIREF
        { get; set; }
        public PrefixedName PrefixedName
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.PrefixedName != null)
            {
                this.PrefixedName.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.PrefixedName != null)
            {
                this.PrefixedName.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.PrefixedName != null)
            {
                this.PrefixedName.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.PrefixedName != null)
            {
                this.PrefixedName.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.PrefixedName != null)
            {
                this.PrefixedName.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.PrefixedName != null)
            {
                this.PrefixedName.BuildOther(context, builder);
            }

        }
    }

    public class PrefixedName : TokenPair
    {
        public PrefixedName()
        {
        }
        public String PNAMELN
        { get; set; }
        public String PNAMENS
        { get; set; }

        public void Parse(SwrlContext context)
        {

        }

        public void Wise(SwrlContext context)
        {

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

        }
    }

    public class BlankNode : TokenPair
    {
        public BlankNode()
        {
        }
        public String BLANKNODELABEL
        { get; set; }
        public String ANON
        { get; set; }

        public void Parse(SwrlContext context)
        {

        }

        public void Wise(SwrlContext context)
        {

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

        }
    }

    public class XsdIri : TokenPair
    {
        public XsdIri()
        {
        }
        public String IRIREF
        { get; set; }
        public PrefixedName PrefixedName
        { get; set; }

        public void Parse(SwrlContext context)
        {

            if (this.PrefixedName != null)
            {
                this.PrefixedName.Parse(context);
            }

        }

        public void Wise(SwrlContext context)
        {

            if (this.PrefixedName != null)
            {
                this.PrefixedName.Wise(context);
            }

        }

        public void Format(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.PrefixedName != null)
            {
                this.PrefixedName.Format(context, builder);
            }

        }

        public void BuildQuery(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.PrefixedName != null)
            {
                this.PrefixedName.BuildQuery(context, builder);
            }

        }

        public void BuildMock(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.PrefixedName != null)
            {
                this.PrefixedName.BuildMock(context, builder);
            }

        }

        public void BuildOther(SwrlContext context, IndentStringBuilder builder)
        {

            if (this.PrefixedName != null)
            {
                this.PrefixedName.BuildOther(context, builder);
            }

        }
    }
}