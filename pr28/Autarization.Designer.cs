namespace pr28
{
    partial class Autarization
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.pwdTextBox = new System.Windows.Forms.TextBox();
            this.replaceBTN = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cptTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.captchaIMG = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.captchaPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.captchaIMG)).BeginInit();
            this.captchaPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 282);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "Войти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Логин";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(49, 86);
            this.loginTextBox.MaxLength = 24;
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(156, 29);
            this.loginTextBox.TabIndex = 0;
            // 
            // pwdTextBox
            // 
            this.pwdTextBox.Location = new System.Drawing.Point(49, 176);
            this.pwdTextBox.MaxLength = 30;
            this.pwdTextBox.Name = "pwdTextBox";
            this.pwdTextBox.PasswordChar = '*';
            this.pwdTextBox.Size = new System.Drawing.Size(156, 29);
            this.pwdTextBox.TabIndex = 1;
            // 
            // replaceBTN
            // 
            this.replaceBTN.Location = new System.Drawing.Point(410, 282);
            this.replaceBTN.Name = "replaceBTN";
            this.replaceBTN.Size = new System.Drawing.Size(138, 42);
            this.replaceBTN.TabIndex = 7;
            this.replaceBTN.Text = "Обновить";
            this.replaceBTN.UseVisualStyleBackColor = true;
            this.replaceBTN.Click += new System.EventHandler(this.replaceBTN_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(263, 282);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 42);
            this.button2.TabIndex = 5;
            this.button2.Text = "Проверить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // cptTextBox
            // 
            this.cptTextBox.Location = new System.Drawing.Point(293, 241);
            this.cptTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.cptTextBox.MaxLength = 10;
            this.cptTextBox.Name = "cptTextBox";
            this.cptTextBox.Size = new System.Drawing.Size(214, 29);
            this.cptTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 211);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Введите капчу";
            // 
            // captchaIMG
            // 
            this.captchaIMG.Location = new System.Drawing.Point(254, 15);
            this.captchaIMG.Margin = new System.Windows.Forms.Padding(6);
            this.captchaIMG.Name = "captchaIMG";
            this.captchaIMG.Size = new System.Drawing.Size(300, 190);
            this.captchaIMG.TabIndex = 4;
            this.captchaIMG.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 317);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(21, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "button3";
            this.button3.Visible = false; //-=----------------------------------------------------------------------------
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // captchaPanel
            // 
            this.captchaPanel.Controls.Add(this.captchaIMG);
            this.captchaPanel.Controls.Add(this.cptTextBox);
            this.captchaPanel.Controls.Add(this.label3);
            this.captchaPanel.Controls.Add(this.button2);
            this.captchaPanel.Controls.Add(this.replaceBTN);
            this.captchaPanel.Location = new System.Drawing.Point(0, 0);
            this.captchaPanel.Name = "captchaPanel";
            this.captchaPanel.Size = new System.Drawing.Size(611, 352);
            this.captchaPanel.TabIndex = 9;
            this.captchaPanel.Visible = false;
            this.captchaPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.captchaPanel_Paint);
            // 
            // Autarization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 352);
            this.Controls.Add(this.captchaPanel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pwdTextBox);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Autarization";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.Autarization_Load);
            ((System.ComponentModel.ISupportInitialize)(this.captchaIMG)).EndInit();
            this.captchaPanel.ResumeLayout(false);
            this.captchaPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox pwdTextBox;
        private System.Windows.Forms.Button replaceBTN;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox cptTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox captchaIMG;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel captchaPanel;
    }
}