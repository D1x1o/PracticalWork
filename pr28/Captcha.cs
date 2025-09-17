using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr28
{
    public partial class Captcha : Form
    {
        public Captcha()
        {
            InitializeComponent();
            GenerateCaptcha();
        }
        string cptAnswer = "";
        public void GenerateCaptcha()
        {
            Random r = new Random();
            int captID = r.Next(1, 4);
            string imgPath = "";            
            if(captID == 1)
            {
                imgPath = "1.png";
                captchaIMG.Image = Image.FromFile(imgPath);
                cptAnswer = "$OD49";
            }
            else if (captID == 2)
            {
                imgPath = "2.png";
                captchaIMG.Image = Image.FromFile(imgPath);
                cptAnswer = "J.La3&";
            }
            else if (captID == 3)
            {
                imgPath = "3.png";
                captchaIMG.Image = Image.FromFile(imgPath);
                cptAnswer = "Ay5K!";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cptTextBox.Text == cptAnswer && cptTextBox.Text.Length > 3)
            {
                MessageBox.Show("Капча введена верно!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Капча введена НЕ верно!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cptTextBox.Text = "";
                
            }
        }

        private void replaceBTN_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }
    }
}
