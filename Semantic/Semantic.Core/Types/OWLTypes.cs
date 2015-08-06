using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults;

namespace CodeHelper.Core.Types
{
    public class OWLTypes
    {
        //public Dictionary<string, ITypeInfo> RDF_Types { get; set; }

        //public Dictionary<string, ITypeInfo> RDFS_Types { get; set; }

        //public Dictionary<string, ITypeInfo> OWL_Typtes { get; set; }

        //public Dictionary<string, ITypeInfo> OWL_Properties { get; set; }

        public Dictionary<string, ITypeInfo> XSD_Typtes { get; set; }

        public Dictionary<string, ITypeInfo> Ver_Types { get; set; }

        public Dictionary<string, ITypeInfo> Object_Types { get; set; }
                

        private OWLTypes()
        {
            //this.RDF_Types = new Dictionary<string, ITypeInfo>();
            //this.RDFS_Types = new Dictionary<string, ITypeInfo>();
            //this.OWL_Typtes = new Dictionary<string, ITypeInfo>();
            //this.OWL_Properties = new Dictionary<string, ITypeInfo>();

            this.XSD_Typtes = new Dictionary<string, ITypeInfo>();
            this.Ver_Types = new Dictionary<string, ITypeInfo>();
            this.Object_Types = new Dictionary<string, ITypeInfo>();

            Init();
        }

        private static OWLTypes instance = new OWLTypes();

        public static OWLTypes Instance()
        {
            return instance;
        }

        private void Init()
        {
            var type = new TypeInfoBase();

            #region verb 

            #region rdf
            type.Name = "rdf:type";
            this.Ver_Types.Add(type.Name, type);
            #endregion
            
            #region rdfs
            type.Name = "rdfs:subClassOf";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "rdfs:subPropertyOf";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "rdfs:domain";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "rdfs:range";
            this.Ver_Types.Add(type.Name, type);
            
            type.Name = "rdfs:comment";
            this.Ver_Types.Add(type.Name, type);           
            #endregion

            #region owl
            type.Name = "owl:equivalentClass";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:differentFrom";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:sameAs";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:sourceIndividual";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:assertionProperty";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:targetValue";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:intersectionOf";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:unionOf";
            this.Ver_Types.Add(type.Name, type);
            
            type.Name = "owl:onProperty";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:someValuesFrom";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:allValuesFrom";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:hasValue";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:hasSelf";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:onClass";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:minQualifiedCardinality";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:qualifiedCardinality";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:cardinality";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:oneOf";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:inverseOf";
            this.Ver_Types.Add(type.Name, type);                      
           
            type.Name = "owl:propertyDisjointWith";
            this.Ver_Types.Add(type.Name, type);
           
            type.Name = "owl:propertyChainAxiom";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:hasKey ";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:onDatatype";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:withRestrictions";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:datatypeComplementOf";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:annotatedSource";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:annotatedProperty";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:annotatedTarget";
            this.Ver_Types.Add(type.Name, type);

            type.Name = "owl:equivalentProperty";
            this.Ver_Types.Add(type.Name, type); 
            #endregion            

            #endregion

            #region xsd
            type.Name = "xsd:anyURI";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:base64Binary";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:boolean";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:byte";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:dateTime";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:dateTimeStamp";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:decimal";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:double";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:float";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:hexBinary";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:int";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:integer";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:language";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:Literal";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:long";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:Name";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:NCName";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:negativeInteger";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:NMTOKEN";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:nonNegativeInteger";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:nonPostiveInteger";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:normalizeString";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:PlainLiteral";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:postiveInteger";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:rational";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:real";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:short";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:string";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:token";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:unsignedByte";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:unsignedInt";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:unsignedLong";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:unsignedShort";
            this.XSD_Typtes.Add(type.Name, type);

            type.Name = "xsd:XMLLiteral";
            this.XSD_Typtes.Add(type.Name, type);

            #endregion

            #region object
            type.Name = "owl:SymmetricProperty";
            this.Object_Types.Add(type.Name, type);

            type.Name = "owl:AsymmetricProperty";
            this.Object_Types.Add(type.Name, type);

            type.Name = "owl:ReflexiveProperty";
            this.Object_Types.Add(type.Name, type);

            type.Name = "owl:IrreflexiveProperty";
            this.Object_Types.Add(type.Name, type);

            type.Name = "owl:FunctionalProperty";
            this.Object_Types.Add(type.Name, type);

            type.Name = "owl:InverseFunctionalProperty";
            this.Object_Types.Add(type.Name, type);

            type.Name = "owl:TransitiveProperty";
            this.Object_Types.Add(type.Name, type);

            type.Name = "rdfs:Datatype";
            this.Object_Types.Add(type.Name, type);

            type.Name = "owl:Restriction";
            this.Object_Types.Add(type.Name, type);

            type.Name = "owl:NamedIndividual";
            this.Object_Types.Add(type.Name, type);

            type.Name = "owl:Class";
            this.Object_Types.Add(type.Name, type);

            type.Name = "owl:ObjectProperty";
            this.Object_Types.Add(type.Name, type);

            type.Name = "owl:DatatypeProperty";
            this.Object_Types.Add(type.Name, type);

            type.Name = "owl:NegativePropertyAssertion";
            this.Object_Types.Add(type.Name, type);
            #endregion
        }
    }
}
