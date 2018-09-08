using System.Data.SqlClient;
using System.IO;
using ARCengine.CoreObjects;

namespace ARCengine
{
    public class Image : CoreTableWithID
    {
        #region contructors
        public Image() : base("Images")
        {

        }

        public Image(int id):this(Dome.CurrentDatabase, id)
        {
        }

        public Image(Database database) : this()
        {
            Database = database;
        }

        public Image(Database database, int id) : this(database)
        {
            mID = id;
            Read();
        }
        #endregion

        #region members
        private int mDocumentID;
        private Stream mData;
        private Stream mThumbnail;
        private string mFileName;
        private string mNotesDetails;
        private int mOrd;
        #endregion

        #region properties
        public int DocumentID
        {
            get
            {
                return mDocumentID;
            }
        }
        public string FileName
        {
            get
            {
                return mFileName;
            }
            set
            {
                if(mFileName == value)
                {
                    return;
                }
                mFileName = value;
                mIsDirty = true;
            }
        }
        public string NotesDetails
        {
            get
            {
                return mNotesDetails;
            }
            set
            {
                if(mNotesDetails == value)
                {
                    return;
                }
                mNotesDetails = value;
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
        #endregion

        #region methods
        protected override SqlParameterCollection GetReadParameters()
        {
            SqlParameterCollection result = base.GetReadParameters();
            AddParam(result, "@documentID", SqlParamTypesEnum.Integer, mDocumentID);
            AddParam(result, "@fileName", SqlParamTypesEnum.String, mFileName);
            AddParam(result, "@notesDetails", SqlParamTypesEnum.String, mNotesDetails);
            AddParam(result, "@ord", SqlParamTypesEnum.Integer, mOrd);
            return result;
        }

        protected override SqlParameterCollection GetSaveParameters()
        {
            SqlParameterCollection result = base.GetSaveParameters();
            AddParam(result, "@documentID", SqlParamTypesEnum.Integer, mDocumentID);
            AddParam(result, "@fileName", SqlParamTypesEnum.String, mFileName);
            AddParam(result, "@notesDetails", SqlParamTypesEnum.String, mNotesDetails);
            AddParam(result, "@ord", SqlParamTypesEnum.Integer, mOrd);
            return result;
        }

        protected override void Init(SqlDataReader dr)
        {
            base.Init(dr);
            mDocumentID = GetIntFromDataReader(dr["documentID"]);
            mFileName = GetStringFromDataReader(dr["fileName"]);
            mNotesDetails = GetStringFromDataReader(dr["notesDetails"]);
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                $"DocumentID: {mDocumentID}\n" +
                $"FileName1: '{mFileName}'\n" +
                $"NotesDetails: '{mNotesDetails}'\n" +
                $"Ord: {mOrd}";
        }
        #endregion
    }
}
