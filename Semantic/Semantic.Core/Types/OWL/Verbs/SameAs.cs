using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;
using CodeHelper.Core.Services;

namespace CodeHelper.Core.Types.OWL.Verbs
{
    class SameAs: BaseVerb
    {
        public SameAs()
        {
            //this.Allow_Subject_Class = true;
            this.Allow_Subject_Instance = true;
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
                return "owl:sameAs";
                //return "sameAs";
            }
        }

        public override bool Wise(string subject, string obj)
        {
            return base.Wise(subject, obj);
        }

        public override List<string> AllowSubject(Parser.IParseModule module)
        {
            var result = new List<String>();
            foreach (var ns in module.UsingNameSpaces)
            {
                foreach (var type in GlobalService.ModelManager.ListInstance(ns.Value,null,true))
                {
                    result.Add(type.Name);
                }
            }
            return result;
        }

        public override List<string> AllowVerb(Parser.IParseModule module)
        {
            return base.AllowVerb(module);
        }

        public override List<string> AllowObject(Parser.IParseModule module)
        {
            return base.AllowObject(module);
        }
    }
}
