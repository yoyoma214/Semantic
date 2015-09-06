using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parser;

namespace CodeHelper.Core.Types.Base
{
    public class BaseVerb : IVerb
    {
        public virtual string Name
        {
            get;
            private set;
        }

        public List<string> Domain
        {
            get;
            set;
        }

        public List<string> Range
        {
            get;
            set;
        }

        public virtual bool Wise(string subject, string obj)
        {
            return true;
        }

        public bool Allow_Subject_Class
        {
            get;
            set;
        }

        public bool Allow_Subject_Instance
        {
            get;
            set;
        }

        public bool Allow_Subject_Property
        {
            get;
            set;
        }

        public virtual List<string> AllowSubject(IParseModule module)
        {
            return new List<string>();
        }
    }
}