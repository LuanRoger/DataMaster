using System;

namespace DataMaster.Util.Exceptions
{
    public class DatabaseNonConnectedException : Exception
    {
        private const string EXCEPTION_MESSAGE = "You must be connected to a database.";

        public DatabaseNonConnectedException() : base(EXCEPTION_MESSAGE) { }
    }
}