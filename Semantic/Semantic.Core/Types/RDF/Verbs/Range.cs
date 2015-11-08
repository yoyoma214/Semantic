using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;
using CodeHelper.Core.Parser;

namespace CodeHelper.Core.Types.RDF.Verbs
{
    class Range: BaseVerb
    {
        public Range()
        {            
            //this.Allow_Subject_Instance = true;
            this.Allow_Subject_Property = true; 
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
                return "rdfs:range";
                //return "range";
            }
        }

        public override bool Wise(string subject, string obj)
        {
            return base.Wise(subject, obj);
        }

        public override List<string> AllowObject(IParseModule module)
        {
            var rslt = new List<string>();
            //判断主语是对象类型还是数据类型
            if (string.IsNullOrWhiteSpace(module.Subject))
                return rslt;

            var owlName = module.ResloveName(module.Subject);
            var subject = module.ResloveProperty(owlName.NameSpace, owlName.LocalName);
            if (subject == null)
                return rslt;

            var ts = module.TypeSeeAble(null, null, false);

            if (subject.IsObject)
            {
                foreach (var t in ts)
                {
                    if (!t.IsPrimitive)
                    {
                        rslt.Add(t.Name);
                    }
                }
            }
            else
            {
                foreach (var t in ts)
                {
                    if (t.IsPrimitive)
                    {
                        rslt.Add(t.NameSpace + t.Name);
                    }
                }

                foreach (var t in OWLTypes.Instance().XSD_Typtes)
                {
                    rslt.Add(t.Key);
                }
            }

            return rslt;
        }
    }
}
