namespace Project;

class ProjectType
{
	attr string Name;
	List<ConnectionType> Connections;
}

class ConnectionType
{
	attr string Name;
	attr int DbType;
	attr string ConnectionString;
	attr string DbContexUsingClause;
	attr bool UseAutoMapper;
	List<SqlType> Sqls;
	List<TableType> Tables;
	List<TableType> Views;
	QueryType Query;
	TableRepositoryType TableRepository;
	TableRefMappingType TableRefMapping;
	TableStatusType TableStatus;
}

class QueryType
{
	attr string Name;
	List<SqlType> Sqls;
	List<QueryType> Queries;
}
 
class TableRepositoryType{
	attr string Settings;
}

class TableRefMappingType
{
	attr string Settings;
}

class TableStatusType
{
	attr string Settings;
}

class TableType
{
	attr string Name;
	ModelType Model;
	ColumnSetType ColumnSet;
}

class ModelType
{
	attr string Name;
	attr string ColumnSetName;
	List<FieldType> Fields;	
}

class FieldType
{
	attr string Name;
	attr string ColumnName;
	attr string SystemType;
	attr bool NullAble;
	attr string Description;
	List<ExpandType> Expands;
}

class ExpandType
{
	attr string Key;
	attr string Val;
}

class SqlType
{
	attr string Name;
	attr string SqlStatement;
	attr bool EncloseCondition;
	attr string ResultModel;
}

class ColumnSetType
{
	attr string Name;
	List<ColumnType> Columns;
}

class ColumnType
{
	attr string Name;
	attr string SystemType;
	attr string DbType;
	attr bool AllowDBNull;
	attr int Scale;
	attr int Precision;
	attr int Size;
	attr string Description;
	attr bool IsPK;
	attr string ForeignKeyTable;
	attr string ForeignKeyColumn;
	attr bool IsVirtualFK;
	List<ExpandType> Expands;
}