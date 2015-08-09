using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Types
{
    public interface IObject
    {
        string Name { get; }
        
        bool Wise(string verb);

        bool Allow_Verb_Class { get; set; }  
    }
}
