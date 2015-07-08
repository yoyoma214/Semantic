﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project;
using Microsoft.ApplicationBlocks.Data;
using ICSharpCode.TextEditor.Document;
using CodeHelper.DataBaseHelper.Sql;
using CodeHelper.Core.Error;
//using CodeHelper.Core.Parse.ParseResults.DataViews;
using CodeHelper.DataBaseHelper.GenerateUnit;
using CodeHelper.Common.Extensions;
using CodeHelper.DataBaseHelper.Repository;

namespace CodeHelper.DataBaseHelper
{
    public partial class ServiceFrm : Form
    {
        //SqlType _sqlType = new SqlType();
        //public delegate void OnSave(SqlType sql, ref int hashcode);
        //public event OnSave Save;
        //private int Node_HashCode = 0;
        //private ModelInfo ModelInfo;
        Service service;

        public ServiceFrm(Service service)
            : this()
        {
            this.service = service;
            this.txtName.Text = service.Name;
            this.textEditorControl.Text = service.Code;
        }

        private ServiceFrm()
        {
            InitializeComponent();
            this.textEditorControl.Document.HighlightingStrategy =
                HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");
            this.textEditorControl_Output.Document.HighlightingStrategy =
                HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
            
            this.dataGridView1.RowsAdded += new DataGridViewRowsAddedEventHandler(dataGridView1_RowsAdded);
            this.dataGridView1.RowsRemoved += new DataGridViewRowsRemovedEventHandler(dataGridView1_RowsRemoved);
        }

        void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
       
        }

        void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
          
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
  
            }            
        }
        //public void UpdateItem(SqlType sqlType,string connectionString)
        //{
        //    //this._sqlType = sqlType;
        //    this.txtName.Text = sqlType.Name.Value;
        //    //this.ConnectionString = connectionString; 

        //    this.textEditorControl.Document.TextContent = sqlType.SqlStatement.Statement.Value;
      
        //}
     
        private class StatementInfo
        {
            public string Statement { get; set; }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtName.Text))
            {
                MessageBox.Show("名字不能为空");
                return;
            }

            var folder = new ServiceFolder(this.service.Dom.ParentNode);
            var hash = this.service.Dom.GetHashCode();

            foreach (var s in folder.Services)
            {
                if (s.Dom.GetHashCode() == hash)
                    continue;

                if (s.Name == this.txtName.Name)
                {
                    MessageBox.Show("同个文件夹下名字不能重复");
                    return;
                }
            }
            this.service.Name = this.txtName.Text.Trim();
            this.service.Code = this.textEditorControl.Text.Trim();
            
            //this._sqlType.AddName(this.txtName.Text.Trim()));
            //if ( this._sqlType.HasPagerContentTable())
            //    this._sqlType.RemovePagerContentTable();
            //if ( this._sqlType.HasPagerRecordCountTable())
            //    this._sqlType.RemovePagerRecordCountTable();
           
            ////this.DialogResult = System.Windows.Forms.DialogResult.OK;

            //while (this._sqlType.HasSqlStatement())
            //{
            //    this._sqlType.RemoveSqlStatement();
            //}


            //SqlStatementType sql = new SqlStatementType();
            //sql.AddStatement(this.textEditorControl.Document.TextContent));

            //this._sqlType.AddSqlStatement(sql);
            //if (Save != null)
            //{
            //    this.Save(_sqlType,ref this.Node_HashCode);
            //}

            DBGlobalService.Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {    
            this.textEditorControl.Document.UndoStack.Undo();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 0 && !this.dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                EditSqlStatementFrm f = new EditSqlStatementFrm();
                f.SetSql(this.dataGridView1[this.ColumnSql.Index, e.RowIndex].Value.ToString());
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {                    
                    this.dataGridView1.Rows[e.RowIndex].
                        Cells[this.ColumnSql.Name].Value = f.GetSql();
                }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
  
            StringBuilder sb = new StringBuilder();

            string sql = this.textEditorControl.Document.TextContent;          
           
            if (string.IsNullOrWhiteSpace(sql))
            {
                MessageBox.Show("查询语句不能为空");
                return;
            }

            var selectSql = this.textEditorControl.ActiveTextAreaControl.SelectionManager.SelectedText;
            if (!string.IsNullOrWhiteSpace(selectSql))
            {
                sql = selectSql;
            }
            
            try
            {
                DataSet ds =
                   SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql);

                this.dataGridView1.Hide();

                //List<string> tables = new List<string>();
                //tables.Add("--请选择--");
                this.splitContainer2.Panel2.Controls.Clear();
                List<DataGridView> dgvStack = new List<DataGridView>();
                foreach (DataTable m in ds.Tables)
                {
                    //tables.Add(m.TableName);
                    var dgv = new DataGridView();
                    dgv.AllowUserToAddRows = false;
                    dgv.DataSource = m;
                    dgv.Dock = DockStyle.Fill;
                    dgv.AllowUserToDeleteRows = false;
                    
                    dgvStack.Add(dgv);                    
                }

                if (dgvStack.Count == 1)
                {
                    var dgv = dgvStack[0];
                    this.splitContainer2.Panel2.Controls.Add(dgv);
                }
                else
                {
                    SplitContainer parentContainer = null;

                    while (dgvStack.Count != 0)
                    {
                        if (parentContainer == null)
                        {
                            parentContainer = new SplitContainer();
                            parentContainer.Dock = DockStyle.Fill;
                            parentContainer.Orientation = Orientation.Horizontal;
                            parentContainer.Panel1.Controls.Add(dgvStack[0]);
                            parentContainer.Panel2.Controls.Add(dgvStack[1]);
                            dgvStack.RemoveAt(0);
                            dgvStack.RemoveAt(0);
                            this.splitContainer2.Panel2.Controls.Add(parentContainer);
                        }
                        else
                        {
                            var spContainer = new SplitContainer();

                            spContainer.Dock = DockStyle.Fill;
                            spContainer.Orientation = Orientation.Horizontal;

                            spContainer.Panel1.Controls.Add(dgvStack[0]);
                            dgvStack.RemoveAt(0);

                            if (dgvStack.Count > 1)
                            {
                                spContainer.Panel2.Controls.Add(dgvStack[1]);
                                dgvStack.RemoveAt(0);
                            }
                            else
                            {
                                spContainer.Panel2.Hide();
                            }
                            spContainer.Dock = DockStyle.Bottom;
                            parentContainer.Panel2.Controls.Add(spContainer);

                            parentContainer = spContainer;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("查询出错:" + ex.Message);
            }

        }

        public string ConnectionString
        {
            get
            {
                var s = this.service.ConnectionString;
                
                if (string.IsNullOrWhiteSpace(s))
                {
                    var parent_dom = this.service.Dom.ParentNode;

                    while (true && parent_dom != null)
                    {
                        var parent = new ServiceFolder(parent_dom);
                        s = parent.ConnectionString;
                        if (!string.IsNullOrWhiteSpace(s))
                        {
                            break;
                        }

                        parent_dom = parent_dom.ParentNode;
                    }
                }

                if (!string.IsNullOrWhiteSpace(s))
                {
                    foreach (var conn in DBGlobalService.CurrentProject.Connections)
                    {
                        if (string.Equals(conn.Name, s, StringComparison.OrdinalIgnoreCase))
                        {
                            return conn.ConnectionString;
                        }
                    }
                }
                return s;
            }
        }

        //private bool IsValueType(CodeHelper.Core.Parse.ParseResults.DataViews.DbType type)
        //{
        //    return type == CodeHelper.Core.Parse.ParseResults.DataViews.DbType.Bool ||
        //        type == CodeHelper.Core.Parse.ParseResults.DataViews.DbType.Char ||
        //        type == CodeHelper.Core.Parse.ParseResults.DataViews.DbType.DateTime ||
        //        type == CodeHelper.Core.Parse.ParseResults.DataViews.DbType.Float ||
        //        type == CodeHelper.Core.Parse.ParseResults.DataViews.DbType.Int
        //        ;                                
        //}

        private void btnGenSearchConditionInfo_Click(object sender, EventArgs e)
        {
            /*
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;
            
            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;
            if (dvDB == null)
            {
                OnError(SqlParser.Instance().Errors.ToList());
            }
            if (dvDB != null)
            {
                OnError(dvDB.Errors);

                dvDB.InitOption();
                dvDB.Context.Wise(null);
                var orders = dvDB.OrderPairs;

                var condition_class = new StringBuilder();
                var parameterName = "";
                condition_class.AppendLine(string.Format("public class {0}_Condition", GeneratorUtil.ClassName(this.txtName.Text.Trim())));
                condition_class.AppendLine("{");
                //generate order by type
                if (dvDB.OrderPairs.Count > 0)
                {
                    condition_class.AppendLine(string.Format("\tpublic enum OrderByType"));
                    condition_class.AppendLine(("\t{"));
                    condition_class.Append(("\t\t"));
                    foreach (var order in dvDB.OrderPairs)
                    {
                        condition_class.Append(GeneratorUtil.ClassName(order.SafeName) + "_" + order.OrderType + ",");
                    }
                    condition_class.AppendLine((""));
                    condition_class.AppendLine(("\t}"));
                    condition_class.AppendLine();
                    condition_class.AppendLine(("\tpublic OrderByType OrderBy{get;set;}"));
                    condition_class.AppendLine();
                }

                foreach (var p in dvDB.Context.Parameters)
                {
                    parameterName = p.Name.Substring(1);                    
                    condition_class.AppendLine("\t" + string.Format("public {0}{1} {2}",
                        EnumUtils.GetDescription(p.DbType), p.NullAble && IsValueType(p.DbType) ? "?" : "", GeneratorUtil.ClassName(parameterName)));
                    condition_class.AppendLine("\t" + "{get;set;}");
                    condition_class.AppendLine();

                    foreach (var option in p.Options)
                    {
                        if (option.Name.Equals("op", StringComparison.OrdinalIgnoreCase))
                        {
                            if (option.Value.Equals("all", StringComparison.OrdinalIgnoreCase))
                            {
                                condition_class.AppendLine("\t" + string.Format("public enum {0}_ConditionType",
                                    GeneratorUtil.ClassName(parameterName)));
                                condition_class.AppendLine("\t" + "{");
                                condition_class.AppendLine("\t\t" + "GT,GT_EQ,LT,LT_EQ,EQ,NOT_EQ,BETWEEN");
                                condition_class.AppendLine("\t" + "}");
                                condition_class.AppendLine();
                                condition_class.AppendLine("\t" + string.Format("public {0}_ConditionType {0}_Condition",
                                    GeneratorUtil.ClassName(parameterName)) + "{get;set;}");
                                condition_class.AppendLine();
                            }
                        }
                    }
                }
                condition_class.AppendLine();
                if (dvDB.IsPager)
                {
                    condition_class.AppendLine("\t" + "public int PageIndex{get;set;}");
                    condition_class.AppendLine("\t" + "public int PageSize{get;set;}");
                    condition_class.AppendLine("\t" + "public int RecordCount{get;set;}");
                }

                condition_class.AppendLine("}");

                textEditorControl_Output.Document.TextContent = condition_class.ToString();// dvDB.Context.Render();

                textEditorControl_Output.Refresh();
            }
             * */
        }

        private void OnError(List<ParseErrorInfo> errors)
        {
            this.dataGridView1.DataSource = errors;
        }

        private void btnGenEFFunction_Click(object sender, EventArgs e)
        {
            /*
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;

            if (dvDB != null)
            {
                OnError(dvDB.Errors);

                dvDB.InitOption();
                dvDB.Context.Wise(null);                

                if (dvDB.Context.TableJoinInfos.Count == 0 || dvDB.Context.TableJoinInfos[0].RightModelInfo == null)
                    return;

                //获得对应的model
                var modelName = "unknown";

                if (dvDB.Context.TableJoinInfos.Count == 1)
                {
                    modelName = dvDB.Context.TableJoinInfos[0].RightModelInfo.Name;
                    modelName = GeneratorUtil.ClassName(modelName);
                }


                //生成spacification
                var spec_class = new StringBuilder();
                //推断出model类名
                var condition_class = GeneratorUtil.ClassName( this.txtName.Text.Trim() + "_Condition");
                var condition_variable = "condition";
               
                spec_class.AppendLine(string.Format("public static ISpecification<{0}> {1}({2} {3})"
                    , modelName, GeneratorUtil.ClassName(this.txtName.Text.Trim()), condition_class, condition_variable));

                spec_class.AppendLine("{");

                spec_class.AppendLine(string.Format("\t return new DirectSpecification<{0}>(",modelName));
                
                spec_class.AppendLine("\t\t x=>{ return ");

                var index = 0 ;

                //dvDB.Context.Condition.RenderEFSpec(spec_class);

                //foreach (var conditon in dvDB.Context.Condition.Conditions)
                //{
                    
                //    spec_class.AppendLine("(");
                //    conditon.RenderEFSpec(spec_class);
                //    spec_class.AppendLine(")");
                //    if ( dvDB.Context.RelationTypes.Count > 0 && index < dvDB.Context.RelationTypes.Count)
                //    {
                //        var r = dvDB.Context.RelationTypes[index];
                //        if (r == RelationType.And)
                //        {
                //            spec_class.Append(" && ");
                //        }
                //        else if (r == RelationType.Or)
                //        {
                //            spec_class.Append(" || ");
                //        }
                //        else
                //        {
                //            spec_class.Append(" unknown");
                //        }
                //    }
                //    index++;
                //}

                
                spec_class.AppendLine("\t; }");                

                spec_class.AppendLine("\t);");
                spec_class.AppendLine("}");
                spec_class.AppendLine();


                ////生成Data 接口
                //var repostory_interface = new StringBuilder();
                //repostory_interface.AppendLine(string.Format("List<{0}> {1};", modelName,
                //    GeneratorUtil.ClassName(this.txtName.Text.Trim())));                
                //foreach( var p in dvDB.Context.Parameters)
                //{

                //}

                ////生成Data 实现
                //repostory_interface.AppendLine();

                //var repostory_realize = new StringBuilder();
                //repostory_realize.AppendLine(string.Format("public List<{0}> {1};", modelName,
                //    GeneratorUtil.ClassName(this.txtName.Text.Trim())));

                //repostory_realize.AppendLine("{");
                //repostory_realize.AppendLine(string.Format("\t return this.GetAll({0});", modelName));
                //repostory_realize.AppendLine("}");

                textEditorControl_Output.Document.TextContent = spec_class.ToString();// dvDB.Context.Render();

                textEditorControl_Output.Refresh();
            }
             * */
        }

        private void btnGenSearchConditionDto_Click(object sender, EventArgs e)
        {
            /*
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;

            if (dvDB != null)
            {
                OnError(dvDB.Errors);

                dvDB.InitOption();
                dvDB.Context.Wise(null);
                var orders = dvDB.OrderPairs;

                var condition_class = new StringBuilder();
                var parameterName = "";
                condition_class.AppendLine("[DataContract]");
                condition_class.AppendLine(string.Format("public class {0}_ConditionDto", GeneratorUtil.ClassName(this.txtName.Text.Trim())));
                condition_class.AppendLine("{");
                //generate order by type
                if (dvDB.OrderPairs.Count > 0)
                {
                    condition_class.AppendLine("\t[DataContract]");
                    condition_class.AppendLine(string.Format("\tpublic enum OrderByType"));
                    condition_class.AppendLine(("\t{"));
                    condition_class.Append(("\t\t"));
                    foreach (var order in dvDB.OrderPairs)
                    {
                        condition_class.Append(GeneratorUtil.ClassName(order.SafeName) + "_" + order.OrderType + ",");
                    }
                    condition_class.AppendLine((""));
                    condition_class.AppendLine(("\t}"));
                    condition_class.AppendLine();
                    condition_class.AppendLine("\t[DataMember]");
                    condition_class.AppendLine(("\tpublic OrderByType OrderBy{get;set;}"));
                    condition_class.AppendLine();
                }

                foreach (var p in dvDB.Context.Parameters)
                {
                    parameterName = p.Name.Substring(1);
                    condition_class.AppendLine("\t[DataMember]");
                    condition_class.AppendLine("\t" + string.Format("public {0}{1} {2}",
                         EnumUtils.GetDescription(p.DbType), p.NullAble && IsValueType(p.DbType) ? "?" : "", GeneratorUtil.ClassName(parameterName)));
                    condition_class.AppendLine("\t" + "{get;set;}");
                    condition_class.AppendLine();

                    foreach (var option in p.Options)
                    {
                        if (option.Name.Equals("op", StringComparison.OrdinalIgnoreCase))
                        {
                            if (option.Value.Equals("all", StringComparison.OrdinalIgnoreCase))
                            {
                                condition_class.AppendLine("\t[DataContract]");
                                condition_class.AppendLine("\t" + string.Format("public enum {0}_ConditionType",
                                    GeneratorUtil.ClassName(parameterName)));
                                condition_class.AppendLine("\t" + "{");
                                condition_class.AppendLine("\t[DataMember]");
                                condition_class.AppendLine("\t\t" + "GT,");
                                condition_class.AppendLine("\t[DataMember]");
                                condition_class.AppendLine("\t\t" + "GT_EQ,");
                                condition_class.AppendLine("\t[DataMember]");
                                condition_class.AppendLine("\t\t" + "LT,");
                                condition_class.AppendLine("\t[DataMember]");
                                condition_class.AppendLine("\t\t" + "LT_EQ,");
                                condition_class.AppendLine("\t[DataMember]");
                                condition_class.AppendLine("\t\t" + "EQ,");
                                condition_class.AppendLine("\t[DataMember]");
                                condition_class.AppendLine("\t\t" + "NOT_EQ,");
                                condition_class.AppendLine("\t[DataMember]");
                                condition_class.AppendLine("\t\t" + "BETWEEN");
                                condition_class.AppendLine("\t" + "}");
                                condition_class.AppendLine();
                                condition_class.AppendLine("\t" 
                                    + string.Format("public {0}_ConditionType {0}_Condition"
                                    ,GeneratorUtil.ClassName(parameterName)) + "{get;set;}");

                                condition_class.AppendLine();
                            }
                        }
                    }
                }
                if (dvDB.IsPager)
                {
                    condition_class.AppendLine("\t[DataMember]");
                    condition_class.AppendLine("\t" + "public int PageIndex{get;set;}");
                    condition_class.AppendLine("\t[DataMember]");
                    condition_class.AppendLine("\t" + "public int PageSize{get;set;}");
                    condition_class.AppendLine("\t[DataMember]");
                    condition_class.AppendLine("\t" + "public int RecordCount{get;set;}");
                }

                condition_class.AppendLine("}");

                textEditorControl_Output.Document.TextContent = condition_class.ToString();// dvDB.Context.Render();

                textEditorControl_Output.Refresh();
            }
             */
        }

        private void btnConvertConditionDtoToDomain_Click(object sender, EventArgs e)
        {
            /*
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;

            if (dvDB != null)
            {
                OnError(dvDB.Errors);

                dvDB.InitOption();
                dvDB.Context.Wise(null);
                var orders = dvDB.OrderPairs;
                var dtoName = string.Format("{0}_ConditionDto", GeneratorUtil.ClassName(this.txtName.Text.Trim()));
                var dtoName_variable = GeneratorUtil.VariableName(dtoName);
                var domainName = string.Format("{0}_Condition", GeneratorUtil.ClassName(this.txtName.Text.Trim()));
                var domainName_variable = GeneratorUtil.VariableName(domainName);

                var condition_class = new StringBuilder();
                condition_class.AppendLine(string.Format("public static {0} ConverTo{0}({1} {2})", domainName, dtoName, dtoName_variable));
                condition_class.AppendLine("{");
                condition_class.AppendLine(string.Format("\treturn new {0}()",domainName));
                condition_class.AppendLine("\t{");
                if (dvDB.OrderPairs.Count > 0)
                {
                    condition_class.AppendLine(string.Format("\t\tOrderBy=({1}.OrderByType){0}.OrderBy,", dtoName_variable, domainName));
                }
                foreach (var p in dvDB.Context.Parameters)
                {
                    var parameterName = GeneratorUtil.ClassName(p.Name.Substring(1));
                    condition_class.AppendLine(string.Format("\t{0}={1}.{0},", parameterName, dtoName_variable));

                    foreach (var option in p.Options)
                    {
                        if (option.Name.Equals("op", StringComparison.OrdinalIgnoreCase))
                        {
                            if (option.Value.Equals("all", StringComparison.OrdinalIgnoreCase))
                            {
                                condition_class.AppendLine(string.Format("\t{0}_Condition=({1}.{0}_ConditionType){2}.{0}_Condition,", parameterName, domainName, dtoName_variable));                        
                            }
                        }
                    }
                }

                if (dvDB.IsPager)
                {
                    condition_class.AppendLine(string.Format("\t\tPageIndex={0}.PageIndex,",dtoName_variable));
                    condition_class.AppendLine(string.Format("\t\tPageSize={0}.PageSize,",dtoName_variable));
                    condition_class.AppendLine(string.Format("\t\tRecordCount={0}.RecordCount,", dtoName_variable));                
                }

                condition_class.AppendLine("\t};");
                condition_class.AppendLine("}");        

                textEditorControl_Output.Document.TextContent = condition_class.ToString();// dvDB.Context.Render();

                textEditorControl_Output.Refresh();
            }
             * */
        }

        private void btntConvertConditionDomainToDto_Click(object sender, EventArgs e)
        {
            /*
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;

            if (dvDB != null)
            {
                OnError(dvDB.Errors);

                dvDB.InitOption();
                dvDB.Context.Wise(null);
                var orders = dvDB.OrderPairs;
                var dtoName = string.Format("{0}_ConditionDto", GeneratorUtil.ClassName(this.txtName.Text.Trim()));
                var dtoName_variable = GeneratorUtil.VariableName(dtoName);
                var domainName = string.Format("{0}_Condition", GeneratorUtil.ClassName(this.txtName.Text.Trim()));
                var domainName_variable = GeneratorUtil.VariableName(domainName);

                var condition_class = new StringBuilder();
                condition_class.AppendLine(string.Format("public static {0} ConverTo{0}({1} {2})", dtoName, domainName, domainName_variable));
                condition_class.AppendLine("{");
                condition_class.AppendLine(string.Format("\treturn new {0}()", dtoName));
                condition_class.AppendLine("\t{");
                if (dvDB.OrderPairs.Count > 0)
                {
                    condition_class.AppendLine(string.Format("\t\tOrderBy=({1}.OrderByType){0}.OrderBy,", domainName_variable, dtoName));
                }
                foreach (var p in dvDB.Context.Parameters)
                {
                    var parameterName = GeneratorUtil.ClassName(p.Name.Substring(1));
                    condition_class.AppendLine(string.Format("\t{0}={1}.{0},", parameterName, domainName_variable));

                    foreach (var option in p.Options)
                    {
                        if (option.Name.Equals("op", StringComparison.OrdinalIgnoreCase))
                        {
                            if (option.Value.Equals("all", StringComparison.OrdinalIgnoreCase))
                            {
                                condition_class.AppendLine(string.Format("\t{0}_Condition=({1}.{0}_ConditionType){2}.{0}_Condition,", parameterName, dtoName, domainName_variable));
                            }
                        }
                    }
                }

                if (dvDB.IsPager)
                {
                    condition_class.AppendLine(string.Format("\t\tPageIndex={0}.PageIndex,", domainName_variable));
                    condition_class.AppendLine(string.Format("\t\tPageSize={0}.PageSize,", domainName_variable));
                    condition_class.AppendLine(string.Format("\t\tRecordCount={0}.RecordCount,", domainName_variable));
                }

                condition_class.AppendLine("\t};");
                condition_class.AppendLine("}");

                textEditorControl_Output.Document.TextContent = condition_class.ToString();// dvDB.Context.Render();

                textEditorControl_Output.Refresh();
            }
            */
        }

        private void btnValidateSql_Click(object sender, EventArgs e)
        {
            // List<ParseErrorInfo> errors;

            //ContextMenu contextMenu;

            ////DataViewDB dvDB;

            //SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            //this.textEditorControl_Output.Document.HighlightingStrategy =
            //    HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");

            //textEditorControl_Output.Document.TextContent = null;

            //if (dvDB != null)
            //{
            //    OnError(dvDB.Errors);

            //    dvDB.InitOption();

            //    dvDB.Context.Wise(null);
            //    var builder = new StringBuilder();
            //    dvDB.Context.Render(builder);
            //    this.textEditorControl_Output.Text = builder.ToString();
            //    this.textEditorControl_Output.Invalidate();
            //    textEditorControl_Output.Refresh();
            //}
        }

    }
}
