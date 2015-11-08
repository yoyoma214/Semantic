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

            this.PrevVerbObjects = new Dictionary<string, List<string>>();
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

        /// <summary>
        /// 前面一个语句的主语
        /// </summary>
        public string PrevSubject { get; set; }

        //public List<string> PrevVerbs { get; set; }

        /// <summary>
        /// 前面一个语句的谓语宾语集合
        /// </summary>
        public Dictionary<string, List<string>> PrevVerbObjects { get; set; }

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
                if (ns.Key.Equals(ss[0] + ":"))
                {
                    owlName.LocalName = ss[1];
                    owlName.NameSpace = ns.Value;
                    break;
                }
            }

            return owlName;
        }

        private string GetLocalName(string nameSpace, string name)
        {
            foreach (var ns in this.UsingNameSpaces)
            {
                if (ns.Value.Equals(nameSpace))
                {
                    return ns.Key  + name;
                }
            }
            return null;
        }

        public TypeInfoBase ResloveType(string nameSpace, string name)
        {
            var ln = this.GetLocalName(nameSpace, name);
            if (ln == null)
                return null;

            if (this.Types.ContainsKey(ln))
                return this.Types[ln];
            return null;
        }

        public OWLProperty ResloveProperty(string nameSpace, string name)
        {
            var ln = this.GetLocalName(nameSpace, name);
            if (ln == null)
                return null;

            if (this.Properties.ContainsKey(ln))
                return this.Properties[ln];
            return null;
        }

        public OWLInstance ResloveInstance(string nameSpace, string name)
        {
            var ln = this.GetLocalName(nameSpace, name);
            if (ln == null)
                return null;
            if (this.Instances.ContainsKey(ln))
                return this.Instances[ln];
            return null;
        }

        public object Reslove(string nameSpace, string name)
        {
            var ln = this.GetLocalName(nameSpace, name);
            if (ln == null)
                return null;

            if (this.Types.ContainsKey(ln))
                return this.Types[ln]; 
            if (this.Properties.ContainsKey(ln))
                return this.Properties[ln];
            if (this.Instances.ContainsKey(ln))
                return this.Instances[ln];
            return null;
        }

        public List<object> AnySeeAble(string nameSpace, string name, bool equal)
        {
            var rslt = new List<object>();
            rslt.AddRange(this.TypeSeeAble(nameSpace,name,equal));
            rslt.AddRange(this.PropertySeeAble(nameSpace, name, equal));
            rslt.AddRange(this.InstanceSeeAble(nameSpace, name, equal));
            return rslt;
        }

        public List<TypeInfoBase> TypeSeeAble(string nameSpace, string name, bool equal)
        {
            var rslt = new List<TypeInfoBase>();
            foreach (var p in this.Types.Values)
            {
                if (name != null)
                {
                    if (equal == true)
                    {
                        if (p.Name == name)
                        {
                            rslt.Add(p);
                            continue;
                        }
                    }
                    else
                    {
                        if (p.Name.Contains(name))
                        {
                            rslt.Add(p);
                            continue;
                        }
                    }
                }

                rslt.Add(p);
            }
            return rslt;
        }        

        public List<OWLProperty> PropertySeeAble(string nameSpace, string name, bool equal)
        {
            var rslt = new List<OWLProperty>();
            foreach (var p in this.Properties.Values)
            {                
                if (name != null)
                {
                    if (equal == true)
                    {
                        if (p.Name == name)
                        {
                           rslt.Add(p);
                           continue;
                        }
                    }
                    else
                    {
                        if (p.Name.Contains(name))
                        {
                            rslt.Add(p);
                            continue;
                        }
                    }
                }

                rslt.Add(p);
            }
            return rslt;
        }

        public List<OWLInstance> InstanceSeeAble(string nameSpace, string name, bool equal)
        {
            var rslt = new List<OWLInstance>();
            foreach (var p in this.Instances.Values)
            {
                if (name != null)
                {
                    if (equal == true)
                    {
                        if (p.Name == name)
                        {
                            rslt.Add(p);
                            continue;
                        }
                    }
                    else
                    {
                        if (p.Name.Contains(name))
                        {
                            rslt.Add(p);
                            continue;
                        }
                    }
                }

                rslt.Add(p);
            }
            return rslt;
        }

        public string GetLocalNameSpace(string fullNameSpace)
        {
            foreach (var ns in this.UsingNameSpaces)
            {
                if (ns.Value == fullNameSpace)
                    return ns.Key;
            }

            return null;
        }

        public string GetFullNameSpace(string shortNameSpace)
        {
            foreach (var ns in this.UsingNameSpaces)
            {
                if (ns.Key == shortNameSpace)
                    return ns.Value;
            }

            return null;
        }

        public bool ParseCrashed
        {
            get;
            set;
        }
    }
}