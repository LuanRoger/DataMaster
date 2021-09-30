using System.Data;
using System.IO;
using System.Windows.Forms;
using DataMaster.Managers;

namespace DataMaster
{
    public static class Verifiers
    {
        public static bool HasNotServer(string connString) => 
            string.IsNullOrEmpty(connString) || !connString.Contains("Server=");
        public static bool VerifyConfigurationFile(string filePath) =>
            File.Exists(filePath);
        
        public static bool VerifyConnectionString() => 
            string.IsNullOrEmpty(DbConnectionManager.sqlServerConnection.ConnectionString);
        
        
        /// <returns>If dataTable is empty, return false</returns>
        public static bool VerifyDataTable(DataTable dataTable) => dataTable.Rows.Count > 0;
        public static bool VerifyTreeViewCount(TreeView treeView) => treeView.Nodes.Count == 0;
    }
}
