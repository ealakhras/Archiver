using System.Data;
using System.Data.SqlClient;
using ARCengine.Interfaces;
using ARCengine.Collections;
using System;
using System.Windows.Forms;


namespace ARCengine
{
    public class Database: ICollectionOwner, IUsesPropertiesForm
    {
        #region constructor
        public Database()
        {
            mSqlConnection = new SqlConnection();
            mSqlCommand = new SqlCommand { Connection = mSqlConnection };
            mFolders = new FoldersCollection(this);
            //Dome.Databases.Add(this);
        }

        public Database(string connectionString)
            : this()
        {
            ConnectionString = connectionString;
            // connectionString will auto-connect, if set.
        }
        #endregion

        #region members
        private readonly SqlConnection mSqlConnection;
        private readonly SqlCommand mSqlCommand;
        private string mFriendlyName;
        private bool mAutoConnect;
        private FoldersCollection mFolders;
        #endregion

        #region properties
        public string ConnectionString
        {
            get
            {
                return mSqlConnection.ConnectionString +
                                $";Friendly Name={mFriendlyName}" +
                                $"; Auto Connect={(mAutoConnect ? 1 : 0)}";
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
                if (mAutoConnect)
                {
                    mSqlConnection.Open();
                }
            }
        }
        public string Engine
        {
            get
            {
                if(mSqlConnection.State == ConnectionState.Open)
                {
                    return $"{mSqlConnection.DataSource} ver {mSqlConnection.ServerVersion}";
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
                    Open();
                }
            }
        }
        public FoldersCollection Folders
        {
            get
            {
                return mFolders;
            }
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
        /// Sets sql parameter as the SqlCommand Text, and reset SqlCommand Parameters to parameters
        /// </summary>
        /// <param name="sql">to be assigned to SqlCommand.Text</param>
        /// <param name="parameters">parameters to be set to SqlCommand.Parameters</param>
        private void PrepareSqlCommandParams(SqlParameterCollection parameters)
        {
            mSqlCommand.Parameters.Clear();
            foreach (SqlParameter par in parameters)
            {
                mSqlCommand.Parameters.Add(par);
            }
        }

        public override string ToString()
        {
            return $"Engine: {Engine}, Database: {Name}, Status: {State.ToString()}";
        }

        /// <summary>
        /// Connects database object by activating embedded mSQLConnection
        /// </summary>
        public void Open()
        {
            if (mSqlConnection.State == ConnectionState.Closed)
            {
                mSqlConnection.Open();
                mFolders.Read();
            }
        }

        /// <summary>
        /// Connects database object by activating embedded mSqlConnection
        /// using given connectionString
        /// </summary>
        /// <param name="connectionString"></param>
        public void Open(string connectionString)
        {
            ConnectionString = connectionString;
            Open();
        }

        /// <summary>
        /// Closes mSqlConnection and dispose of Database components
        /// </summary>
        public void Close()
        {
            mSqlConnection.Close();
            mFolders.Clear();
        }

        /// <summary>
        /// Refreshes the Database object with all its internal components.
        /// </summary>
        public void Refresh()
        {
            Close();
            Open();
        }

        /// <summary>
        /// Generic ExecuteDataReader at embedded mSqlCommand
        /// using given sql script and optional parameters
        /// </summary>
        /// <param name="sql">sql script to execute</param>
        /// <param name="parameters">optional sql script parameters</param>
        /// <returns></returns>
        public SqlDataReader ExecuteDataReader(string sql, SqlParameterCollection parameters)
        {
            PrepareSqlCommandParams(parameters);
            return ExecuteDataReader(sql);
        }

        /// <summary>
        /// Generic ExecuteDataReader at embedded mSqlCommand
        /// using given sql script/command
        /// </summary>
        /// <param name="sql">sql script to execute</param>
        /// <returns></returns>
        public SqlDataReader ExecuteDataReader(string sql)
        {
            mSqlCommand.CommandText = sql;
            return mSqlCommand.ExecuteReader();
        }

        /// <summary>
        /// Generic ExecuteNonQuery at embedded mSqlCommand
        /// using given sql script and optional paramters
        /// </summary>
        /// <param name="sql">sql script to execute</param>
        /// <param name="parameters">optional sql script parameters</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, SqlParameterCollection parameters)
        {
            PrepareSqlCommandParams(parameters);
            return ExecuteNonQuery(sql);
        }

        /// <summary>
        /// Generic ExecuteNonQuery at embedded mSqlCommand
        /// using given sql script
        /// </summary>
        /// <param name="sql">sql script to execute</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql)
        {
            mSqlCommand.CommandText = sql;
            return mSqlCommand.ExecuteNonQuery();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
