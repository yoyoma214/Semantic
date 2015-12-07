using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults.Sparqls.Base;

namespace CodeHelper.Core.Parse.ParseResults.Sparqls.Functions
{
    class Rand : BaseFunction
    {
        public Rand()
            : base()
        {
            this.Name = "rand";
        }
    }
}