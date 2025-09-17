using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using pr28_connection;

namespace pr28
{
    public partial class ConnForm : Form
    {
        public ConnForm()
        {
            InitializeComponent();
            LoadConnSettings();
        }

        public void LoadConnSettings()
        {
            serverName.Text = Settings.Default.serverName;
            dbName.Text = Settings.Default.dbName;
            userName.Text = Settings.Default.nameUser;
            userPwd.Text = Settings.Default.pwdUser;
        }

        public void SaveConnSettings()
        {
            Settings.Default.serverName = serverName.Text;
            Settings.Default.dbName = dbName.Text;
            Settings.Default.nameUser = userName.Text;
            Settings.Default.pwdUser = userPwd.Text;
            Settings.Default.Save();
        }

        private string GenerateConnectionString()
        {
            return $"Server={serverName.Text};" +
                   $"Database={dbName.Text};" +
                   $"User Id={userName.Text};" +
                   $"Password={userPwd.Text};";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveConnSettings();
            bool errConn = false;

            try
            {
                string currentConnStr = GenerateConnectionString();

                using (MySqlConnection mysqlconn = new MySqlConnection(currentConnStr))
                {
                    mysqlconn.Open();
                    ConnectoinString.UpdateConnectionString(currentConnStr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения! {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                errConn = true;
            }

            if (!errConn)
            {
                MessageBox.Show("Подключение успешно!", "Успех",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            try
            {
                string testConnStr = GenerateConnectionString();

                using (MySqlConnection mysqlconn = new MySqlConnection(testConnStr))
                {
                    mysqlconn.Open();
                    MessageBox.Show("Тестовое подключение успешно!", "Проверка",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка тестового подключения! {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}