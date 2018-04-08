using System;
using System.Windows.Forms;
using System.ComponentModel;
using ARCengine;
using ARCettings;

namespace ARControls
{
    public partial class DocumentsListView : ListView
    {
        #region constructors
        public DocumentsListView()
        {
            InitializeComponent();
            View = View.Details;
            mIsPopulating = false;
        }
        #endregion

        #region members
        private Folder mFolder;
        private bool mIsPopulating;
        #endregion

        #region properties
        public Folder Folder
        {
            get
            {
                return mFolder;
            }
            set
            {
                if(mFolder == value)
                {
                    return;
                }
                mFolder = value;
                Populate();
            }
        }
        #endregion

        #region methods
        private void Populate()
        {
            try
            {
                mIsPopulating = true;
                BeginUpdate();
                Columns.Clear();

                foreach(Field field in mFolder.Fields)
                {
                    Columns.Add(new FieldColumnHeader(field));
                }
            }
            finally
            {
                mIsPopulating = false;
                EndUpdate();
            }
        }

        protected override void OnColumnWidthChanged(ColumnWidthChangedEventArgs e)
        {
            base.OnColumnWidthChanged(e);
            if(mIsPopulating)
            {
                return;
            }
            FieldColumnHeader fch = (FieldColumnHeader) Columns[e.ColumnIndex];
            fch.Field.Width = fch.Width;
            fch.Field.Save();
        }
        #endregion
    }
}
