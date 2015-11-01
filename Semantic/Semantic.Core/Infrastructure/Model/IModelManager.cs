using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Error;
using CodeHelper.Core.Parser;
using CodeHelper.Core.Types;
using CodeHelper.Core.Infrastructure.Command;
using Project;
using CodeHelper.Core.Parse.ParseResults;

namespace CodeHelper.Core.Infrastructure.Model
{
    public delegate void OnParseError(string file, List<ParseErrorInfo> errors);

    public interface IModelManager : IReceiverHolder
    {
        List<IParseModule> GetAlllModules(ParseType? type);

        void Regist(IModel model);

        //void RegistDb(ConnectionType conn);

        void Remove(IModel model);

        void Remove(Guid fileId);

        IModel GetModel(Guid fileId);

        event OnParseError ParseError;

        event OnParsed OnParsed;

        List<ITypeInfo> ParseType(string type, IParseModule ctx, out string error);

        IModel MakeSureModel(string file);

        List<ParseErrorInfo> Errors
        {
            get;
        }

        IParseModule MakeSureParseModule(string p);

        IParseModule GetParseModule(Guid fileId);

        void FireParsed(IModel model, bool sucess);

        ITypeInfo ResolveType(string nameSpace, string name);

        OWLProperty ResolveProperty(string nameSpace, string name);

        OWLInstance ResolveInstance(string nameSpace, string name);

        object Reslove(string nameSpace, string name);

        object Reslove(List<string> nameSpaces, string name);

        List<ITypeInfo> ListType(string nameSpace, string name, bool equal);

        List<ITypeInfo> ListType(List<string> nameSpaces, string name, bool equal);

        List<OWLProperty> ListProperty(string nameSpace, string name, bool equal);

        List<OWLProperty> ListProperty(List<string> nameSpaces, string name, bool equal);

        List<OWLInstance> ListInstance(string nameSpace, string name, bool equal);

        List<OWLInstance> ListInstance(List<string> nameSpaces, string name, bool equal);
    }
}