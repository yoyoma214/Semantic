using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Items.Semantic
{
    class SparqlNode : BaseNode
    {
        public SparqlNode()
            : base()
        {
            this.TreeNode.Name = this.TreeNode.Text = "查询语句";
        }
    }
}

