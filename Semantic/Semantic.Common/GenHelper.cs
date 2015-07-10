using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Common
{
    public static class GenHelper
    {
        public static string GetClassName(string name)
        {
            return name[0].ToString().ToUpper() + name.Substring(1);
        }

        public static string GetVarName(string name)
        {
            if (name.Equals("object") || name.Equals("int") || name.Equals("string") || name.Equals("float") || name.Equals("decimial") || name.Equals("double"))
                name += "_";

            return name[0].ToString().ToLower() + name.Substring(1);
        }
    }
}
