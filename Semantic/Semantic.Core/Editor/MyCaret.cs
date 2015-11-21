using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Editor
{
    /// <summary>
    /// 编辑器中插入符位置
    /// </summary>
    public class MyCaret
    {
        public int Offset { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
    }
}
