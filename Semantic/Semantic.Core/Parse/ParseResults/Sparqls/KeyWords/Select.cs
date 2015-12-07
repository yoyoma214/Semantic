using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults.Sparqls.Base;

namespace CodeHelper.Core.Parse.ParseResults.Sparqls.KeyWords
{
    class Select : BaseKeyWord
    {
        public Select()
            : base()
        {
            this.Name = "SELECT";
        }
    }
}