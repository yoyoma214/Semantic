using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.XSD
{
    class PlainLiteral : BaseXsdType
    {
        public override string NameSpace
        {
            get
            {
                return NameSpaceEnum.XSD;
            }
        }

        public override string Name
        {
            get
            {
                return "xsd:PlainLiteral";
            }
        }

        public override bool Wise(string verb)
        {
            return base.Wise(verb);
        }
    }
}
