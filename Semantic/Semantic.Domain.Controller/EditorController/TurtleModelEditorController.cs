using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Infrastructure;
using CodeHelper.Core.Infrastructure.Model;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using System.Drawing;
using System.IO;
using CodeHelper.Parser;
using System.Threading;
using CodeHelper.Core.EditorController;
using CodeHelper.Domain.Model;
using CodeHelper.Editors;
using CodeHelper.Domain.Controller.UI;
using ICSharpCode.TextEditor;

namespace CodeHelper.Domain.EditorController
{
    public class TurtleModelEditorController : BaseEditorController
    {
        public string Text { get; set; }

        protected override void OnInputChar(char c, int offset, System.Drawing.Point location)
        {
            if( c ==':' || c == '[')
            {

                //call to parse file     
                location.X += (int)this.editorContainer.Editor.Font.Size;
                location.Y += (int)this.editorContainer.Editor.Font.Height;
                var text = this.editorContainer.Text;
                //var index = this.editorContainer.Editor.Document

                var module = ModelManager.Instance().GetParseModule(this.model.FileId);
                if (module != null)
                {
                    //ContextMenu m = new ContextMenu();
                    var data = new List<string>();

                    foreach (var t in module.Types)
                    {
                        data.Add(t.Name);
                    }
                    foreach (var t in module.Properties)
                    {
                        data.Add(t.Name);
                    }
                    foreach (var t in module.Instances)
                    {
                        data.Add(t.Name);
                    }

                    SenseMenu m = new SenseMenu();

                    m.SetData(data);
                    var l = this.editorContainer.Editor.PointToScreen(new Point(0, 0));

                    m.Location = new Point(location.X + l.X, location.Y + l.Y);
                    m.Show();
                    
                    m.OnCompleteInput += new SenseMenu.CompleteInput((s) => {
                        DoInput(offset, s);     
                    });                    
                }                                      
            }            
        }

        void DoInput(int offset, string text)
        {
            this.editorContainer.Editor.Document.Remove(offset, 1);
            this.editorContainer.Editor.Document.Insert(offset, text);
            TextLocation tl =
                this.editorContainer.Editor.ActiveTextAreaControl.TextArea.Caret.Position;
            tl.Column += text.Length;
            this.editorContainer.Editor.ActiveTextAreaControl.TextArea.Caret.Position = tl;   
        }
     

        void ShowMenu(ContextMenu menu, Point location)
        {
            menu.Show(this.editorContainer.Editor, location);
        }

        public override ContextMenu PopMenuOnKey(Keys key)
        {
            var menu = base.PopMenuOnKey(key);
            if (key == Keys.OemPeriod)
            { 
                //call to parse file                
                //menu.MenuItems.Add(new MenuItem("as"));
                //var text = this.editorContainer.Text;
                //var json = DataModelParser.Instance().Parse(text);
            }
            return menu;
        }

        protected override void OnKeyPreview(KeyEventArgs e, Point location)
        {
            if (e.KeyData == (Keys.Control | Keys.S))
            {
                this.SaveFile();
            }
            base.OnKeyPreview(e, location);
        }
        protected override void OnBind()
        {
            //base.OnBind();

            this.editorContainer.Editor.Document.HighlightingStrategy =
                HighlightingStrategyFactory.CreateHighlightingStrategy("DataModel");

            this.editorContainer.Editor.Document.FoldingManager.FoldingStrategy =
                new XM_ParserFoldingStrategy();           
        }

        void DataModelEditorController_HandleCreated(object sender, EventArgs e)
        {
            var module = ModelManager.Instance().MakeSureParseModule(model.File);
            if (module != null)
            {
                this.editorContainer.Editor.Document.FoldingManager.UpdateFoldings(this.model.File, module);
            }
        }
    }
}
