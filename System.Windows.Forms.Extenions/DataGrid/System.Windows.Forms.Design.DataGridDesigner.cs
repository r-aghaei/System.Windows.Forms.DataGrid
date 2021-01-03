// System.Windows.Forms.Design.DataGridDesigner
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace System.Windows.Forms.Design
{
	internal class DataGridDesigner : ControlDesigner
	{
		protected DesignerVerbCollection designerVerbs;

		private IComponentChangeService changeNotificationService;

		public override DesignerVerbCollection Verbs => designerVerbs;

		private DataGridDesigner()
		{
			designerVerbs = new DesignerVerbCollection();
			designerVerbs.Add(new DesignerVerb(SR.GetString("DataGridAutoFormatString"), OnAutoFormat));
			base.AutoResizeHandles = true;
		}

		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			if (designerHost != null)
			{
				changeNotificationService = (IComponentChangeService)designerHost.GetService(typeof(IComponentChangeService));
				if (changeNotificationService != null)
				{
					changeNotificationService.ComponentRemoved += DataSource_ComponentRemoved;
				}
			}
		}

		private void DataSource_ComponentRemoved(object sender, ComponentEventArgs e)
		{
			DataGrid dataGrid = (DataGrid)base.Component;
			if (e.Component == dataGrid.DataSource)
			{
				dataGrid.DataSource = null;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && changeNotificationService != null)
			{
				changeNotificationService.ComponentRemoved -= DataSource_ComponentRemoved;
			}
			base.Dispose(disposing);
		}

		private void OnAutoFormat(object sender, EventArgs e)
		{
			object component = base.Component;
			DataGrid dgrid = component as DataGrid;
			DataGridAutoFormatDialog dataGridAutoFormatDialog = System.Windows.Forms.DpiHelper.CreateInstanceInSystemAwareContext(() => new DataGridAutoFormatDialog(dgrid));
			if (dataGridAutoFormatDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			DataRow selectedData = dataGridAutoFormatDialog.SelectedData;
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			DesignerTransaction designerTransaction = designerHost.CreateTransaction(SR.GetString("DataGridAutoFormatUndoTitle", base.Component.Site.Name));
			try
			{
				if (selectedData != null)
				{
					PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(DataGrid));
					foreach (DataColumn column in selectedData.Table.Columns)
					{
						object obj = selectedData[column];
						PropertyDescriptor propertyDescriptor = properties[column.ColumnName];
						if (propertyDescriptor == null)
						{
							continue;
						}
						if (Convert.IsDBNull(obj) || obj.ToString().Length == 0)
						{
							propertyDescriptor.ResetValue(dgrid);
							continue;
						}
						try
						{
							TypeConverter converter = propertyDescriptor.Converter;
							object value = converter.ConvertFromString(obj.ToString());
							propertyDescriptor.SetValue(dgrid, value);
						}
						catch
						{
						}
					}
				}
			}
			finally
			{
				designerTransaction.Commit();
			}
			dgrid.Invalidate();
		}
	}
}
