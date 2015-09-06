using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.RDF.Verbs
{
    class Range: BaseVerb
    {
        public Range()
        {            
            //this.Allow_Subject_Instance = true;
            this.Allow_Subject_Property = true; 
        }

        public override string Name
        {
            get
            {
                return "rdfs:range";
            }
        }

        public override bool Wise(string subject, string obj)
        {
            return base.Wise(subject, obj);
        }        
    }
}
