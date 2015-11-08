using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parser;
using CodeHelper.Core.Services;

namespace CodeHelper.Core.Types.Base
{
    class BaseFacet : IFacet
    {
        public List<string> AllowTypes
        {
            get;
            protected set;
        }

        public string Name
        {
            get;
            protected set;
        }

        public string NameSpace
        {
            get;
            protected set;
        }

        public virtual bool Validate(object val, out string error)
        {
            error = null;
            return true;
        }

        public BaseFacet()
        {
            this.AllowTypes = new List<string>();
        }

        public virtual bool AllowDataType(OWLName dataType)
        {
            var type = GlobalService.ModelManager.ResolveType(dataType.NameSpace, dataType.LocalName);
            if (!type.IsPrimitive)
                return false;

            return true;
        }
    }
}
