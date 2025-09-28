
namespace pr28
{
    partial class ConnForm
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
            this.dbName = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.userPwd = new System.Windows.Forms.TextBox();
            this.serverName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fdsfdsdsdsf = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dbName
            // 
            this.dbName.Location = new System.Drawing.Point(15, 190);
            this.dbName.Margin = new System.Windows.Forms.Padding(7);
            this.dbName.Name = "dbName";
            this.dbName.Size = new System.Drawing.Size(196, 34);
            this.dbName.TabIndex = 2;
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(15, 286);
            this.userName.Margin = new System.Windows.Forms.Padding(7);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(196, 34);
            this.userName.TabIndex = 3;
            // 
            // userPwd
            // 
            this.userPwd.Location = new System.Drawing.Point(15, 382);
            this.userPwd.Margin = new System.Windows.Forms.Padding(7);
            this.userPwd.Name = "userPwd";
            this.userPwd.Size = new System.Drawing.Size(196, 34);
            this.userPwd.TabIndex = 4;
            // 
            // serverName
            // 
            this.serverName.Location = new System.Drawing.Point(16, 98);
            this.serverName.Margin = new System.Windows.Forms.Padding(7);
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(196, 34);
            this.serverName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Настройте ваше подключение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Имя сервера";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Название базы данных";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Пользователь";
            // 
            // fdsfdsdsdsf
            // 
            this.fdsfdsdsdsf.AutoSize = true;
            this.fdsfdsdsdsf.Location = new System.Drawing.Point(12, 350);
            this.fdsfdsdsdsf.Name = "fdsfdsdsdsf";
            this.fdsfdsdsdsf.Size = new System.Drawing.Size(81, 26);
            this.fdsfdsdsdsf.TabIndex = 8;
            this.fdsfdsdsdsf.Text = "Пароль";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.button1.Location = new System.Drawing.Point(51, 452);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 56);
            this.button1.TabIndex = 5;
            this.button1.Text = "Подключиться";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::pr28.Properties.Resources.icon;
            this.pictureBox1.Location = new System.Drawing.Point(12, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 25);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // ConnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 521);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fdsfdsdsdsf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverName);
            this.Controls.Add(this.userPwd);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.dbName);
            this.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.MaximizeBox = false;
            this.Name = "ConnForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки подключения";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dbName;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox userPwd;
        private System.Windows.Forms.TextBox serverName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label fdsfdsdsdsf;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}