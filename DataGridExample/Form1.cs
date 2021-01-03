using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGrid1.CaptionText = "Sample Dataset";


            var dataset = new DataSet("SampleDataset");

            var category = new DataTable("Category");
            category.Columns.Add("Id", typeof(int));
            category.Columns.Add("Name", typeof(string));
            category.Rows.Add(1, "C1");
            category.Rows.Add(2, "C2");

            var product = new DataTable("Product");
            product.Columns.Add("Id", typeof(int));
            product.Columns.Add("Name", typeof(string));
            product.Columns.Add("CategoryId", typeof(int));
            product.Columns.Add("Available", typeof(bool));
            product.Rows.Add(1, "P1", 1, true);
            product.Rows.Add(2, "P2", 1, true);
            product.Rows.Add(3, "P3", 1, false);
            product.Rows.Add(4, "P4", 2, true);
            product.Rows.Add(5, "P5", 2, false);

            dataset.Tables.Add(category);
            dataset.Tables.Add(product);

            dataset.Relations.Add(new DataRelation("Products",
                category.Columns["Id"],
                product.Columns["CategoryId"], false));

            dataGrid1.DataSource = dataset;
            //dataGrid1.DataMember = category.TableName;
        }
    }
}
