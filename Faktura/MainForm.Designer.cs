namespace Faktura
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fakturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nowaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wystawioneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bazaDanychToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nabywcyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sprzedawcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usługaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.invoicesListControl1 = new Faktura.InvoicesListControl();
            this.orderControl1 = new Faktura.OrderControl();
            this.buyersControl1 = new Faktura.BuyersControl();
            this.sellerControl1 = new Faktura.SellerControl();
            this.invoiceControl1 = new Faktura.InvoiceControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fakturaToolStripMenuItem,
            this.bazaDanychToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fakturaToolStripMenuItem
            // 
            this.fakturaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nowaToolStripMenuItem,
            this.wystawioneToolStripMenuItem});
            this.fakturaToolStripMenuItem.Name = "fakturaToolStripMenuItem";
            this.fakturaToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.fakturaToolStripMenuItem.Text = "Faktura";
            // 
            // nowaToolStripMenuItem
            // 
            this.nowaToolStripMenuItem.Name = "nowaToolStripMenuItem";
            this.nowaToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.nowaToolStripMenuItem.Text = "Nowa";
            this.nowaToolStripMenuItem.Click += new System.EventHandler(this.nowaToolStripMenuItem_Click);
            // 
            // wystawioneToolStripMenuItem
            // 
            this.wystawioneToolStripMenuItem.Name = "wystawioneToolStripMenuItem";
            this.wystawioneToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.wystawioneToolStripMenuItem.Text = "Wystawione";
            this.wystawioneToolStripMenuItem.Click += new System.EventHandler(this.wystawioneToolStripMenuItem_Click);
            // 
            // bazaDanychToolStripMenuItem
            // 
            this.bazaDanychToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nabywcyToolStripMenuItem,
            this.sprzedawcaToolStripMenuItem,
            this.usługaToolStripMenuItem});
            this.bazaDanychToolStripMenuItem.Name = "bazaDanychToolStripMenuItem";
            this.bazaDanychToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.bazaDanychToolStripMenuItem.Text = "Baza Danych";
            // 
            // nabywcyToolStripMenuItem
            // 
            this.nabywcyToolStripMenuItem.Name = "nabywcyToolStripMenuItem";
            this.nabywcyToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.nabywcyToolStripMenuItem.Text = "Nabywcy";
            this.nabywcyToolStripMenuItem.Click += new System.EventHandler(this.nabywcyToolStripMenuItem_Click);
            // 
            // sprzedawcaToolStripMenuItem
            // 
            this.sprzedawcaToolStripMenuItem.Name = "sprzedawcaToolStripMenuItem";
            this.sprzedawcaToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.sprzedawcaToolStripMenuItem.Text = "Sprzedawca";
            this.sprzedawcaToolStripMenuItem.Click += new System.EventHandler(this.sprzedawcaToolStripMenuItem_Click);
            // 
            // usługaToolStripMenuItem
            // 
            this.usługaToolStripMenuItem.Name = "usługaToolStripMenuItem";
            this.usługaToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.usługaToolStripMenuItem.Text = "Usługa";
            this.usługaToolStripMenuItem.Click += new System.EventHandler(this.usługaToolStripMenuItem_Click);
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // invoicesListControl1
            // 
            this.invoicesListControl1.Location = new System.Drawing.Point(0, 27);
            this.invoicesListControl1.Name = "invoicesListControl1";
            this.invoicesListControl1.Size = new System.Drawing.Size(884, 537);
            this.invoicesListControl1.TabIndex = 5;
            // 
            // orderControl1
            // 
            this.orderControl1.Location = new System.Drawing.Point(0, 27);
            this.orderControl1.Name = "orderControl1";
            this.orderControl1.Size = new System.Drawing.Size(884, 537);
            this.orderControl1.TabIndex = 4;
            // 
            // buyersControl1
            // 
            this.buyersControl1.Location = new System.Drawing.Point(0, 27);
            this.buyersControl1.Name = "buyersControl1";
            this.buyersControl1.Size = new System.Drawing.Size(884, 537);
            this.buyersControl1.TabIndex = 3;
            // 
            // sellerControl1
            // 
            this.sellerControl1.Location = new System.Drawing.Point(0, 27);
            this.sellerControl1.Name = "sellerControl1";
            this.sellerControl1.Size = new System.Drawing.Size(884, 537);
            this.sellerControl1.TabIndex = 2;
            // 
            // invoiceControl1
            // 
            this.invoiceControl1.Location = new System.Drawing.Point(0, 27);
            this.invoiceControl1.Name = "invoiceControl1";
            this.invoiceControl1.Size = new System.Drawing.Size(884, 537);
            this.invoiceControl1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.invoicesListControl1);
            this.Controls.Add(this.orderControl1);
            this.Controls.Add(this.buyersControl1);
            this.Controls.Add(this.sellerControl1);
            this.Controls.Add(this.invoiceControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Faktura VAT";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fakturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nowaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wystawioneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bazaDanychToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private InvoiceControl invoiceControl1;
        private SellerControl sellerControl1;
        private System.Windows.Forms.ToolStripMenuItem nabywcyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sprzedawcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usługaToolStripMenuItem;
        private BuyersControl buyersControl1;
        private OrderControl orderControl1;
        private InvoicesListControl invoicesListControl1;
    }
}

