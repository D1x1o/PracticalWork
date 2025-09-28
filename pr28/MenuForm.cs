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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void Recover_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            this.Hide();
            adminForm.ShowDialog();
            this.Show();
        }

        private void viewProduct_Click(object sender, EventArgs e)
        {
            ShowProduct SP = new ShowProduct();
            this.Hide();
            SP.ShowDialog();
            this.Show();
        }
    }
}
