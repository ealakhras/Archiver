using System.Data.SqlClient;
using ARCengine.CoreObjects;

namespace ARCengine
{
    public class FieldValue : CoreTable
    {
        #region constructors
        public FieldValue() : base("FieldsValues")
        {

        }

        public FieldValue(Database database) : this()
        {
            Database = database;
        }

        public FieldValue(Database database, int documentID, int fieldID): this(database)
        {
            mDocumentID = documentID;
            mFieldID = FieldID;
            Read();
        }

        public FieldValue(Document document, SqlDataReader dr) : this(document.Database)
        {
            mDocumentID = document.ID;
            Init(dr);
        }
        #endregion

        #region members
        private int mDocumentID;
        private int mFieldID;
        private string mValue;
        #endregion

        #region properties
        public int DocumentID
        {
            get
            {
                return mDocumentID;
            }
        }
        public int FieldID
        {
            get
            {
                return mFieldID;
            }
        }
        public string Value
        {
            get
            {
                return mValue;
            }
            set
            {
                if (mValue == value)
                {
                    return;
                }
                mValue = value;
                mIsDirty = true;
            }
        }
        #endregion

        #region method
        protected override SqlParameterCollection GetReadParameters()
        {
            SqlParameterCollection result = base.GetSaveParameters();
            AddParam(result, "@documentID", SqlParamTypes.Integer, mDocumentID);
            AddParam(result, "@fieldID", SqlParamTypes.Integer, mFieldID);
            return result;
        }

        protected override SqlParameterCollection GetSaveParameters()
        {
            SqlParameterCollection result = base.GetSaveParameters();
            AddParam(result, "@documentID", SqlParamTypes.Integer, mDocumentID);
            AddParam(result, "@fieldID", SqlParamTypes.Integer, mFieldID);
            AddParam(result, "@value", SqlParamTypes.String, mValue);
            return result;
        }

        protected override SqlParameterCollection GetDeleteParameters()
        {
            SqlParameterCollection result = base.GetSaveParameters();
            AddParam(result, "@documentID", SqlParamTypes.Integer, mDocumentID);
            AddParam(result, "@fieldID", SqlParamTypes.Integer, mFieldID);
            return result;
        }

        private void Init(int documentID, int fieldID, string value)
        {
            Init();
            mDocumentID = documentID;
            mFieldID = fieldID;
            mValue = value;
        }

        protected override void Init(SqlDataReader dr)
        {
            base.Init(dr);
            Init(
                GetIntFromDataReader(dr["documentID"]),
                GetIntFromDataReader(dr["fieldID"]),
                GetStringFromDataReader(dr["value"]));
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                    $"DocumentID: {mDocumentID}\n" +
                    $"FieldID: {mFieldID}\n" +
                    $"Value: '{mValue}'";
        }
        #endregion
    }
}