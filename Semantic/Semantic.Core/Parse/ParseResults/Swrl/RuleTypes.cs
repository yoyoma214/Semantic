using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults.Swrl.Base;
using CodeHelper.Core.Parse.ParseResults.Swrl.KeyWords;

namespace CodeHelper.Core.Parse.ParseResults.Swrl
{
    public class RuleTypes
    {
        public Dictionary<String, BaseFunction> Funcations { get; set; }
        public Dictionary<String, BaseKeyWord> KeyWords { get; set; }

        private RuleTypes()
        {
            this.Funcations = new Dictionary<string, BaseFunction>();
            this.KeyWords = new Dictionary<string, BaseKeyWord>();
            Init();
        }

        private static RuleTypes instance = new RuleTypes();

        public static RuleTypes Instance()
        {
            return instance;
        }

        private void Init()
        {            
            #region 关键字            
            this.AddKeyWord(new DLSafeRule());
            this.AddKeyWord(new Body());
            this.AddKeyWord(new Head());
            this.AddKeyWord(new Declaration());
            this.AddKeyWord(new Class());
            this.AddKeyWord(new Datatype());
            this.AddKeyWord(new ObjectProperty());
            this.AddKeyWord(new DataProperty());
            this.AddKeyWord(new AnnotationProperty());
            this.AddKeyWord(new NamedIndividual());
            this.AddKeyWord(new SubClassOf());
            this.AddKeyWord(new EquivalentClasses());
            this.AddKeyWord(new DisjointClasses());
            this.AddKeyWord(new DisjointUnion());
            this.AddKeyWord(new SubObjectPropertyOf());
            this.AddKeyWord(new ObjectPropertyChain());
            this.AddKeyWord(new EquivalentObjectProperties());
            this.AddKeyWord(new DisjointObjectProperties());
            this.AddKeyWord(new ObjectPropertyDomain());
            this.AddKeyWord(new ObjectPropertyRange());
            this.AddKeyWord(new InverseObjectProperties());
            this.AddKeyWord(new FunctionalObjectProperty());
            this.AddKeyWord(new InverseFunctionalObjectProperty());
            this.AddKeyWord(new ReflexiveObjectProperty());
            this.AddKeyWord(new IrreflexiveObjectProperty());
            this.AddKeyWord(new SymmetricObjectProperty());
            this.AddKeyWord(new AsymmetricObjectProperty());
            this.AddKeyWord(new TransitiveObjectProperty());
            this.AddKeyWord(new SubDataPropertyOf());
            this.AddKeyWord(new EquivalentDataProperties());
            this.AddKeyWord(new DisjointDataProperties());
            this.AddKeyWord(new DataPropertyDomain());
            this.AddKeyWord(new DataPropertyRange());
            this.AddKeyWord(new FunctionalDataProperty());
            this.AddKeyWord(new DatatypeDefinition());
            this.AddKeyWord(new HasKey());
            this.AddKeyWord(new ClassAtom());
            this.AddKeyWord(new DataRangeAtom());
            this.AddKeyWord(new ObjectPropertyAtom());
            this.AddKeyWord(new DataPropertyAtom());
            this.AddKeyWord(new BuiltInAtom());
            this.AddKeyWord(new SameIndividualAtom());
            this.AddKeyWord(new DifferentIndividualsAtom());
            this.AddKeyWord(new Variable());
            this.AddKeyWord(new DescriptionGraphRule());
            this.AddKeyWord(new DescriptionGraph());
            this.AddKeyWord(new Nodes());
            this.AddKeyWord(new NodeAssertion());
            this.AddKeyWord(new Edges());
            this.AddKeyWord(new EdgeAssertion());
            this.AddKeyWord(new MainClasses());
            this.AddKeyWord(new Annotation());
            this.AddKeyWord(new AnnotationAssertion());
            this.AddKeyWord(new SubAnnotationPropertyOf());
            this.AddKeyWord(new AnnotationPropertyDomain());
            this.AddKeyWord(new AnnotationPropertyRange());
            this.AddKeyWord(new ObjectIntersectionOf());
            this.AddKeyWord(new ObjectUnionOf());
            this.AddKeyWord(new ObjectComplementOf());
            this.AddKeyWord(new ObjectOneOf());
            this.AddKeyWord(new ObjectSomeValuesFrom());
            this.AddKeyWord(new ObjectAllValuesFrom());
            this.AddKeyWord(new ObjectHasValue());
            this.AddKeyWord(new ObjectHasSelf());
            this.AddKeyWord(new ObjectMinCardinality());
            this.AddKeyWord(new ObjectMaxCardinality());
            this.AddKeyWord(new ObjectExactCardinality());
            this.AddKeyWord(new DataSomeValuesFrom());
            this.AddKeyWord(new DataAllValuesFrom());
            this.AddKeyWord(new DataHasValue());
            this.AddKeyWord(new DataMinCardinality());
            this.AddKeyWord(new DataMaxCardinality());
            this.AddKeyWord(new DataExactCardinality());
            this.AddKeyWord(new SameIndividual());
            this.AddKeyWord(new DifferentIndividuals());
            this.AddKeyWord(new ClassAssertion());
            this.AddKeyWord(new ObjectPropertyAssertion());
            this.AddKeyWord(new NegativeObjectPropertyAssertion());
            this.AddKeyWord(new DataPropertyAssertion());
            this.AddKeyWord(new NegativeDataPropertyAssertion());
            this.AddKeyWord(new DataIntersectionOf());
            this.AddKeyWord(new DataUnionOf());
            this.AddKeyWord(new DataComplementOf());
            this.AddKeyWord(new DataOneOf());
            this.AddKeyWord(new ObjectInverseOf());
            this.AddKeyWord(new DatatypeRestriction());
            #endregion

            #region 函数
            //this.AddFunction(new Abs());
            //this.AddFunction(new Bnode());
            //this.AddFunction(new Bound());
            //this.AddFunction(new Cell());
            //this.AddFunction(new Coalesc());
            //this.AddFunction(new Concat());
            //this.AddFunction(new Contains());
            //this.AddFunction(new DataType());
            //this.AddFunction(new Day());
            //this.AddFunction(new Encode_for_uri());
            //this.AddFunction(new Floor());
            //this.AddFunction(new Hours());
            //this.AddFunction(new If());
            //this.AddFunction(new IriN());
            //this.AddFunction(new IsBlank());
            //this.AddFunction(new IsIri());
            //this.AddFunction(new IsLiteral());
            //this.AddFunction(new IsNumber());
            //this.AddFunction(new IsUri());
            //this.AddFunction(new Lang());
            //this.AddFunction(new Langmatches());
            //this.AddFunction(new Lcase());
            //this.AddFunction(new Md5());
            //this.AddFunction(new Minutes());
            //this.AddFunction(new Month());
            //this.AddFunction(new Now());
            //this.AddFunction(new Rand());
            //this.AddFunction(new Regex());
            //this.AddFunction(new Replace());
            //this.AddFunction(new Round());
            //this.AddFunction(new SameTerm());
            //this.AddFunction(new Seconds());
            //this.AddFunction(new Sha1());
            //this.AddFunction(new Sha256());
            //this.AddFunction(new Sha384());
            //this.AddFunction(new Sha512());
            //this.AddFunction(new Str());
            //this.AddFunction(new StrAfter());
            //this.AddFunction(new StrBefore());
            //this.AddFunction(new StrDT());
            //this.AddFunction(new StrEnds());
            //this.AddFunction(new StrLang());
            //this.AddFunction(new StrLen());
            //this.AddFunction(new StrStarts());
            //this.AddFunction(new StrUUID());
            //this.AddFunction(new Substr());
            //this.AddFunction(new Timezone());
            //this.AddFunction(new Tz());
            //this.AddFunction(new Ucase());
            //this.AddFunction(new UriN());
            //this.AddFunction(new UUID());
            //this.AddFunction(new Year());            
            #endregion
        }

        private void AddKeyWord(BaseKeyWord keyWord)
        {
            this.KeyWords.Add(keyWord.Name, keyWord);
        }

        private void AddFunction(BaseFunction funcation)
        {
            this.Funcations.Add(funcation.Name, funcation);
        }

        public List<String> AllKeyWords()
        {
            var rslt = this.KeyWords.Keys.ToList();
            rslt.Sort();
            return rslt;
        }

        public List<String> AllFunctions()
        {
            var rslt = this.Funcations.Keys.ToList();
            rslt.Sort();
            return rslt;
        }
    }
}