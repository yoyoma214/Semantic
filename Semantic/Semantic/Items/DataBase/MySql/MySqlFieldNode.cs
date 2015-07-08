using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.DataBaseHelper.Items.DBItems;
using Project;
using CodeHelper.DataBaseHelper.DbSchema;
using CodeHelper.DataBaseHelper.DbSchema.SqlServer;
using CodeHelper.DataBaseHelper.DbSchema.MySql;

namespace CodeHelper.DataBaseHelper.Items.MySql
{
    class MySqlFieldNode : FieldNode
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

                foreach (ExpandType expand in this.dataInfo.Expands)
                {
                    if (expand.Key.Equals(MySqlColumnSchema.IDENT, StringComparison.InvariantCultureIgnoreCase))
                    {
                        this.IsIdent = bool.Parse(expand.Val);
                    }
                }
            }

        }

        public override void Assign(ColumnSchema column)
        {
            var col = (MySqlColumnSchema)column;
            this.IsIdent = col.IsIdent;
            base.Assign(column);

            //this.Text = "";
        }
    }
}
