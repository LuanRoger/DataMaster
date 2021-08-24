using System.IO;

namespace DataMaster
{
    public static class Verifiers
    {
        public static bool HasNotServer(string connString) => 
            string.IsNullOrEmpty(connString) || !connString.Contains("Server=");
        public static bool VerifyConfigurationFile(string filePath) =>
            File.Exists(filePath);
    }
}
