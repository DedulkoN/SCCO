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
    public partial class FormMoves : Form
    {
        private int UserID = 0;
        private int AssetId;
        public FormMoves(int User, int Asset)
        {
            InitializeComponent();
            UserID = User;
            AssetId = Asset;
            LoadData();
        }

        private void LoadData()
        {
            DataTable dtTable = new DataTable();
            dtTable = MsQuery.Query.RunSelect(string.Format("SELECT [MoviesAssetsID],[Moves],[DateMoves],FIO "+
               " FROM [MovesAssets]   left outer JOIN  Users on UsersID = [UserWhyMove]  where Assets = {0}",
               AssetId));

            DataTable dtMov = new DataTable();
            dtMov = MsQuery.Query.RunSelect("SELECT [MovesID],[NameMoves]  FROM [Moves]");


            dataGridView1.DataSource = dtTable;

            dataGridView1.Columns[0].Visible = false;

            DataGridViewComboBoxColumn cbMov = new DataGridViewComboBoxColumn();
            cbMov.DataSource = dtMov;
            cbMov.DisplayMember = "NameMoves";
            cbMov.ValueMember = "MovesID";
            cbMov.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dataGridView1.Columns.Remove("Moves");
            dataGridView1.Columns.Insert(1, cbMov);
            dataGridView1.Columns[1].DataPropertyName = "Moves";
            dataGridView1.Columns[1].Name = dtTable.Columns[1].ColumnName;
            dataGridView1.Columns[1].HeaderText = "Движение актива";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].Name = dtTable.Columns[2].ColumnName;
            dataGridView1.Columns[2].HeaderText = "Дата движения";
            dataGridView1.Columns[2].DefaultCellStyle.Format = "dd.MM.yyyy";

            dataGridView1.Columns[3].MinimumWidth = 150;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].Name = dtTable.Columns[3].ColumnName;
            dataGridView1.Columns[3].HeaderText = "Данные о проводившем движение актива";
            dataGridView1.Columns[3].ReadOnly = true;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        private void toolStripButtonWord_Click(object sender, EventArgs e)
        {
            Print.ExportToWord(dataGridView1);
        }

        private void toolStripButtonExcel_Click(object sender, EventArgs e)
        {
            Print.ExportToExcel(dataGridView1);
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
                    if (MsQuery.Query.RunEdit(string.Format("delete from MovesAssets where MovesAssetsID = {0}",
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["MovesAssetsID"].Value)))
                        MessageBox.Show("Запись удалена.");
                toolStripButtonRefresh_Click(sender, e);

            }
            catch { }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.RowIndex >= 0)
                    if (MsQuery.Query.RunEdit(string.Format("Insert into MovesAssets values(1, '{2}', {0}, {1})",
                        UserID, AssetId, DateTime.Now.ToShortDateString())))
                        MessageBox.Show("Запись Добавлена.");
                toolStripButtonRefresh_Click(sender, e);

            }
            catch { }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MsQuery.Query.RunEdit(string.Format("Update [MovesAssets] set {0} = '{1}' where MovesAssetsID = '{2}'",
                      dataGridView1.Columns[e.ColumnIndex].Name,
                      dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value,
                      dataGridView1.Rows[e.RowIndex].Cells[0].Value));
        }
    }
}
