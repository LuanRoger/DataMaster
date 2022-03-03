using System;

namespace DatabaseEngineInterpreter.SqlSyntaxInfo;

[Serializable]
public class SqlColumns
{
    public string name {get; private set;}
    public bool hasKey { get; private set; }
    public bool allowNull { get; private set; }
    public string dataType {get; private set; }

    public SqlColumns(string name, bool hasKey, bool allowNull, string dataType)
    {
        this.name = name;
        this.hasKey = hasKey;
        this.allowNull = allowNull;
        this.dataType = dataType;
    }
}