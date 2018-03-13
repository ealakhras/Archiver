using System.Collections;
using System.Data.SqlClient;

namespace ARCengine
{
    public class FolderCollection : CollectionBase
    {
        #region constructors
        public FolderCollection(ICollectionOwner owner)
            : base()
        {
            mOwner = owner;
        }
        #endregion

        #region members
        ICollectionOwner mOwner;
        #endregion

        #region properties
        public Folder this[int index]
        {
            get
            {
                return (Folder)List[index];
            }
            set
            {
                List[index] = value;
            }
        }

        public ICollectionOwner Owner
        {
            get
            {
                return mOwner;
            }
        }
        
        public Database Database
        {
            get
            {
                if (mOwner is Database)
                {
                    return (Database)mOwner;
                }
                if(mOwner is Folder)
                {
                    return ((Folder)mOwner).Database;
                }

                return null;
            }
        }
        #endregion

        #region methods
        public void Add(Folder folder)
        {
            List.Add(folder);
            folder.Parent = mOwner;
        }

        public void Populate()
        {
            Clear();
            if ((mOwner == null) || (mOwner is Database))
            {
                SqlDataReader dr = Database.prcFolders_children();
                Populate(dr);
                dr.Close();
            }
        }

        protected virtual void Populate(SqlDataReader dr)
        {
            while (dr.Read())
            {
                Folder f = new Folder(dr);
                if ((mOwner is Database) && (f.ParentID == 0))
                {
                    Add(f);
                }
                else if (((Folder)Owner).ID == f.ParentID)
                {
                    Add(f);
                }
                else
                {
                    ICollectionOwner parent = ((Folder)Owner).FindParent(f.ParentID);
                    if (parent is Database)
                    {
                        ((Database)parent).Folders.Add(f);
                    }
                    else if(parent is Folder)
                    {
                        ((Folder)parent).SubFolders.Add(f);
                    }
                }
                f.SubFolders.Populate(dr);
            }
        }

        public override string ToString()
        {
            return ToString(1);
        }

        private string ToString(int level)
        {
            string result = string.Empty;
            foreach (Folder f in List)
            {
                result += new string('-', level) + f.Name + '\n';
                result += f.SubFolders.ToString(level + 1);
            }
            return result;
        }
        #endregion
    }
}