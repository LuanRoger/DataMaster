using System;

namespace DataMaster.Exceptions;

public class AuthenticationInformationException : Exception
{
    const string MESSAGE = "The authentication by {0} and must be have a {1} and a {2}";

    public AuthenticationInformationException(string authenticationType, string requirement1, string requirement2) 
        : base(string.Format(MESSAGE, authenticationType, requirement1, requirement2)) {}
}