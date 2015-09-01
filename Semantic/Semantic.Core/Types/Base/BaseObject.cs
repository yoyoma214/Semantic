using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Types.Base
{
    class BaseObject : IObject
    {
        public virtual string Name
        {
            get;
            private set;
        }

        public virtual bool Wise(string verb)
        {
            return true;
        }

        public bool Allow_Verb_Class
        {
            get;
            set;
        }
    }
}
