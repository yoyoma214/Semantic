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
using CodeHelper.Core.Parse.ParseResults;
using CodeHelper.Core.Infrastructure;
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

        Guid? fileId;

        /// <summary>
        /// 记录已经构造过的对象（仅限当次构造，不含历史）
        /// </summary>
        List<object> buildObjects = new List<object>();

        //DesignProjectNode mDesignNode;
        //DBProjectNode mDataBaseNode;
        
        public NavigatePanel()
            : base()
        {
            InitializeComponent();
            
            receiver.OnModuleParsed += new ReceiverBase.ModuleParsedHandler(receiver_OnModuleParsed);            
            this.Load += new EventHandler(NavigatePanel_Load);

            DocumentViewManager.Instance().Receiver.OnFileTabChanged 
                += new ReceiverBase.FileTabChangeHandler(Receiver_OnFileTabChanged);
        }

        void Receiver_OnFileTabChanged(Guid fileId)
        {
            if (this.Visible)
                receiver_OnModuleParsed(fileId);
        }      

        void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TokenPair token = null;

            if (e.Node.Tag is TypeInfoBase)
            {
                token = ((TypeInfoBase)e.Node.Tag).TokenPair;
            }
            else if (e.Node.Tag is OWLInstance)
            {
                token = ((OWLInstance)e.Node.Tag).TokenPair;
            }
            else if (e.Node.Tag is OWLProperty)
            {
                token = ((OWLProperty)e.Node.Tag).TokenPair;
            }
            else if (e.Node.Tag is IRestrictPropertyInfo)
            {
                token = ((RestrictProperty)e.Node.Tag).TokenPair;
            }
            else
                return;

            if (token == null)
                return;

            if (token.BeginToken == null)
                return;

            if (!fileId.HasValue)
                return;

            var ctx = GlobalService.EditorContextManager.Get(fileId.Value);

            if (ctx != null)
            {
                ctx.Controller.RePosition(token.BeginToken.Line - 1,
                    token.BeginToken.CharPositionInLine, RePositionType.Info, null);

                DocumentViewManager.Instance().ActiveView(ctx.Model.FileId);
            }
            //token.BeginToken.CharPositionInLine
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
            if (GlobalService.EditorContextManager.CurrentContext == null)
                return true;

            if (GlobalService.EditorContextManager.CurrentContext.Model.FileId != fileId)
                return true;

            this.fileId = fileId;
            //var model = ModelManager.Instance().GetModel(fileId);
            //var moudel = ModelManager.Instance().MakeSureParseModule(model.File);
            var moudel = ModelManager.Instance().GetParseModule(fileId);
            
            if (moudel != null)
            {
                this.BeginInvoke(new LoadTreeDelegate(this.LoadTree), moudel);
            }
            else
            {
                this.BeginInvoke(new LoadTreeDelegate(this.LoadTree), moudel);
            }
            return true;
        }

        private void LoadTree(IParseModule module)
        {
            if (module == null)
            {
                this.typeRoot.Nodes.Clear();
                this.instanceRoot.Nodes.Clear();
                this.propertyRoot.Nodes.Clear();
                return;
            }
            if (this.treeView1 == null)
                return;

            this.treeView1.BeginUpdate();

            this.typeRoot.Nodes.Clear();
            this.instanceRoot.Nodes.Clear();
            this.propertyRoot.Nodes.Clear();
            buildObjects.Clear();

            foreach (var type in module.Types)
            {
                if (type.Value.Super != null)
                    continue;

                //var node = new TreeNode(type.Key);
                //node.Tag = type.Value;                
                //foreach (var p in type.Value.PropertyInfos)
                //{
                //    var propertyNode = new TreeNode(p.Name);
                //    propertyNode.Tag = p;
                //    propertyNode.SelectedImageKey = propertyNode.ImageKey = "256";                    
                //    node.Nodes.Add(propertyNode);
                //}
                //foreach (var child in type.Value.Children)
                //{
                //    var node2 = new TreeNode(((TypeInfoBase)child).Name);
                //    node2.Tag = child;
                //    node.Nodes.Add(node2);
                //}
                //this.typeRoot.Nodes.Add(node);
                

                BuildClassNode(type.Value, this.typeRoot);                
            }

            foreach (var type in module.Properties)
            {
                if (type.Value.Parent != null)
                    continue;
                //var node = new TreeNode(type.Key);
                //node.Tag = type.Value;
                //this.propertyRoot.Nodes.Add(node);

                BuildPropertyNode(type.Value, this.propertyRoot);
            }

            foreach (var type in module.Instances)
            {             
				//var typeName = type.Value.Type.NameSpace + type.Value.Type.Name;
                var typeName = "";
                if (type.Value.Type != null)
                    typeName = type.Value.Type.NameSpace + type.Value.Type.Name;
                var node = new TreeNode(type.Key + "(" + typeName + ")");
                node.Tag = type.Value;
                this.instanceRoot.Nodes.Add(node);
            }

            this.treeView1.ExpandAll();

            this.treeView1.EndUpdate();
        }

        private void BuildClassNode(TypeInfoBase type,TreeNode parentNode)
        {
            var node = new TreeNode(type.Name);
            node.Tag = type;
            foreach (var p in type.PropertyInfos)
            {
                var propertyNode = new TreeNode(p.Name);
                propertyNode.Tag = p;
                propertyNode.SelectedImageKey = propertyNode.ImageKey = "256";
                node.Nodes.Add(propertyNode);
            }
            foreach (var child in type.Children)
            {
                //var node2 = new TreeNode(((TypeInfoBase)child).Name);
                //node2.Tag = child;
                //node.Nodes.Add(node2);
                BuildClassNode(child as TypeInfoBase, node);
            }
            parentNode.Nodes.Add(node);
            //this.typeRoot.Nodes.Add(node);
        }

        private void BuildPropertyNode(OWLProperty property, TreeNode parentNode)
        {
            var node = new TreeNode(property.Name);
            node.Tag = property;

            foreach (var child in property.Children)
            {
                //var node2 = new TreeNode(((TypeInfoBase)child).Name);
                //node2.Tag = child;
                //node.Nodes.Add(node2);
                BuildPropertyNode(child as OWLProperty, node);
            }
            parentNode.Nodes.Add(node);
        }

        protected override void OnLoad(EventArgs e)
        {
            treeView1 = new TreeView();

            treeView1.ImageList = GlobalService.Icons;

            treeView1.Dock = DockStyle.Fill;

            this.treeView1.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(treeView1_NodeMouseDoubleClick);

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
