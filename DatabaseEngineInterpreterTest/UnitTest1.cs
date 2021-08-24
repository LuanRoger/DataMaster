using DatabaseEngineInterpreter.SqlSyntaxInfo;
using DatabaseEngineInterpreter.Serialization.DsmFile;
using System;
using Xunit;
using System.Collections.Generic;

namespace DatabaseEngineInterpreterTest
{
    public class UnitTest1
    {
        private string path = @"C:\Users\luanr\Desktop\test" + DatabaseEngineInterpreter.Consts.DSM_FILE_EXTENSION;

        [Fact]
        public void Serialization()
        {
            SqlInfo sqlInfo = new("Test", new() { 
                    new DataTable("Pessoa", 
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
}
