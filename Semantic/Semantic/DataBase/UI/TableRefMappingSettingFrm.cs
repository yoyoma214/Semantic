using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project;
using CodeHelper.Core.DbConfig;

namespace CodeHelper.DataBaseHelper.UI
{
    public partial class TableRefMappingSettingFrm : Form
    {

        private TableRefMappingType _modelMapping = null;

        public TableRefMappingSettingFrm(TableRefMappingType tableRepository)
        {
            InitializeComponent();

            _modelMapping = tableRepository;

            this.textEditorControl.Text = _modelMapping.Settings == null ? "" : _modelMapping.Settings.Trim();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            DBGlobalService.FireClearError();
            var conn = ConnectionManager.Get(DBGlobalService.ConnectionString);
            conn.Parse_TableRelation(this.textEditorControl.Text.Trim());
            MessageBox.Show("语法验证通过，但不在此处保证关联的合法性，请在设计阶段保证。");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _modelMapping.Settings = this.textEditorControl.Text.Trim();

            DBGlobalService.Save();

            DBGlobalService.FireClearError();
            var conn = ConnectionManager.Get(DBGlobalService.ConnectionString);
            conn.Parse_TableRelation(_modelMapping.Settings);

            ConnectionManager.Update(conn);
        }
    }
}
