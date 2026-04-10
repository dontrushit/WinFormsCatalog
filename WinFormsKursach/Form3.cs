using System.Linq;
using System.Windows.Forms;
using WinFormsKursach.Helpers;
using WinFormsKursach.Models;

namespace WinFormsKursach
{
    public partial class Form3 : Form
    {
        private readonly Phones? _phone;
        private readonly string _storeName;
        private readonly decimal _unitPrice;

        public Form3()
        {
            InitializeComponent();
            Load += Form3_Load;
            numericUpDown1.ValueChanged += (s, e) => UpdateTotal();
            form3btnBuy.Click += form3btnBuy_Click;
            button3.Click += (s, e) => Close();
        }

        public Form3(Phones phone, decimal price) : this(phone, "Каталог", price) { }

        public Form3(Phones phone, string storeName, decimal price) : this()
        {
            _phone = phone;
            _storeName = storeName ?? "Каталог";
            _unitPrice = price;
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
            if (string.IsNullOrWhiteSpace(tbFIO.Text))
            {
                MessageBox.Show("Введите ФИО.", "Оформление заказа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string phoneText = tbPhoneNumber.Text?.Trim() ?? "";
            string placeholder = "+375( )";
            int digitsCount = phoneText.Count(char.IsDigit);
            if (string.IsNullOrWhiteSpace(phoneText) || phoneText == placeholder || digitsCount < 9)
            {
                MessageBox.Show("Введите номер телефона (не менее 9 цифр).", "Оформление заказа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Заказ оформлен.", "Оформление заказа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
