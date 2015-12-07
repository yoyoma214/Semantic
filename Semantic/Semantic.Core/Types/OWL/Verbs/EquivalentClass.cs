﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;
using CodeHelper.Core.Services;

namespace CodeHelper.Core.Types.OWL.Verbs
{
    class EquivalentClass: BaseVerb
    {
        public EquivalentClass()
        {
            this.Allow_Subject_Class = true;
            this.Allow_Subject_Instance = false;
            this.Allow_Subject_Property = false; 
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
                return "owl:equivalentClass";
                //return "equivalentClass";
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

        public override List<string> AllowObject(Parser.IParseModule module)
        {
            var rslt = new List<string>();

            var types = GlobalService.ModelManager.ListType(module.UsingNameSpaces.Values.ToList(), null, true);
            foreach (var item in types)
            {
                var ns2 = module.GetFullNameSpace(item.NameSpace);
                foreach (var ns in module.UsingNameSpaces)
                {
                    if (ns.Value.Equals(ns2))
                        rslt.Add(ns.Key + item.Name);
                }

                //rslt.Add(item.Name);
            }
           
            return rslt;
        }
    }
}
