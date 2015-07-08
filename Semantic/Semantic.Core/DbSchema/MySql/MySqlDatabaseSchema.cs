using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using CodeHelper.Core.Util;

namespace CodeHelper.DataBaseHelper.DbSchema.MySql
{
    public class MySqlDatabaseSchema : DatabaseSchema
    {
        public override bool TestConnect()
        {
            string sql = "select 1";
            //return SqlHelper.ExecuteScalar(this.ConnectionString, System.Data.CommandType.Text, sql) != null;
            //return OleDbHelper.ExecuteScalar(this.ConnectionString, System.Data.CommandType.Text, sql, null) != null;
            return MySqlHelper.ExecuteScalar(this.ConnectionString, System.Data.CommandType.Text, sql, null) != null;
        }
    }
}
