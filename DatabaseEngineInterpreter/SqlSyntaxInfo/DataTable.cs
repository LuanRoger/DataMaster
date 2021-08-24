using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
