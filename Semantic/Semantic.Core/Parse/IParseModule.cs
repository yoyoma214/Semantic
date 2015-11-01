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

    /// <summary>
    /// 标准的名字结构
    /// </summary>
    public struct OWLName
    {
        /// <summary>
        /// 命名空间
        /// </summary>
        public String NameSpace { get; set; }

        /// <summary>
        /// 本地名称
        /// </summary>
        public String LocalName { get; set; }

        public static string ParseLocalName(string name)
        {
            var ss = name.Split(new char[] { ':' } , StringSplitOptions.RemoveEmptyEntries);
            if (ss.Length == 1)
                return ss[0];

            return ss[1];
        }
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

        Dictionary<string, TypeInfoBase> Types { get; }

        Dictionary<string, OWLProperty> Properties { get; }

        Dictionary<string, OWLInstance> Instances { get; }   

        void Initialize();

        //void Wise();

        List<IParseModule> DependenceModules { get; set; }

        /// <summary>
        /// 得到标准的名字结构
        /// </summary>
        /// <param name="mixedName"></param>
        /// <returns></returns>
        OWLName ResloveName(string mixedName);

        TypeInfoBase ResloveType(string nameSpace,string name);

        OWLProperty ResloveProperty(string nameSpace, string name);

        OWLInstance ResloveInstance(string nameSpace, string name);

        Object Reslove(string nameSpace, string name);

        List<Object> AnySeeAble(string nameSpace, string name, bool equal);

        List<TypeInfoBase> TypeSeeAble(string nameSpace, string name, bool equal);

        List<OWLProperty> PropertySeeAble(string nameSpace, string name, bool equal);

        List<OWLInstance> InstanceSeeAble(string nameSpace, string name, bool equal);

        /// <summary>
        /// 得到名称空间的本地名字，如果没有在当前模块中申明则返回null
        /// </summary>
        /// <param name="fullNameSpace"></param>
        /// <returns></returns>
        string GetLocalNameSpace(string fullNameSpace);

        /// <summary>
        /// 得到命名空间的全名称，如果没有在当前模块中申明则返回null
        /// </summary>
        /// <param name="shortNameSpace"></param>
        /// <returns></returns>
        string GetFullNameSpace(string shortNameSpace);
    }
}
