﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.XSD
{
    class BooleanN : BaseXsdType
    {
        public override string Name
        {
            get
            {
                return "xsd:boolean";
            }
        }

        public override bool Wise(string verb)
        {
            return base.Wise(verb);
        }
    }
}
