using System;
using System.Data.SqlClient;
using dal;


namespace bal
{
    public class Folder : BaseObject
    {
        #region constructors
        public Folder()
            : base()
        {
            mSubFolders = new FoldersCollection(this);
            mName = "<new>";
        }

        public Folder(int id)
            : this()
        {
            SqlDataReader dr = DataDome.Folders.Read(id);
            if (dr.Read())
            {
                InitFromDataReader(dr);
            }
            dr.Close();
        }

        public Folder(SqlDataReader dr)
            : this()
        {
            InitFromDataReader(dr);
        }
        #endregion
        
        #region members
        private int mID;
        private int mParentID;
        private string mName;
        private string mDescription;
        private string mCreator;
        private DateTime mCreationDate;
        private FoldersCollection mSubFolders;
        protected Folder mParentFolder;
        #endregion

        #region properties
        public int ID
        {
            get
            {
                return mID;
            }
        }

        public int ParentID
        {
            get
            {
                return mParentID;
            }
            set
            {
                if(mParentID == value)
                {
                    return;
                }
                mParentID = value;
                mIsDirty = true;
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

        public Folder ParentFolder
        {
            get
            {
                return mParentFolder;
            }
            set
            {
                if (mParentFolder == value)
                {
                    return;
                }
                mParentFolder = value;
                mParentID = value.mID;
                mIsDirty = true;
            }
        }

        public FoldersCollection SubFolders
        {
            get
            {
                return mSubFolders;
            }
        }
        #endregion

        #region methods
        protected override void InitFromDataReader(SqlDataReader dr)
        {
            mID = GetIntFromDataReader(dr["id"]);
            mParentID = GetIntFromDataReader(dr["parentID"]);
            mName = GetStringFromDataReader(dr["name"]);
            mDescription = GetStringFromDataReader(dr["description"]);
            mCreator = GetStringFromDataReader(dr["creator"]);
            mCreationDate = GetDateTimeFromDataReader(dr["creationDate"]);
            mIsDirty = false;
        }

        public override void Save()
        {
            if (!mIsDirty)
                return;

            SqlDataReader dr = DataDome.Folders.Save(mID, mParentID, mName, mDescription);
            if (dr.Read())
            {
                InitFromDataReader(dr);
            }
            dr.Close();
            base.Save();
        }

        public override void Delete()
        {
            DataDome.Folders.Delete(mID);
            base.Delete();
        }

        public override void Refresh()
        {
            SqlDataReader dr = DataDome.Folders.Read(mID);
            if (dr.Read())
            {
                InitFromDataReader(dr);
            }
            dr.Close();
            base.Refresh();
        }

        public override string ToString()
        {
            string result = string.Format("Name: '{0}'", mName) + '\n';
            result += string.Format("ID: {0}", mID) + '\n';
            result += string.Format("ParentID: {0}", mParentID) + '\n';
            result += string.Format("Description: '{0}'", mDescription) + '\n';
            result += string.Format("Creator: '{0}'", mCreator) + '\n';
            result += string.Format("CreationDate: {0}", mCreationDate) + '\n';
            return result;
        }

        public Folder FindParent(int parentID)
        {
            Folder f = mParentFolder;
            while (f != null)
            {
                if (f.ID == parentID)
                {
                    break;
                }
                else
                {
                    f = f.FindParent(parentID);
                }
            }
            return f;
        }
        #endregion
    }
}
