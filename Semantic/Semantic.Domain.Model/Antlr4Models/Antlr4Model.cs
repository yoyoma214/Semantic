using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Domain.Model.Antlr4Models
{
    public class Antlr4Model: BaseModel
    {
        internal Antlr4Model() { }

        //public DataViewDB ModelDB { get; set; }

        public override Core.Parser.ParseType ParseType
        {
            get
            {
                return Core.Parser.ParseType.Antlr4Model;
            }
            set
            {
                base.ParseType = value;
            }
        }
    }
}
