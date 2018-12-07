using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace AcsessSCCO
{

    public partial class FormMain : Form
    {

        private int UserRoleID=0;
        private int UserID=0;



        public FormMain()
        {
            MsQuery.Query = new MsSQLqery(ClassSetting.GetBase());
            MsQuery.Query.TestConnect();

            FormLogin FL = new FormLogin();
            if (FL.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UserRoleID = FL.UserRole;
                UserID = FL.UserID;
                FL.Dispose();

            }
            else {

                FL.Dispose();
                Application.Exit();
            }
           
            


            InitializeComponent();
            LoadData();
            TypeFilter.SelectedIndex = 0;
            if (UserRoleID != 1) панельАдминистратораToolStripMenuItem.Visible = false;
        }


        private void LoadData(String Filter = "")
        {
            DataTable dtAsset = new DataTable();
            dtAsset = MsQuery.Query.RunSelect("SELECT [AssetsID],[TypeAssets], [Location], [AssetsStatus] ,[InventoryNumber],[Info]  FROM [Assets] " 
                + Filter);

            DataTable dtType = new DataTable();
            dtType = MsQuery.Query.RunSelect("SELECT  [TypeAssetsID], [NameAssets]  FROM [TypeAssets]");

            DataTable dtAssetsStatus = new DataTable();
            dtAssetsStatus = MsQuery.Query.RunSelect("SELECT [AssetsStatusID], [NameAssetsStatus]  FROM [AssetsStatus]");

            DataTable dtLocation = new DataTable();
            dtLocation = MsQuery.Query.RunSelect("SELECT [LocationID],[NameLocation]  FROM [Location]");

            dataGridView1.DataSource = dtAsset;

            dataGridView1.Columns["AssetsID"].Visible = false;


            DataGridViewComboBoxColumn cbType = new DataGridViewComboBoxColumn();
            cbType.DataSource = dtType;
            cbType.DisplayMember = "NameAssets";
            cbType.ValueMember = "TypeAssetsID";
            cbType.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dataGridView1.Columns.Remove("TypeAssets");
            dataGridView1.Columns.Insert(1, cbType);
            dataGridView1.Columns[1].DataPropertyName = "TypeAssets";
            dataGridView1.Columns[1].Name = dtAsset.Columns[1].ColumnName;
            dataGridView1.Columns[1].HeaderText = "Тип актива";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;


            DataGridViewComboBoxColumn cbLoc = new DataGridViewComboBoxColumn();
            cbLoc.DataSource = dtLocation;
            cbLoc.DisplayMember = "NameLocation";
            cbLoc.ValueMember = "LocationID";
            cbLoc.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dataGridView1.Columns.Remove("Location");
            dataGridView1.Columns.Insert(2, cbLoc);
            dataGridView1.Columns[2].DataPropertyName = "Location";
            dataGridView1.Columns[2].Name = dtAsset.Columns[2].ColumnName;
            dataGridView1.Columns[2].HeaderText = "Местоположение";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;



            DataGridViewComboBoxColumn cbStatus = new DataGridViewComboBoxColumn();
            cbStatus.DataSource = dtAssetsStatus;
            cbStatus.DisplayMember = "NameAssetsStatus";
            cbStatus.ValueMember = "AssetsStatusID";
            cbStatus.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dataGridView1.Columns.Remove("AssetsStatus");
            dataGridView1.Columns.Insert(3, cbStatus);
            dataGridView1.Columns[3].DataPropertyName = "AssetsStatus";
            dataGridView1.Columns[3].Name = dtAsset.Columns[3].ColumnName;
            dataGridView1.Columns[3].HeaderText = "Статус";
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;


            dataGridView1.Columns[4].Name = dtAsset.Columns[4].ColumnName;
            dataGridView1.Columns[4].HeaderText = "Инвентарный номер";
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns[5].Name = dtAsset.Columns[5].ColumnName;
            dataGridView1.Columns[5].HeaderText = "Дополнительная информация";
            dataGridView1.Columns[5].MinimumWidth = 150;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;     
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            switch (TypeFilter.SelectedIndex)
            {
                case 1:

                    int TypeAssetsID = Convert.ToInt32(MsQuery.Query.RunCalc(string.Format("SELECT max(TypeAssetsID)  FROM [TypeAssets] where NameAssets = '{0}'", Filter.SelectedItem.ToString())));
                    LoadData(string.Format(" where TypeAssets = {0}", TypeAssetsID));

                    break;
                case 2:

                    int LocationID = Convert.ToInt32(MsQuery.Query.RunCalc(string.Format("SELECT max(LocationID)  FROM [Location] where NameLocation = '{0}'", Filter.SelectedItem.ToString())));
                    LoadData(string.Format(" where Location = {0}", LocationID));

                    break;

                case 3:
                    int AssetsStatusID = Convert.ToInt32(MsQuery.Query.RunCalc(string.Format("SELECT max(AssetsStatusID)  FROM [AssetsStatus] where NameAssetsStatus = '{0}'", Filter.SelectedItem.ToString())));
                    LoadData(string.Format(" where AssetsStatus = {0}", AssetsStatusID));
                    break;
                default:
                    LoadData();
                    break;

            }
        }

        private void TypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(TypeFilter.SelectedIndex)
            {
                case 0:
                    Filter.Visible = false;
                    Filter.Items.Clear();
                    LoadData();
                    break;

                case 1:
                    Filter.Visible = true;
                    DataTable dtType = new DataTable();
                    dtType = MsQuery.Query.RunSelect("SELECT  [NameAssets]  FROM [TypeAssets]");
                    Filter.Items.Clear();
                    foreach (DataRow DR in dtType.Rows)
                        Filter.Items.Add(DR["NameAssets"].ToString());
                    Filter.DropDownStyle = ComboBoxStyle.DropDownList;
                    break;
                case 2:
                    Filter.Visible = true;
                    DataTable dtLocation = new DataTable();
                    dtLocation = MsQuery.Query.RunSelect("SELECT [NameLocation]  FROM [Location]");
                    Filter.Items.Clear();
                    foreach (DataRow DR in dtLocation.Rows)
                        Filter.Items.Add(DR["NameLocation"].ToString());
                    Filter.DropDownStyle = ComboBoxStyle.DropDownList;
                    break;

                case 3:
                    Filter.Visible = true;
                    DataTable dtAssetsStatus = new DataTable();
                    dtAssetsStatus = MsQuery.Query.RunSelect("SELECT  [NameAssetsStatus]  FROM [AssetsStatus]");
                    Filter.Items.Clear();
                    foreach (DataRow DR in dtAssetsStatus.Rows)
                        Filter.Items.Add(DR["NameAssetsStatus"].ToString());
                    Filter.DropDownStyle = ComboBoxStyle.DropDownList;
                    break;
                case 4:
                    Filter.Visible = true;
                    Filter.Items.Clear();
                    Filter.DropDownStyle = ComboBoxStyle.DropDown;
                    break;


            }
        }

        private void Filter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TypeFilter.SelectedIndex==4)
            {

                LoadData(String.Format(" where InventoryNumber like '{0}%'", Filter.Text));
                

            }
        }

        private void Filter_SelectedIndexChanged(object sender, EventArgs e)
        {      
            switch (TypeFilter.SelectedIndex)
            {
                case 1:                    
                                        
                   int TypeAssetsID = Convert.ToInt32(  MsQuery.Query.RunCalc(string.Format( "SELECT max(TypeAssetsID)  FROM [TypeAssets] where NameAssets = '{0}'", Filter.SelectedItem.ToString())));
                    LoadData( string.Format( " where TypeAssets = {0}", TypeAssetsID));

                    break;
                case 2:

                    int LocationID = Convert.ToInt32(MsQuery.Query.RunCalc(string.Format( "SELECT max(LocationID)  FROM [Location] where NameLocation = '{0}'", Filter.SelectedItem.ToString())));
                    LoadData( string.Format(" where Location = {0}", LocationID));                  
                
                    break;

                case 3:
                    int AssetsStatusID = Convert.ToInt32(MsQuery.Query.RunCalc(string.Format("SELECT max(AssetsStatusID)  FROM [AssetsStatus] where NameAssetsStatus = '{0}'", Filter.SelectedItem.ToString())));
                    LoadData( string.Format(" where AssetsStatus = {0}", AssetsStatusID));               
                    break;             


            }
        }

        private void toolStripButtonToWord_Click(object sender, EventArgs e)
        {
            Print.ExportToWord(dataGridView1);
        }

        private void toolStripButtonToExcel_Click(object sender, EventArgs e)
        {
            Print.ExportToExcel(dataGridView1);
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            FormAddAsset formAdd = new FormAddAsset();
            if (formAdd.ShowDialog() == DialogResult.OK)
                toolStripButtonRefresh_Click(sender, e);
        }

        private void toolStripButtonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.RowIndex >= 0)
                    if (MsQuery.Query.RunEdit(string.Format("delete from Assets where AssetsID = {0}",
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["AssetsID"].Value)))
                        MessageBox.Show("Запись удалена.");
                toolStripButtonRefresh_Click(sender, e);

            }
            catch { }
        }

        private void toolStripButtonMov_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.RowIndex >= 0)
                {
                    int asset = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["AssetsID"].Value);
                    FormMoves form = new FormMoves(UserID, asset);
                    form.Show();
                }
            }
            catch { }
        }

        private void панельАдминистратораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdminPanel FA = new FormAdminPanel();
            FA.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string PathDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName);
            string PathDirDoc = PathDir + @"\Help.docx";
            if (System.IO.File.Exists(PathDirDoc))
            {
                Word.Application wordapp;
                wordapp = new Word.Application();
                wordapp.Visible = true;
                Object filename = PathDirDoc;
                Object confirmConversions = Type.Missing;
                Object readOnly = Type.Missing;
                Object addToRecentFiles = Type.Missing;
                Object passwordDocument = Type.Missing;
                Object passwordTemplate = Type.Missing;
                Object revert = Type.Missing;
                Object writePasswordDocument = Type.Missing;
                Object writePasswordTemplate = Type.Missing;
                Object format = Type.Missing;
                Object encoding = Type.Missing;
                Object visible = Type.Missing;
                Object openConflictDocument = Type.Missing;
                Object openAndRepair = Type.Missing;
                Object documentDirection = Type.Missing;
                Object noEncodingDialog = Type.Missing;

                wordapp.Documents.Add(ref filename);

                Word.Document document = wordapp.Application.ActiveDocument;

            }
            else MessageBox.Show("Не найдет файл справки");
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MsQuery.Query.RunEdit(string.Format("Update [Assets] set {0} = '{1}' where AssetsID = '{2}'",
                       dataGridView1.Columns[e.ColumnIndex].Name,
                       dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value,
                       dataGridView1.Rows[e.RowIndex].Cells[0].Value));
              
        }

        private void типыАктивовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCatalog fc = new FormCatalog("TypeAssets");
            if (fc.ShowDialog() == DialogResult.OK )
                toolStripButtonRefresh_Click(sender, e);
        }

        private void местоположенияАктивовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCatalog fc = new FormCatalog("Location");
            if (fc.ShowDialog() == DialogResult.OK)
                toolStripButtonRefresh_Click(sender, e);
        }

        private void статусыАктивовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCatalog fc = new FormCatalog("AssetsStatus");
            if (fc.ShowDialog() == DialogResult.OK)
                toolStripButtonRefresh_Click(sender, e);
        }

        private void действияСАктивамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCatalog fc = new FormCatalog("Moves");
            if (fc.ShowDialog() == DialogResult.OK)
                toolStripButtonRefresh_Click(sender, e);
        }
    }
}
