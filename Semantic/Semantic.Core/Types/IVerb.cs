using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Types
{
    public interface IVerb
    {
        string Name { get; }

        List<string> Domain { get; set; }

        List<string> Range { get; set; }

        bool Wise(string subject, string obj);

        bool Allow_Subject_Class { get; set; }

        bool Allow_Subject_Instance { get; set; }

        bool Allow_Subject_Property { get; set; }
    }
}
