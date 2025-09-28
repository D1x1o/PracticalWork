using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using pr28_connection;
using MySql.Data.MySqlClient;
using System.IO;

namespace pr28
{
    public partial class AdminForm : Form
    {
        string connStr = ConnectoinString.GetConnectionString();
        public AdminForm()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void recoverDb_Click(object sender, EventArgs e)
        {
            RestoreDatabaseStructure();
        }
        private void RestoreDatabaseStructure()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "SQL files (*.sql)|*.sql";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();

                    string[] lines = File.ReadAllLines(dialog.FileName);
                    string currentCommand = "";

                    foreach (string line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line) || line.Trim().StartsWith("--"))
                            continue;

                        currentCommand += line;

                        if (line.Trim().EndsWith(";"))
                        {
                            if (!string.IsNullOrWhiteSpace(currentCommand.Trim(';', ' ', '\t', '\r', '\n')))
                            {
                                MySqlCommand cmd = new MySqlCommand(currentCommand, conn);
                                cmd.ExecuteNonQuery();
                            }
                            currentCommand = "";
                        }
                    }

                    conn.Close();
                    MessageBox.Show("Структура БД была восстановлена!");
                    SelectTable.Items.Clear();
                    FillComboBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }



        private void FillComboBox()
        {
            try
            {
                using (MySqlConnection Conn = new MySqlConnection(connStr))
                {
                    Conn.Open();
                    MySqlCommand cmd = new MySqlCommand("show tables;", Conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        SelectTable.Items.Add(reader.GetValue(0).ToString());
                    }
                }
            }
            catch (Exception e) { MessageBox.Show($"{e.Message}"); }
        }

        private void ImportData_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectTable.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите таблицу!", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                    openFileDialog.Title = "Выберите CSV файл для импорта";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        string tableName = SelectTable.SelectedItem.ToString();

                        if (!File.Exists(filePath))
                        {
                            MessageBox.Show("Выбранный файл не существует!", "Ошибка",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        using (MySqlConnection mySqlConnection = new MySqlConnection(connStr))
                        {
                            mySqlConnection.Open();

                            int importRows = ImportCSV(filePath, tableName, mySqlConnection);

                            if (importRows > 0)
                            {
                                MessageBox.Show($"Успешно импортировано {importRows} записей в таблицу {tableName}!",
                                              "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Не удалось импортировать данные!", "Предупреждение",
                                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                        SelectTable.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при импорте данных: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ImportCSV(string filePath, string tableName, MySqlConnection connection)
        {
            int affectedRows = 0;

            try
            {
                var lines = File.ReadAllLines(filePath, Encoding.UTF8);

                if (lines.Length == 0)
                {
                    MessageBox.Show("CSV файл пуст!", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

                string[] headers = lines[0].Split(',');
                for (int i = 1; i < lines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lines[i]))
                        continue;

                    string[] values = lines[i].Split(',');
                    string columns = string.Join(", ", headers);
                    string parameters = string.Join(", ", headers.Select(h => $"@{h}"));

                    string query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        for (int j = 0; j < headers.Length && j < values.Length; j++)
                        {
                            cmd.Parameters.AddWithValue($"@{headers[j]}", values[j]);
                        }

                        affectedRows += cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка импорта CSV: {ex.Message}", ex);
            }

            return affectedRows;
        }
    }
}
