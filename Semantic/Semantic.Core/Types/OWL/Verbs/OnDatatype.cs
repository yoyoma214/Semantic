using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;
using CodeHelper.Core.Parser;

namespace CodeHelper.Core.Types.OWL.Verbs
{
    class OnDatatype: BaseVerb
    {
        public OnDatatype()
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
                return "owl:onDatatype";
                //return "onDatatype";
            }
        }

        public override bool Wise(string subject, string obj)
        {
            return base.Wise(subject, obj);
        }

        public override List<string> AllowObject(IParseModule module)
        {
            var rslt = new List<string>();
            rslt.AddRange(OWLTypes.Instance().XSD_Typtes.Keys);
            return rslt;
        }

        public override List<string> AllowSubject(Parser.IParseModule module)
        {
            return base.AllowSubject(module);
        }

        public override List<string> AllowVerb(Parser.IParseModule module)
        {
            return base.AllowVerb(module);
        }

    }
}
