using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parser;
using CodeHelper.Core.Services;

namespace CodeHelper.Core.Types.Base
{
    public class BaseVerb : IVerb
    {
        public virtual string Name
        {
            get;
            private set;
        }

        public List<string> Domain
        {
            get;
            set;
        }

        public List<string> Range
        {
            get;
            set;
        }

        public virtual bool Wise(string subject, string obj)
        {
            return true;
        }

        public bool Allow_Subject_Class
        {
            get;
            set;
        }

        public bool Allow_Subject_Instance
        {
            get;
            set;
        }

        public bool Allow_Subject_Property
        {
            get;
            set;
        }

        public virtual List<string> AllowSubject(IParseModule module)
        {
            return new List<string>();
        }

        public virtual List<string> AllowVerb(IParseModule module)
        {
            throw new NotImplementedException();
        }

        public virtual List<string> AllowObject(IParseModule module)
        {
            var rslt = new List<string>();

            var types = GlobalService.ModelManager.ListType(module.UsingNameSpaces.Values.ToList(),null,true);
            foreach (var item in types)
            {
                foreach(var ns in module.UsingNameSpaces)
                {
                    if (ns.Value.Equals(item.NameSpace))
                        rslt.Add(ns.Key + item.Name);
                }
                
                //rslt.Add(item.Name);
            }

            var props = GlobalService.ModelManager.ListProperty(module.UsingNameSpaces.Values.ToList(),null,true);
            foreach (var item in props)
            {
                foreach (var ns in module.UsingNameSpaces)
                {
                    if (ns.Value.Equals(item.NameSpace))
                        rslt.Add(ns.Key + item.Name);
                }                
            }

            var ints = GlobalService.ModelManager.ListInstance(module.UsingNameSpaces.Values.ToList(),null,true);
            foreach (var item in ints)
            {
                foreach (var ns in module.UsingNameSpaces)
                {
                    if (ns.Value.Equals(item.NameSpace))
                        rslt.Add(ns.Key + item.Name);
                }
            }

            rslt.AddRange(OWLTypes.Instance().Object_Types.Keys);
            return rslt;
        }

        public virtual string NameSpace
        {
            get { throw new NotImplementedException(); }
        }
    }
}