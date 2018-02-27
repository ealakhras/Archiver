using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dal;


namespace bal
{
    public class Folder: BaseObject
    {
        protected int mID;
        protected int mParentID;
        protected string mName;
        protected string mDescription;
        protected string mCreator;
        protected DateTime mCreationDate;

        public int ID
        {
            get
            {
                return mID;
            }
        }

        public int ParentID
        {
            get
            {
                return mParentID;
            }
            set
            {
                if(mParentID == value)
                {
                    return;
                }
                mParentID = value;
                mIsDirty = true;
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
                if(mDescription == value)
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

        public Folder()
            : base()
        {
        }

        public Folder(int id)
            : this()
        {
            SqlDataReader dr = DataDome.Folders.Read(id);
            InitFromDataReader(dr);
            dr.Close();
        }

        protected override void InitFromDataReader(SqlDataReader dr)
        {
            if ((dr != null) && (dr.Read()))
            {
                mID = int.Parse(dr["id"].ToString());
                mParentID = int.Parse(dr["parentID"].ToString());
                mName = dr["name"].ToString();
                mDescription = dr["description"].ToString();
                mCreator = dr["creator"].ToString();
                mCreationDate = DateTime.Parse(dr["creationDate"].ToString());
                mIsDirty = false;
            }
        }

        public override void Save()
        {
            SqlDataReader dr = DataDome.Folders.Save(mID, mParentID, mName, mDescription);
            InitFromDataReader(dr);
            dr.Close();
            base.Save();
        }

        public override void Delete()
        {
            DataDome.Folders.Delete(mID);
            base.Delete();
        }

        public override void Refresh()
        {
            SqlDataReader dr = DataDome.Folders.Read(mID);
            InitFromDataReader(dr);
            dr.Close();
            base.Refresh();
        }
    }
}
