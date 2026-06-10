using Microsoft.Extensions.DependencyInjection;
using WinFormsCatalog.Helpers;
using WinFormsCatalog.Models;
using WinFormsCatalog.Services;

namespace WinFormsCatalog
{
    public partial class Form3 : Form
    {
        private readonly Phone? _phone;
        private readonly string _storeName;
        private readonly decimal _unitPrice;
        private readonly ICatalogService _catalogService;

        public Form3()
            : this(null, "Каталог", 0, CompositionRoot.Services.GetRequiredService<ICatalogService>())
        {
        }

        public Form3(Phone phone, decimal price)
            : this(phone, "Каталог", price)
        {
        }

        public Form3(Phone phone, string storeName, decimal price)
            : this(phone, storeName, price, CompositionRoot.Services.GetRequiredService<ICatalogService>())
        {
        }

        public Form3(Phone? phone, string storeName, decimal unitPrice, ICatalogService catalogService)
        {
            _phone = phone;
            _storeName = storeName;
            _unitPrice = unitPrice;
            _catalogService = catalogService;
            InitializeComponent();
            Load += Form3_Load;
            numericUpDown1.ValueChanged += (_, _) => UpdateTotal();
            form3btnBuy.Click += form3btnBuy_Click;
            button3.Click += (_, _) => Close();
        }

        private void Form3_Load(object? sender, EventArgs e)
        {
            if (_phone == null) return;
            label6.Text = _phone.Name;
            label7.Text = $"Магазин: {_storeName}";
            label8.Text = $"Цена: {_unitPrice:N0} Р";
            label8.Visible = true;

            numericUpDown1.Minimum = 1;
            numericUpDown1.Value = 1;
            UpdateTotal();

            PhoneImageHelper.Load(pictureBox1, _phone);
        }

        private void UpdateTotal()
        {
            int qty = (int)numericUpDown1.Value;
            label9.Text = $"Количество: {qty} шт.";
            label10.Text = $"Итого: {_unitPrice * qty:N0} Р";
        }

        private void form3btnBuy_Click(object? sender, EventArgs e)
        {
            if (_phone == null)
                return;

            if (string.IsNullOrWhiteSpace(tbFIO.Text))
            {
                MessageBox.Show("Введите ФИО.", "Оформление заказа", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }

            string phoneText = tbPhoneNumber.Text?.Trim() ?? "";
            string placeholder = "+375( )";
            int digitsCount = phoneText.Count(char.IsDigit);
            if (string.IsNullOrWhiteSpace(phoneText) || phoneText == placeholder || digitsCount < 9)
            {
                MessageBox.Show("Введите номер телефона (не менее 9 цифр).", "Оформление заказа", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }

            try
            {
                var orderId = _catalogService.CreateOrder(new OrderRequest
                {
                    PhoneId = _phone.Id,
                    ShopName = _storeName,
                    UnitPrice = _unitPrice,
                    Quantity = (int)numericUpDown1.Value,
                    CustomerName = tbFIO.Text.Trim(),
                    CustomerPhone = phoneText,
                    Address = string.IsNullOrWhiteSpace(tbAdressInfo.Text) ? null : tbAdressInfo.Text.Trim()
                });

                MessageBox.Show(
                    $"Заказ №{orderId} оформлен.",
                    "Оформление заказа",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.None);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось сохранить заказ.{Environment.NewLine}{Environment.NewLine}{ex.Message}",
                    "Оформление заказа",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
