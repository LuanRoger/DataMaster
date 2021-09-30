using System;

namespace DataMaster.Util.Exceptions
{
    public class DatabaseConnectedException : Exception
    {
        private const string EXCEPTION_MESSAGE = "You must only be connected to the server.";
        
        public DatabaseConnectedException() : base(EXCEPTION_MESSAGE) { }
    }
}