using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Types.Base
{
    class BaseXsdType : IXsdType
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

        public virtual string NameSpace
        {
            get { throw new NotImplementedException(); }
        }
    }
}
