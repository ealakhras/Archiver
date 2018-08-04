using System.Data;
using System.Data.SqlClient;


namespace ARCdataTier
{
    public class Database
    {
        #region constructors
        public Database()
        {
            mSqlConnection = new SqlConnection();
            mSqlCommand = new SqlCommand("", mSqlConnection);
            Folders = new Folders(this);
            Documents = new Documents(this);
            Fields = new Fields(this);
            FieldsValues = new FieldsValues(this);
            Images = new Images(this);
            LOVs = new LOVs(this);
        }

        public Database(string connectionString) : this()
        {
            ConnectionString = connectionString;
        }
        #endregion

        #region members
        private readonly SqlConnection mSqlConnection;
        private readonly SqlCommand mSqlCommand;
        private string mFriendlyName;
        private bool mAutoConnect;
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
                if (mSqlConnection.State == ConnectionState.Open)
                {
                    return $"{mSqlConnection.DataSource} ver {mSqlConnection.ServerVersion}";
                }

                string conStr = mSqlConnection.ConnectionString;
                string[] keywords = conStr.Split(';');
                foreach (string keyword in keywords)
                {
                    if (keyword.StartsWith("Data Source"))
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

        public ConnectionState State
        {
            get
            {
                return mSqlConnection.State;
            }
        }

        public Folders Folders { get; }
        public Documents Documents { get; }
        public Images Images { get; }
        public Fields Fields { get; }
        public FieldsValues FieldsValues { get; }
        public LOVs LOVs { get; }

        #endregion

        #region methods
        public override string ToString()
        {
            return $"Engine: {Engine}, Database: {Name}, State: {(State.ToString())}";
        }

        /// <summary>
        /// Connects database object by activating embedded mSQLConnection
        /// </summary>
        public void Connect()
        {
            if (mSqlConnection.State == ConnectionState.Closed)
            {
                mSqlConnection.Open();
            }
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
        public void Close()
        {
            mSqlConnection.Close();
        }

        public void Refresh()
        {
            Close();
            Connect();
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
        #endregion
    }
}