using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DataMaster;

public static class Verifiers
{
    public static bool HasNotServer(string connString) => 
        string.IsNullOrEmpty(connString) || !connString.Contains("Server=");
    /// <summary>
    /// Check if the file exists.
    /// </summary>
    /// <param name="filePath">Path of the file to check.</param>
    /// <returns>Return <c>true</c> if exist and <c>false</c> if not.</returns>
    public static bool CheckFile(string filePath) =>
        File.Exists(filePath);

    /// <returns>If dataTable is empty, return false</returns>
    public static bool VerifyDataTable(DataTable dataTable) => dataTable.Rows.Count > 0;
    public static bool VerifyTreeViewCount(TreeView treeView) => treeView.Nodes.Count == 0;
}