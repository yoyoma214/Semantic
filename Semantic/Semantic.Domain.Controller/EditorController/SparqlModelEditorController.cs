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
using CodeHelper.Core.Services;
using ICSharpCode.TextEditor;
using CodeHelper.Core.Parser;
using CodeHelper.Domain.Controller.UI;
using CodeHelper.Core.Editor;

namespace CodeHelper.Domain.EditorController
{
    public class SparqlModelEditorController : BaseEditorController
    {
        public string Text { get; set; }

        protected override void OnInputChar(char c, int offset, System.Drawing.Point location)
        {
            if (Char.IsWhiteSpace(c) || ".#;{}\"',;/\\".Contains(c))
                return;

            if (c == '?' || c == '$' || c == '^' || c == '@')
            {
                this.model.Fake = false;
                var module = ModelManager.Instance().GetParseModule(this.model.FileId);
                module.Fake = false;

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
                var caret = this.editorContainer.Editor.ActiveTextAreaControl.Caret;
                this.model.Caret = new MyCaret() { Line = caret.Line, Column = caret.Column + 1, Offset = caret.Offset };
                var prevText = "";
                int count = 0;
                while (count < 100)
                {
                    var ch = text[offset - count];
                    if (ch == '\r' || ch == '\n' || ch == ' ' || ch == ';' || ch == '\t' || ch == '(' || ch == ')'
                        || ch == '{' || ch == '}' || ch == '<' || ch == '>'
                        )
                    {
                        break;
                    }
                    prevText = ch + prevText;
                    count++;
                }

                OnIntelligence(location, offset, prevText, false);
            }
            else
            {
                this.model.Content = this.editorContainer.Text;
                var caret = this.editorContainer.Editor.ActiveTextAreaControl.Caret;
                this.model.Caret = new MyCaret() { Line = caret.Line, Column = caret.Column + 1, Offset = caret.Offset };
                this.model.Caret.Column -= 1;
                this.model.Caret.FakeColumn = this.model.Caret.Column;
                var prevText = c.ToString();
                //前面可以是换行符或者制表符
                if (this.model.Content.Length < 1) return;

                var line = this.editorContainer.Editor.Document.GetLineSegmentForOffset(offset);
                var ss = this.editorContainer.Editor.Document.GetText(line.Offset, offset - line.Offset);

                for (var i = ss.Length - 1; i > 0; i--)
                {
                    var ch = ss[i];
                    if (ch == '#') return;//如果是注释则返回
                    if (ch == '.') return;//如果是.后则返回                    
                }

                for (var i = ss.Length - 1; i > 0; i--)
                {
                    var ch = ss[i];
                    if (char.IsWhiteSpace(ch) || ",;".Contains(ch))
                        break;

                    //this.model.Caret.Offset -= 1;
                    this.model.Caret.FakeColumn -= 1;
                    prevText = ch + prevText;
                }

                model.Fake = true;
                OnIntelligence(location, offset, prevText, false);
            }
        }

        private delegate void DoSenseDelegate(Point location, int offset, string prevText, IParseModule module, bool fake);

        void ModelManager_OnParsed(IModel model, bool success)
        {
            
        }

        void DoSense(Point location, int offset, string prevText, IParseModule module, bool fake)
        {
            SparqlSenseMenu m = new SparqlSenseMenu();

            m.SetData(prevText, module,fake);
            var l = this.editorContainer.Editor.PointToScreen(new Point(0, 0));

            m.Location = new Point(location.X + l.X, location.Y + l.Y);
            m.Show();

            m.OnCompleteInput += new SparqlSenseMenu.CompleteInput((s) =>
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
                //如果插入点行后面空白则插入空格
                var line = this.editorContainer.Editor.Document.GetLineSegmentForOffset(offset);
                
                var ss = this.editorContainer.Editor.Document.GetText(offset + 1 , line.Offset - offset + line.Length);
                
                if ( String.IsNullOrWhiteSpace(ss))
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

        private void OnIntelligence(Point location, int offset, string prevText, bool fake)
        {
            OnParsed d = null;

            d = new OnParsed((m, sucess) =>
            {
                GlobalService.ModelManager.OnParsed -= d;

                if (m.FileId != this.model.FileId)
                    return;

                var module = ModelManager.Instance().GetParseModule(this.model.FileId);

                if (module.ParseCrashed)
                    return;

                if (this.editorContainer.Editor.InvokeRequired)
                {
                    this.editorContainer.Editor.Invoke(new DoSenseDelegate(this.DoSense), location, offset, prevText, module,fake);
                }
            });

            GlobalService.ModelManager.OnParsed += d;
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
                HighlightingStrategyFactory.CreateHighlightingStrategy("SparQL");

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
