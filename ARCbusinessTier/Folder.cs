using System.Data.SqlClient;
using ARCdataTier;

namespace ARCbusinessTier
{
    public class Folder : BaseObjectWithID
    {
        #region constructors
        public Folder() : base()
        {

        }

        public Folder(Database database) : base(database)
        {

        }

        public Folder(Database database, int id) : base(database, id)
        {

        }

        public Folder(int id, int parentID, string name, string description = "", int imageIndex = 0, bool inheritsFields = true)
        {
            Init(id, name, description);
            Init(parentID, imageIndex, inheritsFields);
        }
        #endregion

        #region members
        private int mParentID;
        private int mImageIndex;
        private bool mInheritsFields;
        #endregion

        #region properties
        public int ParentID
        {
            get
            {
                return mParentID;
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
        public bool InheritsFields
        {
            get
            {
                return mInheritsFields;
            }
            set
            {
                if(mInheritsFields == value)
                {
                    return;
                }
                mInheritsFields = value;
                mIsDirty = true;
            }
        }
        #endregion

        #region methods
        protected override void InitDatabase(Database database)
        {
            base.InitDatabase(database);
            mTable = mDatabase.Folders;
        }

        protected override void DoSave()
        {
            using (SqlDataReader dr = ((ARCdataTier.Folders)mTable).Save(mID, mParentID, mName, mDescription, mImageIndex, mInheritsFields))
            {
                if (dr.Read())
                {
                    Init(dr);
                }
                dr.Close();
            }
        }

        private void Init(int parentID, int imageIndex, bool inheritsFields)
        {
            mParentID = parentID;
            mImageIndex = imageIndex;
            mInheritsFields = inheritsFields;
        }

        protected override void Init(SqlDataReader dr)
        {
            base.Init(dr);
            Init(
                GetIntFromDataReader(dr["parentID"]),
                GetIntFromDataReader(dr["imageIndex"]),
                GetBoolFromDataReader(dr["inheritsFields"]));
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                    $"ParentID: {mParentID}\n" +
                    $"ImageIndex: {mImageIndex}\n" +
                    $"InheritsFields: {(mInheritsFields ? "true" : "false")}";
        }
        #endregion
    }
}