using System;
using System.Data.SqlClient;

namespace ARCengine
{
    public class Field : BaseTable
    {
        #region constructors
        public Field()
            : base("Fields")
        {

        }

        public Field(Folder folder)
            : this()
        {
            mFolder = folder;
        }

        public Field(Folder folder, SqlDataReader dr)
            : this(folder)
        {
            Read(dr);
        }
        #endregion

        #region members
        private int mID;
        private int mFolderID;
        private Folder mFolder;
        private string mName;
        private string mDescription;
        private FieldType mType;
        private string mDefVal;
        private int mOrd;
        private int mImageIndex;
        private string mCreator;
        private DateTime mCreationDate;
        #endregion

        #region properties
        public int ID
        {
            get
            {
                return mID;
            }
        }

        public int FolderID
        {
            get
            {
                return mFolderID;
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

        public FieldType Type
        {
            get
            {
                return mType;
            }
            set
            {
                if(mType == value)
                {
                    return;
                }
                mType = value;
                mIsDirty = true;
            }
        }

        public string DefVal
        {
            get
            {
                return mDefVal;
            }
            set
            {
                if(mDefVal == value)
                {
                    return;
                }
                mDefVal = value;
                mIsDirty = true;
            }
        }

        public int Ord
        {
            get
            {
                return mOrd;
            }
            set
            {
                if(mOrd == value)
                {
                    return;
                }
                mOrd = value;
                mIsDirty = true;
            }
        }

        public int ImageIndex
        {
            get
            {
                return mImageIndex;
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
        public new void Read(int id)
        {
            base.Read(id);
        }

        public override void Read(SqlDataReader dr)
        {
            mID = GetIntFromDataReader(dr["id"]);
            mFolderID = GetIntFromDataReader(dr["parentID"]);
            mName = GetStringFromDataReader(dr["name"]);
            mDescription = GetStringFromDataReader(dr["description"]);
            mType = FieldTypeUtil.FromChar(GetStringFromDataReader(dr["type"]));
            mImageIndex = GetIntFromDataReader(dr["imageIndex"]);
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
            return new object[] { mID, mFolder, mName, mDescription };
        }

        protected override object[] GetDeleteParameters()
        {
            return new object[] { mID };
        }
        #endregion
    }

    public enum FieldType { Text, Number, DateTime, YesNo, Lookup };

    public static class FieldTypeUtil
    {
        public static string ToChar(FieldType fieldtype)
        {
            switch (fieldtype)
            {
                case FieldType.Number: return "N";
                case FieldType.DateTime: return "D";
                case FieldType.YesNo: return "Y";
                case FieldType.Lookup: return "L";
                default: return "T";
            }
        }

        public static FieldType FromChar(string fieldtype)
        {
            switch (fieldtype)
            {
                case "N": return FieldType.Number;
                case "D": return FieldType.DateTime;
                case "Y": return FieldType.YesNo;
                case "L": return FieldType.Lookup;
                default: return FieldType.Text;
            }
        }
    }
}
