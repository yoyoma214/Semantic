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
            var varName = GetVarName(name);

            if (varName.StartsWith("@"))
                return "@" + name[0].ToString().ToUpper() + name.Substring(1);

            return name[0].ToString().ToUpper() + name.Substring(1);
        }

        public static string GetVarName(string name)
        {
            if (name.Equals("object", StringComparison.InvariantCultureIgnoreCase)
                || name.Equals("int", StringComparison.InvariantCultureIgnoreCase)
                || name.Equals("string", StringComparison.InvariantCultureIgnoreCase)
                || name.Equals("float", StringComparison.InvariantCultureIgnoreCase)
                || name.Equals("decimial", StringComparison.InvariantCultureIgnoreCase)
                || name.Equals("double", StringComparison.InvariantCultureIgnoreCase))
                name = "@" + name;

            if ( name.StartsWith("@"))
                return "@" + name[1].ToString().ToLower() + name.Substring(2);

            return name[0].ToString().ToLower() + name.Substring(1);
        }
    }
}
