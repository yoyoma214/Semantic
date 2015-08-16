using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parser;
using CodeHelper.Core.Error;
using CodeHelper.Core.Types;
using CodeHelper.Core.Services;
using CodeHelper.Core.Parse.ParseResults;

namespace CodeHelper.Core.Parse
{
    public abstract class ParseModuleBase : TokenPair, IParseModule
    {
        public ParseModuleBase()
        {
            this.Types = new Dictionary<string, TypeInfoBase>();
            this.Properties = new Dictionary<string, OWLProperty>();
            this.Instances = new Dictionary<string, OWLInstance>();
            Errors = new List<ParseErrorInfo>();
            UsingNameSpaces = new Dictionary<string, string>();
        }

        public string Name { get; set; }

        public virtual ParseType ParseType
        {
            get;
            set;
        }

        public List<ParseErrorInfo> Errors
        {
            get;
            set;
        }

        public string NameSpace
        {
            get;
            set;
        }

        public Dictionary<string, string> UsingNameSpaces
        {
            get;
            set;
        } 

        public Dictionary<string,OWLProperty> Properties { get; set; }

        public Dictionary<string, OWLInstance> Instances { get; set; }        

        string mFile = null;

        public string File
        {
            get
            {
                if (GlobalService.ModelManager != null)
                {
                    var model = GlobalService.ModelManager.GetModel(this.FileId);
                    if (model == null)
                        return null;

                    return model.File;
                }
                else
                    return mFile;
            }
            set
            {
                mFile = value;
            }

        }

        public Guid FileId
        {
            get;
            set;
        }


        public Dictionary<string, TypeInfoBase> Types
        {
            get;
            set;
        }

        public abstract void Initialize();

        public virtual void Wise()
        {
            foreach (var t in this.Types.Values)
            {
                t.Wise();
            }            
        }

        public List<IParseModule> DependenceModules
        {
            get;
            set;
        }

        public InputCharInfo InputChar
        {
            get;
            set;
        }

        public string Subject
        {
            get;
            set;
        }

        public string Verb
        {
            get;
            set;
        }

        public string Object
        {
            get;
            set;
        }


        public OWLName ResloveName(string mixedName)
        {
            if (mixedName.StartsWith(":"))
                return new OWLName() { NameSpace = this.NameSpace, LocalName = mixedName.Substring(1) };

            var ss = mixedName.Split(new char[]{':'}, StringSplitOptions.RemoveEmptyEntries);

            OWLName owlName = new OWLName();

            foreach (var ns in this.UsingNameSpaces)
            {
                if (ns.Key.Equals(ss[0]))
                {
                    owlName.NameSpace = ns.Key;
                    break;
                }
            }

            return owlName;
        }
    }
}
