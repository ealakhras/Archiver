using System.Data.SqlClient;
using ARCengine.Interfaces;
using ARCengine.Collections;

namespace ARCengine
{
    public class Folder : CoreTableWithID, ICollectionOwner
    {
        #region constructors
        public Folder() : base("Folders")
        {
            mSubFolders = new FoldersCollection(this);
            mFields = new FieldsCollection(this);
            mDocuments = new DocumentsCollection(this);
        }

        public Folder(Database database) : this()
        {
            Database = database;
        }

        public Folder(Database database, int id) : this(database)
        {
            mID = id;
            Read();
        }
        #endregion

        #region members
        private int mParentID;
        private bool mInheritsFields;
        private int mImageIndex;
        private FoldersCollection mSubFolders;
        private ICollectionOwner mParent;
        private DocumentsCollection mDocuments;
        private FieldsCollection mFields;
        #endregion

        #region properties
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
                mIsDirty = true;
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
                if(mImageIndex == value)
                {
                    return;
                }
                mImageIndex = value;
                mIsDirty = true;
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
        public FieldsCollection Fields
        {
            get
            {
                if(mFields.NeedsRefreshing)
                {
                    mFields.Refresh();
                }
                return mFields;
            }
        }
        public DocumentsCollection Documents
        {
            get
            {
                if(mDocuments.NeedsRefreshing)
                {
                    mDocuments.Refresh();
                }
                return mDocuments;
            }
        }
        #endregion

        #region methods
        protected override SqlParameterCollection GetSaveParameters()
        {
            SqlParameterCollection result = base.GetSaveParameters();
            AddParam(result, "@parentID", SqlParamTypes.Integer, mParentID);
            AddParam(result, "@imageIndex", SqlParamTypes.Integer, mImageIndex);
            AddParam(result, "@inheritsFields", SqlParamTypes.Boolean, mInheritsFields);    
            return result;
        }

        protected override void Init(SqlDataReader dr)
        {
            base.Init(dr);
            mParentID = GetIntFromDataReader(dr["parentID"]);
            mImageIndex = GetIntFromDataReader(dr["imageIndex"]);
            mInheritsFields = GetBoolFromDataReader(dr["inheritsFields"]);
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

        public SqlDataReader Tree(int id = 0)
        {
            return mDatabase.ExecuteDataReader($"exec prcFolders_tree {id}");
        }

        public override string ToString()
        {
            return $"Name: {mName}\nID: {mID}\nParentID: {mParentID}\nDescription: {mDescription}\nCreator: {mCreator}\nCreationDate: {mCreationDate}";
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
        #endregion
    }
}