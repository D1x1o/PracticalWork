using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using pr28_connection;

namespace pr28
{
    public partial class ShowProduct : Form
    {
        string ConnStr = ConnectoinString.GetConnectionString();

        int pageSize = 10;   
        int currentPage = 0;
        int totalRows = 0; 

        public ShowProduct()
        {
            InitializeComponent();
            CountTotalRows(); 
            FillDGV(); 
        }

        private void CountTotalRows()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnStr))
            using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM PRODUCT;", conn))
            {
                conn.Open();
                totalRows = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void FillDGV()
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    string query = $"SELECT * FROM PRODUCT LIMIT {pageSize} OFFSET {currentPage * pageSize};";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }

                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dt;

                
                    dataGridView1.Columns["ProductArticleNumber"].Visible = false;
                    dataGridView1.Columns["ProductUnit"].Visible = false;
                dataGridView1.Columns["ProductPhoto"].Visible = false;
                dataGridView1.Columns["ProductMaxDiscount"].Visible = false;
                    dataGridView1.Columns["ProductSupplier"].Visible = false;
                    dataGridView1.Columns["ProductDiscountAmount"].Visible = false;
                    dataGridView1.Columns["ProductCategory"].Visible = false;
                    dataGridView1.Columns["ProductQuantityInStockrole"].Visible = false;

                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn.Name = "ImageColumn";
                imageColumn.HeaderText = "Изображение";
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dataGridView1.Columns.Add(imageColumn);
                dataGridView1.Columns["ImageColumn"].DisplayIndex = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells.Count > 11 && row.Cells[11].Value != null)
                    {
                        string fileName = row.Cells[11].Value.ToString().Trim();
                        string imagePath = $"img/{fileName}";
                        if (File.Exists(imagePath))
                        {
                            row.Cells["ImageColumn"].Value = Image.FromFile(imagePath);
                        }
                    }
                }
                UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}!");
            }
        }

        private void UpdateButtonsState()
        {
            ButtonNext.Enabled = currentPage > 0;
            int maxPage = (int)Math.Ceiling((double)totalRows / pageSize) - 1;
            ButtonNext.Enabled = currentPage < maxPage;
            if(currentPage == 0)
            {
                ButtonBack.Enabled = false;
            }
            else
            {
                ButtonBack.Enabled = true;
            }
            NowPage.Text = (currentPage + 1).ToString();
            pageAll.Text = (maxPage + 1).ToString();
        }

        private void ButtonBack_Click_1(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                FillDGV();
            }
        }

        private void ButtonNext_Click_1(object sender, EventArgs e)
        {
            currentPage++;
            FillDGV();
        }
    }
}
