using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using pr28_connection;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Security.Cryptography;

namespace pr28
{
    public partial class Autarization : Form
    {
        string connStr = ConnectoinString.GetConnectionString();
        public Autarization()
        {
            InitializeComponent();

            captchaIMG.Visible = false;
            label3.Visible = false;
            cptTextBox.Visible = false;
            button2.Visible = false;
            replaceBTN.Visible = false;
        }
        bool captchaTrue = false;
        private void Autarization_Load(object sender, EventArgs e)
        {
            CheckConnectionOnStart();
        }

        private void CheckConnectionOnStart()
        {
            bool connectionSuccessful = false;
            int attemptCount = 0;

            while (!connectionSuccessful && attemptCount < 3)
            {
                attemptCount++;

                try
                {
                    
                    using (MySqlConnection mysqlconn = new MySqlConnection(connStr))
                    {
                        mysqlconn.Open();
                        connectionSuccessful = true;
                    }
                }
                catch (Exception ex)
                {
                    if (attemptCount >= 3)
                    {
                        MessageBox.Show("Не удалось подключиться к базе данных после нескольких попыток",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                        return;
                    }
                    DialogResult result = MessageBox.Show($"Ошибка подключения к базе данных!\n{ex.Message}\n\nХотите настроить подключение?",
                        "Ошибка подключения",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error);

                    if (result == DialogResult.Yes)
                    {
                        ConnForm CF = new ConnForm();
                        if (CF.ShowDialog() == DialogResult.OK)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        Application.Exit();
                        return;
                    }
                }
            }
        }

        public void Connection()
        {
            try
            {
                string connStr = ConnectoinString.GetConnectionString();
                using (MySqlConnection mysqlconn = new MySqlConnection(connStr))
                {
                    mysqlconn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}");
                ShowConnectionForm();
            }
        }

        private void ShowConnectionForm()
        {
            ConnForm CF = new ConnForm();
            if (CF.ShowDialog() == DialogResult.OK)
            {
                CheckConnectionOnStart();
            }
        }

        int authAtt = 0;
        private bool isBlocked = false;
        private string cptAnswer = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (isBlocked)
            {
                MessageBox.Show("Система заблокирована на 10 секунд", "Блокировка",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка длины
            if (loginTextBox.Text.Length < 3 || pwdTextBox.Text.Length < 3)
            {
                MessageBox.Show("Логин или пароль слишком короткие", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Админ
            if (loginTextBox.Text == "admin" && pwdTextBox.Text == "admin")
            {
                MessageBox.Show("Вход выполнен!", "Успех",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                MenuForm Menu = new MenuForm();
                this.Hide();
                Menu.ShowDialog();
                this.Show();
                return;
            }

            // Проверка капчи
            if (authAtt >= 1 && !captchaTrue)
            {
                MessageBox.Show("Сначала введите капчу!", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                GenerateCaptcha();
                return;
            }

            // Обычный пользователь
            if (CheckUser())
            {
                int role = CheckUserRole();
                if (role == 1)
                {
                    UserSettings.Default.user = loginTextBox.Text.Trim();
                    MessageBox.Show("Добро пожаловать!", "Вход выполнен",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UserMenu menu = new UserMenu();
                    Hide();
                    menu.ShowDialog();
                    Show();

                    // Сбрасываем счетчик попыток при успешном входе
                    authAtt = 0;
                    captchaTrue = false;
                }
                return;
            }

            HandleFailedLogin();
        }


        private bool CheckUser()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT UserPassword FROM user WHERE UserLogin = '{loginTextBox.Text}';", conn);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string storedHash = result.ToString();
                    string inputHash = GetHashPwd(pwdTextBox.Text);

                    if (storedHash == inputHash)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Логин или пароль введены неверно!");
                    }
                }
            }
            return false;
        }

        private int CheckUserRole()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT UserRole FROM user WHERE UserLogin = '{loginTextBox.Text}';", conn);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
            }
            return -1;
        }

        private string GetHashPwd(string pwd)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(pwd);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder result = new StringBuilder();
                foreach (byte b in hash)
                {
                    result.Append(b.ToString("x2"));
                }
                return result.ToString();
            }
        }

        private void HandleFailedLogin()
        {
            authAtt++;

            if (authAtt == 1)
            {
                MessageBox.Show("Логин или пароль введены неверно! Требуется ввод CAPTCHA.", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
                ShowCaptcha();
            }
            else if (authAtt > 1)
            {
                MessageBox.Show("Логин или пароль были введены неверно! \nСистема будет заблокирована на 10 секунд!", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
                cptTextBox.Text = "";
                GenerateCaptcha();
                BlockSystem();
            }
        }

        private void ShowCaptcha()
        {
            GenerateCaptcha();
            captchaIMG.Visible = true;
            label3.Visible = true;
            cptTextBox.Visible = true;
            button2.Visible = true;
            replaceBTN.Visible = true;
        }
        private void HideCaptcha()
        {
            captchaIMG.Visible = false;
            label3.Visible = false;
            cptTextBox.Visible = false;
            button2.Visible = false;
            replaceBTN.Visible = false;
        }

        public void GenerateCaptcha()
        {
            button1.Enabled = false;
            Random r = new Random();
            int captID = r.Next(1, 4);
            string imgPath = "";

            if (captID == 1)
            {
                imgPath = "1.png";
                if (File.Exists(imgPath))
                {
                    captchaIMG.Image = Image.FromFile(imgPath);
                    cptAnswer = "$OD49";
                }
            }
            else if (captID == 2)
            {
                imgPath = "2.png";
                if (File.Exists(imgPath))
                {
                    captchaIMG.Image = Image.FromFile(imgPath);
                    cptAnswer = "J.La3&";
                }
            }
            else if (captID == 3)
            {
                imgPath = "3.png";
                if (File.Exists(imgPath))
                {
                    captchaIMG.Image = Image.FromFile(imgPath);
                    cptAnswer = "Ay5K!";
                }
            }
        }

        private void BlockSystem()
        {
            isBlocked = true;
            SetControlsEnabled(false);
            Thread blockThread = new Thread(() =>
            {
                Thread.Sleep(10000);

                this.Invoke(new Action(() =>
                {
                    isBlocked = false;
                    SetControlsEnabled(true);
                    cptTextBox.Text = "";
                    MessageBox.Show("Система разблокирована", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loginTextBox.Text = "";
                    pwdTextBox.Text = "";
                    HideCaptcha();
                }));
            });

            blockThread.IsBackground = true;
            blockThread.Start();
        }

        private void SetControlsEnabled(bool enabled)
        {
            loginTextBox.Enabled = enabled;
            pwdTextBox.Enabled = enabled;
            button1.Enabled = enabled;
            cptTextBox.Enabled = enabled;
            button2.Enabled = enabled;
            replaceBTN.Enabled = enabled;
            button3.Enabled = enabled;
        }

        private void CheckCredentials()
        {
            if (loginTextBox.Text == "admin" && pwdTextBox.Text == "admin")
            {
                MessageBox.Show("Вход выполнен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                HandleFailedLogin();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowConnectionForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cptTextBox.Text == cptAnswer)
            {
                MessageBox.Show("CAPTCHA введена верно!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                captchaTrue = true;
                button1.Enabled = true;
                CheckCredentials();
            }
            else
            {
                MessageBox.Show("CAPTCHA введена неверно!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cptTextBox.Text = "";
                GenerateCaptcha();
                BlockSystem();
            }
        }

        private void replaceBTN_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }
    }
}