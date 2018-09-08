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
            mState = DatabaseStateEnum.Initializing;
            mSqlConnection = new SqlConnection();
            mSqlCommand = new SqlCommand { Connection = mSqlConnection };
            mFolders = new FoldersCollection(this);
            Dome.Databases.Add(this);
        }

        public Database(string connectionString)
            : this()
        {
            ConnectionString = connectionString;
            // connectionString will auto-connect, if set.
        }
        #endregion

        #region members
        private DatabaseStateEnum mState;
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
                mState = DatabaseStateEnum.Initializing;

                // strip to formal connection string, and put result into conStr:
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

                // now try using conStr:
                try
                {
                    // this might raise exceptions:
                    mSqlConnection.ConnectionString = conStr;

                    // connect if AutoConnect:
                    if (mAutoConnect)
                    {
                        mSqlConnection.Open();
                    }
                    mState = DatabaseStateEnum.Ready;
                }
                catch (Exception ex)
                {
                    mState = DatabaseStateEnum.ErrorInConnectionString;
                    MessageBox.Show(ex.Message);
                    //throw;
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
                if (mFolders.NeedsRefreshing)
                {
                    mFolders.Refresh();
                }
                return mFolders;
            }
        }
        public DatabaseStateEnum State
        {
            get
            {
                switch (mState)
                {
                    case DatabaseStateEnum.Initializing:
                        return DatabaseStateEnum.Initializing;

                    case DatabaseStateEnum.ErrorInConnectionString:
                        return DatabaseStateEnum.ErrorInConnectionString;

                    case DatabaseStateEnum.ErrorInDBStructure:
                        return DatabaseStateEnum.ErrorInDBStructure;

                    default: // Ready, Opened, Closed
                        return mSqlConnection.State == ConnectionState.Closed ? DatabaseStateEnum.Closed : DatabaseStateEnum.Opened;
                }
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
                SqlParameter p = new SqlParameter(par.ParameterName, par.SqlDbType);
                p.Value = par.Value;
                mSqlCommand.Parameters.Add(p);
            }
        }

        public override string ToString()
        {
            return $"Engine: {Engine}, Database: {Name}, State: {State.ToString()}";
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
