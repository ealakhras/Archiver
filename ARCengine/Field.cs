using System;
using System.Data.SqlClient;

namespace ARCengine
{
    public enum FieldTypes { Text, Number, DateTime, YesNo, Lookup };
    public enum FieldAlignment { Left, Center, Right };


    public class Field : CoreTableWithID
    {
        #region constructors
        public Field() : base("Fields")
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

        /*
        public Field(Folder folder) : this()
        {
            mFolder = folder;
            mDatabase = folder.Database;
        }

        public Field(Folder folder, SqlDataReader dr) : this(folder)
        {
            Read(dr);
        }
        */
        #endregion

        #region members
        private int mFolderID;
        private Folder mFolder;
        private FieldTypes mType;
        private string mDefVal;
        private int mWidth;
        private FieldAlignment mAlignment;
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
        public FieldTypes Type
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
        public FieldAlignment Alignment
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
            AddParam(result, "@folderID", SqlParamTypes.Integer, mFolderID);
            AddParam(result, "@type", SqlParamTypes.String, FieldTypeUtil.ToChar(mType));
            AddParam(result, "@defVal", SqlParamTypes.String, mDefVal);
            AddParam(result, "@width", SqlParamTypes.Integer, mWidth);
            AddParam(result, "@alignment", SqlParamTypes.String, FieldAlignmentUtil.ToChar(mAlignment));
            AddParam(result, "@lovID", SqlParamTypes.Integer, mLOVID);
            AddParam(result, "@ord", SqlParamTypes.Integer, mOrd);
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
        public static string ToChar(FieldTypes fieldtype)
        {
            switch (fieldtype)
            {
                case FieldTypes.Number: return "N";
                case FieldTypes.DateTime: return "D";
                case FieldTypes.YesNo: return "Y";
                case FieldTypes.Lookup: return "L";
                default: return "T";
            }
        }

        public static FieldTypes FromChar(string fieldtype)
        {
            switch (fieldtype)
            {
                case "N": return FieldTypes.Number;
                case "D": return FieldTypes.DateTime;
                case "Y": return FieldTypes.YesNo;
                case "L": return FieldTypes.Lookup;
                default: return FieldTypes.Text;
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
        public static string ToChar(FieldAlignment fieldalignment)
        {
            switch (fieldalignment)
            {
                case FieldAlignment.Left: return "L";
                case FieldAlignment.Right: return "R";
                default: return "C";
            }
        }

        /// <summary>
        /// Converts a string to FieldAlignment.
        /// </summary>
        /// <param name="fieldalignment"></param>
        /// <returns></returns>
        public static FieldAlignment FromChar(string fieldalignment)
        {
            switch (fieldalignment)
            {
                case "L": return FieldAlignment.Left;
                case "R": return FieldAlignment.Right;
                default: return FieldAlignment.Center;
            }
        }
    }   
}
