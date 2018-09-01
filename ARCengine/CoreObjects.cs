using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ARCengine.Exceptions;

namespace ARCengine
{
    public enum SqlParamTypes { String, Integer, DateTime, Boolean, Image };

    public abstract class CoreTable
    {
        #region constructors
        public CoreTable(string tableName)
        {
            mTableName = tableName;
            mIsNew = true;
            mIsDirty = true;
            mIsDeleted = false;
        }

        public CoreTable(string tableName, Database database) : this(tableName)
        {
            Database = database;
        }
        #endregion

        #region members
        protected Database mDatabase;
        protected string mTableName;
        protected bool mIsNew;
        protected bool mIsDirty;
        protected bool mIsDeleted;
        #endregion

        #region properties
        public bool IsNew => mIsNew;
        public bool IsDirty => mIsDirty;
        public bool IsDeleted => mIsDeleted;
        public Database Database
        {
            get
            {
                return mDatabase;
            }
            set
            {
                if (mDatabase == value)
                {
                    return;
                }
                mIsDirty = true;
            }
        }
        public string TableName
        {
            get
            {
                return mTableName;
            }
        }
        public bool IsConnected
        {
            get
            {
                return !((mDatabase == null) && (mDatabase.State == ConnectionState.Open));
            }
        }
        #endregion

        #region methods
        protected virtual void Init()
        {
            mIsNew = false;
            mIsDeleted = false;
            mIsDirty = false;
        }

        protected virtual void Init(SqlDataReader dr)
        {
            // i do nothing here.
            Init();
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

        protected char GetCharFromDataReader(object drField)
        {
            if ((drField != null) && char.TryParse(drField.ToString(), out char result))
            {
                return result;
            }
            return char.MinValue;
        }

        protected Stream GetStreamFromDataReader(object drField)
        {
            return null;
        }

        protected virtual SqlParameterCollection GetReadParameters()
        {
            return new SqlCommand().Parameters;
        }

        protected virtual SqlParameterCollection GetSaveParameters()
        {
            return new SqlCommand().Parameters;
        }

        protected virtual SqlParameterCollection GetDeleteParameters()
        {
            return new SqlCommand().Parameters;
        }

        private string GetReadProcedure()
        {
            return $"prc{mTableName}_read";
        }

        private string GetSaveProcedure()
        {
            return $"prc{mTableName}_save";
        }

        private string GetDeleteProcedure()
        {
            return $"prc{mTableName}_delete";
        }

        /// <summary>
        /// adds a SqlParameter to destination SqlParametersCollection
        /// </summary>
        /// <param name="destination">SqlParametersCollection to add to</param>
        /// <param name="paramName">new parameter name</param>
        /// <param name="paramType">new parameter type</param>
        /// <param name="paramValue">new parameter value</param>
        protected void AddParam(SqlParameterCollection destination, string paramName, SqlParamTypes paramType, object paramValue)
        {
            switch (paramType)
            {
                case SqlParamTypes.String:
                    destination.Add(paramName, SqlDbType.VarChar).Value = paramValue;
                    break;

                case SqlParamTypes.Integer:
                    destination.Add(paramName, SqlDbType.BigInt).Value = paramValue;
                    break;

                case SqlParamTypes.DateTime:
                    destination.Add(paramName, SqlDbType.DateTime).Value = paramValue;
                    break;

                case SqlParamTypes.Boolean:
                    destination.Add(paramName, SqlDbType.Bit).Value = paramValue;
                    break;

                case SqlParamTypes.Image:
                    destination.Add(paramName, SqlDbType.VarBinary).Value = paramValue;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// DAL Read.
        /// </summary>
        /// <returns></returns>
        protected virtual void DoRead()
        {
            using (SqlDataReader dr = mDatabase.ExecuteDataReader(GetReadProcedure(), GetReadParameters()))
            {
                if (dr.Read())
                {
                    Init(dr);
                }
                dr.Close();
            }
            mIsNew = false;
            mIsDeleted = false;
            mIsDirty = false;
        }

        /// <summary>
        /// DAL Save.
        /// </summary>
        /// <returns></returns>
        protected virtual void DoSave()
        {
            using (SqlDataReader dr = mDatabase.ExecuteDataReader(GetSaveProcedure(), GetSaveParameters()))
            {
                if (dr.Read())
                {
                    Init(dr);
                }
                dr.Close();
            }
            mIsNew = false;
            mIsDeleted = false;
            mIsDirty = false;
        }

        /// <summary>
        /// DAL Delete.
        /// </summary>
        /// <returns></returns>
        protected virtual void DoDelete()
        {
            mDatabase.ExecuteNonQuery(GetDeleteProcedure(), GetDeleteParameters());
            mIsNew = true;
            mIsDeleted = true;
            mIsDirty = true;
        }

        /// <summary>
        /// Initiates object by excuting DAL Reader and populating members accordingly.
        /// </summary>
        public void Read()
        {
            if (!IsConnected)
            {
                throw new MissingDatabaseException();
            }
            DoRead();
        }

        /// <summary>
        /// Saves object by calling DAL Save and providing members as parameters.
        /// </summary>
        public virtual void Save()
        {
            if (!IsConnected)
            {
                throw new MissingDatabaseException();
            }
            DoSave();
        }

        /// <summary>
        /// Saves object to a destination database
        /// </summary>
        /// <param name="database">destination database</param>
        /// <returns></returns>
        public void Save(Database database)
        {
            Database = database;
            Save();
        }

        /// <summary>
        /// Deletes object from Database by executing DAL Delete.
        /// </summary>
        public void Delete()
        {
            if (!IsConnected)
            {
                throw new MissingDatabaseException();
            }
            DoDelete();
        }

        /// <summary>
        /// Refresh object by calling Read.
        /// </summary>
        public virtual void Refresh()
        {
            Read();
        }

        public override string ToString()
        {
            return $"Type: {base.ToString()}\nIsNew: {mIsNew}, IsDirty: {mIsDirty}, IsDeleted: {mIsDeleted}";
        }
        #endregion
    }


    public abstract class CoreTableWithID : CoreTable
    {
        #region constructors
        public CoreTableWithID(string tableName) : base(tableName)
        {
            mID = 0;
            mName = "<new>";
            mCreationDate = DateTime.Now;
        }

        public CoreTableWithID(string tableName, Database database) : this(tableName)
        {
            Database = database;
        }

        public CoreTableWithID(string tableName, Database database, int id) : this(tableName, database)
        {
            mID = id;
            Read();
        }

        public CoreTableWithID(string tableName, int id, string name, string description = "") : this(tableName)
        {
            Init(id, name, description);
        }
        #endregion

        #region members
        protected int mID;
        protected string mName;
        protected string mDescription;
        protected string mCreator;
        protected DateTime mCreationDate;
        #endregion

        #region properties
        public int ID
        {
            get
            {
                return mID;
            }
        }
        public string Name
        {
            get
            {
                return mName;
            }
            set
            {
                if (mName == value)
                {
                    return;
                }
                mName = value;
                mIsDirty = true;
            }
        }
        public string Description
        {
            get
            {
                return mDescription;
            }
            set
            {
                if (mDescription == value)
                {
                    return;
                }
                mDescription = value;
                mIsDirty = true;
            }
        }
        public string Creator
        {
            get
            {
                return mCreator;
            }
        }
        public DateTime CreationDate
        {
            get
            {
                return mCreationDate;
            }
        }
        #endregion

        #region methods
        protected override SqlParameterCollection GetReadParameters()
        {
            SqlParameterCollection result = base.GetReadParameters();
            AddParam(result, "@id", SqlParamTypes.Integer, mID);
            return result;
        }

        protected override SqlParameterCollection GetSaveParameters()
        {
            SqlParameterCollection result = base.GetSaveParameters();
            AddParam(result, "@id", SqlParamTypes.Integer, mID);
            AddParam(result, "@name", SqlParamTypes.String, mName);
            AddParam(result, "@description", SqlParamTypes.String, mDescription);
            return result;
        }

        protected override SqlParameterCollection GetDeleteParameters()
        {
            SqlParameterCollection result = base.GetDeleteParameters();
            AddParam(result, "@id", SqlParamTypes.Integer, mID);
            return result;
        }

        protected void Init(int id, string name, string description)
        {
            Init(id, name, description, "", DateTime.Now);
        }

        protected void Init(int id, string name, string description, string creator, DateTime creationDate)
        {
            base.Init();
            mID = id;
            mName = name;
            mDescription = description;
            mCreator = creator;
            mCreationDate = creationDate;
        }

        protected override void Init(SqlDataReader dr)
        {
            base.Init(dr);
            Init(
                GetIntFromDataReader(dr["id"]),
                GetStringFromDataReader(dr["name"]),
                GetStringFromDataReader(dr["description"]),
                GetStringFromDataReader(dr["creator"]),
                GetDateTimeFromDataReader(dr["creationDate"]));
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nID: {mID}\nName: '{mName}'\nDesciption: '{mDescription}'\nCreator: {mCreator}\nCreationDate: {mCreationDate}";
        }
        #endregion
    }
}