using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse
{
    public interface IToken
    {
        int Line { get;}
        int CharPositionInLine { get; set; }
        int EndCharPositionInLine { get; }
        int Length { get; }
    }
}
