using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;
using CodeHelper.Core.Services;

namespace CodeHelper.Core.Types.OWL.Verbs
{
    class PropertyChainAxiom: BaseVerb
    {
        public PropertyChainAxiom()
        {
            //this.Allow_Subject_Class = true;
            //this.Allow_Subject_Instance = true;
            this.Allow_Subject_Property = true; 
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
                return "owl:propertyChainAxiom";
            }
        }

        public override bool Wise(string subject, string obj)
        {
            return base.Wise(subject, obj);
        }

        public override List<string> AllowObject(Parser.IParseModule module)
        {
            var rslt = new List<string>();
            var props = GlobalService.ModelManager.ListProperty(module.UsingNameSpaces.Values.ToList(), null, true);
            foreach (var item in props)
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
