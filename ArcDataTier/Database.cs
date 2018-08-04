using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace ArcDataTier
{
    public class Database
    {
        public Database()
        {
            mSqlConnection = new SqlConnection();
        }

        public Database(string connectionString):base()
        {
            if (mSqlConnection.State == ConnectionState.Open)
            {
                mSqlConnection.Close();
            }
            mSqlConnection.ConnectionString = connectionString;
        }

        private readonly SqlConnection mSqlConnection;

        public void Connect()
        {
            mSqlConnection.Open();
        }
    }

}
