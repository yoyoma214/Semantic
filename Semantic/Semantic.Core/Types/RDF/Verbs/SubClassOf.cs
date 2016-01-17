using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;
using CodeHelper.Core.Parser;
using CodeHelper.Core.Services;

namespace CodeHelper.Core.Types.RDF.Verbs
{
    class SubClassOf: BaseVerb
    {
        public SubClassOf()
        {
            this.Allow_Subject_Class = true;
            //this.Allow_Subject_Instance = true;
            //this.Allow_Subject_Property = false; 
        }
        public override string NameSpace
        {
            get
            {
                return NameSpaceEnum.RDFS;
            }
        }

        public override string Name
        {
            get
            {
                return "rdfs:subClassOf";
                //return "subClassOf";
            }
        }

        public override bool Wise(string subject, string obj)
        {
            return base.Wise(subject, obj);
        }

        public override List<string> AllowObject(IParseModule module)
        {
            var rslt = new List<string>();

            var types = GlobalService.ModelManager.ListType(module.UsingNameSpaces.Values.ToList(), null, true);
            foreach (var item in types)
            {
                //foreach (var ns in module.UsingNameSpaces)
                //{
                //    if (ns.Value.Equals(item.NameSpace))
                //        rslt.Add(ns.Key + item.Name);
                //}

                rslt.Add(item.NameSpace + item.Name);
            }
    
            return rslt;
        }
    }
}

