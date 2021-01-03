namespace System.Windows.Forms
{

    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System;
    using System.Globalization;

    /// <summary>
    ///    <para>Identifies a cell in the grid.</para>
    /// </summary>    
    public struct DataGridCell
    {
        private int rowNumber;
        private int columnNumber;

        /// <summary>
        /// <para>Gets or sets the number of a column in the <see cref='System.Windows.Forms.DataGrid'/> control.</para>
        /// </summary>
        public int ColumnNumber
        {
            get
            {
                return columnNumber;
            }
            set
            {
                columnNumber = value;
            }
        }

        /// <summary>
        /// <para>Gets or sets the number of a row in the <see cref='System.Windows.Forms.DataGrid'/> control.</para>
        /// </summary>
        public int RowNumber
        {
            get
            {
                return rowNumber;
            }
            set
            {
                rowNumber = value;
            }
        }

        /// <summary>
        ///    <para>
        ///       Initializes a new instance of the <see cref='System.Windows.Forms.DataGridCell'/> class.
        ///    </para>
        /// </summary>
        public DataGridCell(int r, int c)
        {
            this.rowNumber = r;
            this.columnNumber = c;
        }

        /// <summary>
        ///    <para>
        ///       Gets a value indicating whether the <see cref='System.Windows.Forms.DataGridCell'/> is identical to a second
        ///    <see cref='System.Windows.Forms.DataGridCell'/>.
        ///    </para>
        /// </summary>        
        public override bool Equals(object o)
        {
            if (o is DataGridCell)
            {
                DataGridCell rhs = (DataGridCell)o;
                return (rhs.RowNumber == RowNumber && rhs.ColumnNumber == ColumnNumber);
            }
            else
                return false;
        }

        /// <summary>
        ///    <para>
        ///       Gets
        ///       a hash value that uniquely identifies the cell.
        ///    </para>
        /// </summary>
        public override int GetHashCode()
        {
            return ((~rowNumber * (columnNumber + 1)) & 0x00ffff00) >> 8;
        }

        /// <summary>
        ///    <para>
        ///       Gets the row number and column number of the cell.
        ///    </para>
        /// </summary>
        public override string ToString()
        {
            return "DataGridCell {RowNumber = " + RowNumber.ToString(CultureInfo.CurrentCulture) +
                   ", ColumnNumber = " + ColumnNumber.ToString(CultureInfo.CurrentCulture) + "}";
        }

    }

}
