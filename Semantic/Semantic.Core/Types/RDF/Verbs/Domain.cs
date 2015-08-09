using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.RDF.Verbs
{
    class Domain: BaseVerb
    {
        public Domain()
            : base()
        {
            this.Allow_Subject_Class = true;
        }

        public override string Name
        {
            get
            {
                return "rdfs:domain";
            }
        }
    }
}