using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.OWL.Verbs
{
    class HasValue: BaseVerb
    {
        public HasValue()
        {
            this.Allow_Subject_Class = true;
            this.Allow_Subject_Instance = false;
            this.Allow_Subject_Property = false; 
        }

        public override string Name
        {
            get
            {
                return "owl:hasValue";
            }
        }

        public override bool Wise(string subject, string obj)
        {
            return base.Wise(subject, obj);
        }        
    }
}
