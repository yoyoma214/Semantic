using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.DataBaseHelper.GenerateUnit;
using CodeHelper.Core.Infrastructure.Model;
using CodeHelper.Core.Parser;
using CodeHelper.Core.DbConfig;
using CodeHelper.Domain.Model;
using CodeHelper.DataBaseHelper;
using CodeHelper.Core.Types;
using CodeHelper.Common;
using CodeHelper.Core.Parse.ParseResults;

namespace CodeHelper.DataBase.GenerateUnit.GenSchema
{
    class GenSchema : BaseGen
    {
        Connection Conn = null;

        public GenSchema(Connection conn)
        {
            Conn = conn;      
        }

        public override void Generate(StringBuilder b)
        {
            var builder = new IndentStringBuilder();
            var nameSpace = "db." + this.Conn.Name;

            var modules_tmp = ModelManager.Instance().GetAlllModules(ParseType.DataModel);

            var modules = new List<IParseModule>();

            foreach (var m in modules_tmp)
            {
                foreach (var ns in m.UsingNameSpaces)
                {
                    if (ns.Equals(nameSpace, StringComparison.OrdinalIgnoreCase))
                    {
                        modules.Add(m);
                        break;
                    }
                }
            }

            var types = new Dictionary<string,ITypeInfo>();

            foreach (var m in modules)
            {
                foreach (var t in m.Types)
                    types.Add(t.Name.ToLower(), t);
            }

            foreach (var table in Conn.ConnData.Tables)
            {
                builder.IncreaseIndentFormatLine("表 {0}:",table.Name);
                ITypeInfo type = null;
                if ( types.ContainsKey(table.Name.ToLower()))
                    type = types[table.Name.ToLower()];

                foreach (var column in table.ColumnSet.Columns)
                {
                    IPropertyInfo filed = null;// type.PropertyInfos[0]
                    if (type != null)
                    {
                        foreach (var f in type.PropertyInfos)
                        {
                            if (f.Name.Equals(column.Name, StringComparison.OrdinalIgnoreCase))
                            {
                                filed = f;
                                continue;
                            }
                        }
                    }

                    if ( filed != null )
                    {
                        foreach (var attr in filed.Attributes)
                        {
                            builder.AppendFormatLine(attr.Name + ":" + string.Join(",",attr.Parameters));
                        }
                    }

                    builder.AppendFormatLine("{0} {1} {2}", column.Name, column.IsPK, column.DbType, column.AllowDBNull);
                    
                }

                builder.DecreaseIndentLine();
            }
           
            b.Append(builder.ToString());
            base.Generate(b);
        }
    }
}

