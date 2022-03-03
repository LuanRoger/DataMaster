using System;
using System.Collections.Generic;

namespace DatabaseEngineInterpreter.SqlSyntaxInfo;

[Serializable]
public class SqlTable
{
    public string name { get; set; }
    public List<SqlColumns> colunms { get; set; }

    public SqlTable(string name, List<SqlColumns> colunms)
    {
        this.name = name;
        this.colunms = colunms;
    }
}