using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Domain.Model.TurtleModels
{
    class TurtleModel: BaseModel
    {
        internal TurtleModel() { }

        //public DataViewDB ModelDB { get; set; }

        public override Core.Parser.ParseType ParseType
        {
            get
            {
                return Core.Parser.ParseType.TurtleModel;
            }
            set
            {
                base.ParseType = value;
            }
        }
    }
}
