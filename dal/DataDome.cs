using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace dal
{
    public static class DataDome
    {
        private static SqlConnection mConnection;
        private static SqlCommand mCommand;
        private static Folders mFolders;

        public static Folders Folders
        {
            get
            {
                return mFolders;
            }
        }

        public static void ConnectTo(string connectionString)
        {
            mConnection = new SqlConnection(connectionString);
            mConnection.Open();

            mCommand = new SqlCommand { Connection = mConnection };
            mFolders = new Folders();
        }

        public static SqlDataReader ExecuteDataReader(string sql)
        {
            mCommand.CommandText = sql;
            return mCommand.ExecuteReader();
        }

        public static int ExecuteNonQuery(string sql)
        {
            mCommand.CommandText = sql;
            return mCommand.ExecuteNonQuery();
        }
    }
}
