namespace System.Windows.Forms
{
    /// <summary>
    ///    <para>
    ///       Specifies how parent row labels of a DataGrid
    ///       control are displayed.
    ///    </para>
    /// </summary>
    public enum DataGridParentRowsLabelStyle
    {
        /// <summary>
        ///    <para>
        ///       Display no parent row labels.
        ///    </para>
        /// </summary>
        None = 0,
        /// <summary>
        ///    <para>
        ///       Displaya the parent table name.
        ///    </para>
        /// </summary>
        TableName = 1,
        /// <summary>
        ///    <para>
        ///       Displaya the parent column name.
        ///    </para>
        /// </summary>
        ColumnName = 2,
        /// <summary>
        ///    <para>
        ///       Displays
        ///       both the parent table and column names.
        ///    </para>
        /// </summary>
        Both = 3,
    }
}
