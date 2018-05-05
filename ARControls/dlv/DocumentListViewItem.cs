using System.Windows.Forms;
using ARCengine;

namespace ARControls
{
    class DocumentListViewItem: ListViewItem
    {
        public DocumentListViewItem(Document document)
        {
            mDocument = document;
            for (int i = 0; i < document.FieldsValues.Count; i++)
            {
                if (i == 0)
                {
                    Text = document.FieldsValues[i].Value;
                }
                else
                {
                    SubItems.Add(document.FieldsValues[i].Value);
                }
            }

            /*
            foreach (FieldValue fieldValue in document.FieldsValues)
            {
                SubItems.Add(fieldValue.Value);
            }
            */
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
