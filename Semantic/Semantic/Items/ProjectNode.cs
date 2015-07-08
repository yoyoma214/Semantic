using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.Core.Services;
using CodeHelper.Xml;

namespace CodeHelper.Items
{
    class ProjectNode :BaseNode
    {        
        //private CustomModelSetNode _customModelSetNode = new CustomModelSetNode();
        public ProjectNode()
            : base()
        {
            //this.TreeNode.Text = this.TreeNode.Name = "数据库";
            

            this.TreeNode.SelectedImageKey = this.TreeNode.ImageKey = "067";
            //this._customModelSetNode.Parent = this;
        }
        //public ProjectNode(TreeNode treeNode):base(treeNode)
        //{
        //}
        private ProjectType dataInfo = new ProjectType();
        internal override CodeHelper.Xml.DataNode DataInfo
        {
            get
            {
                this.dataInfo.Name = this.Name;
                //while (this.dataInfo.HasConnection())
                //    this.dataInfo.RemoveConnection();
                //this.dataInfo.Connections.RemoveAll();
                //while (this.dataType.CustomModelSet.HasModel())
                //    this.dataType.CustomModelSet.RemoveModel();

                //foreach(ConnectionNode node in this._connectionPkgNode.Children)
                //{
                //    this.dataInfo.Connections.AddChild((ConnectionType)node.DataInfo);
                //}
                //foreach (ModelNode node in this._customModelSetNode.Children)
                //{
                //    this.dataType.CustomModelSet.AddModel((ModelType)node.DataInfo);
                //}

                return dataInfo;
            }
            set
            {
                //this.Children.Clear();
                this.dataInfo = (ProjectType)value;
                this.Name = this.dataInfo.Name;
                this.Text = this.Name;
                //this._connectionPkgNode.Reset(this.dataInfo.Connections.OrderBy(x=>x.Name));
                //if (!this.dataInfo.HasCustomModelSet())
                //{
                //    this.dataInfo.AddCustomModelSet(new CustomModelSetType());
                //}
                //this._customModelSetNode.DataInfo = this.dataInfo.CustomModelSet;
            }
        }

        public override void Save()
        {
            //DBGlobalService.CurrentProject = (ProjectType)this.DataInfo;

            GlobalService.CurrentProject = (ProjectType)this.DataInfo;

            base.Save();

            GlobalService.CurrentProject.Dom.OwnerDocument.Save(GlobalService.ProjectFile);

            //GlobalService.BusinessCfgDoc.Save(GlobalService.BizFile);
        }

        public override void Load()
        {            
            base.Load();
        }
    }
}

