using System;
using System.Collections.Generic;

namespace DatabaseEngineInterpreter.SqlSyntaxInfo
{
    [Serializable]
    public class DataTable
    {
        public string name { get; set; }
        public List<DataTableColumns> colunms { get; set; }

        public DataTable(string name, List<DataTableColumns> colunms)
        {
            this.name = name;
            this.colunms = colunms;
        }
    }
}
