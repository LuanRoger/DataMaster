using System;
using System.Collections.Generic;

namespace DatabaseEngineInterpreter.SqlSyntaxInfo
{
    [Serializable]
    public class SqlInfo
    {
        public string databaseName {get; set;}
        public List<DataTable> tables { get; set; }

        public SqlInfo(string databaseName, List<DataTable> tables)
        {
            this.databaseName = databaseName;
            this.tables = tables;
        }
    }
}
