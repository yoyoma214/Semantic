using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.RDF.Verbs
{
    public class RDF_Type : BaseVerb
    {
        public RDF_Type()
        {
            this.Allow_Subject_Class = true;
            this.Allow_Subject_Instance = true;
            this.Allow_Subject_Property = false; 
        }

        public override string Name
        {
            get
            {
                return "rdf:type";
            }
        }

        public override bool Wise(string subject, string obj)
        {
            return base.Wise(subject, obj);
        }        
    }
}
