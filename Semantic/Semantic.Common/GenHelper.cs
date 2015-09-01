using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Common
{
    public static class GenHelper
    {
        public static string GetClassNameOld(string name)
        {
            return name[0].ToString().ToUpper() + name.Substring(1);
        }

        public static string GetClassName(string name,bool special = false)
        {
            var varName = GetVarName(name, special);

            return varName[0].ToString().ToUpper() + varName.Substring(1);
        }

        public static string GetVarName(string name, bool special = false)
        {
            if (name.Equals("object", StringComparison.InvariantCultureIgnoreCase)
                || name.Equals("int", StringComparison.InvariantCultureIgnoreCase)
                || name.Equals("string", StringComparison.InvariantCultureIgnoreCase)
                || name.Equals("float", StringComparison.InvariantCultureIgnoreCase)
                || name.Equals("decimial", StringComparison.InvariantCultureIgnoreCase)
                || name.Equals("double", StringComparison.InvariantCultureIgnoreCase))
                name = "@" + name;

            var newName = Special(name, special);
        

            if (newName.StartsWith("@"))
                return "@" + newName[1].ToString().ToLower() + newName.Substring(2);

            return newName[0].ToString().ToLower() + newName.Substring(1);
        }

        private static string Special(string name, bool special)
        {
            if (special)
                return name;

            var newName = "";

            var prev_underline = false;

            for (var index = 0; index < name.Length; index++)
            {

                if (name[index] == '_')
                {
                    prev_underline = true;
                    continue;
                }


                if (prev_underline)
                {
                    newName += char.ToUpper(name[index]);
                    prev_underline = false;
                }
                else
                {
                    newName += name[index];
                }

            }

            return newName;
        }
    }
}
