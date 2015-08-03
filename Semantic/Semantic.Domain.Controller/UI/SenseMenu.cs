using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeHelper.Domain.Controller.UI
{
    public partial class SenseMenu : Form
    {
        private List<string> data = new List<string>();

        public delegate void CompleteInput(string text);

        public event CompleteInput OnCompleteInput;

        public SenseMenu()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;

            this.textBox1.KeyDown += new KeyEventHandler(textBox1_KeyDown);
            this.textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);            
            this.LostFocus += new EventHandler(SenseMenu_LostFocus);
            
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);

            if (OnCompleteInput != null)
                OnCompleteInput(GetInput());

            this.Close();
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
                if (OnCompleteInput != null)
                    OnCompleteInput(GetInput());

                this.Close();
            }
        }

        public void SetData(List<string> data)
        {
            this.data.AddRange(data);

            textBox1_TextChanged(null, null);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
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
        
            foreach (var t in this.data)
            {
                if ( t.Contains(this.textBox1.Text.Trim()))
                    this.listView1.Items.Add(new ListViewItem(t));
            }

            if (this.listView1.Items.Count > 0)
                this.listView1.Items[0].Selected = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
