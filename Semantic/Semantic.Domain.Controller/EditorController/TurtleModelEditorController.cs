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
using CodeHelper.Core.Parser;
using CodeHelper.Core.Services;

namespace CodeHelper.Domain.EditorController
{
    public class TurtleModelEditorController : BaseEditorController
    {
        public TurtleModelEditorController()
            : base()
        {            
        }

        public string Text { get; set; }

        protected override void OnInputChar(char c, int offset, System.Drawing.Point location)
        {
            if (c == ':' || c=='@' || c=='^')
            {
                if (c == '^')
                {
                    if (offset > 1 && this.editorContainer.Text[offset - 1] != '^')
                        return;

                }

                //call to parse file     
                location.X += (int)this.editorContainer.Editor.Font.Size;
                location.Y += (int)this.editorContainer.Editor.Font.Height;
                var text = this.editorContainer.Text;
                //var index = this.editorContainer.Editor.Document

                var prevText = "";
                int count = 0;
                while (count < 100)
                {
                    var ch = text[offset - count];
                    if (ch == '\r' || ch == '\n' || ch == ' ')
                    {
                        break;
                    }
                    prevText = ch + prevText;
                    count++;
                }

                OnParsed d = null;

                d = new OnParsed((m, sucess) =>
                {
                    GlobalService.ModelManager.OnParsed -= d;

                    if (m.FileId != this.model.FileId)
                        return;

                    var module = ModelManager.Instance().GetParseModule(this.model.FileId);

                    if (this.editorContainer.Editor.InvokeRequired)
                    {
                        this.editorContainer.Editor.Invoke(new DoSenseDelegate(this.DoSense), location, offset, prevText, module);
                    }
                });
                
                GlobalService.ModelManager.OnParsed += d;
            }
        }        

        private delegate void DoSenseDelegate(Point location, int offset, string prevText, IParseModule module);

        void ModelManager_OnParsed(IModel model, bool success)
        {
            
        }

        void DoSense(Point location, int offset, string prevText, IParseModule module )
        {
            SenseMenu m = new SenseMenu();

            m.SetData(prevText, module);
            var l = this.editorContainer.Editor.PointToScreen(new Point(0, 0));

            m.Location = new Point(location.X + l.X, location.Y + l.Y);
            m.Show();

            m.OnCompleteInput += new SenseMenu.CompleteInput((s) =>
            {
                DoInput(prevText,offset, s);
            });

            //m.OnCompleteInput -= new SenseMenu.CompleteInput((s) =>
            //{
            //    DoInput(offset, s);
            //});
        }

        void DoInput(string prevText ,int offset, string text)
        {
            Console.WriteLine("offset" + offset + ":" + text);
            if (!text.EndsWith(" "))
            {
                text += " ";
            }

            TextLocation tl =
                    this.editorContainer.Editor.ActiveTextAreaControl.TextArea.Caret.Position;

            if (prevText.EndsWith("^^"))
            {
                this.editorContainer.Editor.Document.Insert(offset + 1, text);
                tl.Column += text.Length;
                this.editorContainer.Editor.ActiveTextAreaControl.TextArea.Caret.Position = tl;
            }
            else
            {                
                this.editorContainer.Editor.Document.Remove(offset - prevText.Length + 1, prevText.Length);
                this.editorContainer.Editor.Document.Insert(offset - prevText.Length + 1, text);

                tl.Column += text.Length - prevText.Length;
                this.editorContainer.Editor.ActiveTextAreaControl.TextArea.Caret.Position = tl;
            }

            this.editorContainer.Editor.ActiveTextAreaControl.Invalidate();
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
