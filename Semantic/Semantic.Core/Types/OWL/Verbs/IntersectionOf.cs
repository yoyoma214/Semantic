using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.OWL.Verbs
{
    class IntersectionOf: BaseVerb
    {
        public IntersectionOf()
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
                return "owl:intersectionOf";
                //return "intersectionOf";
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
            return base.AllowObject(module);
        }
    }
}

