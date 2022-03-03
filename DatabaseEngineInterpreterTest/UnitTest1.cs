using DatabaseEngineInterpreter.SqlSyntaxInfo;
using DatabaseEngineInterpreter.Serialization.DsmFile;
using System;
using Xunit;

namespace DatabaseEngineInterpreterTest;

public class UnitTest1
{
    private readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + 
                                   DatabaseEngineInterpreter.Consts.DSM_FILE_EXTENSION;

    [Fact]
    public void Serialization()
    {
        SqlInfo sqlInfo = new("Test", new() { 
            new("Peaple", 
                new(){new("ID", true, false, "int")})
        });
        sqlInfo.Serialize(path);
    }

    [Fact]
    public void Deserialization()
    {
        SqlInfo sqlInfo = DsmFileSerializer.Deserializate(path);
    }
}