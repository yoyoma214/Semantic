using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;
using CodeHelper.Core.Services;

namespace CodeHelper.Core.Types.RDF.Verbs
{
    public class RDF_Type : BaseVerb
    {
        public RDF_Type()
        {
            this.Allow_Subject_Class = true;
            this.Allow_Subject_Instance = true;
            this.Allow_Subject_Property = false;
        }

        public override string NameSpace
        {
            get
            {
                return NameSpaceEnum.RDF;
            }
        }

        public override string Name
        {
            get
            {
                return "rdf:type";
            }
        }

        public override bool Wise(string subject, string obj)
        {
            return base.Wise(subject, obj);
        }

        public override List<string> AllowSubject(Parser.IParseModule module)
        {            
            var subject = module.Subject;
            var obj = GlobalService.ModelManager.Reslove(module.UsingNameSpaces.Values.ToList(), subject);
            return base.AllowSubject(module);
        }

        public override List<string> AllowObject(Parser.IParseModule module)
        {
            var rslt = new List<string>();
            var obj = module.Object;
            //类型，属性，约束
            var types = GlobalService.ModelManager.ListType(module.UsingNameSpaces.Values.ToList(),null,true);
            foreach(var t in types)
            {
                var ns = module.GetLocalNameSpace(t.NameSpace);
                if (ns == null) ns = ":";
                rslt.Add(ns + t.Name);
            }

            var props = GlobalService.ModelManager.ListProperty(module.UsingNameSpaces.Values.ToList(),null,true);
            foreach (var p in props)
            {
                var ns = module.GetLocalNameSpace(p.NameSpace);
                if (ns == null) ns = ":";
                rslt.Add(ns + p.Name);
            }

            foreach (var ob in OWLTypes.Instance().Object_Types.Values)
            {
                if (ob.AllowVerb(this))
                {
                    var ns = module.GetLocalNameSpace(ob.NameSpace);
                    if (ns == null) ns = ":";
                    rslt.Add(ns + ob.Name);
                }
            }

            rslt.AddRange(OWLTypes.Instance().XSD_Typtes.Keys);
                        
             return rslt;
        }
    }
}