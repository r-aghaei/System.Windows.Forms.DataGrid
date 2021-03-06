namespace System.Windows.Forms
{

    using System.Diagnostics;

    using System;
    using System.Collections;
    using System.Windows.Forms;
    using System.ComponentModel;
    using System.Globalization;

    /// <summary>
    /// <para>Represents a collection of <see cref='System.Windows.Forms.DataGridTableStyle'/> objects in the <see cref='System.Windows.Forms.DataGrid'/> 
    /// control.</para>
    /// </summary>
    [ListBindable(false)]
    public class GridTableStylesCollection : BaseCollection, IList
    {
        CollectionChangeEventHandler onCollectionChanged;
        ArrayList items = new ArrayList();
        DataGrid owner = null;

        /// <internalonly/>
        int IList.Add(object value)
        {
            return this.Add((DataGridTableStyle)value);
        }

        /// <internalonly/>
        void IList.Clear()
        {
            this.Clear();
        }

        /// <internalonly/>
        bool IList.Contains(object value)
        {
            return items.Contains(value);
        }

        /// <internalonly/>
        int IList.IndexOf(object value)
        {
            return items.IndexOf(value);
        }

        /// <internalonly/>
        void IList.Insert(int index, object value)
        {
            throw new NotSupportedException();
        }

        /// <internalonly/>
        void IList.Remove(object value)
        {
            this.Remove((DataGridTableStyle)value);
        }

        /// <internalonly/>
        void IList.RemoveAt(int index)
        {
            this.RemoveAt(index);
        }

        /// <internalonly/>
        bool IList.IsFixedSize
        {
            get { return false; }
        }

        /// <internalonly/>
        bool IList.IsReadOnly
        {
            get { return false; }
        }

        /// <internalonly/>
        object IList.this[int index]
        {
            get { return items[index]; }
            set { throw new NotSupportedException(); }
        }

        /// <internalonly/>
        void ICollection.CopyTo(Array array, int index)
        {
            this.items.CopyTo(array, index);
        }

        /// <internalonly/>
        int ICollection.Count
        {
            get { return this.items.Count; }
        }

        /// <internalonly/>
        bool ICollection.IsSynchronized
        {
            get { return false; }
        }

        /// <internalonly/>
        object ICollection.SyncRoot
        {
            get { return this; }
        }

        /// <internalonly/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }

        internal GridTableStylesCollection(DataGrid grid)
        {
            owner = grid;
        }

        /// <summary>
        ///    <para>[To be supplied.]</para>
        /// </summary>
        protected override ArrayList List
        {
            get
            {
                return items;
            }
        }

        /* implemented in BaseCollection
        /// <summary>
        ///      Retrieves the number of GridTables in the collection.
        /// </summary>
        /// <returns>
        ///      The number of GridTables in the collection.
        /// </returns>
        public override int Count {
            get {
                return items.Count;
            }
        }
        */

        /// <summary>
        ///      Retrieves the DataGridTable with the specified index.
        /// </summary>
        public DataGridTableStyle this[int index]
        {
            get
            {
                return (DataGridTableStyle)items[index];
            }
        }

        /// <summary>
        ///      Retrieves the DataGridTable with the name provided.
        /// </summary>
        public DataGridTableStyle this[string tableName]
        {
            get
            {
                if (tableName == null)
                    throw new ArgumentNullException("tableName");
                int itemCount = items.Count;
                for (int i = 0; i < itemCount; ++i)
                {
                    DataGridTableStyle table = (DataGridTableStyle)items[i];
                    // NOTE: case-insensitive
                    if (String.Equals(table.MappingName, tableName, StringComparison.OrdinalIgnoreCase))
                        return table;
                }
                return null;
            }
        }

        internal void CheckForMappingNameDuplicates(DataGridTableStyle table)
        {
            if (String.IsNullOrEmpty(table.MappingName))
                return;
            for (int i = 0; i < items.Count; i++)
                if (((DataGridTableStyle)items[i]).MappingName.Equals(table.MappingName) && table != items[i])
                    throw new ArgumentException(SR.GetString(SR.DataGridTableStyleDuplicateMappingName), "table");
        }

        /// <summary>
        /// <para>Adds a <see cref='System.Windows.Forms.DataGridTableStyle'/> to this collection.</para>
        /// </summary>
        public virtual int Add(DataGridTableStyle table)
        {
            // set the rowHeaderWidth on the newly added table to at least the minimum value
            // on its owner
            if (this.owner != null && this.owner.MinimumRowHeaderWidth() > table.RowHeaderWidth)
                table.RowHeaderWidth = this.owner.MinimumRowHeaderWidth();

            if (table.DataGrid != owner && table.DataGrid != null)
                throw new ArgumentException(SR.GetString(SR.DataGridTableStyleCollectionAddedParentedTableStyle), "table");
            table.DataGrid = owner;
            CheckForMappingNameDuplicates(table);
            table.MappingNameChanged += new EventHandler(TableStyleMappingNameChanged);
            int index = items.Add(table);
            OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, table));

            return index;
        }

        private void TableStyleMappingNameChanged(object sender, EventArgs pcea)
        {
            OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
        }

        /// <summary>
        ///    <para>[To be supplied.]</para>
        /// </summary>
        public virtual void AddRange(DataGridTableStyle[] tables)
        {
            if (tables == null)
            {
                throw new ArgumentNullException("tables");
            }
            foreach (DataGridTableStyle table in tables)
            {
                table.DataGrid = owner;
                table.MappingNameChanged += new EventHandler(TableStyleMappingNameChanged);
                items.Add(table);
            }
            OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
        }

        /// <summary>
        ///    <para>[To be supplied.]</para>
        /// </summary>
        public event CollectionChangeEventHandler CollectionChanged
        {
            add
            {
                onCollectionChanged += value;
            }
            remove
            {
                onCollectionChanged -= value;
            }
        }

        /// <summary>
        ///    <para>[To be supplied.]</para>
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < items.Count; i++)
            {
                DataGridTableStyle element = (DataGridTableStyle)items[i];
                element.MappingNameChanged -= new EventHandler(TableStyleMappingNameChanged);
            }

            items.Clear();
            OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
        }

        /// <summary>
        ///      Checks to see if a DataGridTableStyle is contained in this collection.
        /// </summary>
        public bool Contains(DataGridTableStyle table)
        {
            int index = items.IndexOf(table);
            return index != -1;
        }

        /// <summary>
        /// <para>Checks to see if a <see cref='System.Windows.Forms.DataGridTableStyle'/> with the given name
        ///    is contained in this collection.</para>
        /// </summary>
        public bool Contains(string name)
        {
            int itemCount = items.Count;
            for (int i = 0; i < itemCount; ++i)
            {
                DataGridTableStyle table = (DataGridTableStyle)items[i];
                // NOTE: case-insensitive
                if (String.Compare(table.MappingName, name, true, CultureInfo.InvariantCulture) == 0)
                    return true;
            }
            return false;
        }

        /*
        public override IEnumerator GetEnumerator() {
            return items.GetEnumerator();
        }

        public override IEnumerator GetEnumerator(bool allowRemove) {
            if (!allowRemove)
                return GetEnumerator();
            else
                throw new NotSupportedException(SR.GetString(SR.DataGridTableCollectionGetEnumerator));
        }
        */

        /// <summary>
        ///    <para>[To be supplied.]</para>
        /// </summary>
        protected void OnCollectionChanged(CollectionChangeEventArgs e)
        {
            if (onCollectionChanged != null)
                onCollectionChanged(this, e);

            DataGrid grid = owner;
            if (grid != null)
            {
                /* FOR DEMO: Microsoft: TableStylesCollection::OnCollectionChanged: set the datagridtble
                DataView dataView = ((DataView) grid.DataSource);
                if (dataView != null) {
                    DataTable dataTable = dataView.Table;
                    if (dataTable != null) {
                        if (Contains(dataTable)) {
                            grid.SetDataGridTable(this[dataTable]);
                        }
                    }
                }
                */
                grid.checkHierarchy = true;
            }
        }

        /// <summary>
        ///    <para>[To be supplied.]</para>
        /// </summary>
        public void Remove(DataGridTableStyle table)
        {
            int tableIndex = -1;
            int itemsCount = items.Count;
            for (int i = 0; i < itemsCount; ++i)
                if (items[i] == table)
                {
                    tableIndex = i;
                    break;
                }
            if (tableIndex == -1)
                throw new ArgumentException(SR.GetString(SR.DataGridTableCollectionMissingTable), "table");
            else
                RemoveAt(tableIndex);
        }

        /// <summary>
        ///    <para>[To be supplied.]</para>
        /// </summary>
        public void RemoveAt(int index)
        {
            DataGridTableStyle element = (DataGridTableStyle)items[index];
            element.MappingNameChanged -= new EventHandler(TableStyleMappingNameChanged);
            items.RemoveAt(index);
            OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, element));
        }
    }
}
