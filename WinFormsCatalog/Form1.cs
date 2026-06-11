using Microsoft.Extensions.DependencyInjection;
using WinFormsCatalog.Helpers;
using WinFormsCatalog.Models;
using WinFormsCatalog.Services;

namespace WinFormsCatalog
{
    public partial class Form1 : Form
    {
        private readonly ICatalogService _catalogService;
        private CatalogFilterOptions _filterOptions = new();
        private decimal _defaultMaxPrice;

        public Form1() : this(AppServices.Provider.GetRequiredService<ICatalogService>())
        {
        }

        public Form1(ICatalogService catalogService)
        {
            _catalogService = catalogService;
            InitializeComponent();
            dgvPhones.DoubleClick += (_, _) => OpenDetail();
            button1.Click += (_, _) => OpenDetail();
            resetFilters.Click += resetFilters_Click;
            cbSort.SelectedIndexChanged += cbSort_SelectedIndexChanged;
            lstProducer.ItemCheck += (_, _) =>
            {
                if (IsHandleCreated)
                    BeginInvoke(ApplyFiltersAndSort);
            };
            cmbOs.SelectedIndexChanged += FiltersChanged;
            numPriceMin.ValueChanged += FiltersChanged;
            numPriceMax.ValueChanged += FiltersChanged;
            numRamMin.ValueChanged += FiltersChanged;
            numStorageMin.ValueChanged += FiltersChanged;
            checkBox1.CheckedChanged += FiltersChanged;
            txtSearch.TextChanged += FiltersChanged;
            dgvPhones.Resize += (_, _) => SetGridColumns();
        }

        protected override void OnDpiChanged(DpiChangedEventArgs e)
        {
            base.OnDpiChanged(e);
            SetGridColumns();
        }

        private void SetGridColumns()
        {
            if (!dgvPhones.IsHandleCreated || dgvPhones.ClientSize.Width < 300)
                return;

            Font hf = dgvPhones.ColumnHeadersDefaultCellStyle.Font ?? dgvPhones.Font;
            int h = TextRenderer.MeasureText("Ay", dgvPhones.Font).Height;
            dgvPhones.ColumnHeadersHeight = TextRenderer.MeasureText("Ay", hf).Height + 8;
            dgvPhones.RowTemplate.Height = h + 6;

            colProducer.Width = TextRenderer.MeasureText(colProducer.HeaderText, hf).Width + 20;
            colPrice.Width = TextRenderer.MeasureText(colPrice.HeaderText, hf).Width + 24;
            colRam.Width = TextRenderer.MeasureText(colRam.HeaderText, hf).Width + 16;
            colStorage.Width = TextRenderer.MeasureText(colStorage.HeaderText, hf).Width + 20;
            colScreen.Width = TextRenderer.MeasureText(colScreen.HeaderText, hf).Width + 16;

            int fixedCols = colProducer.Width + colPrice.Width + colRam.Width + colStorage.Width + colScreen.Width;
            int nameWidth = dgvPhones.ClientSize.Width - fixedCols - 4;
            colName.Width = Math.Max(nameWidth, 140);
        }

        private void FillPhonesList(IEnumerable<Phone> phones)
        {
            phonesBindingSource.DataSource = phones.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _filterOptions = _catalogService.GetFilterOptions();
                _defaultMaxPrice = _filterOptions.MaxPrice;
                FillFilterCombos();
                ApplyFiltersAndSort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось загрузить каталог из базы данных.{Environment.NewLine}{Environment.NewLine}{DatabaseErrorHelper.ToUserMessage(ex)}",
                    "Каталог",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            SetGridColumns();
        }

        private void FillFilterCombos()
        {
            cbSort.Items.Clear();
            cbSort.Items.AddRange(new object[] {
                "По цене (сначала дешёвые)",
                "По цене (сначала дорогие)",
                "Модель А-Я",
                "Модель Я-А",
                "По ОЗУ (сначала меньше)",
                "По ОЗУ (сначала больше)"
            });
            cbSort.SelectedIndex = 0;

            lstProducer.Items.Clear();
            foreach (var producer in _filterOptions.Producers)
                lstProducer.Items.Add(producer);

            cmbOs.Items.Clear();
            cmbOs.Items.Add("Все");
            foreach (var os in _filterOptions.OperatingSystems)
                cmbOs.Items.Add(os);
            cmbOs.SelectedIndex = 0;

            decimal maxRange = Math.Max(_filterOptions.MaxPrice * 2, 100000);
            numPriceMin.Minimum = 0;
            numPriceMin.Maximum = maxRange;
            numPriceMin.Value = 0;
            numPriceMax.Minimum = 0;
            numPriceMax.Maximum = maxRange;
            numPriceMax.Value = _filterOptions.MaxPrice;

            numRamMin.Minimum = 0;
            numRamMin.Maximum = Math.Max(_filterOptions.MaxRamGb, 32);
            numRamMin.Increment = 2;
            numRamMin.Value = 0;

            numStorageMin.Minimum = 0;
            numStorageMin.Maximum = Math.Max(_filterOptions.MaxStorageGb, 1024);
            numStorageMin.Increment = 64;
            numStorageMin.Value = 0;
        }

        private void ApplyFiltersAndSort()
        {
            try
            {
                var phones = _catalogService.Search(BuildFilterCriteria());
                FillPhonesList(phones);
            }
            catch (Exception ex)
            {
                FillPhonesList([]);
                MessageBox.Show(
                    $"Не удалось применить фильтры.{Environment.NewLine}{Environment.NewLine}{DatabaseErrorHelper.ToUserMessage(ex)}",
                    "Каталог",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private PhoneFilterCriteria BuildFilterCriteria()
        {
            decimal priceMin = Math.Min(numPriceMin.Value, numPriceMax.Value);
            decimal priceMax = Math.Max(numPriceMin.Value, numPriceMax.Value);

            return new PhoneFilterCriteria
            {
                Producers = GetSelectedProducers(),
                Os = cmbOs.SelectedIndex > 0 && cmbOs.SelectedItem is string os ? os : null,
                PriceMin = priceMin,
                PriceMax = priceMax,
                OnlyInStock = checkBox1.Checked,
                MinRamGb = (int)numRamMin.Value,
                MinStorageGb = (int)numStorageMin.Value,
                Search = txtSearch.Text?.Trim() ?? "",
                Sort = (PhoneSortOption)Math.Max(cbSort.SelectedIndex, 0)
            };
        }

        private void resetFilters_Click(object? sender, EventArgs e)
        {
            for (int i = 0; i < lstProducer.Items.Count; i++)
                lstProducer.SetItemChecked(i, false);
            cmbOs.SelectedIndex = 0;
            numPriceMin.Value = numPriceMin.Minimum;
            numPriceMax.Value = _defaultMaxPrice;
            checkBox1.Checked = false;
            numRamMin.Value = numRamMin.Minimum;
            numStorageMin.Value = numStorageMin.Minimum;
            txtSearch.Clear();
            ApplyFiltersAndSort();
        }

        private List<string> GetSelectedProducers()
        {
            var selected = new List<string>();
            foreach (var item in lstProducer.CheckedItems)
            {
                if (item is string producer)
                    selected.Add(producer);
            }
            return selected;
        }

        private void cbSort_SelectedIndexChanged(object? sender, EventArgs e) => ApplyFiltersAndSort();
        private void FiltersChanged(object? sender, EventArgs e) => ApplyFiltersAndSort();

        private void OpenDetail()
        {
            if (dgvPhones.CurrentRow?.DataBoundItem is not Phone phone)
            {
                MessageBox.Show("Выберите телефон из списка", "Каталог", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var form2 = new Form2(phone, _catalogService);
            form2.ShowDialog();
        }
    }
}
