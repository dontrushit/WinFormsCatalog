namespace WinFormsCatalog
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            label1 = new Label();
            filters = new GroupBox();
            resetFilters = new Button();
            numStorageMin = new NumericUpDown();
            labelStorageMin = new Label();
            numRamMin = new NumericUpDown();
            labelRamMin = new Label();
            checkBox1 = new CheckBox();
            cmbOs = new ComboBox();
            label4 = new Label();
            numPriceMax = new NumericUpDown();
            numPriceMin = new NumericUpDown();
            label3 = new Label();
            lstProducer = new CheckedListBox();
            label2 = new Label();
            label5 = new Label();
            cbSort = new ComboBox();
            phonesBindingSource = new BindingSource(components);
            dgvPhones = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colProducer = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colRam = new DataGridViewTextBoxColumn();
            colStorage = new DataGridViewTextBoxColumn();
            colScreen = new DataGridViewTextBoxColumn();
            button1 = new Button();
            txtSearch = new TextBox();
            filters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numStorageMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRamMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPriceMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPriceMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)phonesBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhones).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(50, 50, 50);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(248, 30);
            label1.TabIndex = 0;
            label1.Text = "Мобильные телефоны";
            // 
            // filters
            // 
            filters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            filters.BackColor = Color.FromArgb(238, 238, 238);
            filters.Controls.Add(resetFilters);
            filters.Controls.Add(numStorageMin);
            filters.Controls.Add(labelStorageMin);
            filters.Controls.Add(numRamMin);
            filters.Controls.Add(labelRamMin);
            filters.Controls.Add(checkBox1);
            filters.Controls.Add(cmbOs);
            filters.Controls.Add(label4);
            filters.Controls.Add(numPriceMax);
            filters.Controls.Add(numPriceMin);
            filters.Controls.Add(label3);
            filters.Controls.Add(lstProducer);
            filters.Controls.Add(label2);
            filters.Font = new Font("Segoe UI", 9.75F);
            filters.Location = new Point(12, 62);
            filters.Name = "filters";
            filters.Size = new Size(236, 416);
            filters.TabIndex = 1;
            filters.TabStop = false;
            filters.Text = "Фильтры";
            // 
            // resetFilters
            // 
            resetFilters.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resetFilters.BackColor = Color.FromArgb(238, 238, 238);
            resetFilters.FlatAppearance.MouseDownBackColor = Color.FromArgb(238, 238, 238);
            resetFilters.FlatAppearance.MouseOverBackColor = Color.FromArgb(238, 238, 238);
            resetFilters.FlatStyle = FlatStyle.Flat;
            resetFilters.ForeColor = Color.FromArgb(0, 120, 215);
            resetFilters.Location = new Point(9, 375);
            resetFilters.Name = "resetFilters";
            resetFilters.Size = new Size(218, 34);
            resetFilters.TabIndex = 6;
            resetFilters.Text = "Сбросить фильтры";
            resetFilters.UseVisualStyleBackColor = false;
            // 
            // numStorageMin
            // 
            numStorageMin.Location = new Point(9, 339);
            numStorageMin.Name = "numStorageMin";
            numStorageMin.Size = new Size(218, 25);
            numStorageMin.TabIndex = 11;
            // 
            // labelStorageMin
            // 
            labelStorageMin.AutoSize = true;
            labelStorageMin.Location = new Point(15, 321);
            labelStorageMin.Name = "labelStorageMin";
            labelStorageMin.Size = new Size(92, 17);
            labelStorageMin.TabIndex = 10;
            labelStorageMin.Text = "Память от, гб:";
            // 
            // numRamMin
            // 
            numRamMin.Location = new Point(9, 291);
            numRamMin.Name = "numRamMin";
            numRamMin.Size = new Size(218, 25);
            numRamMin.TabIndex = 9;
            // 
            // labelRamMin
            // 
            labelRamMin.AutoSize = true;
            labelRamMin.Location = new Point(15, 273);
            labelRamMin.Name = "labelRamMin";
            labelRamMin.Size = new Size(72, 17);
            labelRamMin.TabIndex = 8;
            labelRamMin.Text = "ОЗУ от, гб:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(9, 245);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(134, 21);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "Только в наличии";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // cmbOs
            // 
            cmbOs.FormattingEnabled = true;
            cmbOs.Location = new Point(9, 215);
            cmbOs.Name = "cmbOs";
            cmbOs.Size = new Size(218, 25);
            cmbOs.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 197);
            label4.Name = "label4";
            label4.Size = new Size(26, 17);
            label4.TabIndex = 6;
            label4.Text = "ОС";
            // 
            // numPriceMax
            // 
            numPriceMax.Location = new Point(121, 168);
            numPriceMax.Name = "numPriceMax";
            numPriceMax.Size = new Size(106, 25);
            numPriceMax.TabIndex = 5;
            // 
            // numPriceMin
            // 
            numPriceMin.Location = new Point(9, 168);
            numPriceMin.Name = "numPriceMin";
            numPriceMin.Size = new Size(106, 25);
            numPriceMin.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 147);
            label3.Name = "label3";
            label3.Size = new Size(100, 17);
            label3.TabIndex = 2;
            label3.Text = "Цена: От... До...";
            // 
            // lstProducer
            // 
            lstProducer.BackColor = Color.FromArgb(250, 250, 250);
            lstProducer.BorderStyle = BorderStyle.FixedSingle;
            lstProducer.CheckOnClick = true;
            lstProducer.Location = new Point(9, 47);
            lstProducer.Name = "lstProducer";
            lstProducer.Size = new Size(218, 94);
            lstProducer.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 29);
            label2.Name = "label2";
            label2.Size = new Size(101, 17);
            label2.TabIndex = 2;
            label2.Text = "Производитель";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.Location = new Point(254, 62);
            label5.Name = "label5";
            label5.Size = new Size(80, 17);
            label5.TabIndex = 2;
            label5.Text = "Сортировка";
            // 
            // cbSort
            // 
            cbSort.BackColor = Color.FromArgb(250, 250, 250);
            cbSort.FlatStyle = FlatStyle.Flat;
            cbSort.FormattingEnabled = true;
            cbSort.Location = new Point(254, 83);
            cbSort.Name = "cbSort";
            cbSort.Size = new Size(248, 23);
            cbSort.TabIndex = 3;
            // 
            // phonesBindingSource
            // 
            phonesBindingSource.DataSource = typeof(Models.Phone);
            // 
            // dgvPhones
            // 
            dgvPhones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPhones.AutoGenerateColumns = false;
            dgvPhones.BackgroundColor = Color.White;
            dgvPhones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPhones.Columns.AddRange(new DataGridViewColumn[] { colName, colProducer, colPrice, colRam, colStorage, colScreen });
            dgvPhones.DataSource = phonesBindingSource;
            dgvPhones.Font = new Font("Segoe UI", 10F);
            dgvPhones.Location = new Point(254, 112);
            dgvPhones.MultiSelect = false;
            dgvPhones.Name = "dgvPhones";
            dgvPhones.ReadOnly = true;
            dgvPhones.RowHeadersVisible = false;
            dgvPhones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhones.Size = new Size(509, 336);
            dgvPhones.TabIndex = 4;
            // 
            // colName
            // 
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Название";
            colName.MinimumWidth = 10;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 200;
            // 
            // colProducer
            // 
            colProducer.DataPropertyName = "Producer";
            colProducer.HeaderText = "Производитель";
            colProducer.MinimumWidth = 10;
            colProducer.Name = "colProducer";
            colProducer.ReadOnly = true;
            colProducer.Width = 115;
            // 
            // colPrice
            // 
            colPrice.DataPropertyName = "Price";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            colPrice.DefaultCellStyle = dataGridViewCellStyle1;
            colPrice.HeaderText = "Цена, р.";
            colPrice.MinimumWidth = 10;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            colPrice.Width = 88;
            // 
            // colRam
            // 
            colRam.DataPropertyName = "RamGb";
            colRam.HeaderText = "ОЗУ, гб";
            colRam.MinimumWidth = 10;
            colRam.Name = "colRam";
            colRam.ReadOnly = true;
            colRam.Width = 68;
            // 
            // colStorage
            // 
            colStorage.DataPropertyName = "StorageGb";
            colStorage.HeaderText = "Память, гб";
            colStorage.MinimumWidth = 10;
            colStorage.Name = "colStorage";
            colStorage.ReadOnly = true;
            colStorage.Width = 82;
            // 
            // colScreen
            // 
            colScreen.DataPropertyName = "ScreenSize";
            colScreen.HeaderText = "Экран";
            colScreen.MinimumWidth = 10;
            colScreen.Name = "colScreen";
            colScreen.ReadOnly = true;
            colScreen.Width = 60;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(0, 120, 215);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 120, 215);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 120, 215);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(599, 454);
            button1.Name = "button1";
            button1.Size = new Size(164, 36);
            button1.TabIndex = 5;
            button1.Text = "Подробнее / Купить";
            button1.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.BackColor = Color.FromArgb(250, 250, 250);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Location = new Point(599, 83);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = " Поиск...";
            txtSearch.Size = new Size(164, 23);
            txtSearch.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(786, 497);
            Controls.Add(txtSearch);
            Controls.Add(button1);
            Controls.Add(dgvPhones);
            Controls.Add(cbSort);
            Controls.Add(label5);
            Controls.Add(filters);
            Controls.Add(label1);
            MinimumSize = new Size(786, 497);
            Name = "Form1";
            Text = "Каталог мобильных телефонов";
            Load += Form1_Load;
            filters.ResumeLayout(false);
            filters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numStorageMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRamMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPriceMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPriceMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)phonesBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private GroupBox filters;
        private Label label3;
        private CheckedListBox lstProducer;
        private Label label2;
        private Label labelRamMin;
        private NumericUpDown numRamMin;
        private Label labelStorageMin;
        private NumericUpDown numStorageMin;
        private NumericUpDown numPriceMax;
        private NumericUpDown numPriceMin;
        private ComboBox cmbOs;
        private Label label4;
        private CheckBox checkBox1;
        private Label label5;
        private ComboBox cbSort;
        private BindingSource phonesBindingSource;
        private DataGridView dgvPhones;
        private Button resetFilters;
        private Button button1;
        private TextBox txtSearch;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colProducer;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colRam;
        private DataGridViewTextBoxColumn colStorage;
        private DataGridViewTextBoxColumn colScreen;
    }
}
