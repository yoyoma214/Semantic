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
        /// <summary>
        /// 用于提示的优先考虑
        /// </summary>
        public int Column { get; set; }
        /// <summary>
        /// 用于提示的次要考虑
        /// </summary>
        public int FakeColumn { get; set; }
    }
}
