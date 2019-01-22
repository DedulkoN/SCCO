using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.IO;

namespace AcsessSCCO
{
    /// <summary>
    /// Класс выполнения SQL-запросов
    /// </summary>
    class MsSQLqery
    {
        private SqlConnectionStringBuilder SqlBuilderConnect = new SqlConnectionStringBuilder();

        public MsSQLqery(SqlConnectionStringBuilder SqlBuilderConnectLine)
        {
            SqlBuilderConnect = SqlBuilderConnectLine;
        }


        /// <summary>
        /// Выполнение sql-запроса Select
        /// </summary>
        /// <param name="query">Текст запроса</param>
        /// <returns>Возвращает таблицу результата</returns>
        public DataTable RunSelect(string query)
        {
            SqlConnection testConnection = new SqlConnection(SqlBuilderConnect.ToString());
            SqlCommand testCommand = testConnection.CreateCommand();
            DataTable ResultTable = new DataTable();

            try
            {
                testConnection.Open();
                testCommand.CommandText = query;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(testCommand);
                dataAdapter.Fill(ResultTable);
                testConnection.Close();
                return ResultTable;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ResultTable;
            }
        }


        /// <summary>
        /// Выполнение sql-запроса Select
        /// </summary>
        /// <param name="query">Текст запроса</param>
        /// <param name="argName">Массив имен параметров</param>
        /// <param name="argValue">Массив соответствующих параметров</param>
        /// <returns>Возвращает таблицу результата</returns>
        public DataTable RunSelect(string query, string[] argName, object[] argValue)
        {
            SqlConnection testConnection = new SqlConnection(SqlBuilderConnect.ToString());
            SqlCommand testCommand = testConnection.CreateCommand();
            DataTable ResultTable = new DataTable();

            try
            {
                testConnection.Open();
                testCommand.CommandText = query;
                for (int i = 0; i < argName.Length; i++)
                    testCommand.Parameters.Add(new SqlParameter(argName[i], argValue[i]));
                SqlDataAdapter dataAdapter = new SqlDataAdapter(testCommand);
                dataAdapter.Fill(ResultTable);
                testConnection.Close();
                return ResultTable;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ResultTable;
            }
        }


        /// <summary>
        /// Выполнение sql-запроса для нахождения одного значения
        /// </summary>
        /// <param name="query">Текст запроса</param>

        /// <returns>Возвращает одно значения типа Object</returns>
        public Object RunCalc(string query)
        {

            SqlConnection testConnection = new SqlConnection(SqlBuilderConnect.ToString());
            SqlCommand testCommand = testConnection.CreateCommand();
            Object ResultStr = DBNull.Value;

            try
            {
                testConnection.Open();
                testCommand.CommandText = query;
                ResultStr = testCommand.ExecuteScalar();
                testConnection.Close();
                return ResultStr;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return DBNull.Value;
            }

        }



        /// <summary>
        /// Выполнение sql-запроса для нахождения одного значения
        /// </summary>
        /// <param name="query">Текст запроса</param>
        /// <param name="parametr">Доп параметр выполнения обозначенный как @parametr</param>
        /// <returns>Возвращает одно значения типа Object</returns>
        public Object RunCalc(string query, string parametr)
        {

            SqlConnection testConnection = new SqlConnection(SqlBuilderConnect.ToString());
            SqlCommand testCommand = testConnection.CreateCommand();
            Object ResultStr = DBNull.Value;

            try
            {
                testConnection.Open();
                testCommand.CommandText = query;
                testCommand.Parameters.AddWithValue("@parametr", parametr);
                ResultStr = testCommand.ExecuteScalar();
                testConnection.Close();
                return ResultStr;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return DBNull.Value;
            }

        }


        /// <summary>
        /// Выполнение sql-запроса для изменений в БД (Insert, Update)
        /// </summary>
        /// <param name="query">Текст запроса</param>
        /// <param name="ermsg">Необходимость вывода сообщения об ошибке</param>
        /// <returns>Возвращает true при удачном выполнении</returns>
        public bool RunEdit(string query, Boolean ermsg = true)
        {
            SqlConnection testConnection = new SqlConnection(SqlBuilderConnect.ToString());
            SqlCommand testCommand = testConnection.CreateCommand();

            try
            {
                testConnection.Open();

                testCommand.CommandText = string.Format("set language \'русский\'");
                testCommand.ExecuteNonQuery();


                testCommand.CommandText = query;
                testCommand.ExecuteNonQuery();
                testConnection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                //
                if (ermsg) MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else throw;
                return false;
            }
            finally
            {
                testConnection.Close();
            }
        }


        /// <summary>
        /// Выполнение sql-запроса для изменений в БД (Insert, Update)
        /// </summary>
        /// <param name="query">Текст запроса</param>
        /// <param name="parametr">Доп параметр выполнения обозначенный как @parametr</param>
        ///  <param name="ermsg">Необходимость вывода сообщения об ошибке</param>
        /// <returns>Возвращает true при удачном выполнении</returns>
        public bool RunEdit(string query, string parametr, Boolean ermsg = true)
        {
            SqlConnection testConnection = new SqlConnection(SqlBuilderConnect.ToString());
            SqlCommand testCommand = testConnection.CreateCommand();

            try
            {
                testConnection.Open();
                testCommand.CommandText = query;
                testCommand.Parameters.AddWithValue("@parametr", parametr);
                testCommand.ExecuteNonQuery();
                testConnection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                //
                if (ermsg) MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }





        /// <summary>
        /// Проверяет подключение к БД
        /// </summary>
        /// <returns>Возвращает true при удачном подключении</returns>
        public Boolean TestConnect()
        {
            try
            {
                SqlConnection testConnection = new SqlConnection(SqlBuilderConnect.ToString());
                SqlCommand testCommand = testConnection.CreateCommand();
                testConnection.Open();
                testCommand.CommandText = string.Format("set language \'русский\'");
                testCommand.ExecuteNonQuery();
                testConnection.Close();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка подключения!");
                return false;
            }
        }


    }

    /// <summary>
    /// Статический класс выполнения SQL-запросов
    /// Требует предварительного создания объекта MsSQLqery и передачи его в класс
    /// </summary>
    static class MsQuery
    {
        public static MsSQLqery Query; 

    }


    /// <summary>
    /// Класс для установки настроек подключения к БД
    /// </summary>
    static class ClassSetting
    {
        public static SqlConnectionStringBuilder GetBase()
        {
            SqlConnectionStringBuilder BaseSqlBuilderConnect = new SqlConnectionStringBuilder();
            XmlDocument conDoc = new XmlDocument();
            conDoc.LoadXml(File.ReadAllText(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName) + "\\ConnectDB.xml"));
            BaseSqlBuilderConnect.DataSource = conDoc.GetElementsByTagName("IPadress")[0].InnerText;
            BaseSqlBuilderConnect.InitialCatalog = conDoc.GetElementsByTagName("DatabaseName")[0].InnerText;
            BaseSqlBuilderConnect.UserID = conDoc.GetElementsByTagName("User")[0].InnerText;
            BaseSqlBuilderConnect.Password = conDoc.GetElementsByTagName("Password")[0].InnerText;
            BaseSqlBuilderConnect.PersistSecurityInfo = false;
            BaseSqlBuilderConnect.IntegratedSecurity = false;
            return BaseSqlBuilderConnect;
        }

    }
}
