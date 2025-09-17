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

namespace pr28
{
    public partial class Autarization : Form
    {
        public Autarization()
        {
            InitializeComponent();
            captchaPanel.Visible = false;
        }

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
                    string connStr = ConnectoinString.GetConnectionString();
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

            if (loginTextBox.Text.Length >= 3 && pwdTextBox.Text.Length >= 3)
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
            else
            {
                MessageBox.Show("Логин или пароль слишком короткие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleFailedLogin()
        {
            authAtt++;

            if (authAtt == 1)
            {
                MessageBox.Show("Логин и пароль введены неверно! Требуется ввод CAPTCHA.", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
                ShowCaptcha();
            }
            else if (authAtt > 1)
            {
                MessageBox.Show("Логин, пароль или CAPTCHA введены неверно!", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
                cptTextBox.Text = "";
                GenerateCaptcha();
                BlockSystem();
            }
        }

        private void ShowCaptcha()
        {
            captchaPanel.Visible = true;
            GenerateCaptcha();
        }

        public void GenerateCaptcha()
        {
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
                    captchaPanel.Visible = false;
                    MessageBox.Show("Система разблокирована", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (cptTextBox.Text == cptAnswer)
            {
                MessageBox.Show("CAPTCHA введена верно!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                captchaPanel.Visible = false;
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

        private void replaceBTN_Click_1(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowConnectionForm();
        }

        private void captchaPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}