using System;
using System.Data;
using System.Windows.Forms;

namespace AcsessSCCO
{
    public partial class FormLogin : Form
    {

        public int UserID = 0;
        public int UserRole = 0;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DTtemp = new DataTable();
                DTtemp = MsQuery.Query.RunSelect(string.Format("SELECT *  FROM [Users] where UserLogin = '{0}' and UserPassword = '{1}'",
                    textBoxLogin.Text, ClassCipler.GetHashString(textBoxPassword.Text)));
                UserID = Convert.ToInt32(DTtemp.Rows[0]["UsersID"].ToString());
                UserRole = Convert.ToInt32(DTtemp.Rows[0]["RolesUser"].ToString());
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception)
            {
                MessageBox.Show("Вход не выполнен" + Environment.NewLine + "Неверное сочетание логина и пароля", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
