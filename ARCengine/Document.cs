using System;
using System.Data.SqlClient;
using ARCengine.Collections;

namespace ARCengine
{
    public class Document : CoreTableWithID
    {
        #region constructors
        public Document() : base("Documents")
        {
            mFieldsValues = new FieldsValuesCollection(this);
        }

        public Document(Database database) :this()
        {
            Database = database;
        }

        public Document(Database database, int id) : this(database)
        {
            mID = id;
            Read();
        }

        /*
        public Document(Folder folder, SqlDataReader dr) : this()
        {
            mFolderID = folder.ID;
            mFolder = folder;
            Init(dr);
        }
        */
        #endregion

        #region members
        private Folder mFolder;
        private int mFolderID;
        private FieldsValuesCollection mFieldsValues;
        #endregion

        #region properties
        public int FolderID
        {
            get
            {
                return mFolderID;
            }
            set
            {
                if(mFolderID == value)
                {
                    return;
                }
                mFolderID = value;
                mIsDirty = true;
            }
        }
        public Folder Folder
        {
            get
            {
                return mFolder;
            }
            set
            {
                if (mFolder == value)
                {
                    return;
                }
                mFolder = value;
                mFolderID = value.ID;
                mIsDirty = true;
            }
        }
        public FieldsValuesCollection FieldsValues
        {
            get
            {
                if (mFieldsValues.NeedsRefreshing)
                {
                    mFieldsValues.Refresh();
                }
                return mFieldsValues;
            }
        }
        #endregion

        #region method
        protected override SqlParameterCollection GetSaveParameters()
        {
            SqlParameterCollection result = base.GetSaveParameters();
            AddParam(result, "@folderID", SqlParamTypes.Integer, mFolderID);
            return result;
        }

        protected override void Init(SqlDataReader dr)
        {
            base.Init(dr);
            mFolderID = GetIntFromDataReader(dr["folderID"]);
        }

        public void ReadFieldsValues(SqlDataReader dr)
        {
            mFieldsValues.Read(dr);
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nFolderID: {mFolderID}";
        }
        #endregion
    }
}
