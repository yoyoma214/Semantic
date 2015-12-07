using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults.Sparqls.Base;

namespace CodeHelper.Core.Parse.ParseResults.Sparqls.Functions
{
    class Sha512 : BaseFunction
    {
        public Sha512()
            : base()
        {
            this.Name = "sha512";
        }
    }
}