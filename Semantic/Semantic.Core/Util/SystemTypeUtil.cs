using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Util
{
    public static class SystemTypeUtil
    {
        private static Dictionary<string, Type> types = new Dictionary<string, Type>();

        static SystemTypeUtil()
        {
            types.Add("int", typeof(int));
            types.Add("Int32", typeof(int));
            types.Add("short", typeof(short));
            types.Add("string", typeof(string));
            types.Add("String", typeof(String));
            types.Add("double", typeof(double));
            types.Add("float", typeof(float));
            types.Add("decimal", typeof(decimal));
            types.Add("long", typeof(long));
            types.Add("Date", typeof(DateTime));
            types.Add("DateTime", typeof(DateTime));
        }

        public static bool IsEqual(string type1, string type2)
        {
            var typeA = types.ContainsKey(type1) ? types[type1] : null;
            var typeB = types.ContainsKey(type2) ? types[type2] : null;

            if (typeA == null || typeB == null) return false;

            return typeA == typeB;
        }
    }
}
