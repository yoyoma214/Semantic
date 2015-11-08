﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types.Base;
using CodeHelper.Core.Types.RDF.Verbs;

namespace CodeHelper.Core.Types.RDF.Objects
{
    class Datatype : BaseObject
    {
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
                return "rdfs:Datatype";
                //return "Datatype";
            }
        }

        public override bool Wise(string verb)
        {
            return base.Wise(verb);
        }
        public override bool AllowVerb(IVerb verb)
        {
            if (verb is RDF_Type)
                return true;

            return false;
        }

        public override bool AllowVerb(string fullName)
        {
            return base.AllowVerb(fullName);
        }                
    }
}
