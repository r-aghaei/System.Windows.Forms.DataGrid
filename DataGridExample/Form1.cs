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
            var table = new DataTable();
            table.Columns.Add("C1", typeof(int));
            table.Columns.Add("C2", typeof(string));
            table.Columns.Add("C3", typeof(bool));
            table.Rows.Add(1, "One", true);
            table.Rows.Add(2, "Two", false);

            var grid = new DataGrid();
            grid.Dock = DockStyle.Fill;
            grid.DataSource = table;

            this.Controls.Add(grid);
        }
    }
}
