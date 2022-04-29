namespace DatabaseEngine.Exceptions;

public class InvalidDatabaseName : Exception
{
    private const string MESSAGE = "The database name {0} is invalid for {1} provider.";

    public InvalidDatabaseName(string databaseName, string providerName) :
        base(string.Format(MESSAGE, databaseName, providerName)) {/*Nothing*/}
}