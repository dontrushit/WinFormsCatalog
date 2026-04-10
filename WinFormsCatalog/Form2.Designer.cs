namespace WinFormsCatalog
{
    partial class Form2
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            label2 = new Label();
            listView1 = new ListView();
            parametrColumn = new ColumnHeader();
            valueColumn = new ColumnHeader();
            listView2 = new ListView();
            columnShop = new ColumnHeader();
            columnPrice = new ColumnHeader();
            button2 = new Button();
            label3 = new Label();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.FromArgb(50, 50, 50);
            label1.Location = new Point(25, 9);
            label1.Name = "label1";
            label1.Size = new Size(118, 32);
            label1.TabIndex = 0;
            label1.Text = "Название";
            pictureBox1.Location = new Point(42, 61);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(195, 282);
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            button1.BackColor = Color.FromArgb(0, 120, 215);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 120, 215);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 120, 215);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.ForeColor = Color.White;
            button1.Location = new Point(76, 360);
            button1.Name = "button1";
            button1.Size = new Size(129, 40);
            button1.TabIndex = 2;
            button1.Text = "Купить";
            button1.UseVisualStyleBackColor = false;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(285, 36);
            label2.Name = "label2";
            label2.Size = new Size(142, 21);
            label2.TabIndex = 3;
            label2.Text = "Характеристики";
            listView1.BackColor = Color.White;
            listView1.BorderStyle = BorderStyle.FixedSingle;
            listView1.Columns.AddRange(new ColumnHeader[] { parametrColumn, valueColumn });
            listView1.Location = new Point(285, 60);
            listView1.Name = "listView1";
            listView1.Size = new Size(243, 327);
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            parametrColumn.Text = "Параметр";
            parametrColumn.Width = 120;
            valueColumn.Text = "Значение";
            valueColumn.Width = 120;
            listView2.BackColor = Color.White;
            listView2.BorderStyle = BorderStyle.FixedSingle;
            listView2.Columns.AddRange(new ColumnHeader[] { columnShop, columnPrice });
            listView2.FullRowSelect = true;
            listView2.GridLines = true;
            listView2.Location = new Point(566, 75);
            listView2.Name = "listView2";
            listView2.Size = new Size(204, 182);
            listView2.TabIndex = 5;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            columnShop.Text = "Магазин";
            columnShop.Width = 100;
            columnPrice.Text = "Цена";
            columnPrice.Width = 100;
            button2.BackColor = Color.FromArgb(0, 120, 215);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 120, 215);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 120, 215);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button2.ForeColor = Color.White;
            button2.Location = new Point(566, 263);
            button2.Name = "button2";
            button2.Size = new Size(204, 43);
            button2.TabIndex = 6;
            button2.Text = "Купить за";
            button2.TextAlign = ContentAlignment.MiddleCenter;
            button2.UseVisualStyleBackColor = false;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(555, 36);
            label3.Name = "label3";
            label3.Size = new Size(236, 25);
            label3.TabIndex = 7;
            label3.Text = "Цены в разных магазинах";
            button3.BackColor = Color.FromArgb(245, 245, 245);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(245, 245, 245);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 245, 245);
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.FromArgb(0, 120, 215);
            button3.Location = new Point(12, 421);
            button3.Name = "button3";
            button3.Size = new Size(131, 24);
            button3.TabIndex = 8;
            button3.Text = "← Назад к каталогу";
            button3.UseVisualStyleBackColor = false;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Карточка товара";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Button button1;
        private Label label2;
        private ListView listView1;
        private ColumnHeader parametrColumn;
        private ColumnHeader valueColumn;
        private ListView listView2;
        private ColumnHeader columnShop;
        private ColumnHeader columnPrice;
        private Button button2;
        private Label label3;
        private Button button3;
    }
}