using System;
using System.Data.SqlClient;
using ARCengine.Exceptions;

namespace ARCengine
{
    public abstract class BaseTable
    {
        #region constructors
        public BaseTable(string tableName)
        {
            mTableName = tableName;
            mDatabase = Dome.CurrentDatabase;
            mNeedsSaving = true;
            mNeedsRefreshing = true;
            mHasBeenDeleted = false;
        }

        public BaseTable(Database database, string tableName)
            : this(tableName)
        {
            mDatabase = database;
        }
        #endregion

        #region members
        protected Database mDatabase;
        protected string mTableName;
        protected bool mNeedsSaving;
        protected bool mNeedsRefreshing;
        protected bool mHasBeenDeleted;
        #endregion

        #region properties
        public Database Database
        {
            get
            {
                return mDatabase;
            }
        }
        public string TableName
        {
            get
            {
                return mTableName;
            }
        }
        public bool NeedsSaving
        {
            get
            {
                return mNeedsSaving;
            }
        }
        public bool NeedsRefreshing
        {
            get
            {
                return mNeedsRefreshing;
            }
        }
        public bool HasBeenDeleted
        {
            get
            {
                return mHasBeenDeleted;
            }
        }
        #endregion

        #region methods
        /// <summary>
        /// Formats DAL procedure parameters into a compatible common string.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Reads a DataReader Field as an Integer.
        /// </summary>
        /// <param name="drField"></param>
        /// <returns></returns>
        protected int GetIntFromDataReader(object drField)
        {
            if ((drField != null) && (int.TryParse(drField.ToString(), out int result)))
                return result;

            return 0;
        }

        /// <summary>
        /// Reads a DataReader Field as a String.
        /// </summary>
        /// <param name="drField"></param>
        /// <returns></returns>
        protected string GetStringFromDataReader(object drField)
        {
            if (drField != null)
                return drField.ToString();

            return string.Empty;
        }

        /// <summary>
        /// Reads a DataReader Field as a DateTime.
        /// </summary>
        /// <param name="drField"></param>
        /// <returns></returns>
        protected DateTime GetDateTimeFromDataReader(object drField)
        {
            if ((drField != null) && (DateTime.TryParse(drField.ToString(), out DateTime result)))
            {
                return result;
            }
            return DateTime.MinValue;
        }

        /// <summary>
        /// Reads a DataReader field as a Bool.
        /// </summary>
        /// <param name="drField"></param>
        /// <returns></returns>
        protected bool GetBoolFromDataReader(object drField)
        {
            if ((drField != null) && (bool.TryParse(drField.ToString(), out bool result)))
            {
                return result;
            }
            return false;
        }

        protected abstract object[] GetReadParameters();

        protected abstract object[] GetSaveParameters();

        protected abstract object[] GetDeleteParameters();

        /// <summary>
        /// DAL Read.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private SqlDataReader DoRead(params object[] parameters)
        {
            if (mDatabase == null)
            {
                throw new MissingDatabaseException();
            }
            return mDatabase.ExecuteDataReader("exec prc{0}_read {1}", mTableName, PrepareParameters(parameters));
        }

        /// <summary>
        /// DAL Save.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private SqlDataReader DoSave(params object[] parameters)
        {
            if (mDatabase == null)
            {
                throw new MissingDatabaseException();
            }
            return mDatabase.ExecuteDataReader("exec prc{0}_save {1}", mTableName, PrepareParameters(parameters));
        }

        /// <summary>
        /// DAL Delete.
        /// </summary>
        /// <param name="parameters"></param>
        private void DoDelete(params object[] parameters)
        {
            if (mDatabase == null)
            {
                throw new MissingDatabaseException();
            }
            mDatabase.ExecuteNonQuery("exec prc{0}_delete {1}", mTableName, PrepareParameters(parameters));
        }

        /// <summary>
        /// Initiates object by excuting DAL Reader and populating members accordingly.
        /// </summary>
        public virtual void Read()
        {
            SqlDataReader dr = DoRead(GetReadParameters());
            if (dr.Read())
            {
                Read(dr);
            }
            dr.Close();
        }

        /// <summary>
        /// Initiates object from DAL given it's id.
        /// </summary>
        /// <param name="id"></param>
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

        /// <summary>
        /// Populate object member from given DataReader.
        /// </summary>
        /// <param name="dr">An Opened DataReader pointing to targeted DAL record</param>
        public virtual void Read(SqlDataReader dr)
        {
            mNeedsSaving = false;
            mNeedsRefreshing = false;
            mHasBeenDeleted = false;
        }

        /// <summary>
        /// Saves object by calling DAL Save and providing members as parameters.
        /// </summary>
        public virtual void Save()
        {
            SqlDataReader dr = DoSave(GetSaveParameters());
            if (dr.Read())
            {
                Read(dr);
            }
            dr.Close();
            mNeedsSaving = false;
            mNeedsRefreshing = false;
        }

        /// <summary>
        /// Deletes object from Database by executing DAL Delete.
        /// </summary>
        public virtual void Delete()
        {
            DoDelete(GetDeleteParameters());
            mNeedsSaving = false;
            mNeedsRefreshing = false;
            mHasBeenDeleted = true;
        }

        /// <summary>
        /// Refresh object by calling Read.
        /// </summary>
        public virtual void Refresh()
        {
            Read();
        }
        #endregion
    }
}
