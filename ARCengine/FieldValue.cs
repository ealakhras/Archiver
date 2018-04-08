using System;
using System.Data.SqlClient;
using ARCengine.Collections;


namespace ARCengine
{
    public class FieldValue:BaseTable
    {
        #region constructors
        public FieldValue()
            : base("FieldsValues")
        {
        }

        public FieldValue(int id)
            : this()
        {
            Read(id);
        }

        public FieldValue(Document document, SqlDataReader dr)
            : this()
        {
            mDocument = document;
            Read(dr);
        }
        #endregion

        #region members
        private Document mDocument;
        private int mFieldID;
        private string mValue;
        #endregion

        #region properties
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
                if(mValue == value)
                {
                    return;
                }
                mValue = value;
                mNeedsSaving = true;
            }
        }
        public Document Document
        {
            get
            {
                return mDocument;
            }
        }
        #endregion

        #region method
        protected override object[] GetReadParameters()
        {
            return new object[] { mFieldID };
        }

        protected override object[] GetSaveParameters()
        {
            return new object[] { mDocument.ID, mFieldID, mValue };
        }

        protected override object[] GetDeleteParameters()
        {
            return new object[] { mDocument.ID, mFieldID };
        }

        protected override void Read(int id)
        {
            base.Read(id);
        }

        public override void Read(SqlDataReader dr)
        {
            mFieldID = GetIntFromDataReader(dr["fieldID"]);
            mValue = GetStringFromDataReader(dr["value"]);
            base.Read(dr);
        }
        #endregion
    }
}
