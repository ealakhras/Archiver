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
        #region members
        private static SqlConnection mConnection;
        private static SqlCommand mCommand;
        private static Folders mFolders;
        #endregion

        #region methods
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

        public static SqlDataReader ExecuteDataReader(string sql, params object[] parameters)
        {
            mCommand.CommandText = string.Format(sql, parameters);
            return mCommand.ExecuteReader();
        }

        public static int ExecuteNonQuery(string sql, params object[] parameters)
        {
            mCommand.CommandText = string.Format(sql, parameters);
            return mCommand.ExecuteNonQuery();
        }
        #endregion
    }
}
