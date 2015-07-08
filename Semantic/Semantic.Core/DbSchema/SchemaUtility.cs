﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using CodeHelper.DataBaseHelper.DbSchema.Postgres;
using CodeHelper.Core;
using CodeHelper.DataBaseHelper.DbSchema.MySql;
using CodeHelper.DataBaseHelper.DbSchema.SqlServer;

namespace CodeHelper.DataBaseHelper.DbSchema
{
    public class SchemaUtility
    {
        static Dictionary<DatabaseType, DbTypeProvider> DbTypeProviders;
        static SchemaUtility()
        {
            DbTypeProviders = new Dictionary<DatabaseType, DbTypeProvider>();
            DbTypeProviders.Add(DatabaseType.Postgres, new PostgresDbTypeProvider());
            DbTypeProviders.Add(DatabaseType.MySql, new MySqlDbTypeProvider());
            DbTypeProviders.Add(DatabaseType.SqlServer, new SqlDbTypeProvider());
            DbTypeProviders.Add(DatabaseType.UnKnown, new DbTypeProvider());
        }

        public static Type GetSystemType(DatabaseType dbType, string nativeType)
        {
            return DbTypeProviders[dbType].GetSystemType(nativeType);
        }

        public static Type GetSystemType(DatabaseType dbType, DbType type)
        {
            return DbTypeProviders[dbType].GetSystemType(type);
        }

        public static DbType GetDbType(DatabaseType dbType, string nativeType)
        {
            return DbTypeProviders[dbType].GetDbType(nativeType);
        }

        public static string GetSpecifcDbType(DatabaseType dbType, string nativeType)
        {
            return DbTypeProviders[dbType].GetSpecifcDbType(dbType, nativeType);
        }
    }

}

