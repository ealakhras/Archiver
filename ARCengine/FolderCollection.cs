using System.Collections;
using System.Data.SqlClient;

namespace ARCengine
{
    public class FolderCollection : CollectionBase
    {
        #region constructors
        public FolderCollection(Folder owner)
            : base()
        {
            mOwner = owner;
        }
        #endregion

        #region members
        Folder mOwner;
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
        public Folder Owner
        {
            get
            {
                return mOwner;
            }
        }

        #endregion

        #region methods
        public void Add(Folder folder)
        {
            List.Add(folder);
            folder.ParentFolder = Owner;
        }

        public void Populate()
        {
            Clear();
            int id = Owner == null ? 0 : Owner.ID;
            SqlDataReader dr = Owner.Database.Folders.Children(id);
            Populate(dr, this);
            dr.Close();
        }

        protected virtual void Populate(SqlDataReader dr, FolderCollection rootCollection)
        {
            while (dr.Read())
            {
                Folder f = new Folder(dr);
                if(Owner == null && f.ParentID == 0)
                {
                    Add(f);
                }
                else if (Owner != null && f.ParentID == 0)
                {
                    rootCollection.Add(f);
                }
                else if (Owner.ID == f.ParentID)
                {
                    Add(f);
                }
                else
                {
                    Folder parent = Owner.FindParent(f.ParentID);
                    if (parent != null)
                    {
                        parent.SubFolders.Add(f);                        
                    }
                }
                f.SubFolders.Populate(dr, rootCollection);
            }
        }

        public override string ToString()
        {
            string result = Owner.Name + '\n';
            result += ToString(1);
            return result;
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