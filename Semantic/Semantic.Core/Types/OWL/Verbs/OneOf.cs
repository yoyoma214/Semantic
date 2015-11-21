using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;
using CodeHelper.Core.Services;
using CodeHelper.Core.Parser;

namespace CodeHelper.Core.Types.OWL.Verbs
{
    class OneOf: BaseVerb
    {
        public OneOf()
        {
            this.Allow_Subject_Class = true;
            //this.Allow_Subject_Instance = true;
            //this.Allow_Subject_Property = true; 
        }
        public override string NameSpace
        {
            get
            {
                return NameSpaceEnum.OWL;
            }
        }

        public override string Name
        {
            get
            {
                return "owl:oneOf";
                //return "oneOf";
            }
        }

        public override bool Wise(string subject, string obj)
        {
            return base.Wise(subject, obj);
        }

        public override List<string> AllowSubject(Parser.IParseModule module)
        {
            return base.AllowSubject(module);
        }

        public override List<string> AllowVerb(Parser.IParseModule module)
        {
            return base.AllowVerb(module);
        }

        public override List<string> AllowObject(IParseModule module)
        {
            var rslt = new List<string>();
            
            var ints = GlobalService.ModelManager.ListInstance(module.UsingNameSpaces.Values.ToList(), null, true);
            foreach (var item in ints)
            {
                foreach (var ns in module.UsingNameSpaces)
                {
                    if (ns.Value.Equals(item.NameSpace))
                        rslt.Add(ns.Key + item.Name);
                }
            }

            
            return rslt;
        }
    }
}
