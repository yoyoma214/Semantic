using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using CodeHelper.Domain.Model.XmlModels;
//using CodeHelper.Domain.Model.DataModels;
using CodeHelper.Core.Infrastructure.Model;
using CodeHelper.Core.Parser;
using System.Threading;
using CodeHelper.Parser;
//using CodeHelper.Core.Parse.ParseResults.XmlModels;
using Newtonsoft.Json;
//using CodeHelper.Core.Parse.ParseResults.DataModels;
using CodeHelper.Core.Error;
using CodeHelper.Core.Services;
using System.IO;
using CodeHelper.Core.Types;
using CodeHelper.Core.Parse.ParseResults;
using CodeHelper.Core.Infrastructure.Command;
using CodeHelper.Core.Command;
using CodeHelper.Commands;
using Project;

namespace CodeHelper.Domain.Model
{
    public partial class ModelManager : IModelManager
    {
        ReceiverBase receiver = new ReceiverBase();

        public ReceiverBase Receiver
        {
            get
            {
                return receiver;
            }
        }

        AutoResetEvent ResetEvent = new AutoResetEvent(false);

        WorkEngine workEngine = new WorkEngine();

        //bool engineWaiting = false;
        //object objSync = new object();

        DateTime autoParseTime;

        //Semaphore semaphore = new Semaphore(0, 1000);

        const int AUTO_PARSE_INTERVAL = 2;

        public event OnParseError ParseError;

        public event OnParsed OnParsed;

        public List<ParseErrorInfo> Errors
        {
            get;
            set;
        }

        /// <summary>
        /// 1 : true 0 :false
        /// </summary>
        private long WiseCompeleted = 0;

        /// <summary>
        /// 1 : true 0 :false
        /// </summary>
        private long EnableAutoParse = 0;

        private Dictionary<Guid, IModel> Models = new Dictionary<Guid, IModel>();

        private Dictionary<Guid, IParseModule> ParseModules = new Dictionary<Guid, IParseModule>();

        private Dictionary<string, List<IParseModule>> Namespace_Modules
                                                  = new Dictionary<string, List<IParseModule>>();

        public List<IParseModule> GetAlllModules(ParseType? type)
        {
            var rslt = new List<IParseModule>();
            foreach (var m in ParseModules.Values)
            {
                if (type.HasValue)
                {
                    if (type == m.ParseType)
                        rslt.Add(m);
                }
                else
                {
                    rslt.Add(m);
                }
            }
            return rslt;
        }

        //private Dictionary<string, ITypeInfo> Types = new Dictionary<string, ITypeInfo>();

        private ModelManager()
        {
            autoParseTime = DateTime.Now;
            EnableAutoParse = 1;

            //var cmdHost_common = CommandHostManager.Instance().Get(CommandHostManager.HostType.Common);
            //cmdHost_common.AddCommand(new ExitProcessCommand(this.Receiver));

            this.Errors = new List<ParseErrorInfo>();

            GlobalService.Idle += new EventHandler(GlobalService_Idle);

            this.receiver.OnExitProcess += new ReceiverBase.ExitProcessHandler(receiver_OnExitProcess);
            workEngine.WiseCompleted += new OnWiseCompleted(workEngine_WiseCompleted);
            workEngine.Continue += new OnContinue(workEngine_Continue);
            workEngine.Start();
        }

        bool receiver_OnExitProcess()
        {
            this.workEngine.Stop();

            return false;
        }

        void workEngine_Continue()
        {
            //this.engineWaiting = false; 
        }

        void workEngine_WiseCompleted(List<ParseErrorInfo> errors)
        {
            if (this.ParseError != null && errors != null)
            {
                var copy = new ParseErrorInfo[errors.Count];
                errors.CopyTo(copy);
                this.ParseError(null, copy.ToList());
            }

            this.Errors = errors;
            this.ResetEvent.Set();
        }

        public IModel MakeSureModel(string file)
        {

            foreach (var m in Models.Values)
            {
                if (m.File == file)
                {
                    return m;
                }
            }

            var extension = Path.GetExtension(file);

            IModel model = null;

            if (extension == Dict.Extenstions.Turtle_Extension)
            {
                model = new Domain.Model.TurtleModels.TurtleModel();
            }
            else if (extension == Dict.Extenstions.Antlr4_Extension)
            {
                model = new Domain.Model.Antlr4Models.Antlr4Model();
            }
            else if (extension == Dict.Extenstions.Sparql_Extension)
            {
                model = new Domain.Model.SparqlModels.SparqlModel();
            }
            model.FileId = Guid.NewGuid();

            model.File = file;

            model.Open();

            this.Regist(model);

            return model;
        }

        private bool mClearError = false;

        void GlobalService_Idle(object sender, EventArgs e)
        {
            if (DateTime.Now.Subtract(autoParseTime).TotalSeconds > AUTO_PARSE_INTERVAL
             && Interlocked.Read(ref EnableAutoParse) == 1
             )
            {
                if (this.workEngine.IsWiseCompleted)
                {
                    var waitingForParseModels = this.Models.Values.Where(x =>

                        !x.IsParsed && x.Content.Count(c => c == '\n') > 2)//至少有3行

                        .ToList();

                    waitingForParseModels.ForEach(x =>
                            this.workEngine.AddWaitingParseModel(x)
                     );

                    if (waitingForParseModels.Count > 0)
                    {
                        this.workEngine.ActiveOneTime();
                    }
                }
            }
        }

        private static ModelManager instance = new ModelManager();

        public static ModelManager Instance()
        {
            return instance;
        }

        public IParseModule MakeSureParseModule(string file)
        {

            var model = this.MakeSureModel(file);

            if (this.workEngine.ParsedModules.ContainsKey(model.FileId))
                return this.workEngine.ParsedModules[model.FileId];

            this.workEngine.AddWaitingParseModel(model);

            this.workEngine.ActiveOneTime();

            ResetEvent.WaitOne(10000);

            if (this.workEngine.ParsedModules.ContainsKey(model.FileId))
                return this.workEngine.ParsedModules[model.FileId];

            return null;

        }

        public void Regist(IModel model)
        {
            this.Models.Add(model.FileId, model);

            OnRegist(model);

        }

        private void OnRegist(IModel model)
        {
            model.ChangeName += new OnChangeName(model_ChangeName);
            model.InvokeParse += new OnInvokeParse(model_InvokeParse);
            model.Removed += new OnRemoved(model_Removed);
        }

        private void OnRemove(IModel model)
        {
            model.ChangeName -= new OnChangeName(model_ChangeName);
            model.InvokeParse -= new OnInvokeParse(model_InvokeParse);
            model.Removed -= new OnRemoved(model_Removed);
        }

        private string GetNameSpace(string s)
        {
            return string.IsNullOrWhiteSpace(s) ? "" : s.Trim();
        }

        void model_InvokeParse(IModel model, int charIndex)
        {
            //throw new NotImplementedException();
        }

        void model_Removed(IModel model)
        {
            throw new NotImplementedException();
        }

        void model_ChangeName(IModel model, string oldName, string newName)
        {
            throw new NotImplementedException();
        }

        public IModel GetModel(Guid file)
        {
            if (this.Models.ContainsKey(file))
                return this.Models[file];

            return null;
        }

        public void Remove(IModel model)
        {
            this.workEngine.OnRemoveModule(model.FileId);
            this.Models.Remove(model.FileId);
            this.Models.Add(model.FileId, model);
            this.OnRemove(model);
        }

        public void Remove(Guid fileId)
        {
            if (this.Models.ContainsKey(fileId))
            {
                var model = this.Models[fileId];
                this.Remove(model);
            }
        }

        public List<ITypeInfo> ParseType(string type, IParseModule ctx, out string error)
        {
            return this.workEngine.ParseType(type, ctx, out error);
        }

        public IParseModule GetParseModule(Guid fileId)
        {
            if (this.ParseModules.ContainsKey(fileId))
                return this.ParseModules[fileId];

            return null;
        }

        public void FireParsed(IModel model, bool sucess)
        {
            if (this.OnParsed != null)
                this.OnParsed(model, sucess);
        }

        public ITypeInfo ResolveType(string nameSpace, string name)
        {
            return Reslove(nameSpace, name) as ITypeInfo;
        }

        public OWLProperty ResolveProperty(string nameSpace, string name)
        {
            return Reslove(nameSpace, name) as OWLProperty;
        }

        public OWLInstance ResolveInstance(string nameSpace, string name)
        {
            return Reslove(nameSpace, name) as OWLInstance;
        }

        public object Reslove(string nameSpace, string name)
        {
            if (!this.Namespace_Modules.ContainsKey(nameSpace))
            {
                return null;
            }

            var modules = this.Namespace_Modules[nameSpace];
            foreach (var m in modules)
            {
                if (m.Types.ContainsKey(name))
                    return m.Types[name];
                if (m.Properties.ContainsKey(name))
                    return m.Properties[name];
                if (m.Instances.ContainsKey(name))
                    return m.Instances[name];
            }

            return null;
        }

        public List<ITypeInfo> ListType(string nameSpace)
        {
            var rslt = new List<ITypeInfo>();

            if (!this.Namespace_Modules.ContainsKey(nameSpace))
            {
                return rslt;
            }

            var modules = this.Namespace_Modules[nameSpace];
            foreach (var m in modules)
            {
                rslt.AddRange(m.Types.Values);
            }

            return rslt;
        }

        public List<OWLProperty> ListProperty(string nameSpace)
        {
            var rslt = new List<OWLProperty>();

            if (!this.Namespace_Modules.ContainsKey(nameSpace))
            {
                return rslt;
            }

            var modules = this.Namespace_Modules[nameSpace];
            foreach (var m in modules)
            {
                rslt.AddRange(m.Properties.Values);
            }

            return rslt;
        }

        public List<OWLInstance> ListInstance(string nameSpace)
        {
            var rslt = new List<OWLInstance>();

            if (!this.Namespace_Modules.ContainsKey(nameSpace))
            {
                return rslt;
            }

            var modules = this.Namespace_Modules[nameSpace];
            foreach (var m in modules)
            {
                rslt.AddRange(m.Instances.Values);
            }

            return rslt;
        }
    }
}