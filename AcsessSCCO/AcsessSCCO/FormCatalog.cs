using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcsessSCCO
{
    public partial class FormCatalog : Form
    {

        private string TableName;
        public FormCatalog(string tableCatalog)
        {
            InitializeComponent();
            TableName = tableCatalog;
            LoadData();
        }

        private void LoadData()
        {
            DataTable dataTable = new DataTable();
            dataTable = MsQuery.Query.RunSelect(string.Format("Select * from {0}", TableName));

            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[0].Name = dataTable.Columns[0].ColumnName;
            
            dataGridView1.Columns[1].Name = dataTable.Columns[1].ColumnName;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            switch (TableName)
            {
                case "TypeAssets":
                    dataGridView1.Columns[1].HeaderText = "Наименование типа актива";
                    break;
                case "Location":
                    dataGridView1.Columns[1].HeaderText = "Наименование местоположения актива";
                    break;
                case "AssetsStatus":
                    dataGridView1.Columns[1].HeaderText = "Наименование статуса актива";
                    break;
                case "Moves":
                    dataGridView1.Columns[1].HeaderText = "Наименование типа изменения актива";
                    break;
                default:
                    dataGridView1.Columns[1].HeaderText = "Наименование";
                    break;
            }
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void toolStripButtonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.RowIndex >= 0)
                    if (MsQuery.Query.RunEdit(string.Format("delete from {1} where {2} = {0}",
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value,
                        TableName,
                        dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name)))
                        MessageBox.Show("Запись удалена.");
                toolStripButtonRefresh_Click(sender, e);

            }
            catch { }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            MsQuery.Query.RunEdit(string.Format("Insert into {0} values(' ')", TableName));
            LoadData();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MsQuery.Query.RunEdit(string.Format("Update {3} set {0} = '{1}' where {4} = '{2}'",
                      dataGridView1.Columns[e.ColumnIndex].Name,
                      dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value,
                      dataGridView1.Rows[e.RowIndex].Cells[0].Value,
                      TableName,
                      dataGridView1.Columns[0].Name
                      ));
        }

        private void FormCatalog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
