
namespace pr28
{
    partial class AdminForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.SelectTable = new System.Windows.Forms.ComboBox();
            this.recoverDb = new System.Windows.Forms.Button();
            this.ImportData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите таблицу";
            // 
            // SelectTable
            // 
            this.SelectTable.FormattingEnabled = true;
            this.SelectTable.Location = new System.Drawing.Point(12, 67);
            this.SelectTable.Name = "SelectTable";
            this.SelectTable.Size = new System.Drawing.Size(286, 33);
            this.SelectTable.TabIndex = 1;
            // 
            // recoverDb
            // 
            this.recoverDb.Location = new System.Drawing.Point(12, 201);
            this.recoverDb.Name = "recoverDb";
            this.recoverDb.Size = new System.Drawing.Size(286, 40);
            this.recoverDb.TabIndex = 2;
            this.recoverDb.Text = "Восстановить БД";
            this.recoverDb.UseVisualStyleBackColor = true;
            this.recoverDb.Click += new System.EventHandler(this.recoverDb_Click);
            // 
            // ImportData
            // 
            this.ImportData.Location = new System.Drawing.Point(12, 155);
            this.ImportData.Name = "ImportData";
            this.ImportData.Size = new System.Drawing.Size(286, 40);
            this.ImportData.TabIndex = 3;
            this.ImportData.Text = "Импорт данных";
            this.ImportData.UseVisualStyleBackColor = true;
            this.ImportData.Click += new System.EventHandler(this.ImportData_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 259);
            this.Controls.Add(this.ImportData);
            this.Controls.Add(this.recoverDb);
            this.Controls.Add(this.SelectTable);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "AdminForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Форма Администратора";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SelectTable;
        private System.Windows.Forms.Button recoverDb;
        private System.Windows.Forms.Button ImportData;
    }
}