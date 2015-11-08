using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.UI;
using System.Windows.Forms;
using System.IO;
using CodeHelper.Core.Command;
using CodeHelper.Core.Services;
using CodeHelper.Commands.TurtleModel;

namespace CodeHelper.Items.Semantic
{
    class TurtleDirectoryNode : FolderNode
    {
        public TurtleDirectoryNode()
            : base("Turtle", "Turtle")
        {
            this.TreeNode.Name = this.TreeNode.Text = "文件夹";
        }

        public override System.Windows.Forms.ContextMenu GetPopMenu()
        {
            this.EnableEdit = false;

            var menu = base.GetPopMenu();

            menu.MenuItems.Add("新建Turtle文件", this.OnNewDataModel);
       

            return menu;
        }

        protected void OnNewDataModel(object sender, EventArgs args)
        {
            var dlg = new NewFrm();

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var newName = dlg.GetName();
            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("名称不能为空");
                return;
            }

            var fileName = System.IO.Path.Combine(this.Path, newName) + ".turtle";
            if (File.Exists(fileName))
            {
                MessageBox.Show("文件已经存在");
                return;
            }

            var writer = File.CreateText(fileName);
            writer.Flush();
            writer.Close();

            var dataModel = new FileNode();

            dataModel.Parent = this;
            dataModel.Text = dataModel.Name = newName;
            dataModel.FullName = fileName;

            this.TreeNode.Expand();

            var cmdHost = CommandHostManager.Instance().Get(
                CommandHostManager.HostType.OWL);
            var cmd = cmdHost.GetCommand(Dict.Commands.NewTurtleModel)
                as NewTurtleModelCommand;

            cmd.File = dataModel.FullName;
            dataModel.FileId = Guid.NewGuid();

            cmdHost.RunCommand(Dict.Commands.NewDataModel);
        }

        //public override bool IsFolder
        //{
        //    get
        //    {
        //        return true;
        //    }
        //}

        public override void OnDoubleClick()
        {
            if (this.TreeNode.IsExpanded)
            {
                this.TreeNode.ExpandAll();
            }
            else
            {
                this.TreeNode.Collapse();
            }

            base.OnDoubleClick();
        }

        public override void Save()
        {
            var dir = System.IO.Path.Combine(GlobalService.CurrentPrj_Dir, "Turtle");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            base.Save();
        }

        public override void Load()
        {
            var dir = System.IO.Path.Combine(GlobalService.CurrentPrj_Dir, "Turtle");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
           
            base.Load();
        }
        public override Dict.NodeType NodeType
        {
            get
            {
                return Dict.NodeType.SourceDirectory;
            }
        }

        protected override void LoadFile()
        {
            var directory = new DirectoryInfo(Path);

            foreach (var dm in directory.GetFiles("*" + Dict.Extenstions.Turtle_Extension))
            {
                var dmNode = new TurtleFileNode();
                dmNode.FullName = dm.FullName;
                dmNode.Parent = this;
            }

            base.LoadFile();
        }
    }
}
