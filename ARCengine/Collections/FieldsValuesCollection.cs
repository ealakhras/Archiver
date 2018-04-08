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
            mNeedsRefreshing = false;
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
            Clear();
            SqlDataReader dr = Database.ExecuteDataReader("exec prcFieldsValues_read @documentID = {0}", mDocument.ID);
            Read(dr);
            dr.Close();
        }

        private void Read(SqlDataReader dr)
        {
            while (dr.Read())
            {
                Add(new FieldValue(mDocument, dr));
            }
            mNeedsRefreshing = false;
        }

        public void Save()
        {
            foreach (Document document in List)
            {
                if (document.NeedsSaving)
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