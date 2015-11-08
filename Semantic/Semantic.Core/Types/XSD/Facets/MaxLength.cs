using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.XSD.Facets
{
    class MaxLength : BaseFacet
    {
        public MaxLength()
            : base()
        {
            this.Name = "xsd:maxLength";
            this.NameSpace = NameSpaceEnum.XSD;
            this.AllowTypes.Add(BaseXsdType.UniType_String);
            this.AllowTypes.Add(BaseXsdType.UniType_Binary);
            this.AllowTypes.Add(BaseXsdType.UniType_Iri);
        }
    }
}
