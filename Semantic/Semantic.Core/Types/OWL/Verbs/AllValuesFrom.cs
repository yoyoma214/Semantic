using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;
using CodeHelper.Core.Services;

namespace CodeHelper.Core.Types.OWL.Verbs
{
    public class AllValuesFrom : BaseVerb
    {
        public AllValuesFrom()
        {
            this.Allow_Subject_Class = false;
            this.Allow_Subject_Instance = false;
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
                return "owl:allValuesFrom";
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
                foreach (var type in GlobalService.ModelManager.ListType(ns.Value))
                {
                    result.Add(type.Name);
                }
            }
            return result;
        }
    }
}
