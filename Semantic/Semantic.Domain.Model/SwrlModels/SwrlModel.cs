using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Domain.Model.SwrlModels
{
    public class SwrlModel: BaseModel
    {
        internal SwrlModel() { }

        //public DataViewDB ModelDB { get; set; }

        public override Core.Parser.ParseType ParseType
        {
            get
            {
                return Core.Parser.ParseType.SwrlModel;
            }
            set
            {
                base.ParseType = value;
            }
        }
    }
}
