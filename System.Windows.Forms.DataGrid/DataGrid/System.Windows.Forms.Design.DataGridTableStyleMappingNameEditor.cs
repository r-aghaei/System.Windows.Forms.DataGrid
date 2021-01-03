// System.Windows.Forms.Design.DataGridTableStyleMappingNameEditor
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace System.Windows.Forms.Design
{
	internal class DataGridTableStyleMappingNameEditor : UITypeEditor
	{
		private DesignBindingPicker designBindingPicker;

		public override bool IsDropDownResizable => true;

		private DataGridTableStyleMappingNameEditor()
		{
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (provider != null && context != null && context.Instance != null)
			{
				DataGridTableStyle dataGridTableStyle = (DataGridTableStyle)context.Instance;
				if (dataGridTableStyle.DataGrid == null)
				{
					return value;
				}
				PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(dataGridTableStyle.DataGrid)["DataSource"];
				if (propertyDescriptor != null)
				{
					object value2 = propertyDescriptor.GetValue(dataGridTableStyle.DataGrid);
					if (designBindingPicker == null)
					{
						designBindingPicker = new DesignBindingPicker();
					}
					DesignBinding initialSelectedItem = new DesignBinding(value2, (string)value);
					DesignBinding designBinding = designBindingPicker.Pick(context, provider, showDataSources: false, showDataMembers: true, selectListMembers: true, value2, string.Empty, initialSelectedItem);
					if (value2 != null && designBinding != null)
					{
						value = ((!string.IsNullOrEmpty(designBinding.DataMember) && designBinding.DataMember != null) ? designBinding.DataField : "");
					}
				}
			}
			return value;
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}
	}
}