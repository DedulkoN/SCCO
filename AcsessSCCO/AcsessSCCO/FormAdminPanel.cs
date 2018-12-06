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
    public partial class FormAdminPanel : Form
    {
        public FormAdminPanel()
        {
            InitializeComponent();
            DataTable table = new DataTable();
            table = MsQuery.Query.RunSelect("SELECT [RoleUserID],[NameRoleUser]  FROM [RoleUsers]");
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "NameRoleUser";
            comboBox1.ValueMember = "RoleUserID";
            groupBox1.Visible = false;
            LoadData();

        }

        private void LoadData()
        {
            DataTable dtUsers;
            dtUsers = MsQuery.Query.RunSelect("SELECT [UsersID],[UserLogin],[UserPassword],[RolesUser],[FIO]  FROM Users");
            DataTable dtRole = new DataTable();
            dtRole = MsQuery.Query.RunSelect("SELECT [RoleUserID],[NameRoleUser]  FROM [RoleUsers]");

            dataGridView1.DataSource = dtUsers;

            dataGridView1.Columns["UsersID"].Visible = false;

            dataGridView1.Columns[1].Name = dtUsers.Columns[1].ColumnName;
            dataGridView1.Columns[1].HeaderText = "Логин";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns[2].Name = dtUsers.Columns[2].ColumnName;
            dataGridView1.Columns[2].HeaderText = "Пароль(Защифрованный)";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewComboBoxColumn cbRole = new DataGridViewComboBoxColumn();
            cbRole.DataSource = dtRole;
            cbRole.DisplayMember = "NameRoleUser";
            cbRole.ValueMember = "RoleUserID";
            cbRole.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dataGridView1.Columns.Remove("RolesUser");
            dataGridView1.Columns.Insert(3, cbRole);
            dataGridView1.Columns[3].DataPropertyName = "RolesUser";
            dataGridView1.Columns[3].Name = dtUsers.Columns[3].ColumnName;
            dataGridView1.Columns[3].HeaderText = "Роль пользователя";
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns[4].Name = dtUsers.Columns[4].ColumnName;
            dataGridView1.Columns[4].HeaderText = "ФИО пользователя";
            dataGridView1.Columns[4].MinimumWidth = 100;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void buttonNoAdd_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            MsQuery.Query.RunEdit(string.Format("insert into Users values ('{0}', '{1}',{2}, '{3}')",
                textBoxLogin.Text,
                ClassCipler.GetHashString(textBoxPass.Text),
                comboBox1.SelectedValue,
                textBoxFIO.Text                
                ));
            groupBox1.Visible = false;
            LoadData();
        }

        private void toolStripButtonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.RowIndex >= 0)
                    if (MsQuery.Query.RunEdit(string.Format("delete from Users where UsersID = {0}",
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["UsersID"].Value)))
                        MessageBox.Show("Запись удалена.");
                LoadData();

            }
            catch { }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 2)
                {

                    if (MsQuery.Query.RunEdit(string.Format("Update Users set {0} = '{1}' where UsersID = '{2}'",
                        dataGridView1.Columns[e.ColumnIndex].Name,
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value,
                        dataGridView1.Rows[e.RowIndex].Cells[0].Value)))
                        MessageBox.Show("Запись изменена.");
                }
                else if (MsQuery.Query.RunEdit(string.Format("Update Users set {0} = '{1}' where UsersID = '{2}'",
                       dataGridView1.Columns[e.ColumnIndex].Name,
                       ClassCipler.GetHashString( dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()),
                       dataGridView1.Rows[e.RowIndex].Cells[0].Value)))
                    MessageBox.Show("Запись изменена.");

                LoadData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
