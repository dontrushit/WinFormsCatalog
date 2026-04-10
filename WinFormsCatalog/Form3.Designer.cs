namespace WinFormsCatalog
{
    partial class Form3
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
            groupBox1 = new GroupBox();
            tbAdressInfo = new TextBox();
            label5 = new Label();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            tbPhoneNumber = new TextBox();
            label3 = new Label();
            tbFIO = new TextBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            form3btnBuy = new Button();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            button3 = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            label1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.FromArgb(50, 50, 50);
            label1.Location = new Point(261, 19);
            label1.Name = "label1";
            label1.Size = new Size(280, 43);
            label1.TabIndex = 0;
            label1.Text = "Оформление заказа";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(tbAdressInfo);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(tbPhoneNumber);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(tbFIO);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(35, 92);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(328, 325);
            groupBox1.TabIndex = 1;
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox1.TabStop = false;
            groupBox1.Text = "Контактная информация";
            tbAdressInfo.BackColor = Color.FromArgb(250, 250, 250);
            tbAdressInfo.BorderStyle = BorderStyle.FixedSingle;
            tbAdressInfo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbAdressInfo.Location = new Point(28, 241);
            tbAdressInfo.Multiline = true;
            tbAdressInfo.Name = "tbAdressInfo";
            tbAdressInfo.PlaceholderText = "Город, улица, дом, квартира";
            tbAdressInfo.Size = new Size(274, 33);
            tbAdressInfo.TabIndex = 7;
            label5.AutoSize = true;
            label5.Location = new Point(28, 223);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 6;
            label5.Text = "Адрес";
            numericUpDown1.Location = new Point(106, 194);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(75, 23);
            numericUpDown1.TabIndex = 5;
            label4.AutoSize = true;
            label4.Location = new Point(28, 196);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 4;
            label4.Text = "Количество";
            tbPhoneNumber.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbPhoneNumber.Location = new Point(28, 141);
            tbPhoneNumber.Multiline = true;
            tbPhoneNumber.BackColor = Color.FromArgb(250, 250, 250);
            tbPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
            tbPhoneNumber.Name = "tbPhoneNumber";
            tbPhoneNumber.Size = new Size(274, 40);
            tbPhoneNumber.TabIndex = 3;
            tbPhoneNumber.Text = "+375( )";
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(28, 113);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 2;
            label3.Text = "Телефон";
            tbFIO.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbFIO.BackColor = Color.FromArgb(250, 250, 250);
            tbFIO.BorderStyle = BorderStyle.FixedSingle;
            tbFIO.Location = new Point(28, 60);
            tbFIO.Multiline = true;
            tbFIO.Name = "tbFIO";
            tbFIO.PlaceholderText = "Ваше полное имя";
            tbFIO.Size = new Size(274, 40);
            tbFIO.TabIndex = 1;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(28, 32);
            label2.Name = "label2";
            label2.Size = new Size(54, 25);
            label2.TabIndex = 0;
            label2.Text = "ФИО";
            groupBox2.Controls.Add(form3btnBuy);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(pictureBox1);
            groupBox2.Controls.Add(label6);
            groupBox2.BackColor = Color.White;
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox2.Location = new Point(395, 65);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(374, 352);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ваш заказ";
            form3btnBuy.BackColor = Color.FromArgb(0, 120, 215);
            form3btnBuy.FlatAppearance.BorderSize = 0;
            form3btnBuy.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 120, 215);
            form3btnBuy.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 120, 215);
            form3btnBuy.FlatStyle = FlatStyle.Flat;
            form3btnBuy.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            form3btnBuy.ForeColor = Color.White;
            form3btnBuy.Location = new Point(22, 277);
            form3btnBuy.Name = "form3btnBuy";
            form3btnBuy.Size = new Size(288, 57);
            form3btnBuy.TabIndex = 15;
            form3btnBuy.Text = "Купить";
            form3btnBuy.UseVisualStyleBackColor = false;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label10.Location = new Point(22, 236);
            label10.Name = "label10";
            label10.Size = new Size(91, 32);
            label10.TabIndex = 14;
            label10.Text = "Итого: ";
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label9.Location = new Point(142, 130);
            label9.Name = "label9";
            label9.Size = new Size(96, 21);
            label9.TabIndex = 13;
            label9.Text = "Количество:";
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label8.Location = new Point(142, 100);
            label8.Name = "label8";
            label8.Size = new Size(50, 21);
            label8.TabIndex = 12;
            label8.Text = "Цена:";
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.Location = new Point(142, 77);
            label7.Name = "label7";
            label7.Size = new Size(74, 21);
            label7.TabIndex = 11;
            label7.Text = "Магазин:";
            pictureBox1.Location = new Point(22, 80);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(114, 145);
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            label6.AutoEllipsis = true;
            label6.Location = new Point(22, 27);
            label6.Name = "label6";
            label6.Size = new Size(330, 50);
            label6.TabIndex = 9;
            label6.Text = "Название";
            button3.BackColor = Color.FromArgb(245, 245, 245);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(245, 245, 245);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 245, 245);
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.FromArgb(0, 120, 215);
            button3.Location = new Point(4, 423);
            button3.Name = "button3";
            button3.Size = new Size(131, 24);
            button3.TabIndex = 9;
            button3.Text = "← Назад к каталогу";
            button3.UseVisualStyleBackColor = false;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Оформление заказа";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private TextBox tbFIO;
        private Label label2;
        private TextBox tbPhoneNumber;
        private Label label3;
        private NumericUpDown numericUpDown1;
        private Label label4;
        private TextBox tbAdressInfo;
        private Label label5;
        private GroupBox groupBox2;
        private PictureBox pictureBox1;
        private Label label6;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label10;
        private Button form3btnBuy;
        private Button button3;
    }
}