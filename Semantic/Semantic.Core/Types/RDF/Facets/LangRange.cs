using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.RDF.Facets
{
    class LangRange: BaseFacet
    {
        public LangRange()
            : base()
        {
            this.Name = "xsd:langRange";
            this.NameSpace = NameSpaceEnum.XSD;
            this.AllowTypes.Add(BaseXsdType.UniType_String);            
            //this.AllowTypes.Add(BaseXsdType.UniType_Iri);
        }

        public override bool Validate(object val, out string error)
        {
            //rdf:PlainLiteral
            return base.Validate(val, out error);
        }
    }
}