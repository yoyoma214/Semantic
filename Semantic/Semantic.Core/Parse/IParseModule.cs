using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Error;
using CodeHelper.Core.Types;
using CodeHelper.Core.Parse;
using CodeHelper.Core.Parse.ParseResults;

namespace CodeHelper.Core.Parser
{
    public struct InputCharInfo
    {
        public char Char;
        public int Line;
        public int CharPositionInLine;
    }

    public interface IParseModule : IWiseble
    {
        string Subject { get; set; }

        string Verb { get; set; }

        string Object { get; set; }

        string Name { get; set; }

        InputCharInfo InputChar { get; set; }

        ParseType ParseType { get; set; }

        List<ParseErrorInfo> Errors { get; set; }

        string NameSpace { get; set; }

        Dictionary<string, string> UsingNameSpaces { get; set; }

        Guid FileId { get; set; }

        string File { get; set; }
        
        Dictionary<string, TypeInfoBase> Types { get; set; }

        Dictionary<string, OWLProperty> Properties { get; set; }

        Dictionary<string, OWLInstance> Instances { get; set; }   

        void Initialize();

        //void Wise();

        List<IParseModule> DependenceModules { get; set; }
    }
}
