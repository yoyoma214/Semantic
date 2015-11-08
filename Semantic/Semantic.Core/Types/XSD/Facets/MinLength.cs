using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.XSD.Facets
{
    class MinLength : BaseFacet
    {
        public MinLength()
            : base()
        {
            this.Name = "xsd:minLength";
            this.NameSpace = NameSpaceEnum.XSD;
            this.AllowTypes.Add(BaseXsdType.UniType_String);
            this.AllowTypes.Add(BaseXsdType.UniType_Binary);
            this.AllowTypes.Add(BaseXsdType.UniType_Iri);
        }
    }
}