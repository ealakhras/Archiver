using System;
using System.Data.SqlClient;

namespace ARCengine.CoreObjects
{
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