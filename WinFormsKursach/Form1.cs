using System.Data.OleDb;
using System.IO;
using WinFormsKursach.Helpers;
using WinFormsKursach.Models;

namespace WinFormsKursach
{
    public partial class Form1 : Form
    {
        private List<Phones> _allPhones = new List<Phones>();

        public Form1()
        {
            InitializeComponent();
            dgvPhones.DoubleClick += (s, e) => OpenDetail();
            button1.Click += (s, e) => OpenDetail();
            resetFilters.Click += resetFilters_Click;
            cbSort.SelectedIndexChanged += cbSort_SelectedIndexChanged;
            cmbProducer.SelectedIndexChanged += FiltersChanged;
            cmbOs.SelectedIndexChanged += FiltersChanged;
            numPriceMin.ValueChanged += FiltersChanged;
            numPriceMax.ValueChanged += FiltersChanged;
            checkBox1.CheckedChanged += FiltersChanged;
            txtSearch.TextChanged += FiltersChanged;
        }
        public void LoadPhonesFromDB()
        {
            if (!File.Exists(DbHelper.GetDbPath()))
                return;

            var list = new List<Phones>();
            string query =
                "SELECT P.id, P.Model, C.Producer, C.Os, C.ScreenSize, C.RamGb, C.StorageGb, C.ImageUrl, C.InStock, " +
                "C.ScreenTech, C.ScreenResolution, C.ScreenRefreshHz, C.Processor, C.CameraMp, C.BatteryMah, C.Waterproof, C.Description, " +
                "(SELECT MIN(S.Price) FROM Shops S WHERE S.id_phone = P.id) AS Price " +
                "FROM Phones P INNER JOIN Characteristics C ON C.id_phone = P.id";

            using (var conn = new OleDbConnection(DbHelper.GetConnectionString()))
            {
                conn.Open();
                using (var cmd = new OleDbCommand(query, conn))
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var phone = new Phones
                        {
                            Id = GetInt(reader, "id"),
                            Name = reader["Model"] == DBNull.Value ? "" : reader["Model"].ToString() ?? "",
                            Producer = GetString(reader, "Producer"),
                            Price = reader["Price"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Price"]),
                            Os = GetString(reader, "Os"),
                            ScreenSize = GetString(reader, "ScreenSize"),
                            RamGb = GetInt(reader, "RamGb"),
                            StorageGb = GetInt(reader, "StorageGb"),
                            ImageUrl = GetString(reader, "ImageUrl"),
                            InStock = reader["InStock"] == DBNull.Value || reader["InStock"] == null ? true : Convert.ToBoolean(reader["InStock"]),
                            ScreenTech = GetString(reader, "ScreenTech"),
                            ScreenResolution = GetString(reader, "ScreenResolution"),
                            ScreenRefreshHz = GetInt(reader, "ScreenRefreshHz"),
                            Processor = GetString(reader, "Processor"),
                            CameraMp = GetInt(reader, "CameraMp"),
                            BatteryMah = GetInt(reader, "BatteryMah"),
                            Waterproof = GetString(reader, "Waterproof"),
                            Description = GetString(reader, "Description")
                        };
                        list.Add(phone);
                    }
                }
            }

            _allPhones = list;
        }

        private static string GetString(OleDbDataReader reader, string col)
        {
            try
            {
                var v = reader[col];
                if (v == null || v == DBNull.Value) return "";
                return v.ToString()?.Trim() ?? "";
            }
            catch { return ""; }
        }

        private static int GetInt(OleDbDataReader reader, string col)
        {
            try
            {
                var v = reader[col];
                if (v == null || v == DBNull.Value) return 0;
                return Convert.ToInt32(v);
            }
            catch { return 0; }
        }

        private void FillPhonesList(IEnumerable<Phones> phones)
        {
            phonesBindingSource.DataSource = phones.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPhonesFromDB();
            FillFilterCombos();
            ApplyFiltersAndSort();
        }

        private void FillFilterCombos()
        {
            cbSort.Items.Clear();
            cbSort.Items.AddRange(new object[] {
                "По цене (сначала дешёвые)",
                "По цене (сначала дорогие)",
                "Модель А-Я",
                "Модель Я-А"
            });
            cbSort.SelectedIndex = 0;

            var producers = _allPhones.Select(p => p.Producer).Distinct().OrderBy(x => x).ToList();
            cmbProducer.Items.Clear();
            cmbProducer.Items.Add("Все");
            foreach (var p in producers) cmbProducer.Items.Add(p);
            cmbProducer.SelectedIndex = 0;

            var osList = _allPhones.Select(p => p.Os).Distinct().OrderBy(x => x).ToList();
            cmbOs.Items.Clear();
            cmbOs.Items.Add("Все");
            foreach (var os in osList) cmbOs.Items.Add(os);
            cmbOs.SelectedIndex = 0;

            if (_allPhones.Count > 0)
            {
                decimal maxPrice = _allPhones.Max(p => p.Price);
                decimal maxRange = Math.Max(maxPrice * 2, 100000);
                numPriceMin.Minimum = 0;
                numPriceMin.Maximum = maxRange;
                numPriceMin.Value = 0;
                numPriceMax.Minimum = 0;
                numPriceMax.Maximum = maxRange;
                numPriceMax.Value = maxPrice;
            }
        }

        private void ApplyFiltersAndSort()
        {
            var query = _allPhones.AsEnumerable();

            if (cmbProducer.SelectedIndex > 0 && cmbProducer.SelectedItem is string prod)
                query = query.Where(p => p.Producer == prod);
            if (cmbOs.SelectedIndex > 0 && cmbOs.SelectedItem is string os)
                query = query.Where(p => p.Os == os);
            decimal priceMin = Math.Min(numPriceMin.Value, numPriceMax.Value);
            decimal priceMax = Math.Max(numPriceMin.Value, numPriceMax.Value);
            query = query.Where(p => p.Price >= priceMin && p.Price <= priceMax);
            if (checkBox1.Checked)
                query = query.Where(p => p.InStock);
            string search = txtSearch.Text?.Trim() ?? "";
            if (search.Length > 0)
                query = query.Where(p => (p.Name?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false) ||
                                         (p.Producer?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false));

            int sortIndex = cbSort.SelectedIndex;
            query = sortIndex switch
            {
                1 => query.OrderByDescending(p => p.Price),
                2 => query.OrderBy(p => p.Name),
                3 => query.OrderByDescending(p => p.Name),
                _ => query.OrderBy(p => p.Price)
            };

            FillPhonesList(query.ToList());
        }

        private void resetFilters_Click(object? sender, EventArgs e)
        {
            cmbProducer.SelectedIndex = 0;
            cmbOs.SelectedIndex = 0;
            numPriceMin.Value = numPriceMin.Minimum;
            if (_allPhones.Count > 0)
                numPriceMax.Value = _allPhones.Max(p => p.Price);
            checkBox1.Checked = false;
            txtSearch.Clear();
            ApplyFiltersAndSort();
        }

        private void cbSort_SelectedIndexChanged(object? sender, EventArgs e) => ApplyFiltersAndSort();
        private void FiltersChanged(object? sender, EventArgs e) => ApplyFiltersAndSort();

        private void OpenDetail()
        {
            if (dgvPhones.CurrentRow == null)
            {
                MessageBox.Show("Выберите телефон из списка.", "Каталог", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var phone = (Phones)dgvPhones.CurrentRow.DataBoundItem;
            using var form2 = new Form2(phone);
            form2.ShowDialog();
        }
    }
}
