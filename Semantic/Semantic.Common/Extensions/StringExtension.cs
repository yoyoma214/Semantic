using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Common.Extensions
{
    public static class StringExtension
    {
        public static T JsonToObject<T>(this string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        public static int CountIndex(this string text, int line, int charInLine)
        {           
            var lint_count = 1 ;
            for (var i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    lint_count++;
                }

                if (lint_count == line)
                {
                    return i + charInLine;                    
                }
            }

            return -1;
        }
    }
}
