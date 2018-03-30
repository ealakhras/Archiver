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
        private ICollectionOwner mOwner;
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
        /// <summary>
        /// adds folder to the collection
        /// </summary>
        /// <param name="folder">new folder to add</param>
        public void Add(Folder folder)
        {
            List.Add(folder);
            folder.Parent = mOwner;
        }

        /// <summary>
        /// populates folders by calling Database.prcFolders_children() for roots.
        /// </summary>
        public void Populate()
        {
            Clear();
            if ((mOwner == null) || (mOwner is Database))
            {
                SqlDataReader dr = Database.ExecuteDataReader("exec prcFolders_tree");
                Populate(dr);
                dr.Close();
            }
        }

        /// <summary>
        /// populates folders reculsivelly.
        /// </summary>
        /// <param name="dr"></param>
        protected virtual void Populate(SqlDataReader dr)
        {
            while (dr.Read())
            {
                // create a folder for current dr record:
                Folder f = new Folder(dr);

                // if owner is a Database, or parentID is 0, then it's a root:
                if ((mOwner is Database) && (f.ParentID == 0))
                {
                    Add(f);
                }

                // if current folder is the new folder's parent, add it to it:
                else if (((Folder)Owner).ID == f.ParentID)
                {
                    Add(f);
                }
                else
                {
                    // search for the parent:
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
                // call reculsivelly:
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