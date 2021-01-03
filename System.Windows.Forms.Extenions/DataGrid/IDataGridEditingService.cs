namespace System.Windows.Forms
{
    using System.Diagnostics;
    using System;

    /// <summary>
    ///    <para>The DataGrid exposes hooks to request editing commands
    ///       via this interface.</para>
    /// </summary>
    public interface IDataGridEditingService
    {
        bool BeginEdit(DataGridColumnStyle gridColumn, int rowNumber);

        bool EndEdit(DataGridColumnStyle gridColumn, int rowNumber, bool shouldAbort);
    }
}
