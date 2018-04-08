using System;
using System.Windows.Forms;
using ARCengine;

namespace ARControls
{
    public class FieldColumnHeader: ColumnHeader
    {
        public FieldColumnHeader(Field field)
            : base()
        {
            mField = field;
            Text = field.Name;
            TextAlign = (HorizontalAlignment)field.Alignment;
            Width = field.Width;
        }

        #region members
        private Field mField;
        #endregion

        #region properties
        public Field Field
        {
            get
            {
                return mField;
            }
        }
        #endregion
    }
}
