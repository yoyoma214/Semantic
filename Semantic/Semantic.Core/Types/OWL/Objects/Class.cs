﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.OWL.Objects
{
    class Class : BaseObject
    {
        public override string Name
        {
            get
            {
                return "owl:Class";
            }
        }

        public override bool Wise(string verb)
        {
            return base.Wise(verb);
        }
    }
}

