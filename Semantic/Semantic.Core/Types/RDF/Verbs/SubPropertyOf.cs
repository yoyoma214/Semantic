using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.RDF.Verbs
{
    class SubPropertyOf: BaseVerb
    {
        public SubPropertyOf()
        {
            //this.Allow_Subject_Class = true;
            //this.Allow_Subject_Instance = true;
            this.Allow_Subject_Property = true; 
        }
        public override string NameSpace
        {
            get
            {
                return NameSpaceEnum.RDFS;
            }
        }

        public override string Name
        {
            get
            {
                return "rdfs:subPropertyOf";
            }
        }

        public override bool Wise(string subject, string obj)
        {
            return base.Wise(subject, obj);
        }        
    }
}
