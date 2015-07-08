using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Items.Semantic
{
    class RuleSetNode : BaseNode
    {
        public RuleSetNode()
            : base()
        {
            this.TreeNode.Name = this.TreeNode.Text = "规则集";
        }
    }
}
