namespace DataMaster.Util.ConnStringBuilder;

public interface IConnStringBuilder
{
    public string connectionString { get; }
    public void Clear();
}