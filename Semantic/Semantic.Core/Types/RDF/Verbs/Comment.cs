using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.RDF
{
    class Comment : BaseVerb
    {
        public Comment()
            : base()
        {
            this.Allow_Subject_Class = true;
            this.Allow_Subject_Instance = true;
            this.Allow_Subject_Property = true;
        }

        public override string Name
        {
            get
            {
                return "rdfs:comment";
            }
        }
    }
}
