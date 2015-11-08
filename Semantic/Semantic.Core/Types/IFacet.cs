using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Types
{
    interface IFacet
    {
        List<string> AllowTypes { get; }
        string Name { get; set; }
        string NameSpace { get; set; }
        bool Validate(object val , out string error);
    }
}