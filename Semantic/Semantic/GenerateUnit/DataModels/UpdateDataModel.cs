using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Infrastructure.Model;
using CodeHelper.Core.Parser;
using CodeHelper.Common;
using CodeHelper.DataBaseHelper;
using CodeHelper.Common.Extensions;
using CodeHelper.Core.Util;
using Project;

namespace CodeHelper.GenerateUnit.DataModels
{
    class UpdateDataModel : BaseGen
    {
        IModel model = null;
        IParseModule module = null;

        public UpdateDataModel(IModel model, IParseModule module)
        {
            this.model = model;
            this.module = module;
        }

        public override void Generate(StringBuilder b)
        {
            var builder = new NStringBuilder(model.Content);
            
            var text = model.Content;

            var ns_list = new List<string>();

            foreach (var ns in module.UsingNameSpaces)
            {
                if (ns.StartsWith("db."))
                {
                    ns_list.Add(ns.Substring(3));
                }
            }

            var tables = DBGlobalService.CurrentProject.GetTables(ns_list);

            foreach (var clz in module.Types)
            {
                if ( !tables.ContainsKey(clz.Name) )
                    continue;

                //获得对应表对象
                var table = tables[clz.Name];
                
                foreach (var f in clz.PropertyInfos)
                {
                    var column = table.FindColumn(f.Name);
                    //列标记为删除
                    if (column == null)
                    {
                        builder.Insert(text.CountIndex(f.TokenPair.EndToken.Line, 1), "\t//已删除\r\n");                        
                        continue;
                    }
                }

                foreach (var column in table.ColumnSet.Columns)
                {
                    var f = clz.FindProperty(column.Name);
                    //列标记新增
                    if (f == null)
                    {
                        builder.Insert(text.CountIndex(clz.TokenPair.EndToken.Line, 0),

                            string.Format("\n\t//新增\r\n\t{0} ({1},\"{2}\",{3},{4});", column.Name, column.SystemType, column.FullDbType(), column.AllowDBNull, column.IsPK));
                        continue;
                    }
                }

                foreach (var column in table.ColumnSet.Columns)
                {
                    var f = clz.FindProperty(column.Name) as CodeHelper.Core.Parse.ParseResults.DataModels.FieldInfo;
                    if(f == null)
                    continue;

                    //列标记为已更改

                    if (!SystemTypeUtil.IsEqual(f.Type, column.SystemType) || f.Nullabe != column.AllowDBNull ||
                        f.Db_type != column.FullDbType() || f.Is_pk != column.IsPK
                        )
                    {                                                    
                        builder.Insert(text.CountIndex(f.TokenPair.EndToken.Line, 1),

                               string.Format("\n\t//已更改为\r\n\t{0} ({1},\"{2}\",{3},{4});\\\\", column.Name, column.SystemType, column.FullDbType(), column.AllowDBNull, column.IsPK));
                        continue;
                    }
                }
            }

            b.Append(builder.StringBuilder0.ToString());
            base.Generate(b);
        }
    }
}
