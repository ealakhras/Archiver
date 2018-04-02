using System;
using System.Data.SqlClient;
using ARCengine.Interfaces;
using ARCengine.Collections;

namespace ARCengine
{
    public class Folder : BaseTable, ICollectionOwner
    {
        #region constructors
        public Folder()
            : base("Folders")
        {
            mSubFolders = new FolderCollection(this);
            mFields = new FieldsCollection(this);
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
        #endregion

        #region members
        private int mID;
        private int mParentID;
        private string mName;
        private string mDescription;
        private int mImageIndex;
        private bool mInheritsFields;
        private string mCreator;
        private DateTime mCreationDate;
        private FolderCollection mSubFolders;
        private ICollectionOwner mParent;
        private FieldsCollection mFields;
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
                mNeedsSaving = true;
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
                mNeedsSaving = true;
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
                mNeedsSaving = true;
            }
        }

        public int ImageIndex
        {
            get
            {
                return mImageIndex;
            }
            set
            {
                if (mImageIndex == value)
                {
                    return;
                }
                mImageIndex = value;
                mNeedsSaving = true;
            }
        }

        public bool InheritsFields
        {
            get
            {
                return mInheritsFields;
            }
            set
            {
                if (mInheritsFields = value)
                {
                    return;
                }
                mInheritsFields = value;
                mNeedsSaving = true;
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

        public ICollectionOwner Parent
        {
            get
            {
                return mParent;
            }
            set
            {
                if (mParent == value)
                {
                    return;
                }
                mParent = value;
                if((value == null) || (value is Database))
                {
                    mParentID = 0;
                }
                else
                {
                    mParentID = ((Folder)value).mID;
                }
                mNeedsSaving = true;
            }
        }

        public FolderCollection SubFolders
        {
            get
            {
                return mSubFolders;
            }
        }

        public FieldsCollection Fields
        {
            get
            {
                return mFields;
            }
        }
        #endregion

        #region methods
        public override void Read(SqlDataReader dr)
        {
            mID = GetIntFromDataReader(dr["id"]);
            mParentID = GetIntFromDataReader(dr["parentID"]);
            mName = GetStringFromDataReader(dr["name"]);
            mDescription = GetStringFromDataReader(dr["description"]);
            mImageIndex = GetIntFromDataReader(dr["imageIndex"]);
            mInheritsFields = GetBoolFromDataReader(dr["inheritsFields"]);
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
            return new object[] { mID, mParent, mName, mDescription };
        }

        protected override object[] GetDeleteParameters()
        {
            return new object[] { mID };
        }

        public SqlDataReader Tree(object id = null)
        {
            return mDatabase.ExecuteDataReader("exec prcFolders_tree {0}", id);
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

        public ICollectionOwner FindParent(int parentID)
        {
            ICollectionOwner parent = mParent;
            while ((parent != null) && !(parent is Database))
            {
                if (((Folder)parent).ID == parentID)
                {
                    break;
                }
                else
                {
                    parent = ((Folder)parent).FindParent(parentID);
                }
            }
            return parent;
        }

        public override void Save()
        {
            base.Save();
            mFields.Save();
            mSubFolders.Save();
        }

        public override void Refresh()
        {
            base.Refresh();
            mFields.Refresh();
            mSubFolders.Refresh();
        }
        #endregion
    }
}