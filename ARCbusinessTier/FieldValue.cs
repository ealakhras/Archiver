using ARCdataTier;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARCbusinessTier
{
    public class FieldValue : BaseObject
    {
        #region constructors
        public FieldValue() : base()
        {

        }

        public FieldValue(Database database):base(database)
        {

        }

        public FieldValue(int documentID, int fieldID, string value = "")
        {
            Init(documentID, fieldID, value);
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
                if(mValue == value)
                {
                    return;
                }
                mValue = value;
                mIsDirty = true;
            }
        }
        #endregion

        #region methods
        protected override void InitDatabase(Database database)
        {
            base.InitDatabase(database);
            mTable = database.FieldsValues;
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

        protected override void DoDelete()
        {
            ((FieldsValues)mTable).Delete(mDocumentID, mFieldID);
        }

        protected override void DoRead()
        {
            using (SqlDataReader dr = ((FieldsValues)mTable).Read(mDocumentID, mFieldID))
            {
                if(dr.Read())
                {
                    Init(dr);
                }
                dr.Close();
            }
        }

        protected override void DoSave()
        {
            using (SqlDataReader dr = ((FieldsValues)mTable).Save(mDocumentID, mFieldID, mValue))
            {
                if(dr.Read())
                {
                    Init(dr);
                }
                dr.Close();
            }
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