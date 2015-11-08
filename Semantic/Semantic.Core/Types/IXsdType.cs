using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Types
{
    public interface IXsdType
    {
        string NameSpace { get; }

        string Name { get; }

        bool Wise(string verb);

        string UniversalDataType { get; }

        bool IsNumber();

        bool IsString();

        bool IsBoolean();

        bool IsBinary();

        bool IsIri();

        bool IsTime();

        bool IsXmlLiteral();
    }
}
