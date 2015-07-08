using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Items.Semantic
{
    class QueryNode : BaseNode
    {
        public QueryNode()
            : base()
        {
            this.TreeNode.Name = this.TreeNode.Text = "查询";
        }
    }
}
