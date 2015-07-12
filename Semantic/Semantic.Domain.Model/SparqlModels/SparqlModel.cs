using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Domain.Model.SparqlModels
{
    public class SparqlModel: BaseModel
    {
        internal SparqlModel() { }

        //public DataViewDB ModelDB { get; set; }

        public override Core.Parser.ParseType ParseType
        {
            get
            {
                return Core.Parser.ParseType.SparqlModel;
            }
            set
            {
                base.ParseType = value;
            }
        }
    }
}
