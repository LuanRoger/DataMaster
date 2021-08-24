using System;
using System.Collections.Generic;

namespace DatabaseEngineInterpreter.SqlSyntaxInfo
{
    [Serializable]
    public class SqlUpdateInfo
    {
        public List<string> forDeleteTable {get; set;}
        public List<DataTable> forAddTable {get; set;}
        public List<Dictionary<string, DataTable>> forModifyTable {get; set;}
    }
}