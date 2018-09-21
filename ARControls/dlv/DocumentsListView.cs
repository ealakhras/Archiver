using System.Windows.Forms;
using ARCengine;
using System.Threading;
using System.ComponentModel;
using System;

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
            //mPopulateThread = new Thread(new ThreadStart(SafelyPopulate));
            mDocumentAddDelegate = new DocumentAddDelegate(SafelyAddDocument);
            mPopulateDelegate = new PopulateDelegate(SafelyPopulate2);
        }
        #endregion

        #region members
        private Folder mFolder;
        private bool mIsPopulating;
        private /*volatile*/ bool mPopulateThreadAborted;
        private Thread mPopulateThread;
        private DocumentAddDelegate mDocumentAddDelegate;
        private PopulateDelegate mPopulateDelegate;
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

        delegate void DocumentAddDelegate(Document document);
        delegate void PopulateDelegate();

        #region methods


        private void Populate()
        {
            mIsPopulating = true;
            // signal the thread abort:
            // and wait for it to gracefully abort:
            mPopulateThreadAborted = true;
            if (!(mPopulateThread is null) && (mPopulateThread.IsAlive))
            {
                mPopulateThreadAborted = true;
                mPopulateThread.Join();
            }

            // add columns here:
            Columns.Clear();
            mFolder.Fields.Refresh(true);
            foreach (Field field in mFolder.Fields)
            {
                Columns.Add(new FieldColumnHeader(field));
            }
            SafelyPopulate();
            /*
            // now launch the thread again:
            mPopulateThreadAborted = false;
            mPopulateThread = new Thread(new ThreadStart(SafelyPopulate2));
            mPopulateThread.Start();
            */
            mIsPopulating = false;
        }

        private void SafelyPopulate()
        {
            try
            {
                mIsPopulating = true;
                //BeginUpdate();
                Items.Clear();
                mFolder.Documents.Refresh(true);
                foreach (Document document in mFolder.Documents)
                {
                    //if (mPopulateThreadAborted)
                    //{
                    //    break;
                    //}
                    SafelyAddDocument(document);
                }
            }
            finally
            {
                //EndUpdate();
                mIsPopulating = false;
            }
        }

        private void SafelyPopulate2()
        {
            if (InvokeRequired)
            {
                this.Invoke(mPopulateDelegate, new object[] { });
            }
            else
            {
                SafelyPopulate();
            }
        }

        private void SafelyAddDocument(Document document)
        {
            if (InvokeRequired)
            {
                this.Invoke(mDocumentAddDelegate, new object[] { document });
            }
            else
            {
                Items.Add(new DocumentListViewItem(document));
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
