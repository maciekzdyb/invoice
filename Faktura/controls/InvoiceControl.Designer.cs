namespace Faktura
{
    partial class InvoiceControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceControl));
            this.btnSafeInvoice = new System.Windows.Forms.Button();
            this.nrFVtextBox = new System.Windows.Forms.TextBox();
            this.sprzedazDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.platnoscDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.wystawdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.platnoscComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rachunekSprzedBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nipNabtextBox = new System.Windows.Forms.TextBox();
            this.adresNabtextBox = new System.Windows.Forms.TextBox();
            this.miejscNabtextBox = new System.Windows.Forms.TextBox();
            this.kodNabtextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.nazwaNabtextBox = new System.Windows.Forms.TextBox();
            this.cenaNettoTextBox = new System.Windows.Forms.TextBox();
            this.nazwaSprzedtextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.kodSprzedtextBox = new System.Windows.Forms.TextBox();
            this.printBtn = new System.Windows.Forms.Button();
            this.uslugaTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.miejscSprzedtextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.adresSprzedtextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nipSprzedtextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.textBoxBrutto = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxVAT = new System.Windows.Forms.TextBox();
            this.platnoscNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.platnoscNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSafeInvoice
            // 
            this.btnSafeInvoice.Location = new System.Drawing.Point(739, 477);
            this.btnSafeInvoice.Name = "btnSafeInvoice";
            this.btnSafeInvoice.Size = new System.Drawing.Size(75, 23);
            this.btnSafeInvoice.TabIndex = 76;
            this.btnSafeInvoice.Text = "Zapisz";
            this.btnSafeInvoice.UseVisualStyleBackColor = true;
            this.btnSafeInvoice.Click += new System.EventHandler(this.btnSafeInvoice_Click);
            // 
            // nrFVtextBox
            // 
            this.nrFVtextBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nrFVtextBox.Location = new System.Drawing.Point(194, 43);
            this.nrFVtextBox.Name = "nrFVtextBox";
            this.nrFVtextBox.Size = new System.Drawing.Size(100, 20);
            this.nrFVtextBox.TabIndex = 52;
            this.nrFVtextBox.TextChanged += new System.EventHandler(this.NrFVtextBox_TextChanged);
            // 
            // sprzedazDateTimePicker
            // 
            this.sprzedazDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.sprzedazDateTimePicker.Location = new System.Drawing.Point(723, 63);
            this.sprzedazDateTimePicker.Name = "sprzedazDateTimePicker";
            this.sprzedazDateTimePicker.Size = new System.Drawing.Size(106, 20);
            this.sprzedazDateTimePicker.TabIndex = 54;
            // 
            // platnoscDateTimePicker
            // 
            this.platnoscDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.platnoscDateTimePicker.Location = new System.Drawing.Point(666, 349);
            this.platnoscDateTimePicker.Name = "platnoscDateTimePicker";
            this.platnoscDateTimePicker.Size = new System.Drawing.Size(106, 20);
            this.platnoscDateTimePicker.TabIndex = 70;
            this.platnoscDateTimePicker.ValueChanged += new System.EventHandler(this.platnoscDateTimePicker_ValueChanged);
            // 
            // wystawdateTimePicker
            // 
            this.wystawdateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.wystawdateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.wystawdateTimePicker.Location = new System.Drawing.Point(723, 37);
            this.wystawdateTimePicker.Name = "wystawdateTimePicker";
            this.wystawdateTimePicker.Size = new System.Drawing.Size(106, 20);
            this.wystawdateTimePicker.TabIndex = 53;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(574, 355);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 13);
            this.label15.TabIndex = 73;
            this.label15.Text = "Termin płatności";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(629, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "data wystawienia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(639, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "data sprzedaży";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(56, 299);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 13);
            this.label16.TabIndex = 75;
            this.label16.Text = "Nr rachunku";
            // 
            // platnoscComboBox
            // 
            this.platnoscComboBox.FormattingEnabled = true;
            this.platnoscComboBox.Items.AddRange(new object[] {
            "przelew",
            "gotówka"});
            this.platnoscComboBox.Location = new System.Drawing.Point(666, 307);
            this.platnoscComboBox.Name = "platnoscComboBox";
            this.platnoscComboBox.Size = new System.Drawing.Size(121, 21);
            this.platnoscComboBox.TabIndex = 71;
            this.platnoscComboBox.Text = "przelew";
            this.platnoscComboBox.TextChanged += new System.EventHandler(this.platnoscComboBox_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(577, 310);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 13);
            this.label14.TabIndex = 72;
            this.label14.Text = "Forma płatności";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Nr fakrury";
            // 
            // rachunekSprzedBox
            // 
            this.rachunekSprzedBox.Location = new System.Drawing.Point(132, 296);
            this.rachunekSprzedBox.Name = "rachunekSprzedBox";
            this.rachunekSprzedBox.ReadOnly = true;
            this.rachunekSprzedBox.Size = new System.Drawing.Size(250, 20);
            this.rachunekSprzedBox.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Sprzedawca";
            // 
            // nipNabtextBox
            // 
            this.nipNabtextBox.Location = new System.Drawing.Point(537, 246);
            this.nipNabtextBox.Name = "nipNabtextBox";
            this.nipNabtextBox.ReadOnly = true;
            this.nipNabtextBox.Size = new System.Drawing.Size(91, 20);
            this.nipNabtextBox.TabIndex = 65;
            // 
            // adresNabtextBox
            // 
            this.adresNabtextBox.Location = new System.Drawing.Point(537, 221);
            this.adresNabtextBox.Name = "adresNabtextBox";
            this.adresNabtextBox.ReadOnly = true;
            this.adresNabtextBox.Size = new System.Drawing.Size(250, 20);
            this.adresNabtextBox.TabIndex = 63;
            // 
            // miejscNabtextBox
            // 
            this.miejscNabtextBox.Location = new System.Drawing.Point(537, 196);
            this.miejscNabtextBox.Name = "miejscNabtextBox";
            this.miejscNabtextBox.ReadOnly = true;
            this.miejscNabtextBox.Size = new System.Drawing.Size(80, 20);
            this.miejscNabtextBox.TabIndex = 60;
            // 
            // kodNabtextBox
            // 
            this.kodNabtextBox.Location = new System.Drawing.Point(537, 170);
            this.kodNabtextBox.Name = "kodNabtextBox";
            this.kodNabtextBox.ReadOnly = true;
            this.kodNabtextBox.Size = new System.Drawing.Size(52, 20);
            this.kodNabtextBox.TabIndex = 58;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(67, 398);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 68;
            this.label13.Text = "Cena netto";
            // 
            // nazwaNabtextBox
            // 
            this.nazwaNabtextBox.Location = new System.Drawing.Point(537, 119);
            this.nazwaNabtextBox.Name = "nazwaNabtextBox";
            this.nazwaNabtextBox.ReadOnly = true;
            this.nazwaNabtextBox.Size = new System.Drawing.Size(280, 20);
            this.nazwaNabtextBox.TabIndex = 56;
            this.nazwaNabtextBox.Click += new System.EventHandler(this.nazwaNabtextBox_Click);
            // 
            // cenaNettoTextBox
            // 
            this.cenaNettoTextBox.Location = new System.Drawing.Point(132, 395);
            this.cenaNettoTextBox.Name = "cenaNettoTextBox";
            this.cenaNettoTextBox.Size = new System.Drawing.Size(96, 20);
            this.cenaNettoTextBox.TabIndex = 69;
            this.cenaNettoTextBox.TextChanged += new System.EventHandler(this.amount_TextChanged);
            // 
            // nazwaSprzedtextBox
            // 
            this.nazwaSprzedtextBox.Location = new System.Drawing.Point(139, 119);
            this.nazwaSprzedtextBox.Name = "nazwaSprzedtextBox";
            this.nazwaSprzedtextBox.ReadOnly = true;
            this.nazwaSprzedtextBox.Size = new System.Drawing.Size(280, 20);
            this.nazwaSprzedtextBox.TabIndex = 55;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "Nazwa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(537, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Nabywca";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "Adres";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(56, 355);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 67;
            this.label12.Text = "Nazwa usługi";
            // 
            // kodSprzedtextBox
            // 
            this.kodSprzedtextBox.Location = new System.Drawing.Point(156, 170);
            this.kodSprzedtextBox.Name = "kodSprzedtextBox";
            this.kodSprzedtextBox.ReadOnly = true;
            this.kodSprzedtextBox.Size = new System.Drawing.Size(50, 20);
            this.kodSprzedtextBox.TabIndex = 57;
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(632, 477);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(101, 23);
            this.printBtn.TabIndex = 41;
            this.printBtn.Text = "podgląd wydruku";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // uslugaTextBox
            // 
            this.uslugaTextBox.Location = new System.Drawing.Point(132, 352);
            this.uslugaTextBox.Multiline = true;
            this.uslugaTextBox.Name = "uslugaTextBox";
            this.uslugaTextBox.ReadOnly = true;
            this.uslugaTextBox.Size = new System.Drawing.Size(250, 40);
            this.uslugaTextBox.TabIndex = 66;
            this.uslugaTextBox.Click += new System.EventHandler(this.uslugaTextBox_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(67, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 49;
            this.label8.Text = "Kod Pocztowy";
            // 
            // miejscSprzedtextBox
            // 
            this.miejscSprzedtextBox.Location = new System.Drawing.Point(155, 196);
            this.miejscSprzedtextBox.Name = "miejscSprzedtextBox";
            this.miejscSprzedtextBox.ReadOnly = true;
            this.miejscSprzedtextBox.Size = new System.Drawing.Size(80, 20);
            this.miejscSprzedtextBox.TabIndex = 59;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(67, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "Miejscowość";
            // 
            // adresSprzedtextBox
            // 
            this.adresSprzedtextBox.Location = new System.Drawing.Point(155, 221);
            this.adresSprzedtextBox.Name = "adresSprzedtextBox";
            this.adresSprzedtextBox.ReadOnly = true;
            this.adresSprzedtextBox.Size = new System.Drawing.Size(250, 20);
            this.adresSprzedtextBox.TabIndex = 62;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(67, 224);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 51;
            this.label10.Text = "Adres";
            // 
            // nipSprzedtextBox
            // 
            this.nipSprzedtextBox.Location = new System.Drawing.Point(155, 247);
            this.nipSprzedtextBox.Name = "nipSprzedtextBox";
            this.nipSprzedtextBox.ReadOnly = true;
            this.nipSprzedtextBox.Size = new System.Drawing.Size(96, 20);
            this.nipSprzedtextBox.TabIndex = 64;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(67, 253);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 61;
            this.label11.Text = "NIP";
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(800, 1000);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // textBoxBrutto
            // 
            this.textBoxBrutto.Location = new System.Drawing.Point(132, 418);
            this.textBoxBrutto.Name = "textBoxBrutto";
            this.textBoxBrutto.Size = new System.Drawing.Size(96, 20);
            this.textBoxBrutto.TabIndex = 77;
            this.textBoxBrutto.TextChanged += new System.EventHandler(this.amount_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(63, 422);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 78;
            this.label17.Text = "Cena brutto";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(93, 444);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(28, 13);
            this.label18.TabIndex = 79;
            this.label18.Text = "VAT";
            // 
            // textBoxVAT
            // 
            this.textBoxVAT.Location = new System.Drawing.Point(132, 442);
            this.textBoxVAT.Name = "textBoxVAT";
            this.textBoxVAT.ReadOnly = true;
            this.textBoxVAT.Size = new System.Drawing.Size(96, 20);
            this.textBoxVAT.TabIndex = 80;
            // 
            // platnoscNumericUpDown1
            // 
            this.platnoscNumericUpDown1.Location = new System.Drawing.Point(666, 375);
            this.platnoscNumericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.platnoscNumericUpDown1.Name = "platnoscNumericUpDown1";
            this.platnoscNumericUpDown1.Size = new System.Drawing.Size(43, 20);
            this.platnoscNumericUpDown1.TabIndex = 81;
            this.platnoscNumericUpDown1.ValueChanged += new System.EventHandler(this.platnoscNumericUpDown1_ValueChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(713, 376);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 13);
            this.label19.TabIndex = 82;
            this.label19.Text = "dni";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(399, 355);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(20, 13);
            this.label20.TabIndex = 83;
            this.label20.Text = "j.m";
            this.label20.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(392, 371);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(34, 20);
            this.textBox1.TabIndex = 84;
            this.textBox1.Visible = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(437, 355);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(23, 13);
            this.label21.TabIndex = 85;
            this.label21.Text = "szt.";
            this.label21.Visible = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(440, 371);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown1.TabIndex = 86;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(345, 440);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 87;
            this.comboBox1.Visible = false;
            // 
            // InvoiceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.platnoscNumericUpDown1);
            this.Controls.Add(this.textBoxVAT);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textBoxBrutto);
            this.Controls.Add(this.btnSafeInvoice);
            this.Controls.Add(this.nrFVtextBox);
            this.Controls.Add(this.sprzedazDateTimePicker);
            this.Controls.Add(this.platnoscDateTimePicker);
            this.Controls.Add(this.wystawdateTimePicker);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.platnoscComboBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rachunekSprzedBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nipNabtextBox);
            this.Controls.Add(this.adresNabtextBox);
            this.Controls.Add(this.miejscNabtextBox);
            this.Controls.Add(this.kodNabtextBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.nazwaNabtextBox);
            this.Controls.Add(this.cenaNettoTextBox);
            this.Controls.Add(this.nazwaSprzedtextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.kodSprzedtextBox);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.uslugaTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.miejscSprzedtextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.adresSprzedtextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nipSprzedtextBox);
            this.Controls.Add(this.label11);
            this.Name = "InvoiceControl";
            this.Size = new System.Drawing.Size(884, 537);
            ((System.ComponentModel.ISupportInitialize)(this.platnoscNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSafeInvoice;
        private System.Windows.Forms.TextBox nrFVtextBox;
        private System.Windows.Forms.DateTimePicker sprzedazDateTimePicker;
        private System.Windows.Forms.DateTimePicker platnoscDateTimePicker;
        private System.Windows.Forms.DateTimePicker wystawdateTimePicker;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox platnoscComboBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rachunekSprzedBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nipNabtextBox;
        private System.Windows.Forms.TextBox adresNabtextBox;
        private System.Windows.Forms.TextBox miejscNabtextBox;
        private System.Windows.Forms.TextBox kodNabtextBox;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox nazwaNabtextBox;
        private System.Windows.Forms.TextBox cenaNettoTextBox;
        private System.Windows.Forms.TextBox nazwaSprzedtextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox kodSprzedtextBox;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.TextBox uslugaTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox miejscSprzedtextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox adresSprzedtextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox nipSprzedtextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TextBox textBoxBrutto;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxVAT;
        private System.Windows.Forms.NumericUpDown platnoscNumericUpDown1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
