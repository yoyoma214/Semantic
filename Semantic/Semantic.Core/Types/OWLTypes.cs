using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults;
using CodeHelper.Core.Types.Base;
using CodeHelper.Core.Types.RDF.Verbs;
using CodeHelper.Core.Types.RDF;
using CodeHelper.Core.Types.OWL.Verbs;
using CodeHelper.Core.Types.XSD;
using CodeHelper.Core.Types.OWL.Objects;
using CodeHelper.Core.Types.RDF.Objects;
using CodeHelper.Core.Services;

namespace CodeHelper.Core.Types
{
    public class OWLTypes
    {
        //public Dictionary<string, ITypeInfo> RDF_Types { get; set; }

        //public Dictionary<string, ITypeInfo> RDFS_Types { get; set; }

        //public Dictionary<string, ITypeInfo> OWL_Typtes { get; set; }

        //public Dictionary<string, ITypeInfo> OWL_Properties { get; set; }

        public Dictionary<string, IXsdType> XSD_Typtes { get; set; }

        public Dictionary<string, BaseVerb> Ver_Types { get; set; }

        public Dictionary<string, IObject> Object_Types { get; set; }

        //public TurtleModule RdfModule { get; set; }

        //public TurtleModule RdfsModule { get; set; }

        //public TurtleModule OwlModule { get; set; }

        //public TurtleModule XsdModule { get; set; }

        private OWLTypes()
        {
            //this.RDF_Types = new Dictionary<string, ITypeInfo>();
            //this.RDFS_Types = new Dictionary<string, ITypeInfo>();
            //this.OWL_Typtes = new Dictionary<string, ITypeInfo>();
            //this.OWL_Properties = new Dictionary<string, ITypeInfo>();

            this.XSD_Typtes = new Dictionary<string, IXsdType>();
            this.Ver_Types = new Dictionary<string, BaseVerb>();
            this.Object_Types = new Dictionary<string, IObject>();

            //this.RdfModule = new TurtleModule();
            //this.RdfModule.Name = "rdf";
            //this.RdfModule.NameSpace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#";
            
            //this.RdfsModule = new TurtleModule();
            //this.RdfModule.Name = "rdfs";
            //this.RdfModule.NameSpace = "http://www.w3.org/2000/01/rdf-schema#";

            //this.OwlModule = new TurtleModule();
            //this.OwlModule.Name = "owl";
            //this.OwlModule.NameSpace = "http://www.w3.org/2002/07/owl#>";

            //this.XsdModule = new TurtleModule();
            //this.XsdModule.Name = "xsd";
            //this.XsdModule.NameSpace = "http://www.w3.org/2001/XMLSchema#";

            Init();
        }

        private static OWLTypes instance = new OWLTypes();

        public static OWLTypes Instance()
        {
            return instance;
        }

        private void Init()
        {
            BaseVerb type = null;

            #region verb 

            #region rdf
            //type.Name = "rdf:type";
            type = new RDF_Type();
            this.Ver_Types.Add(type.Name,type);
            
            #endregion
            
            #region rdfs
           
            type = new SubClassOf();
            this.Ver_Types.Add(type.Name, type);
            
            type = new SubPropertyOf();
            this.Ver_Types.Add(type.Name, type);
            
            type = new Domain();
            this.Ver_Types.Add(type.Name, type);
            
            type = new Range();
            this.Ver_Types.Add(type.Name, type);
                        
            type = new Comment();
            this.Ver_Types.Add(type.Name, type);         
            #endregion

            #region owl
            
            type = new EquivalentClass();
            this.Ver_Types.Add(type.Name, type);
            
            type = new DifferentFrom();
            this.Ver_Types.Add(type.Name, type);
            
            type = new SameAs();
            this.Ver_Types.Add(type.Name, type);
            
            type = new SourceIndividual();
            this.Ver_Types.Add(type.Name, type);
            
            type = new AssertionProperty();
            this.Ver_Types.Add(type.Name, type);
            
            type = new TargetValue();
            this.Ver_Types.Add(type.Name, type);
            
            type = new IntersectionOf();
            this.Ver_Types.Add(type.Name, type);
            
            type = new UnionOf();
            this.Ver_Types.Add(type.Name, type);
                        
            type = new OnProperty();
            this.Ver_Types.Add(type.Name, type);
            
            type = new SomeValuesFrom();
            this.Ver_Types.Add(type.Name, type);
            
            type = new AllValuesFrom();
            this.Ver_Types.Add(type.Name, type);
            
            type = new HasValue();
            this.Ver_Types.Add(type.Name, type);
            
            type = new HasSelf();
            this.Ver_Types.Add(type.Name, type);
            
            type = new OnClass();
            this.Ver_Types.Add(type.Name, type);
            
            type = new MinQualifiedCardinality();
            this.Ver_Types.Add(type.Name, type);
            
            type = new QualifiedCardinality();
            this.Ver_Types.Add(type.Name, type);
            
            type = new Cardinality();
            this.Ver_Types.Add(type.Name, type);
            
            type = new OneOf();
            this.Ver_Types.Add(type.Name, type);
            
            type = new InverseOf();
            this.Ver_Types.Add(type.Name, type);                   
                       
            type = new PropertyDisjointWith();
            this.Ver_Types.Add(type.Name, type);
                       
            type = new PropertyChainAxiom();
            this.Ver_Types.Add(type.Name, type);
            
            type = new HasKey();
            this.Ver_Types.Add(type.Name, type);
            
            type = new OnDatatype();
            this.Ver_Types.Add(type.Name, type);
            
            type = new WithRestrictions();
            this.Ver_Types.Add(type.Name, type);
            
            type = new DatatypeComplementOf();
            this.Ver_Types.Add(type.Name, type);
            
            type = new AnnotatedSource();
            this.Ver_Types.Add(type.Name, type);
            
            type = new AnnotatedProperty();
            this.Ver_Types.Add(type.Name, type);
            
            type = new AnnotatedTarget();
            this.Ver_Types.Add(type.Name, type);
            
            type = new EquivalentProperty();
            this.Ver_Types.Add(type.Name, type);
            #endregion            

            #endregion

            IXsdType xsd = null;

            #region xsd
            xsd = new AnyURI();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new Base64Binary();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new BooleanN();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new ByteN();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new DateTimeN();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new DateTimeStamp();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new DecimalN();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new DoubleN();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new FloatN();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new HexBinary();
            this.XSD_Typtes.Add(xsd.Name, xsd);

            xsd = new IntN();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new IntegerN();
            this.XSD_Typtes.Add(xsd.Name, xsd);
           
            xsd = new Language();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new Literal();
            this.XSD_Typtes.Add(xsd.Name, xsd);
           
            xsd = new LongN();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new NameN();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new NCName();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new NegativeInteger();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new NMTOKEN();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new NonNegativeInteger();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new NonPostiveInteger();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new NormalizeString();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new PlainLiteral();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new PostiveInteger();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new Rational();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new Real();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new ShortN();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new StringN();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new TokenN();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new UnsignedByte();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new UnsignedInt();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new UnsignedLong();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new UnsignedShort();
            this.XSD_Typtes.Add(xsd.Name, xsd);
            
            xsd = new XMLLiteral();
            this.XSD_Typtes.Add(xsd.Name, xsd);

            #endregion

            IObject obj = null;

            #region object
               
            obj = new SymmetricProperty();
            this.Object_Types.Add(obj.Name, obj);
     
            obj = new AsymmetricProperty();
            this.Object_Types.Add(obj.Name, obj);
     
            obj = new ReflexiveProperty();
            this.Object_Types.Add(obj.Name, obj);
            
            obj = new IrreflexiveProperty();
            this.Object_Types.Add(obj.Name, obj);

            obj = new FunctionalProperty();
            this.Object_Types.Add(obj.Name, obj);
            
            obj = new InverseFunctionalProperty();
            this.Object_Types.Add(obj.Name, obj);
            
            obj = new TransitiveProperty();
            this.Object_Types.Add(obj.Name, obj);
            
            obj = new Datatype();
            this.Object_Types.Add(obj.Name, obj);
            
            obj = new Restriction();
            this.Object_Types.Add(obj.Name, obj);
            
            obj = new NamedIndividual();
            this.Object_Types.Add(obj.Name, obj);
            
            obj = new Class();
            this.Object_Types.Add(obj.Name, obj);
            
            obj = new ObjectProperty();
            this.Object_Types.Add(obj.Name, obj);
            
            obj = new DatatypeProperty();
            this.Object_Types.Add(obj.Name, obj);
            
            obj = new NegativePropertyAssertion();
            this.Object_Types.Add(obj.Name, obj);
            #endregion
        }
    }
}