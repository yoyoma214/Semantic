using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Types
{
    public interface IXsdType
    {
        string Name { get; }

        bool Wise(string verb);
    }
}
