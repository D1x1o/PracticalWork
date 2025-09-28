
namespace pr28
{
    partial class MenuForm
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
            this.Recover = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.viewProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Recover
            // 
            this.Recover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.Recover.Location = new System.Drawing.Point(16, 96);
            this.Recover.Margin = new System.Windows.Forms.Padding(7);
            this.Recover.Name = "Recover";
            this.Recover.Size = new System.Drawing.Size(336, 46);
            this.Recover.TabIndex = 0;
            this.Recover.Text = "Восстановление";
            this.Recover.UseVisualStyleBackColor = false;
            this.Recover.Click += new System.EventHandler(this.Recover_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::pr28.Properties.Resources.icon;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 25);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // viewProduct
            // 
            this.viewProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.viewProduct.Location = new System.Drawing.Point(17, 156);
            this.viewProduct.Margin = new System.Windows.Forms.Padding(7);
            this.viewProduct.Name = "viewProduct";
            this.viewProduct.Size = new System.Drawing.Size(336, 46);
            this.viewProduct.TabIndex = 0;
            this.viewProduct.Text = "Просмотр товара";
            this.viewProduct.UseVisualStyleBackColor = false;
            this.viewProduct.Click += new System.EventHandler(this.viewProduct_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 464);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.viewProduct);
            this.Controls.Add(this.Recover);
            this.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "MenuForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Recover;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button viewProduct;
    }
}