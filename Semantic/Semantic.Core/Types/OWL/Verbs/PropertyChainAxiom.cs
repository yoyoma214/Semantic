using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.OWL.Verbs
{
    class PropertyChainAxiom: BaseVerb
    {
        public PropertyChainAxiom()
        {
            //this.Allow_Subject_Class = true;
            //this.Allow_Subject_Instance = true;
            this.Allow_Subject_Property = true; 
        }

        public override string Name
        {
            get
            {
                return "owl:propertyChainAxiom";
            }
        }

        public override bool Wise(string subject, string obj)
        {
            return base.Wise(subject, obj);
        }        
    }
}
