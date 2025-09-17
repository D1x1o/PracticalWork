
namespace pr28
{
    partial class Captcha
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
            this.captchaIMG = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cptTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.replaceBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.captchaIMG)).BeginInit();
            this.SuspendLayout();
            // 
            // captchaIMG
            // 
            this.captchaIMG.Location = new System.Drawing.Point(15, 15);
            this.captchaIMG.Margin = new System.Windows.Forms.Padding(6);
            this.captchaIMG.Name = "captchaIMG";
            this.captchaIMG.Size = new System.Drawing.Size(300, 190);
            this.captchaIMG.TabIndex = 0;
            this.captchaIMG.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 211);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите капчу";
            // 
            // cptTextBox
            // 
            this.cptTextBox.Location = new System.Drawing.Point(54, 241);
            this.cptTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.cptTextBox.MaxLength = 10;
            this.cptTextBox.Name = "cptTextBox";
            this.cptTextBox.Size = new System.Drawing.Size(214, 29);
            this.cptTextBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 280);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "Проверить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // replaceBTN
            // 
            this.replaceBTN.Location = new System.Drawing.Point(171, 279);
            this.replaceBTN.Name = "replaceBTN";
            this.replaceBTN.Size = new System.Drawing.Size(138, 42);
            this.replaceBTN.TabIndex = 2;
            this.replaceBTN.Text = "Обновить";
            this.replaceBTN.UseVisualStyleBackColor = true;
            this.replaceBTN.Click += new System.EventHandler(this.replaceBTN_Click);
            // 
            // Captcha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 337);
            this.ControlBox = false;
            this.Controls.Add(this.replaceBTN);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cptTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.captchaIMG);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Captcha";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Captcha";
            ((System.ComponentModel.ISupportInitialize)(this.captchaIMG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox captchaIMG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cptTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button replaceBTN;
    }
}