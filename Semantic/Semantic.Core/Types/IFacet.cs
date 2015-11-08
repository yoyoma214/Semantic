using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parser;

namespace CodeHelper.Core.Types
{
    public interface IFacet
    {
        List<string> AllowTypes { get; }
        string Name { get; }
        string NameSpace { get; }
        bool Validate(object val, out string error);
        bool AllowDataType(OWLName dataType);
    }
}