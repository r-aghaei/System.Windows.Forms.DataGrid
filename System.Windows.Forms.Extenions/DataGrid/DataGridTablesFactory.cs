namespace System.Windows.Forms
{
    using System.Text;
    using System.Runtime.Remoting;

    using System.Diagnostics;
    using System;
    using System.Collections;
    using System.ComponentModel;

    using System.Windows.Forms;
    using Microsoft.Win32;

    /// <summary>
    ///    <para>[To be supplied.]</para>
    /// </summary>
    public sealed class GridTablesFactory
    {
        // private static DataTableComparer dtComparer = new DataTableComparer();

        // not creatable...
        //
        private GridTablesFactory()
        {
        }


        /// <summary>
        ///      Takes a DataView and creates an intelligent mapping of
        ///      DataView storage types into available DataColumn types.
        /// </summary>
        public static DataGridTableStyle[]
            CreateGridTables(DataGridTableStyle gridTable, object dataSource, string dataMember, BindingContext bindingManager)
        {
            return new DataGridTableStyle[] { gridTable };
        }
    }
}
