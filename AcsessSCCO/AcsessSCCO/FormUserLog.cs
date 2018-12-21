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
    public partial class FormUserLog : Form
    {

        private bool FilterOn = false;
        public FormUserLog()
        {
            InitializeComponent();

            
            DataTable dtType = new DataTable();
            dtType = MsQuery.Query.RunSelect("SELECT [UserLogin] FROM [Users]");
            toolStripComboBoxUser.Items.Clear();
            foreach (DataRow DR in dtType.Rows)
                toolStripComboBoxUser.Items.Add(DR["UserLogin"].ToString());
            toolStripComboBoxUser.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadData();
        }

        private void LoadData(string Filter = "")
        {
            DataTable dataTable = new DataTable();
            dataTable = MsQuery.Query.RunSelect("SELECT [ID], UserLogin, FIO,[UserLog],[DateLog]  FROM [UserLog] inner join Users on Users.UsersID = UserLog.UserID " + Filter );

            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[1].HeaderText = "Логин пользователя";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns[2].HeaderText = "ФИО пользователя";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns[3].HeaderText = "Лог";
            dataGridView1.Columns[3].MinimumWidth = 150;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns[4].HeaderText = "Время";
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;            

        }

        private void toolStripButtonDelFiltr_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (FilterOn) toolStripButtonOk_Click(sender, e);
            else LoadData();
        }

        private void toolStripButtonOk_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(MsQuery.Query.RunCalc(string.Format("SELECT MAX( [UsersID])   FROM [Users] where UserLogin = '{0}'", toolStripComboBoxUser.SelectedItem.ToString())));
            LoadData(string.Format(" where UserLog.UserID = {0}", UserID));
        }
    }
}
