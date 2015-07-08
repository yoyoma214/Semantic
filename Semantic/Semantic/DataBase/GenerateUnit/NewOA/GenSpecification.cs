using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.DbSchema;
using CodeHelper.DataBaseHelper.Items.DBItems;

namespace CodeHelper.DataBaseHelper.GenerateUnit.NewOA
{
    class GenSepcification: BaseGen
    {
        ModelType Model = null;
        ColumnSetNode ColumnSetNode = null;

        public GenSepcification(ModelType model, ColumnSetNode columnSetNode)
        {
            this.Model = model;
            this.ColumnSetNode = columnSetNode;
        }

        public override void Generate(StringBuilder builder)
        {
            builder.AppendLine(
@"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.ZCH49.OASystem.Domain.Specification;

namespace AAA
{
");

            builder.AppendLine(string.Format(
                "     public static class " + this.Model.Name
                + "Specification", this.Model.Name));
            builder.AppendLine("     {");
            //builder.AppendLine(string.Format("\t\tList<{0}> GetList( List<Guid> id_list )", GeneratorUtil.ClassName(this.Model.Name.Value)));
            builder.AppendLine();
            builder.Append(@"        public static ISpecification<{0}> GetList( List<Guid> id_list )
        {
".Replace("{0}", this.Model.Name));
            FieldType idField = null;
            ColumnSchema keyColumn = null;

            foreach(var f in this.Model.Fields)
            {
                
                foreach (var column in this.ColumnSetNode.Columns)
                {
                    if (column.IsPK && column.Name == f.ColumnName)
                    {
                        keyColumn = column;
                        idField = f;
                        break;//一般只有一个pk，其他情况暂不处理
                    }
                }
            }
            //builder.AppendLine();
            if (idField.NullAble)
            {
                builder.AppendFormat("          return new DirectSpecification<{0}>(x => id_list.Contains(x.Id??default(Guid)));", this.Model.Name);
            }
            else
            {
                builder.AppendFormat("          return new DirectSpecification<{0}>(x => id_list.Contains(x.Id));", this.Model.Name);
            }
            builder.AppendLine();
            builder.AppendLine("        }");
            builder.AppendLine("   }");
            builder.Append("}");
            base.Generate(builder);
        }
    }
}
