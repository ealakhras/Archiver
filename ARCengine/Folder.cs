using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ARCengine
{
    class Folder : BaseTable
    {
        #region constructors
        public Folder()
            : base("Folders")
        {
            //mSubFolders = new FoldersCollection(this);
            mName = "<new>";
        }

        public Folder(int id)
            : this()
        {
            Read(id);
        }

        public Folder(SqlDataReader dr)
            : this()
        {
            Read(dr);
        }

        public Folder(Database database)
            : this()
        {
            mDatabase = database;
        }

        public Folder(Database database, int id)
            : this(database)
        {
            Read(id);
        }

        public Folder(Database database, SqlDataReader dr)
            : this(database)
        {
            Read(dr);
        }
        #endregion

        #region members
        private int mID;
        private int mParentID;
        private string mName;
        private string mDescription;
        private string mCreator;
        private DateTime mCreationDate;
        //private FoldersCollection mSubFolders;
        private Folder mParentFolder;
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
                if (mParentID == value)
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

        /*
                public FoldersCollection SubFolders
                {
                    get
                    {
                        return mSubFolders;
                    }
                }
        */
        #endregion

        #region methods
        public new void Read(int id)
        {
            base.Read(id);
        }

        public override void Read(SqlDataReader dr)
        {
            mID = GetIntFromDataReader(dr["id"]);
            mParentID = GetIntFromDataReader(dr["parentID"]);
            mName = GetStringFromDataReader(dr["name"]);
            mDescription = GetStringFromDataReader(dr["description"]);
            mCreator = GetStringFromDataReader(dr["creator"]);
            mCreationDate = GetDateTimeFromDataReader(dr["creationDate"]);
            base.Read(dr);
        }

        protected override object[] GetReadParameters()
        {
            return new object[] { mID };
        }

        protected override object[] GetSaveParameters()
        {
            return new object[] { mID, mParentFolder, mName, mDescription };
        }

        protected override object[] GetDeleteParameters()
        {
            return new object[] { mID };
        }

        public SqlDataReader Children(object id = null)
        {
            return base.DoExecuteDataReader("exec prcFolders_children {0}", id);
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