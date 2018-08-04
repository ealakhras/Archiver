using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARCdataTier;

namespace ARCbusinessTier
{
    public class BaseObject
    {
        #region constructors
        public BaseObject()
        {
            mIsNew = true;
            mIsDirty = true;
            mIsDeleted = false;
        }

        public BaseObject(Database database) : this()
        {
            InitDatabase(database);
        }
        #endregion

        #region members
        protected Database mDatabase;
        protected BaseTable mTable;
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
                InitDatabase(value);
            }
        }
        public bool IsConnected
        {
            get
            {
                return !(mDatabase == null);
            }
        }
        #endregion

        #region methods
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
            if((drField != null) && char.TryParse(drField.ToString(), out char result))
            {
                return result;
            }
            return char.MinValue;
        }

        protected Stream GetStreamFromDataReader(object drField)
        {
            return null;
        }

        protected virtual void InitDatabase(Database database)
        {
            mDatabase = database;
            mIsDirty = true;
        }

        protected virtual void Init()
        {
            mIsNew = false;
            mIsDirty = false;
        }

        protected virtual void Init(SqlDataReader dr)
        {
            // i do nothing here.
            // Init();
        }

        protected virtual void DoRead()
        {
            // i do nothing here.
        }

        protected virtual void DoSave()
        {
            // i do nothing here.
        }

        protected virtual void DoDelete()
        {
            // i do nothing here.
        }

        public bool Read()
        {
            if (!IsConnected)
            {
                return false;
            }
            DoRead();
            //mIsNew = false;
            //mIsDirty = false;
            //mIsDeleted = false;
            return true;
        }

        public bool Save()
        {
            if (!IsConnected)
            {
                return false;
            }
            DoSave();
            mIsNew = false;
            mIsDirty = false;
            mIsDeleted = false;
            return true;
        }

        public bool Save(Database database)
        {
            Database = database;
            return Save();
        }

        public bool Delete()
        {
            if (!IsConnected)
            {
                return false;
            }
            DoDelete();
            mIsNew = true;
            mIsDirty = false;
            mIsDeleted = true;
            return true;
        }

        public bool Delete(Database database)
        {
            Database = database;
            return Delete();
        }

        public bool Refresh()
        {
            return Read();
        }

        public override string ToString()
        {
            return $"Type: {base.ToString()}\nIsNew: {mIsNew}, IsDirty: {mIsDirty}, IsDeleted: {mIsDeleted}";
        }
        #endregion
    }



    public class BaseObjectWithID : BaseObject
    {
        #region constructors
        public BaseObjectWithID() : base()
        {
            mID = 0;
            mCreationDate = DateTime.Now;
        }

        public BaseObjectWithID(Database database) : base(database)
        {

        }

        public BaseObjectWithID(Database database, int id) : this(database)
        {
            Read(id);
        }

        public BaseObjectWithID(int id, string name, string description = "")
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
                if(mName == value)
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
                if(mDescription == value)
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
        protected void Init(int id, string name, string description)
        {
            Init(id, name, description, "", DateTime.Now);
        }

        protected void Init(int id, string name, string description, string creator, DateTime creationDate)
        {
            Init();
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

        protected override void DoRead()
        {
            using (SqlDataReader dr = ((BaseTableWithID)mTable).Read(mID))
            {
                if (dr.Read())
                {
                    Init(dr);
                }
                dr.Close();
            }
        }

        protected override void DoDelete()
        {
            ((BaseTableWithID)mTable).Delete(mID);
        }

        public bool Read(int id)
        {
            mID = id;
            return Read();
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nID: {mID}\nName: '{mName}'\nDesciption: '{mDescription}'\nCreator: {mCreator}\nCreationDate: {mCreationDate}";
        }
        #endregion
    }
}