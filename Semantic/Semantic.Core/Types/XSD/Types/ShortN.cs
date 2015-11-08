using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.XSD
{
    class ShortN : BaseXsdType
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
                return "xsd:short";
            }
        }

        public override bool Wise(string verb)
        {
            return base.Wise(verb);
        }
    }
}