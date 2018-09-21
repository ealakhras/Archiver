using System.Windows.Forms;
using ARCengine;

namespace ARControls
{
    class DocumentListViewItem: ListViewItem
    {
        public DocumentListViewItem(Document document)
        {
            bool firstItem = true;
            mDocument = document;
            foreach (FieldValue fv in document.FieldsValues)
            {
                if(firstItem)
                {
                    firstItem = false;
                    Text = fv.Value;
                }
                else
                {
                    SubItems.Add(fv.Value);
                }
            }
        }

        #region members
        Document mDocument;
        #endregion

        #region properties
        Document Document
        {
            get
            {
                return mDocument;
            }
        }
        #endregion
    }
}
