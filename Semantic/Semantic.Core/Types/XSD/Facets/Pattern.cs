using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.XSD.Facets
{
    class Pattern: BaseFacet
    {
        public Pattern()
            : base()
        {
            this.Name = "xsd:pattern";
            this.NameSpace = NameSpaceEnum.XSD;
            this.AllowTypes.Add(BaseXsdType.UniType_String);            
            this.AllowTypes.Add(BaseXsdType.UniType_Iri);
        }
    }
}
