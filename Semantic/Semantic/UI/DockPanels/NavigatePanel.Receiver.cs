using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Infrastructure.Command;
using CodeHelper.Items;
using CodeHelper.Core.Services;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using CodeHelper.Core.Command;
using CodeHelper.Commands.DataModel;
//using CodeHelper.DataBaseHelper.Items.DBItems;
using CodeHelper.DataBaseHelper;
using CodeHelper.Xml;
using Project;
using CodeHelper.Core;
using CodeHelper.Domain.Model;
using CodeHelper.Core.Parser;
//using CodeHelper.DataBaseHelper.Sql;
//using CodeHelper.Core.DbConfig;

namespace CodeHelper.UI.DockPanels
{
    partial class NavigatePanel : IReceiverHolder
    {
        ReceiverBase receiver = new ReceiverBase();

        TreeView treeView1;

        TreeNode typeRoot;

        TreeNode propertyRoot;

        TreeNode instanceRoot;

        //DesignProjectNode mDesignNode;
        //DBProjectNode mDataBaseNode;

        public NavigatePanel()
            : base()
        {
            InitializeComponent();

            receiver.OnModuleParsed += new ReceiverBase.ModuleParsedHandler(receiver_OnModuleParsed);
            this.Load += new EventHandler(NavigatePanel_Load);            
        }

        void NavigatePanel_Load(object sender, EventArgs e)
        {
            this.typeRoot = new TreeNode("类");
            this.propertyRoot = new TreeNode("属性");
            this.instanceRoot = new TreeNode("实例");

            this.treeView1.Nodes.Add(this.typeRoot);
            this.treeView1.Nodes.Add(this.propertyRoot);
            this.treeView1.Nodes.Add(this.instanceRoot);
        }
        
        private delegate void LoadTreeDelegate(IParseModule module);


        bool receiver_OnModuleParsed(Guid fileId)
        {
            var moudel = ModelManager.Instance().GetParseModule(fileId);
            if (moudel != null)
            {
                this.BeginInvoke(new LoadTreeDelegate(this.LoadTree),moudel);
            }
            return true;
        }

        private void LoadTree(IParseModule module)
        {
            this.treeView1.BeginUpdate();

            this.typeRoot.Nodes.Clear();
            this.instanceRoot.Nodes.Clear();
            this.propertyRoot.Nodes.Clear();
            
            foreach(var type in module.Types)
                this.typeRoot.Nodes.Add(type.Key);

            foreach (var type in module.Properties)
                this.propertyRoot.Nodes.Add(type.Key);

            foreach (var type in module.Instances)
                this.instanceRoot.Nodes.Add(type.Key);

            this.treeView1.ExpandAll();

            this.treeView1.EndUpdate();
        }

        protected override void OnLoad(EventArgs e)
        {
            treeView1 = new TreeView();

            treeView1.ImageList = GlobalService.Icons;

            treeView1.Dock = DockStyle.Fill;

            this.Controls.Add(treeView1);

            
            this.treeView1.AllowDrop = true;

            this.ShowIcon = false;
            this.TabText = this.Text = "导航";
            base.OnLoad(e);
            
        }

        public ReceiverBase Receiver
        {
            get
            {
                return receiver;
            }
        }
    }
}
