﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.XSD
{
    class UnsignedShort : BaseXsdType
    {
        public override string Name
        {
            get
            {
                return "xsd:unsignedShort";
            }
        }

        public override bool Wise(string verb)
        {
            return base.Wise(verb);
        }
    }
}
