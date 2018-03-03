using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dal;

namespace bal
{
    public class FoldersCollection : BaseCollection
    {
        #region constructors
        public FoldersCollection(Folder owner)
            : base(owner)
        {
        }
        #endregion
        
        #region properties
        public new Folder this[int index]
        {
            get
            {
                return (Folder)base[index];
            }
            set
            {
                base[index] = value;
            }
        }
        public Folder Owner
        {
            get
            {
                return (Folder)mOwner;
            }
        }

        #endregion

        #region methods
        public void Add(Folder folder)
        {
            base.Add(folder);
            folder.ParentFolder = Owner;
        }

        public override void Populate()
        {
            Clear();
            int id = Owner == null ? 0 : Owner.ID;
            SqlDataReader dr = DataDome.Folders.Children(id);
            Populate(dr, this);
            dr.Close();
        }

        protected virtual void Populate(SqlDataReader dr, FoldersCollection rootCollection)
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