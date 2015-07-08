using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.DbSchema
{
    /// <summary>
    /// 外键约束信息
    /// </summary>
    public class ForeignKeyInfo
    {
        public string FK_Table { get; set; }
        public string FK_Column { get; set; }
        public string PK_Table { get; set; }
        public string PK_Column { get; set; }
        public string Constraint_Name { get; set; }
    }
}
