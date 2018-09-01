using System;
using System.Collections;
using System.Data.SqlClient;


namespace ARCengine.Collections
{

    public class FieldsValuesCollection : CollectionBase
    {
        #region constructors
        public FieldsValuesCollection(Document document)
        {
            mDocument = document;
            mNeedsRefreshing = true;
        }
        #endregion

        #region members
        private Document mDocument;
        private bool mNeedsRefreshing;
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
                if (mNeedsRefreshing)
                {
                    Read();
                }
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

        public bool NeedsRefreshing
        {
            get
            {
                return mNeedsRefreshing;
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
        private void Read()
        {
            SqlDataReader dr = Database.ExecuteDataReader("exec prcFieldsValues_read @documentID = {0}", mDocument.ID);

            // do a beforehand-read. This is to make Read(dr) compatible
            // with DocumentsCollection.Read(dr)
            if (dr.Read())
            {
                Read(dr);
            }
            dr.Close();
        }

        protected internal void Read(SqlDataReader dr)
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
            mNeedsRefreshing = false;
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

        public void Refresh()
        {
            Read();
        }
        #endregion
    }
}