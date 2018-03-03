using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace bal
{
    public class BaseFolder : BaseObject
    {
        public BaseFolder()
            : base()
            {
                mSubFolders = new FoldersCollection(this);
        }

        public BaseFolder(SqlDataReader dr)
            : this()
        {
            InitFromDataReader(dr);
        }

        #region members
        protected int mID;
        protected string mName;
        protected string mDescription;
        protected string mCreator;
        protected DateTime mCreationDate;
        protected FoldersCollection mSubFolders;
        #endregion

        #region properties
        public int ID
        {
            get
            {
                return mID;
            }
        }

        public string Name
        {
            get
            {
                return mName;
            }
            set
            {
                if (mName == value)
                {
                    return;
                }
                mName = value;
                mIsDirty = true;
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
                mIsDirty = true;
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

        public FoldersCollection SubFolders
        {
            get
            {
                return mSubFolders;
            }
        }
        #endregion

        protected override void InitFromDataReader(SqlDataReader dr)
        {
            mID = GetIntFromDataReader(dr["id"]);
            mParentID = GetIntFromDataReader(dr["parentID"]);
            mName = GetStringFromDataReader(dr["name"]);
            mDescription = GetStringFromDataReader(dr["description"]);
            mCreator = GetStringFromDataReader(dr["creator"]);
            mCreationDate = GetDateTimeFromDataReader(dr["creationDate"]);
            mIsDirty = false;
        }
    }
}