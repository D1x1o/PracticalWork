
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
            this.SuspendLayout();
            // 
            // dbName
            // 
            this.dbName.Location = new System.Drawing.Point(14, 175);
            this.dbName.Margin = new System.Windows.Forms.Padding(6);
            this.dbName.Name = "dbName";
            this.dbName.Size = new System.Drawing.Size(180, 29);
            this.dbName.TabIndex = 2;
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(14, 264);
            this.userName.Margin = new System.Windows.Forms.Padding(6);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(180, 29);
            this.userName.TabIndex = 3;
            // 
            // userPwd
            // 
            this.userPwd.Location = new System.Drawing.Point(14, 353);
            this.userPwd.Margin = new System.Windows.Forms.Padding(6);
            this.userPwd.Name = "userPwd";
            this.userPwd.Size = new System.Drawing.Size(180, 29);
            this.userPwd.TabIndex = 4;
            // 
            // serverName
            // 
            this.serverName.Location = new System.Drawing.Point(15, 90);
            this.serverName.Margin = new System.Windows.Forms.Padding(6);
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(180, 29);
            this.serverName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Настройте ваше подключение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Имя сервера";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Название базы данных";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Пользователь";
            // 
            // fdsfdsdsdsf
            // 
            this.fdsfdsdsdsf.AutoSize = true;
            this.fdsfdsdsdsf.Location = new System.Drawing.Point(11, 323);
            this.fdsfdsdsdsf.Name = "fdsfdsdsdsf";
            this.fdsfdsdsdsf.Size = new System.Drawing.Size(76, 24);
            this.fdsfdsdsdsf.TabIndex = 8;
            this.fdsfdsdsdsf.Text = "Пароль";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 417);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 52);
            this.button1.TabIndex = 5;
            this.button1.Text = "Подключиться";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ConnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 481);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ConnForm";
            this.ShowIcon = false;
            this.Text = "Настройки подключения";
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
    }
}