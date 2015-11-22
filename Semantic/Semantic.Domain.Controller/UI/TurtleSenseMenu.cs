using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeHelper.Core.Types;
using CodeHelper.Core.Services;
using CodeHelper.Core.Parser;
using CodeHelper.Core.Parse.ParseResults;

namespace CodeHelper.Domain.Controller.UI
{
    public partial class TurtleSenseMenu : Form
    {
        private List<string> data = new List<string>();

        private int m_selectIndex = -1;

        public delegate void CompleteInput(string text);

        public event CompleteInput OnCompleteInput;

        IParseModule m_module { get; set; }

        public TurtleSenseMenu()
        {
            InitializeComponent();
            

            //ColumnHeader ch = new ColumnHeader();
            //ch.Text = "列标题1";   //设置列标题  
            //ch.Width = 120;    //设置列宽度  
            //ch.TextAlign = HorizontalAlignment.Left;   //设置列的对齐方式  
            //this.listView1.Columns.Add(ch);

            this.listView1.View = View.List;
            this.listView1.GridLines = true;
            this.listView1.FullRowSelect = true;
            this.listView1.SmallImageList = GlobalService.Icons;

            this.StartPosition = FormStartPosition.Manual;

            this.textBox1.KeyDown += new KeyEventHandler(textBox1_KeyDown);
            this.textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            this.LostFocus += new EventHandler(SenseMenu_LostFocus);
            this.listView1.KeyDown += new KeyEventHandler(textBox1_KeyDown);
            this.listView1.MouseClick += new MouseEventHandler(listView1_MouseClick);
        }

        void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            FireCompleteInput();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.Close();
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            if (this.Visible)
            {
                this.Close();
            }
            this.Visible = false;
            //FireCompleteInput();
        }

        void SenseMenu_LostFocus(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }        

        void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                FireCompleteInput();            
            }
            else if (e.KeyValue == (int)Keys.Down)
            {
                OnSelect(true);
            }
            else if (e.KeyValue == (int)Keys.Up)
            {
                OnSelect(false);
            }
            else if (e.KeyValue == (int)Keys.Left)
            {
                OnSelectHorizontal(true);
            }
            else if (e.KeyValue == (int)Keys.Right)
            {
                OnSelectHorizontal(false);
            }
        }

        private void OnSelect(bool? down)
        {
            if (this.listView1.Items.Count == 0)
                return;

            if (m_selectIndex > -1)
            {
                this.listView1.Items[m_selectIndex].Selected = false;
                this.listView1.Items[m_selectIndex].BackColor = Color.White;
            }

            if (down == null)
            {
                m_selectIndex = 0;                
            }
            else if (down == true)
            {
                if (m_selectIndex == -1)
                {
                    m_selectIndex = 0;
                }
                else
                {
                    m_selectIndex += 1;
                    if (m_selectIndex == this.listView1.Items.Count)
                        m_selectIndex = 0;
                }
            }
            else if ( down == false )
            {
                if (m_selectIndex == -1)
                {
                    m_selectIndex = this.listView1.Items.Count-1;
                }
                else
                {
                    m_selectIndex -= 1;
                    if (m_selectIndex == -1)
                        m_selectIndex = this.listView1.Items.Count - 1;
                }
            }

            this.listView1.Items[m_selectIndex].BackColor = Color.SaddleBrown;
            this.listView1.Items[m_selectIndex].Selected = true;
        }

        private void OnSelectHorizontal(bool left)
        {
            ListViewItem lvi = null;

            if (this.m_selectIndex == -1)
            {
                return;
            }
            
            int rowCount = 0;
            var times = 0;
            ListViewItem prevItem = null;
            while (times < 200)
            {
                var item = this.listView1.GetItemAt(0, 0 + 5 * times);

                times++;

                if ( item == null )
                    continue;

                if (prevItem == null)
                {
                    prevItem = item;
                    rowCount = 1;
                }
                else
                {
                    if (item != prevItem)
                    {
                        rowCount += 1;
                        prevItem = item;
                    }
                }               
            }

            var columnCount = this.listView1.Items.Count % rowCount > 0 ? this.listView1.Items.Count / rowCount + 1 :
                this.listView1.Items.Count / rowCount;

            int mod = this.listView1.Items.Count % columnCount;
            //int rowCount = (this.listView1.Items.Count + mod) / columnCount;

            var oldSelectItem = this.listView1.Items[m_selectIndex];
            
            var bounds = this.listView1.Items[m_selectIndex].GetBounds(ItemBoundsPortion.Entire);
            
            var newIndex = 0;

            if (left)
            {
                newIndex = m_selectIndex - rowCount;

                if (newIndex < 0)
                {
                    newIndex = m_selectIndex + (columnCount - 1) * rowCount - 1;
                    if (newIndex >= this.listView1.Items.Count)
                        newIndex = m_selectIndex + (columnCount - 2 ) * rowCount - 1;
                    if (newIndex < 0)
                        return;
                    lvi = this.listView1.Items[newIndex];
                }
                else
                {
                    lvi = this.listView1.Items[newIndex];
                }
            }
            else
            {

                newIndex = m_selectIndex + rowCount;

                if (newIndex >= this.listView1.Items.Count)
                {
                    newIndex = m_selectIndex - (columnCount - 1) * rowCount + 1;
                    if ( newIndex < 0 )
                        newIndex = m_selectIndex - (columnCount - 2) * rowCount + 1;

                    if (newIndex >= this.listView1.Items.Count)
                        return;

                    lvi = this.listView1.Items[newIndex];
                }
                else
                {
                    lvi = this.listView1.Items[newIndex];
                }
            }

            if (lvi != null)
            {
                oldSelectItem.Selected = false;
                oldSelectItem.BackColor = Color.White;

                lvi.Selected = true;
                lvi.BackColor = Color.SaddleBrown;
                this.m_selectIndex = lvi.Index;
            }
        }

        public void SetData(string prevText, IParseModule module, bool fake)
        {
            this.m_module = module;
            if (prevText == null)
                return;

            //prevText = prevText.Trim();
            //foreach (var t in module.Types.Keys)
            //{
            //    data.Add(t);
            //}
            //foreach (var t in module.Properties.Keys)
            //{
            //    data.Add(t);
            //}
            //foreach (var t in module.Instances.Keys)
            //{
            //    data.Add(t);
            //}

            var model = GlobalService.ModelManager.GetModel(module.FileId);
            module.Fake = model.Fake;
            if (model.Fake && module.Subject == null && module.Verb == null && module.Object == null)//对应虚拟输入并且为主键
            {
                this.data.AddRange(TurtleSensor.SubjectSensor.Sensor(prevText.Trim(), module));
            }
            else if ( prevText.EndsWith("^^"))
            {
                this.data.Clear();

                this.data.AddRange(OWLTypes.Instance().XSD_Typtes.Keys);
            }
            else if (!string.IsNullOrWhiteSpace(module.Object))
            {
                //this.data.AddRange(OWLTypes.Instance().Object_Types.Keys);
                this.data.AddRange(TurtleSensor.ObjectSensor.Sensor(prevText.Trim(), module));
            }
            else if (!string.IsNullOrWhiteSpace(module.Verb))
            {
                this.data.Clear();

                if (!module.Fake)
                {
                    this.data.AddRange(TurtleSensor.VerbSensor.Sensor(prevText.Trim(), module));
                }
                else
                {
                    this.data.AddRange(TurtleSensor.ObjectSensor.Sensor(prevText.Trim(), module));
                }
            }
            else if (!string.IsNullOrWhiteSpace(module.Subject))
            {
                this.data.Clear();

                if (!module.Fake)
                {
                    this.data.AddRange(TurtleSensor.SubjectSensor.Sensor(prevText.Trim(), module));
                }
                else
                {
                    this.data.AddRange(TurtleSensor.VerbSensor.Sensor(prevText.Trim(), module));
                }
                //foreach (var ns in module.UsingNameSpaces)
                //{
                //    var ps = GlobalService.ModelManager.lis(ns.Value);
                //    foreach (var property in ps)
                //        this.data.Add(property.Name);
                //}
            }          
            if ( prevText.EndsWith("^^"))
                this.textBox1.Text = ":";
            else            
            this.textBox1.Text = prevText.Trim();
            this.textBox1.SelectionStart = this.textBox1.Text.Length;
            if (prevText == "")
                textBox1_TextChanged(null, null);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }

        private void FireCompleteInput()
        {
            if (OnCompleteInput != null)
                OnCompleteInput(GetInput());

            this.OnCompleteInput = null;
            this.Close();            
        }

        private string GetInput()
        {
            if (this.listView1.SelectedItems.Count > 0)
                return this.listView1.SelectedItems[0].Text;

            return this.textBox1.Text.Trim();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.listView1.Clear();

            this.listView1.BeginUpdate();

            m_selectIndex = -1;

            foreach (var t in this.data)
            {
                if (t.ToLower().Contains(this.textBox1.Text.Trim().ToLower()))
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.ImageKey = "129"; 
                    lvi.Text = t;

                    this.listView1.Items.Add(lvi);
                }
            }

            this.listView1.EndUpdate();

            this.OnSelect(null);  
        }
    }

    public class TurtleSensor
    {
        public class SubjectSensor
        {
            public static List<String> Sensor(string prevText, IParseModule module)
            {
                var data = new List<String>();
                //data.AddRange(module.Types.Keys);
                //data.AddRange(module.Properties.Keys);
                //data.AddRange(module.Instances.Keys);

                foreach (var ns in module.UsingNameSpaces)
                {
                    var types = GlobalService.ModelManager.ListType(ns.Value,null,true);
                    foreach (var each in types)
                        data.Add(ns.Key + each.Name);

                    var ps = GlobalService.ModelManager.ListProperty(ns.Value,null,true);
                    foreach (var each in ps)
                        data.Add(ns.Key + each.Name);

                    var ins = GlobalService.ModelManager.ListInstance(ns.Value,null,true);
                    foreach (var each in ins)
                        data.Add(ns.Key + each.Name);
                }

                return data;
            }
        }

        public class VerbSensor
        {
            public static List<String> Sensor(string prevText, IParseModule module)
            {
                var data = new List<String>();

                var subject = module.Subject;
                var isAnonymous = module.Subject == null;
                //if (string.IsNullOrWhiteSpace(subject))
                //    return new List<string>();

                if (isAnonymous)
                {
                    if (module.PrevVerbObjects.Count > 0)
                    {
                        if (module.PrevVerbObjects.Last().Key == "owl:withRestrictions")
                        {
                            return SenseFact(prevText, module);
                        }
                    }

                    data.AddRange(OWLTypes.Instance().Ver_Types.Keys);
                    return data;
                }

                OWLName owlName = module.ResloveName(subject);

                object obj = GlobalService.ModelManager.Reslove(owlName.NameSpace, owlName.LocalName);
                if (obj == null)
                {
                    data.AddRange(OWLTypes.Instance().Ver_Types.Keys);
                    return data;
                }

                #region 如果主语是类
                if (obj is ITypeInfo || isAnonymous)
                {
                    foreach (var ver in OWLTypes.Instance().Ver_Types)
                    {
                        if (ver.Value.Allow_Subject_Class)
                        {
                            data.Add(ver.Key);
                        }
                    }
                    return data;
                }

                #endregion

                #region 如果主语是实例
                if (obj is OWLInstance)
                {
                    foreach (var ver in OWLTypes.Instance().Ver_Types)
                    {
                        if (ver.Value.Allow_Subject_Instance)
                        {
                            data.Add(ver.Key);
                        }
                    }

                    //添加当前模块能看到的属性
                    var nss = new List<string>();
                    if (prevText == ":")
                    {
                        nss = module.UsingNameSpaces.Values.ToList();
                    }
                    else
                    {
                        var t = module.GetFullNameSpace(prevText);
                        if (t != null)
                            nss.Add(t);
                    }

                    var ps = GlobalService.ModelManager.ListProperty(nss, null, true);

                    //var ps = module.PropertySeeAble(owlName.NameSpace, null, false);
                    foreach (var p in ps)
                    {
                        data.Add(module.GetLocalNameSpace(owlName.NameSpace) + p.Name);
                    }

                    //data.AddRange(ps.Select(x=> owlName.LocalName + ":" + x.Name));

                    return data;
                }

                #endregion

                #region 如果主语是属性
                if (obj is OWLProperty)
                {
                    foreach (var ver in OWLTypes.Instance().Ver_Types)
                    {
                        if (ver.Value.Allow_Subject_Property)
                        {
                            data.Add(ver.Key);
                        }
                    }
                    return data;
                }

                #endregion

                foreach (var p in module.Properties.Keys)
                {
                    data.Add(p);
                }

                foreach (var ns in module.UsingNameSpaces)
                {
                    var ps = GlobalService.ModelManager.ListProperty(ns.Value, null, true);
                    foreach (var property in ps)
                        data.Add(property.Name);
                }

                return data;
            }

            private static List<String> SenseFact(string prevText, IParseModule module)
            {
                var data = new List<String>();

                string typeName = null;
                foreach (var vo in module.PrevVerbObjects)
                {
                    if (vo.Key == "owl:onDatatype")
                    {
                        typeName = vo.Value[0];
                    }
                }
                
                var owlName = module.ResloveName(typeName);
                //var dataType = module.ResloveType(owlName.NameSpace, owlName.LocalName);

                foreach (var f in OWLTypes.Instance().Ver_Facets)
                {
                    if (f.Value.AllowDataType(owlName))
                    {
                        data.Add(f.Key);
                    }
                }

                return data;
            }
        }

        public class ObjectSensor
        {
            public static List<String> Sensor(string prevText, IParseModule module)
            {
               OWLName owlName = module.ResloveName(module.Verb);

                foreach (var ns in module.UsingNameSpaces)
                {
                    object obj = GlobalService.ModelManager.Reslove(owlName.NameSpace, module.Verb);

                    if (obj != null)
                    {
                    }
                    if (obj is IVerb)
                    {
                        var verb =obj as IVerb;
                        return verb.AllowObject(module);                        
                    }
                }
                return new List<string>();
            }
        }
    }
}