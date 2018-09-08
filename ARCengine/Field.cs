using System.Data.SqlClient;
using ARCengine.CoreObjects;

namespace ARCengine
{
    public class Field : CoreTableWithID
    {
        #region constructors
        public Field() : base("Fields")
        {
        }

        /// <summary>
        /// Creates an instance of Field, and initiates it from id at Dome.CurrentDatabase
        /// </summary>
        /// <param name="id">id of Field in Dome.CurrentData to be fetched</param>
        public Field(int id) : this(Dome.CurrentDatabase, id)
        {
        }

        public Field(Database database) : this()
        {
            Database = database;
        }

        public Field(Database database, int id) : this(database)
        {
            mID = id;
            Read();
        }

        public Field(Folder folder) : this(folder.Database)
        {
            mFolder = folder;
            mFolderID = folder.ID;
        }

        public Field(Folder folder, SqlDataReader dr) : this(folder)
        {
            Init(dr);
        }
        #endregion

        #region members
        private int mFolderID;
        private Folder mFolder;
        private FieldTypesEnum mType;
        private string mDefVal;
        private int mWidth;
        private FieldAlignmentEnum mAlignment;
        private int mLOVID;
        private int mOrd;
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
                if (mFolderID == value)
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
        public FieldTypesEnum Type
        {
            get
            {
                return mType;
            }
            set
            {
                if (mType == value)
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
                if (mDefVal == value)
                {
                    return;
                }
                mDefVal = value;
                mIsDirty = true;
            }
        }
        public FieldAlignmentEnum Alignment
        {
            get
            {
                return mAlignment;
            }
            set
            {
                if (mAlignment == value)
                {
                    return;
                }
                mAlignment = value;
                mIsDirty = true;
            }
        }
        public int Width
        {
            get
            {
                return mWidth;
            }
            set
            {
                if (mWidth == value)
                {
                    return;
                }
                mWidth = value;
                mIsDirty = true;
            }
        }
        public int LOVID
        {
            get
            {
                return mLOVID;
            }
            set
            {
                if(mLOVID == value)
                {
                    return;
                }
                mLOVID = value;
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
                if (mOrd == value)
                {
                    return;
                }
                mOrd = value;
                mIsDirty = true;
            }
        }
        #endregion

        #region methods
        protected override void Init(SqlDataReader dr)
        {
            base.Init(dr);
            mFolderID = GetIntFromDataReader(dr["folderID"]);
            mType = FieldTypeUtil.FromChar(GetStringFromDataReader(dr["type"]));
            mWidth = GetIntFromDataReader(dr["width"]);
            mAlignment = FieldAlignmentUtil.FromChar(GetStringFromDataReader(dr["alignment"]));
            mDefVal = GetStringFromDataReader(dr["defVal"]);
            mLOVID = GetIntFromDataReader(dr["lovID"]);
            mOrd = GetIntFromDataReader(dr["ord"]);
        }

        protected override SqlParameterCollection GetSaveParameters()
        {
            SqlParameterCollection result = base.GetSaveParameters();
            AddParam(result, "@folderID", SqlParamTypesEnum.Integer, mFolderID);
            AddParam(result, "@type", SqlParamTypesEnum.String, FieldTypeUtil.ToChar(mType));
            AddParam(result, "@defVal", SqlParamTypesEnum.String, mDefVal);
            AddParam(result, "@width", SqlParamTypesEnum.Integer, mWidth);
            AddParam(result, "@alignment", SqlParamTypesEnum.String, FieldAlignmentUtil.ToChar(mAlignment));
            AddParam(result, "@lovID", SqlParamTypesEnum.Integer, mLOVID);
            AddParam(result, "@ord", SqlParamTypesEnum.Integer, mOrd);
            return result;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                                $"FolderID: {mFolderID}\n" +
                                $"Type: '{FieldTypeUtil.ToChar(mType)}'\n" +
                                $"DefVal: '{mDefVal}\n" +
                                $"Aligment: '{FieldAlignmentUtil.ToChar(mAlignment)}'\n" +
                                $"Width: {mWidth}\n" +
                                $"lovID: {mLOVID}\n" +
                                $"Ord: {mOrd}";
        }
        #endregion
    }

    /// <summary>
    /// static class dedicated for FieldType from/to castings
    /// </summary>
    public static class FieldTypeUtil
    {
        public static string ToChar(FieldTypesEnum fieldtype)
        {
            switch (fieldtype)
            {
                case FieldTypesEnum.Number: return "N";
                case FieldTypesEnum.DateTime: return "D";
                case FieldTypesEnum.YesNo: return "Y";
                case FieldTypesEnum.Lookup: return "L";
                default: return "T";
            }
        }

        public static FieldTypesEnum FromChar(string fieldtype)
        {
            switch (fieldtype)
            {
                case "N": return FieldTypesEnum.Number;
                case "D": return FieldTypesEnum.DateTime;
                case "Y": return FieldTypesEnum.YesNo;
                case "L": return FieldTypesEnum.Lookup;
                default: return FieldTypesEnum.Text;
            }
        }
    }

    public static class FieldAlignmentUtil
    {
        /// <summary>
        /// Converts FieldAlignment to String.
        /// </summary>
        /// <param name="fieldalignment"></param>
        /// <returns></returns>
        public static string ToChar(FieldAlignmentEnum fieldalignment)
        {
            switch (fieldalignment)
            {
                case FieldAlignmentEnum.Left: return "L";
                case FieldAlignmentEnum.Right: return "R";
                default: return "C";
            }
        }

        /// <summary>
        /// Converts a string to FieldAlignment.
        /// </summary>
        /// <param name="fieldalignment"></param>
        /// <returns></returns>
        public static FieldAlignmentEnum FromChar(string fieldalignment)
        {
            switch (fieldalignment)
            {
                case "L": return FieldAlignmentEnum.Left;
                case "R": return FieldAlignmentEnum.Right;
                default: return FieldAlignmentEnum.Center;
            }
        }
    }   
}
