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
using CodeHelper.Commands.Antlr4Model;

namespace CodeHelper.Items.Antlr4
{
    class Antlr4DirectoryNode : FolderNode
    {
        public Antlr4DirectoryNode()
            : base("Antlr4", "Antlr4")
        {
            this.TreeNode.Name = this.TreeNode.Text = "文件夹";
        }

        public override System.Windows.Forms.ContextMenu GetPopMenu()
        {
            this.EnableEdit = false;

            var menu = base.GetPopMenu();

            menu.MenuItems.Add("新建Antlr4文件", this.OnNewDataModel);
       

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

            var fileName = System.IO.Path.Combine(this.Path, newName) + ".g4";
            if (File.Exists(fileName))
            {
                MessageBox.Show("文件已经存在");
                return;
            }

            var writer = File.CreateText(fileName);
            writer.Flush();
            writer.Close();

            var dataModel = new Antlr4FileNode();

            dataModel.Parent = this;
            dataModel.Text = dataModel.Name = newName;
            //dataModel.FullName = fileName;

            this.TreeNode.Expand();

            var cmdHost = CommandHostManager.Instance().Get(
                CommandHostManager.HostType.OWL);
            var cmd = cmdHost.GetCommand(Dict.Commands.NewAntlr4Model)
                as NewAntlr4ModelCommand;

            cmd.File = dataModel.FullName;
            dataModel.FileId = Guid.NewGuid();

            cmdHost.RunCommand(Dict.Commands.NewAntlr4Model);
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
            var dir = System.IO.Path.Combine(GlobalService.CurrentPrj_Dir, "Antlr4");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            base.Save();
        }

        public override void Load()
        {
            var dir = System.IO.Path.Combine(GlobalService.CurrentPrj_Dir, "Antlr4");

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

            foreach (var dm in directory.GetFiles("*" + Dict.Extenstions.Antlr4_Extension))
            {
                var dmNode = new Antlr4FileNode();
                dmNode.FullName = dm.FullName;
                dmNode.Parent = this;
            }

            base.LoadFile();
        }
    }
}
