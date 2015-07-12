using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Items.Semantic
{
    class RuleNode : BaseNode
    {
        public RuleNode()
            : base()
        {
            this.TreeNode.Name = this.TreeNode.Text = "规则";
        }
    }
}
