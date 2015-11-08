using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.RDF.Verbs
{
    class SubClassOf: BaseVerb
    {
        public SubClassOf()
        {
            this.Allow_Subject_Class = true;
            //this.Allow_Subject_Instance = true;
            //this.Allow_Subject_Property = false; 
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
                return "rdfs:subClassOf";
                //return "subClassOf";
            }
        }

        public override bool Wise(string subject, string obj)
        {
            return base.Wise(subject, obj);
        }        
    }
}

