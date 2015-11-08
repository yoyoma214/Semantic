using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.XSD.Facets
{
    class MaxInclusive : BaseFacet
    {
        public MaxInclusive()
            : base()
        {
            this.Name = "xsd:maxInclusive";
            this.NameSpace = NameSpaceEnum.XSD;
            this.AllowTypes.Add(BaseXsdType.UniType_Number);
            this.AllowTypes.Add(BaseXsdType.UniType_Time);     
        }
    }
}
