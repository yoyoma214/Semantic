using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parser;

namespace CodeHelper.Core.Types
{
    public interface IVerb
    {
        string NameSpace { get; }

        string Name { get; }

        List<string> Domain { get; set; }

        List<string> Range { get; set; }

        bool Wise(string subject, string obj);

        List<string> AllowSubject(IParseModule module);

        List<string> AllowVerb(IParseModule module);

        List<string> AllowObject(IParseModule module);

        bool Allow_Subject_Class { get; set; }

        bool Allow_Subject_Instance { get; set; }

        bool Allow_Subject_Property { get; set; }
    }
}
