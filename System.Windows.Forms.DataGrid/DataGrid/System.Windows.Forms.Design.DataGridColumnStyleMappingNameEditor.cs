// System.Windows.Forms.Design.DataGridColumnStyleMappingNameEditor
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace System.Windows.Forms.Design
{
	internal class DataGridColumnStyleMappingNameEditor : UITypeEditor
	{
		private DesignBindingPicker designBindingPicker;

		public override bool IsDropDownResizable => true;

		private DataGridColumnStyleMappingNameEditor()
		{
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (provider != null && context != null && context.Instance != null)
			{
				DataGridColumnStyle dataGridColumnStyle = (DataGridColumnStyle)context.Instance;
				if (dataGridColumnStyle.DataGridTableStyle == null || dataGridColumnStyle.DataGridTableStyle.DataGrid == null)
				{
					return value;
				}
				PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(dataGridColumnStyle.DataGridTableStyle.DataGrid)["DataSource"];
				if (propertyDescriptor != null)
				{
					object value2 = propertyDescriptor.GetValue(dataGridColumnStyle.DataGridTableStyle.DataGrid);
					if (designBindingPicker == null)
					{
						designBindingPicker = new DesignBindingPicker();
					}
					DesignBinding initialSelectedItem = new DesignBinding(null, (string)value);
					DesignBinding designBinding = designBindingPicker.Pick(context, provider, showDataSources: false, showDataMembers: true, selectListMembers: false, value2, string.Empty, initialSelectedItem);
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