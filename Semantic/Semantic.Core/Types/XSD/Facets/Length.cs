using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.XSD.Facets
{
    class Length : BaseFacet
    {
        public Length()
            : base()
        {
            this.Name = "xsd:length";
            this.NameSpace = NameSpaceEnum.XSD;
            this.AllowTypes.Add(BaseXsdType.UniType_String);
            this.AllowTypes.Add(BaseXsdType.UniType_Binary);
            this.AllowTypes.Add(BaseXsdType.UniType_Iri);
        }
    }
}