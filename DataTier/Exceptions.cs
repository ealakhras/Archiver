using System;

namespace ARCdataTier
{
    public class MissingDatabaseException : Exception
    {
        const string MSG_MISSING_DATABASE_EXCEPTION = "Database Connection is not set.";

        public MissingDatabaseException()
            : base(MSG_MISSING_DATABASE_EXCEPTION)
        {
        }
    }
}
