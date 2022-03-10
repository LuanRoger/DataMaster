namespace DatabaseEngine.Exceptions;

public class MandatoryNonNullValue : Exception
{
    const string MESSAGE = "The {0} must be non-null";

    public MandatoryNonNullValue(string varibleName) : base(string.Format(MESSAGE, varibleName)) {}
}