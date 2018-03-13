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
            Dome.CurrentDatabase = this;
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

                mSqlConnection.Close();
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
                //return string.Format("{0} (SQLServer ver {1})", mSqlConnection.DataSource, mSqlConnection.ServerVersion);
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
        public void Connect()
        {
            mSqlConnection.Open();
            mFolders.Populate();
        }

        public void Connect(string connectionString)
        {
            ConnectionString = connectionString;
            Connect();
        }

        public void Disconnect()
        {
            mSqlConnection.Close();
            mFolders.Clear();
        }

        public SqlDataReader ExecuteDataReader(string sql, params object[] parameters)
        {
            mSqlCommand.CommandText = string.Format(sql, parameters);
            return mSqlCommand.ExecuteReader();
        }

        public int ExecuteNonQuery(string sql, params object[] parameters)
        {
            mSqlCommand.CommandText = string.Format(sql, parameters);
            return mSqlCommand.ExecuteNonQuery();
        }

        public SqlDataReader prcFolders_children(int id = 0)
        {
            return ExecuteDataReader("exec prcFolders_children {0}", id);
        }

        public void Refresh()
        {

        }
        
        #endregion
    }
}
