using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARCengine.Exceptions
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
