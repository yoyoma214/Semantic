using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.OleDb;
using CodeHelper.DataBaseHelper.DbSchema.DbSchemaProvider;
using CodeHelper.Core.Util;
using CodeHelper.Core.DbSchema;
using MySql.Data.MySqlClient;
using MySqlHelper = CodeHelper.Core.Util.MySqlHelper;

namespace CodeHelper.DataBaseHelper.DbSchema.MySql
{
    public class MySqlSchemaProvider : BaseDbSchemaProvider
    {
        public override ColumnSchema[] GetTableColumns(string connectionString, TableSchema table)
        {
            throw new NotImplementedException();
        }

        public override TableSchema[] GetTables(string connectionString, DatabaseSchema database)
        {
            List<TableSchema> tableSchemas = new List<TableSchema>();

            using (var conn = new MySqlConnection(connectionString))
            {
                this.ConnectionString = connectionString;
                var tt = MySqlHelper.GetDataSet(conn, CommandType.Text, "Show Tables", null).Tables[0];

                List<string> tableNames = new List<string>();
                Dictionary<string, Dictionary<string, ForeignKeyInfo>> fkMap = null;

                foreach (DataRow tRow in tt.Rows)
                {
                    tableNames.Add(tRow[0].ToString());
                }

                fkMap = this.GetForeignKeys(
                       conn, tableNames);

                foreach (DataRow tRow in tt.Rows)
                {
                    var tableName = tRow[0].ToString();
                    tableSchemas.Add(this.GetTable(tableName, conn, conn, fkMap.ContainsKey(tableName) ? fkMap[tableName] : null));
                }

            }

            //tt.WriteXml("1.xml");

            return tableSchemas.ToArray();

        }
        private TableSchema GetTable(string tableName, MySqlConnection conn, MySqlConnection pkConn,
            Dictionary<string,ForeignKeyInfo> fkOneTable)
        {
            var sql_columns = string.Format(@"    select * from information_schema.columns 
    where table_name = '{0}'
    order by table_schema,table_name",tableName);

            DataTable tt = MySqlHelper.GetDataSet(conn, CommandType.Text, sql_columns, null).Tables[0];

            if (tt.Rows.Count == 0)
                return null;
           
            TableSchema tableSchema = new MySqlTableSchema();
            tableSchema.Name = tt.Rows[0]["TABLE_NAME"].ToString();            
            var sql_view = string.Format(@"select 1 from  information_schema.views where 
                TABLE_SCHEMA = '{0}' and TABLE_NAME = '{1}'", conn.Database, tableName);

            var isView = MySqlHelper.ExecuteScalar(conn, CommandType.Text, sql_view, null);
            tableSchema.IsView = isView != null ? (long)isView == 1 : false;
                                      
            //Dictionary<string, bool> dict_IsIdentity = new Dictionary<string, bool>();
            //Dictionary<string,string> dict_Description = new Dictionary<string,string>();

            //foreach (DataRow row in tt.Rows)
            //{
            //    dict_IsIdentity.Add((string)row["COLUMN_NAME"], row["EXTRA"].Equals("auto_increment") ? true : false);
            //    if (row["COLUMN_COMMENT"] != DBNull.Value)
            //    {
            //        dict_Description.Add((string)row["COLUMN_NAME"], (string)row["COLUMN_COMMENT"]);
            //    }
            //}

            foreach (DataRow fRow in tt.Rows)
            {
                string name = fRow["COLUMN_NAME"].ToString();
                bool allowDBNull = fRow["IS_NULLABLE"].ToString().Equals("NO") ? false : true;
                string dataType = fRow["DATA_TYPE"].ToString();
                string nativeType = fRow["DATA_TYPE"].ToString();
                byte precision = 0;
                byte.TryParse(fRow["NUMERIC_PRECISION"].ToString(), out precision);
                var isPK = fRow["COLUMN_KEY"].ToString() == "PRI";

                int scale = 0;
                int.TryParse(fRow["NUMERIC_SCALE"].ToString(), out scale);

                int size = 0;
                int.TryParse(fRow["CHARACTER_MAXIMUM_LENGTH"].ToString(), out size);
                if (size == 0)
                {
                    int.TryParse(fRow["CHARACTER_OCTET_LENGTH"].ToString(), out size);
                }   
                var columnSchema = new MySqlColumnSchema(
                    isPK, name, dataType, nativeType, size, precision, scale, allowDBNull);
                tableSchema.Columns.Add(columnSchema);

                columnSchema.IsIdent = fRow["EXTRA"].Equals("auto_increment") ? true : false;
                columnSchema.Description = (string)fRow["COLUMN_COMMENT"];

                if (fkOneTable != null)
                {
                    if (fkOneTable.ContainsKey(columnSchema.Name))
                    {
                        ForeignKeyInfo fkInfo = fkOneTable[columnSchema.Name];
                        columnSchema.ForeignKeyTable = fkInfo.FK_Table;
                        columnSchema.ForeignKeyColumn = fkInfo.FK_Column;
                    }
                }
            }
            //获得外键
            //DataTable fk = conn.GetSchema("ForeignKeys", restrictions);
            //foreach (DataRow fkRow in fk.Rows)
            //{
            //    fk.WriteXml("1.xml");
            //}
            return tableSchema;
        }
        public override TableSchema GetTable(string connectionString, string tableName)
        {
            var oleConn = new MySqlConnection(connectionString);
            //oleConn.ConnectionString = "Provider=SQLOLEDB;" + connectionString;
            TableSchema tableSchema = null;

            using (var conn = new MySqlConnection())
            {
                this.ConnectionString = connectionString;            
                conn.ConnectionString = connectionString;
                conn.Open();
                oleConn.Open();
                //Dictionary<string, Dictionary<string, ForeignKeyInfo>> fkMap = this.GetForeignKeys(
                //    conn, new List<string>() { tableName });
                tableSchema = this.GetTable(tableName, conn, oleConn,  null);
                oleConn.Close();
            }
            return tableSchema;
        }

        private Dictionary<string, Dictionary<string, ForeignKeyInfo>> GetForeignKeys(MySqlConnection conn, List<string> tableNames)
        {
            string tables = "";
            foreach (string t in tableNames)
            {
                tables += "'" + t + "',";
            }
            tables = tables.EndsWith(",")?tables.Substring(0,tables.Length-1):tables;

            string sql = string.Format(@"select * from  information_schema.key_column_usage 
where  
    table_schema='{0}' and  
    referenced_table_name is not null;",conn.Database); ;
            if ( !tables.Equals(""))
            {
                sql += "and TABLE_NAME IN (" + tables + ")";
            }
            Dictionary<string, Dictionary<string,ForeignKeyInfo>> fks = new Dictionary<string, Dictionary<string,ForeignKeyInfo>>();
            return fks;
            
        }
    }
}