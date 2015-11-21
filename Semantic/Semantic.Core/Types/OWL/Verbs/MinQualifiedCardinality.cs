using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;

namespace CodeHelper.Core.Types.OWL.Verbs
{
    class MinQualifiedCardinality: BaseVerb
    {
        public MinQualifiedCardinality()
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
                //return "owl:minQualifiedCardinality";
                return "minQualifiedCardinality";
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
            rslt.Add("\"1\"^^xsd:nonNegativeInteger");
            rslt.Add("\"2\"^^xsd:nonNegativeInteger");
            rslt.Add("\"3\"^^xsd:nonNegativeInteger");
            rslt.Add("\"4\"^^xsd:nonNegativeInteger");
            rslt.Add("\"10\"^^xsd:nonNegativeInteger");
            rslt.Add("\"100\"^^xsd:nonNegativeInteger");
            return rslt;
        }
    }
}

