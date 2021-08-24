using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DatabaseEngineInterpreter.SqlSyntaxInfo;

namespace DatabaseEngineInterpreter.Serialization.DduFile
{
    public static class DduFileSerializer
    {
        public static void Serialize(this SqlUpdateInfo sqlInfo, string pathName)
        {
            using (FileStream infoFile = File.OpenWrite(pathName))
            {
                BinaryFormatter binaryWriter = new();
                binaryWriter.Serialize(infoFile, sqlInfo); // NOT SECURE
            }
        }
        public static SqlUpdateInfo Deserializate(string pathName)
        {
            using (FileStream fileStream = File.OpenRead(pathName))
            {
                BinaryFormatter binaryFormatter = new();
                return (SqlUpdateInfo)binaryFormatter.Deserialize(fileStream); // NOT SECURE
            }
        }
    }
}