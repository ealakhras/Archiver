using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ARCengine
{
    public class Database: ICollectionOwner
    {
        #region constructor
        public Database()
        {
            mSqlConnection = new SqlConnection();
            mSqlCommand = new SqlCommand { Connection = mSqlConnection };
            mFolders = new FolderCollection(this);
            Dome.Databases.Add(this);
        }

        public Database(string connectionString)
            : this()
        {
            ConnectionString = connectionString;
            if (AutoConnect)
            {
                Connect();
            }
        }
        #endregion

        #region members
        private SqlConnection mSqlConnection;
        private SqlCommand mSqlCommand;
        private string mFriendlyName;
        private bool mAutoConnect;
        private FolderCollection mFolders;
        #endregion

        #region properties
        public string ConnectionString
        {
            get
            {
                return mSqlConnection.ConnectionString
                            + string.Format(@";Friendly Name=""{0}""", mFriendlyName)
                            + string.Format(@";Auto Connect={1}", mFriendlyName, mAutoConnect ? "1" : "0");
            }
            set
            {
                if (mSqlConnection.ConnectionString == value)
                {
                    return;
                }
                // reset:
                mSqlConnection.Close();
                mAutoConnect = false;
                string conStr = "";
                string[] keywords = value.Split(';');
                foreach (string keyword in keywords)
                {
                    if (keyword.Trim().StartsWith("Friendly Name"))
                    {
                        mFriendlyName = keyword.Substring(keyword.IndexOf('"') + 1).Replace(@"""", "");
                    }
                    else if (keyword.Trim().StartsWith("Auto Connect"))
                    {
                        mAutoConnect = (keyword.Substring(keyword.IndexOf('=') + 1).Trim()) == "0" ? false : true;
                    }
                    else
                    {
                        conStr += @keyword + ';';
                    }
                }
                mSqlConnection.ConnectionString = conStr;
            }
        }

        public string Engine
        {
            get
            {
                if(mSqlConnection.State == ConnectionState.Open)
                {
                    return string.Format("{0} ver {1}", mSqlConnection.DataSource, mSqlConnection.ServerVersion);
                }

                string conStr = mSqlConnection.ConnectionString;
                string[] keywords = conStr.Split(';');
                foreach (string keyword in keywords)
                {
                    if(keyword.StartsWith("Data Source"))
                    {
                        return keyword.Substring(keyword.IndexOf("=") + 1).Trim();
                    }
                }
                return string.Empty;
            }
        }

        public string Name
        {
            get
            {
                return mSqlConnection.Database;
            }
        }

        public string FriendlyName
        {
            get
            {
                return mFriendlyName;
            }
            set
            {
                if (mFriendlyName == value)
                {
                    return;
                }
                mFriendlyName = value;
            }
        }

        public bool AutoConnect
        {
            get
            {
                return mAutoConnect;
            }
            set
            {
                if (mAutoConnect == value)
                {
                    return;
                }
                mAutoConnect = value;
                if (mAutoConnect)
                {
                    Connect();
                }
            }
        }

        public FolderCollection Folders
        {
            get
            {
                return mFolders;
            }
        }

        public override string ToString()
        {
            return string.Format("Engine: {0}, Database: {1}", Engine, Name);
        }

        public ConnectionState State
        {
            get
            {
                return mSqlConnection.State;
            }
        }
        #endregion

        #region methods
        /// <summary>
        /// Connects database object by activating embedded mSQLConnection
        /// </summary>
        public void Connect()
        {
            mSqlConnection.Open();
            mFolders.Populate();
        }

        /// <summary>
        /// Connects database object by activating embedded mSqlConnection
        /// using given connectionString
        /// </summary>
        /// <param name="connectionString"></param>
        public void Connect(string connectionString)
        {
            ConnectionString = connectionString;
            Connect();
        }

        /// <summary>
        /// Closes mSqlConnection and dispose of Database components
        /// </summary>
        public void Disconnect()
        {
            mSqlConnection.Close();
            mFolders.Clear();
        }

        /// <summary>
        /// Generic ExecuteDataReader at embedded mSqlCommand
        /// using given sql script and optional parameters
        /// </summary>
        /// <param name="sql">sql script to execute</param>
        /// <param name="parameters">optional sql script parameters</param>
        /// <returns></returns>
        public SqlDataReader ExecuteDataReader(string sql, params object[] parameters)
        {
            mSqlCommand.CommandText = string.Format(sql, parameters);
            return mSqlCommand.ExecuteReader();
        }

        /// <summary>
        /// Generic ExecuteNonReader at embedded mSqlCommand
        /// using given sql script and optional paramters
        /// </summary>
        /// <param name="sql">sql script to execute</param>
        /// <param name="parameters">optional sql script parameters</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, params object[] parameters)
        {
            mSqlCommand.CommandText = string.Format(sql, parameters);
            return mSqlCommand.ExecuteNonQuery();
        }

        public void ExecuteNonQueryAsync(string sql, params object[] parameters)
        {
            mSqlCommand.CommandText = string.Format(sql, parameters);
            mSqlCommand.ExecuteNonQueryAsync();
        }

        /// <summary>
        /// Refreshes the Database object with all its internal components.
        /// </summary>
        public void Refresh()
        {

        }   
        #endregion
    }
}
