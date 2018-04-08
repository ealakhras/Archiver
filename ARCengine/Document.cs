using System;
using System.Data.SqlClient;
using ARCengine.Collections;

namespace ARCengine
{
    public class Document : BaseTable
    {
        #region constructors
        public Document()
            :base("Documents")
        {
            mFieldsValues = new FieldsValuesCollection(this);
        }

        public Document(int id)
            : this()
        {
            Read(id);
        }

        public Document(Folder folder, SqlDataReader dr)
            :this()
        {
            mFolder = folder;
            Read(dr);
        }
        #endregion

        #region members
        private Folder mFolder;
        private int mID;
        private string mDescription;
        private string mCreator;
        private DateTime mCreationDate;
        private FieldsValuesCollection mFieldsValues;
        #endregion

        #region properties
        public int ID
        {
            get
            {
                return mID;
            }
        }

        public Folder Folder
        {
            get
            {
                return mFolder;
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
                mNeedsSaving = true;
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

        #region method
        protected override object[] GetReadParameters()
        {
            return new object[] { mID };
        }

        protected override object[] GetSaveParameters()
        {
            return new object[] { mID, mFolder.ID, mDescription };
        }

        protected override object[] GetDeleteParameters()
        {
            return new object[] { mID };
        }

        protected override void Read(int id)
        {
            base.Read(id);
        }

        public override void Read(SqlDataReader dr)
        {
            mID = GetIntFromDataReader(dr["id"]);
            mDescription = GetStringFromDataReader(dr["description"]);
            mCreator = GetStringFromDataReader(dr["creator"]);
            mCreationDate = GetDateTimeFromDataReader(dr["creationDate"]);
            base.Read(dr);
        }
        #endregion
    }
}
