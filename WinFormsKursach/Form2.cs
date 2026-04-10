using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using WinFormsKursach.Helpers;
using WinFormsKursach.Models;

namespace WinFormsKursach
{
    public partial class Form2 : Form
    {
        private readonly Phones? _phone;

        public Form2()
        {
            InitializeComponent();
            Load += Form2_Load;
            listView2.SelectedIndexChanged += listView2_SelectedIndexChanged;
            button3.Click += (s, e) => Close();
            button1.Click += OpenOrderForm;
            button2.Click += OpenOrderForm;
        }

        public Form2(Phones phone) : this()
        {
            _phone = phone;
        }

        private void Form2_Load(object? sender, EventArgs e)
        {
            if (_phone == null) return;
            label1.Text = _phone.Name;
            button2.Text = $"Купить за {_phone.Price:N0} Р";

            listView1.Items.Clear();
            AddChar("Название", _phone.Name);
            AddChar("Производитель", _phone.Producer);
            AddChar("ОС", _phone.Os);
            AddChar("Экран", _phone.ScreenSize);
            AddChar("Тип матрицы", _phone.ScreenTech);
            AddChar("Разрешение", _phone.ScreenResolution);
            AddChar("ОЗУ", $"{_phone.RamGb} ГБ");
            AddChar("Память", $"{_phone.StorageGb} ГБ");
            AddChar("Процессор", _phone.Processor);
            AddChar("Камера", $"{_phone.CameraMp} Мп");
            AddChar("Батарея", $"{_phone.BatteryMah} мА·ч");
            AddChar("Влагозащита", _phone.Waterproof);
            if (!string.IsNullOrWhiteSpace(_phone.Description))
                AddChar("Описание", _phone.Description);

            listView2.Items.Clear();
            LoadShopsForPhone(_phone.Id);
            if (listView2.Items.Count > 0)
                listView2.Items[0].Selected = true;

            PhoneImageHelper.Load(pictureBox1, _phone);
            UpdateBuyButtonText();
        }

        private void listView2_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateBuyButtonText();
        }

        private void UpdateBuyButtonText()
        {
            if (listView2.SelectedItems.Count == 0)
            {
                button2.Text = "Купить";
                return;
            }
            string priceText = listView2.SelectedItems[0].SubItems[1].Text;
            button2.Text = $"Купить за {priceText} Р";
        }

        private void LoadShopsForPhone(int phoneId)
        {
            if (!File.Exists(DbHelper.GetDbPath())) return;
            using (var conn = new OleDbConnection(DbHelper.GetConnectionString()))
            {
                conn.Open();
                string query = "SELECT Shop, Price FROM Shops WHERE id_phone = ?";
                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@p1", phoneId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string shop = reader["Shop"] == DBNull.Value ? "" : reader["Shop"].ToString() ?? "";
                            decimal price = reader["Price"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Price"]);
                            listView2.Items.Add(new ListViewItem(new[] { shop, price.ToString("N0") }));
                        }
                    }
                }
            }
        }

        private void AddChar(string param, string value)
        {
            listView1.Items.Add(new ListViewItem(new[] { param, value ?? "" }));
        }

        private void OpenOrderForm(object? sender, EventArgs e)
        {
            if (_phone == null) return;
            if (listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите магазин для покупки.", "Каталог", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var row = listView2.SelectedItems[0];
            string storeName = row.SubItems[0].Text;
            if (!decimal.TryParse(row.SubItems[1].Text.Replace(" ", ""), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out decimal price))
                price = _phone.Price;
            using var form3 = new Form3(_phone, storeName, price);
            form3.ShowDialog();
        }
    }
}
