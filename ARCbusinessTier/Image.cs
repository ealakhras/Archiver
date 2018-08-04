using ARCdataTier;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARCbusinessTier
{
    public class Image : BaseObjectWithID
    {
        #region constructors
        public Image() : base()
        {

        }

        public Image(Database database) : base(database)
        {

        }

        public Image(Database database, int id) : base(database, id)
        {

        }

        public Image(int id, int documentID, string name, string description = "", Stream data = null, Stream thumbnail = null, string fileName1 = "", string fileName2 = "", string notesDetails = "", int ord = 0)
        {
            Init(id, name, description);
            Init(documentID, data, thumbnail, fileName1, fileName2, notesDetails, ord);
        }
        #endregion

        #region members
        private int mDocumentID;
        private Stream mData;
        private Stream mThumbnail;
        private string mFileName1;
        private string mFileName2;
        private string mNotesDetails;
        private int mOrd;
        #endregion

        #region methods
        protected override void InitDatabase(Database database)
        {
            base.InitDatabase(database);
            mTable = mDatabase.Images;
        }

        protected override void DoSave()
        {
            using (SqlDataReader dr = ((ARCdataTier.Images)mTable).Save(mID, mDocumentID, mName, mDescription, mData, mThumbnail, mFileName1, mFileName2, mNotesDetails, mOrd))
            {
                if (dr.Read())
                {
                    Init(dr);
                }
                dr.Close();
            }
        }

        private void Init(int documentID, Stream data, Stream thumbnail, string fileName1, string fileName2, string notesDetails, int ord)
        {
            mDocumentID = documentID;
            mData = data;
            mThumbnail = thumbnail;
            mFileName1 = fileName1;
            mFileName2 = fileName2;
            mNotesDetails = notesDetails;
            mOrd = ord;
        }

        protected override void Init(SqlDataReader dr)
        {
            base.Init(dr);
            Init(
                GetIntFromDataReader(dr["documentID"]),
                GetStreamFromDataReader(dr["data"]),
                GetStreamFromDataReader(dr["thumbnail"]),
                GetStringFromDataReader(dr["fileName1"]),
                GetStringFromDataReader(dr["fileName2"]),
                GetStringFromDataReader(dr["notesDetails"]),
                GetIntFromDataReader(dr["ord"]));
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                $"DocumentID: {mDocumentID}\n" +
                $"FileName1: '{mFileName1}'\n" +
                $"FileName2: '{mFileName2}'\n" +
                $"NotesDetails: '{mNotesDetails}'\n" +
                $"Ord: {mOrd}";
        }
        #endregion
    }
}