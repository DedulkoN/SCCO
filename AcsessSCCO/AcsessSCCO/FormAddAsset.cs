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
    public partial class FormAddAsset : Form
    {
        public FormAddAsset()
        {
            InitializeComponent();

            DataTable dtType = new DataTable();
            dtType = MsQuery.Query.RunSelect("SELECT  [TypeAssetsID], [NameAssets]  FROM [TypeAssets]");

            DataTable dtAssetsStatus = new DataTable();
            dtAssetsStatus = MsQuery.Query.RunSelect("SELECT [AssetsStatusID], [NameAssetsStatus]  FROM [AssetsStatus]");

            DataTable dtLocation = new DataTable();
            dtLocation = MsQuery.Query.RunSelect("SELECT [LocationID],[NameLocation]  FROM [Location]");

            comboBoxType.DataSource = dtType;
            comboBoxType.DisplayMember = "NameAssets";
            comboBoxType.ValueMember = "TypeAssetsID";

            comboBoxStatys.DataSource = dtAssetsStatus;
            comboBoxStatys.DisplayMember = "NameAssetsStatus";
            comboBoxStatys.ValueMember = "AssetsStatusID";

            comboBoxLocality.DataSource = dtLocation;
            comboBoxLocality.DisplayMember = "NameLocation";
            comboBoxLocality.ValueMember = "LocationID";

        }

        private void buttonCansel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FormAddAsset_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (MsQuery.Query.RunEdit(string.Format("insert into Assets values({0}, {1}, {2}, '{3}', '{4}')",
                comboBoxType.SelectedValue,
                comboBoxLocality.SelectedValue,
                comboBoxStatys.SelectedValue,
                textBoxNumber.Text,
                textBoxInfo.Text                
                )))
            {
                MessageBox.Show("Успешно добавлено");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
