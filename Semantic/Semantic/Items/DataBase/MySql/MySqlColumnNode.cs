﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.DataBaseHelper.Items.DBItems;
using Project;
using CodeHelper.DataBaseHelper.DbSchema.SqlServer;
using CodeHelper.DataBaseHelper.DbSchema.MySql;

namespace CodeHelper.DataBaseHelper.Items.MySql
{
    class MySqlColumnNode : ColumnNode
    {    
        bool IsIdent { get; set; }

        internal override CodeHelper.Xml.DataNode DataInfo
        {
            get
            {
                //while (this.dataInfo.HasExpand())
                //{
                //    this.dataInfo.RemoveExpand();
                //}
                this.dataInfo.Expands.RemoveAll();
                ExpandType expand = DBGlobalService.CurrentProjectDoc.CreateNode<ExpandType>();
                expand.Key = MySqlColumnSchema.IDENT;
                expand.Val = this.IsIdent.ToString();
                this.dataInfo.Expands.AddChild(expand);
                return base.DataInfo;
            }
            set
            {
                base.DataInfo = value;
                if (this.Name.Equals("TemplateId"))
                {
                }
                
                    foreach (ExpandType expand in this.dataInfo.Expands)
                    {
                        if (expand.Key.Equals(MySqlColumnSchema.IDENT, StringComparison.InvariantCultureIgnoreCase))
                        {
                            this.IsIdent = bool.Parse(expand.Val);
                        }
                    }
                
                this.Text = this.Name + " ("
                     + (this.IsPK ? "PK, " : "")
                     + (this.IsIdent ? "标识, " : "")
                     + this.DbType + (this.Size > 0 ? "(" + this.Size + ")" : "") + ", "
                     + (this.AllowDBNull ? "null" : "not null")
                     + ")";
            }
        }

        public override DbSchema.ColumnSchema Column
        {
            set
            {
                base.Column = value;
                this.IsIdent = ((MySqlColumnSchema)value).IsIdent;
                this.Text = this.Name + " ("                        
                        + (this.IsPK ? "PK, " : "")
                        + (this.IsIdent ? "标识, " : "")
                        + this.DbType + (this.Size > 0 ? "(" + this.Size + ")" : "") + ", "
                        + (this.AllowDBNull ? "null" : "not null")
                        + ")";
            }
        }
    }
}
