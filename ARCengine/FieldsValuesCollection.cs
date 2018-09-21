using ARCengine.CoreObjects;
using System.Data.SqlClient;


namespace ARCengine.Collections
{

    public class FieldsValuesCollection : CoreCollection
    {
        #region constructors
        public FieldsValuesCollection(Document document):base(typeof(FieldValue))
        {
            mDocument = document;
        }
        #endregion

        #region members
        private Document mDocument;
        #endregion

        #region properties
        public Document Document
        {
            get
            {
                return mDocument;
            }
        }

        public FieldValue this[int index]
        {
            get
            {
                Refresh(true);
                return (FieldValue)List[index];
            }
            set
            {
                List[index] = value;
            }
        }

        public Database Database
        {
            get
            {
                return mDocument.Database;
            }
        }
        #endregion


        #region methods
        public void Add(FieldValue fieldValue)
        {
            List.Add(fieldValue);
        }

        /// <summary>
        /// populates fields from Database.
        /// </summary>
        protected override void Read()
        {
            using (SqlDataReader dr = Database.ExecuteDataReader($"exec prcFieldsValues_read @documentID = {mDocument.ID}"))
            {
                // do a beforehand-read. This is to make Read(dr) compatible
                // with DocumentsCollection.Read(dr)
                if (dr.Read())
                {
                    Read(dr);
                }
                dr.Close();
            }
        }

        public void Read(SqlDataReader dr)
        {
            Clear();
            /*
            while (dr.Read())
            {
                Add(new FieldValue(mDocument, dr));
            }
            */

            // check that it's for my document:
            while (dr.GetInt32(0) == mDocument.ID)
            {
                Add(new FieldValue(mDocument, dr));
                if (!dr.Read())
                {
                    break;
                }
            }
        }

        public void Save()
        {
            foreach (Document document in List)
            {
                if (document.IsDirty)
                {
                    document.Save();
                }
            }
        }
        #endregion
    }
}