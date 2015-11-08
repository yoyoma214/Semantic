using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.XSD.Facets
{
    class MaxExclusive : BaseFacet
    {
        public MaxExclusive()
            : base()
        {
            this.Name = "xsd:maxExclusive";
            this.NameSpace = NameSpaceEnum.XSD;
            this.AllowTypes.Add(BaseXsdType.UniType_Number);
            this.AllowTypes.Add(BaseXsdType.UniType_Time);            
        }
    }
}