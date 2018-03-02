using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using set;


namespace dal
{
    public static class DataDome
    {
        #region constructor
        static DataDome()
        {
            mConnection = new SqlConnection();
            mCommand = new SqlCommand { Connection = mConnection };
            mFolders = new Folders();
        }
        #endregion

        #region members
        private static SqlConnection mConnection;
        private static SqlCommand mCommand;
        private static Folders mFolders;
        #endregion

        #region properties
        public static string DBName
        {
            get
            {
                return mConnection.Database;
            }
        }

        public static string DBEngine
        {
            get
            {
                return string.Format("{0} (SQLServer ver {1})", mConnection.DataSource, mConnection.ServerVersion);
            }
        }
        #endregion

        #region methods
        public static Folders Folders
        {
            get
            {
                return mFolders;
            }
        }

        public static void Connect()
        {
            Connect(RegistryDome.DBConnectionString);
        }

        public static void Connect(string connectionString)
        {
            mConnection.ConnectionString = connectionString;
            mConnection.Open();
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
