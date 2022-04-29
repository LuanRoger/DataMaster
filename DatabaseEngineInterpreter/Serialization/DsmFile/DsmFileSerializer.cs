using DatabaseEngineInterpreter.SqlSyntaxInfo;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// Ws knowing that this method is not secure.
// We already looking for secure alternatives.
#pragma warning disable SYSLIB0011

namespace DatabaseEngineInterpreter.Serialization.DsmFile;

public static class DsmFileSerializer
{
    public static void Serialize(this SqlInfo sqlInfo, string pathName)
    {
        using FileStream infoFile = File.OpenWrite(pathName);
        
        BinaryFormatter binaryWriter = new();
        binaryWriter.Serialize(infoFile, sqlInfo); // NOT SECURE
    }
    public static SqlInfo Deserializate(string pathName)
    {
        using FileStream fileStream = File.OpenRead(pathName);
        
        BinaryFormatter binaryFormatter = new();
        return (SqlInfo)binaryFormatter.Deserialize(fileStream); // NOT SECURE   
    }
}