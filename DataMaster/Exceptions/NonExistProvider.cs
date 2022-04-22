using System;

namespace DataMaster.Exceptions;

public class NonExistProvider : Exception
{
    private const string MESSAGE = "The provider in inde {0} does't exist";

    public NonExistProvider(int providerIndex) : base(string.Format(MESSAGE, providerIndex)) { /*Nothing*/ }
}