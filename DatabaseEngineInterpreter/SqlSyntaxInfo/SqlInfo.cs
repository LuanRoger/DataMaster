using System;
using System.Collections.Generic;

namespace DatabaseEngineInterpreter.SqlSyntaxInfo;

[Serializable]
public class SqlInfo
{
    public string databaseName {get; set;}
    public List<SqlTable> tables { get; set; }

    public SqlInfo(string databaseName, List<SqlTable> tables)
    {
        this.databaseName = databaseName;
        this.tables = tables;
    }
}