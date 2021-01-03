// System.Windows.Forms.Design.DataGridColumnCollectionEditor
using System;
using System.ComponentModel.Design;
using System.Windows.Forms;
namespace System.Windows.Forms.Design
{
	internal class DataGridColumnCollectionEditor : CollectionEditor
	{
		public DataGridColumnCollectionEditor(Type type)
			: base(type)
		{
		}

		protected override Type[] CreateNewItemTypes()
		{
			return new Type[2]
			{
			typeof(DataGridTextBoxColumn),
			typeof(DataGridBoolColumn)
			};
		}
	}
}