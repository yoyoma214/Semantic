﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.OWL.Verbs
{
    class Cardinality: BaseVerb
    {
        public Cardinality()
        {
            this.Allow_Subject_Class = false;
            this.Allow_Subject_Instance = false;
            this.Allow_Subject_Property = true; 
        }

        public override string Name
        {
            get
            {
                return "owl:cardinality";
            }
        }

        public override bool Wise(string subject, string obj)
        {
            return base.Wise(subject, obj);
        }        
    }
}
