using Microsoft.Extensions.DependencyInjection;
using WinFormsCatalog.Helpers;
using WinFormsCatalog.Models;
using WinFormsCatalog.Services;

namespace WinFormsCatalog
{
    public partial class Form2 : Form
    {
        private readonly Phone? _phone;
        private readonly ICatalogService _catalogService;

        public Form2()
            : this(null, CompositionRoot.Services.GetRequiredService<ICatalogService>())
        {
        }

        public Form2(Phone phone)
            : this(phone, CompositionRoot.Services.GetRequiredService<ICatalogService>())
        {
        }

        public Form2(Phone? phone, ICatalogService catalogService)
        {
            _phone = phone;
            _catalogService = catalogService;
            InitializeComponent();
            Load += Form2_Load;
            listView2.SelectedIndexChanged += listView2_SelectedIndexChanged;
            button3.Click += (_, _) => Close();
            button2.Click += OpenOrderForm;
        }

        private void Form2_Load(object? sender, EventArgs e)
        {
            if (_phone == null) return;
            label1.Text = _phone.Name;
            button2.Text = $"Купить за {_phone.Price:N0} ";

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

            int w1 = listView1.ClientSize.Width - 4;
            parametrColumn.Width = w1 / 2;
            valueColumn.Width = w1 - parametrColumn.Width;

            int w2 = listView2.ClientSize.Width - 4;
            columnShop.Width = w2 / 2;
            columnPrice.Width = w2 - columnShop.Width;
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
            button2.Text = $"Купить за {priceText} ";
        }

        private void LoadShopsForPhone(int phoneId)
        {
            try
            {
                foreach (var offer in _catalogService.GetShopOffers(phoneId))
                {
                    listView2.Items.Add(new ListViewItem(new[] { offer.Shop, offer.Price.ToString("N0") }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось загрузить цены магазинов.{Environment.NewLine}{Environment.NewLine}{ex.Message}",
                    "Каталог",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
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
