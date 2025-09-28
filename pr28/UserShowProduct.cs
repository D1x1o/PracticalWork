using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pr28_connection;
using MySql.Data.MySqlClient;
using System.IO;

namespace pr28
{
    public partial class UserShowProduct : Form
    {
        string ConnStr = ConnectoinString.GetConnectionString();

        int pageSize = 10;
        int currentPage = 0;
        int totalRows = 0;

        public UserShowProduct()
        {
            InitializeComponent();
            CountTotalRows();
            FillDGV();
            //MessageBox.Show(UserSettings.Default.user);
            CheckExistOrder();
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

                dataGridView1.Columns["ProductName"].HeaderText = "Название";
                dataGridView1.Columns["ProductCost"].HeaderText = "Стоимость";
                dataGridView1.Columns["ProductManufacturer"].HeaderText = "Прозводитель";
                dataGridView1.Columns["ProductDescription"].HeaderText = "Описание";
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


                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.Name = "ActionColumn";
                buttonColumn.HeaderText = "Действие";
                buttonColumn.Text = "Добавить в корзину";
                buttonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn);

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
            if (currentPage == 0)
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

        private void ButtonNext_Click_1(object sender, EventArgs e)
        {
            currentPage++;
            FillDGV();

        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {

            if (currentPage > 0)
            {
                currentPage--;
                FillDGV();
            }
        }


        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "ActionColumn")
            {
                this.Name = "jkdfhgjkdfhfgjkh";
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string article = row.Cells["ProductArticleNumber"].Value?.ToString() ?? "Не указан";
                string productName = row.Cells["ProductName"].Value?.ToString() ?? "Неизвестный товар";

                //MessageBox.Show($"Товар: {productName}\nАртикул: {article}",
                //               "Информация о товаре", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (CheckExistOrder())
                {
                    UpdateExistOrder(article);
                }
                else
                {
                    CreateNewOrder(article);
                }
                
            }
        }

        private int userID;
        private bool CheckExistOrder()
        {
            userID = 0;
            string query = $"SELECT UserID FROM user WHERE UserLogin = '{UserSettings.Default.user}';";



            using (MySqlConnection conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                object Id = cmd.ExecuteScalar();
                if (Id == null)
                {
                    return false;
                }
                else
                {
                    userID = Convert.ToInt32(Id);
                }

                string query2 = $"SELECT OrderID FROM cart WHERE OrderClient = {userID};";

                MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                object orderID = cmd2.ExecuteScalar();
                if (orderID == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        private void CreateNewOrder(string article)
        {
            Random r = new Random();
            int code = r.Next(100, 999);
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string datePlus7Days = DateTime.Now.AddDays(20).ToString("yyyy-MM-dd HH:mm:ss");
            string query = $"INSERT INTO cart (OrderComposition, OrderDate, OrderDeliveryDate, OrderPickupPoint, OrderClient, OrederCode, OrderStatus) VALUES ('{article}, 1', '{currentDate}', '{datePlus7Days}', 11, {userID}, {code}, 1);";
            using (MySqlConnection conn = new MySqlConnection(ConnStr))
            {

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        private void UpdateExistOrder(string article)
        {
            try
            {
                string query = $"UPDATE cart SET OrderComposition = CONCAT(OrderComposition, ', {article}, 1') WHERE OrderClient = {userID}";
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                }
            }
            catch(Exception e){ MessageBox.Show("Слишком много товаров в корзине!");
            }
        }
    }
}
