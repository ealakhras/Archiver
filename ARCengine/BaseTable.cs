using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ARCengine
{
    public abstract class BaseTable: DatabaseObject
    {
        #region constructors
        public BaseTable(string tableName)
            : base()
        {
            mTableName = tableName;
            mDatabase = Dome.CurrentDatabase;
            mIsDirty = true;
        }

        public BaseTable(Database database, string tableName)
            : this(tableName)
        {
            mDatabase = database;
        }
        #endregion

        #region members
        protected string mTableName;
        #endregion

        #region properties
        public string TableName
        {
            get
            {
                return mTableName;
            }
        }
        #endregion

        #region methods
        private string PrepareParameters(params object[] parameters)
        {
            string result = "";
            foreach (object parameter in parameters)
            {
                if (parameter == null)
                    result += " null,";
                else if (parameter is string)
                {
                    result += " '" + parameter + "',";
                }
                else
                {
                    result += " " + parameter.ToString() + ",";
                }
            }

            // remove last comma, if any:
            return result == "" ? "" : result.Substring(0, result.Length - 1).Trim();
        }

        protected abstract object[] GetReadParameters();
        protected abstract object[] GetSaveParameters();
        protected abstract object[] GetDeleteParameters();

        protected SqlDataReader DoRead(params object[] parameters)
        {
            if (mDatabase == null)
            {
                throw new MissingDatabaseException();
            }
            return mDatabase.ExecuteDataReader("exec prc{0}_read {1}", mTableName, PrepareParameters(parameters));
        }

        protected SqlDataReader DoSave(params object[] parameters)
        {
            if (mDatabase == null)
            {
                throw new MissingDatabaseException();
            }
            return mDatabase.ExecuteDataReader("exec prc{0}_save {1}", mTableName, PrepareParameters(parameters));
        }

        protected void DoDelete(params object[] parameters)
        {
            if (mDatabase == null)
            {
                throw new MissingDatabaseException();
            }
            mDatabase.ExecuteNonQuery("exec prc{0}_delete {1}", mTableName, PrepareParameters(parameters));
        }

        public override void Read()
        {
            SqlDataReader dr = DoRead(GetReadParameters());
            if (dr.Read())
            {
                Read(dr);
            }
            dr.Close();
        }

        protected virtual void Read(int id)
        {
            //this is a generic id read. descendants may override to public visibility.
            SqlDataReader dr = DoRead(new object[] { id });
            if (dr.Read())
            {
                Read(dr);
            }
            dr.Close();
        }

        public virtual void Read(SqlDataReader dr)
        {
            mIsDirty = false;
        }

        public virtual void Save()
        {
            SqlDataReader dr = DoSave(GetSaveParameters());
            if (dr.Read())
            {
                Read(dr);
            }
            dr.Close();
            mIsDirty = false;
        }

        public virtual void Delete()
        {
            DoDelete(GetDeleteParameters());
            mIsDirty = true;
        }
        #endregion
    }
}
