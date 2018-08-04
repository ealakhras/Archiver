using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARCdal
{
    class Database
    {
        public Database(string connectionString)
        {
            mSqlConnection = new SqlConnection(connectionString);
        }

        private readonly SqlConnection mSqlConnection;

    }
}
