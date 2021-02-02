namespace Faktura
{
    partial class InvoicesListControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoicesListControl));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxCountVat = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxCountNetto = new System.Windows.Forms.TextBox();
            this.textBoxCountInv = new System.Windows.Forms.TextBox();
            this.dataGridViewFaktury = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClone = new System.Windows.Forms.Button();
            this.btnPrintSelected = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInvNo = new System.Windows.Forms.TextBox();
            this.printPreviewDialog2 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFaktury)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxCountVat);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.textBoxCountNetto);
            this.groupBox1.Controls.Add(this.textBoxCountInv);
            this.groupBox1.Location = new System.Drawing.Point(956, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(366, 158);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podsumowanie bazy";
            // 
            // textBoxCountVat
            // 
            this.textBoxCountVat.Location = new System.Drawing.Point(216, 105);
            this.textBoxCountVat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCountVat.Name = "textBoxCountVat";
            this.textBoxCountVat.ReadOnly = true;
            this.textBoxCountVat.Size = new System.Drawing.Size(139, 26);
            this.textBoxCountVat.TabIndex = 6;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(100, 28);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(103, 20);
            this.label17.TabIndex = 1;
            this.label17.Text = "il. wyst. faktur";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(56, 69);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(143, 20);
            this.label18.TabIndex = 3;
            this.label18.Text = "łączna kwota netto";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(112, 109);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(89, 20);
            this.label19.TabIndex = 4;
            this.label19.Text = "łączny VAT";
            // 
            // textBoxCountNetto
            // 
            this.textBoxCountNetto.Location = new System.Drawing.Point(216, 65);
            this.textBoxCountNetto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCountNetto.Name = "textBoxCountNetto";
            this.textBoxCountNetto.ReadOnly = true;
            this.textBoxCountNetto.Size = new System.Drawing.Size(139, 26);
            this.textBoxCountNetto.TabIndex = 5;
            // 
            // textBoxCountInv
            // 
            this.textBoxCountInv.Location = new System.Drawing.Point(216, 23);
            this.textBoxCountInv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCountInv.Name = "textBoxCountInv";
            this.textBoxCountInv.ReadOnly = true;
            this.textBoxCountInv.Size = new System.Drawing.Size(139, 26);
            this.textBoxCountInv.TabIndex = 2;
            // 
            // dataGridViewFaktury
            // 
            this.dataGridViewFaktury.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFaktury.Location = new System.Drawing.Point(3, 11);
            this.dataGridViewFaktury.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewFaktury.Name = "dataGridViewFaktury";
            this.dataGridViewFaktury.Size = new System.Drawing.Size(942, 803);
            this.dataGridViewFaktury.TabIndex = 8;
            this.dataGridViewFaktury.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFaktury_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClone);
            this.groupBox2.Controls.Add(this.btnPrintSelected);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxInvNo);
            this.groupBox2.Location = new System.Drawing.Point(956, 179);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(366, 158);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Zaznaczona";
            // 
            // btnClone
            // 
            this.btnClone.Location = new System.Drawing.Point(173, 87);
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(150, 38);
            this.btnClone.TabIndex = 4;
            this.btnClone.Text = "wystaw ponownie";
            this.btnClone.UseVisualStyleBackColor = true;
            this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
            // 
            // btnPrintSelected
            // 
            this.btnPrintSelected.Location = new System.Drawing.Point(7, 87);
            this.btnPrintSelected.Name = "btnPrintSelected";
            this.btnPrintSelected.Size = new System.Drawing.Size(150, 38);
            this.btnPrintSelected.TabIndex = 3;
            this.btnPrintSelected.Text = "podgląd wydruku";
            this.btnPrintSelected.UseVisualStyleBackColor = true;
            this.btnPrintSelected.Click += new System.EventHandler(this.btnPrintSelected_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "nr faktury";
            // 
            // textBoxInvNo
            // 
            this.textBoxInvNo.Location = new System.Drawing.Point(216, 23);
            this.textBoxInvNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxInvNo.Name = "textBoxInvNo";
            this.textBoxInvNo.ReadOnly = true;
            this.textBoxInvNo.Size = new System.Drawing.Size(139, 26);
            this.textBoxInvNo.TabIndex = 2;
            // 
            // printPreviewDialog2
            // 
            this.printPreviewDialog2.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog2.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog2.ClientSize = new System.Drawing.Size(800, 600);
            this.printPreviewDialog2.Enabled = true;
            this.printPreviewDialog2.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog2.Icon")));
            this.printPreviewDialog2.Name = "printPreviewDialog2";
            this.printPreviewDialog2.Visible = false;
            // 
            // InvoicesListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewFaktury);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "InvoicesListControl";
            this.Size = new System.Drawing.Size(1326, 826);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFaktury)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxCountVat;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBoxCountNetto;
        private System.Windows.Forms.TextBox textBoxCountInv;
        private System.Windows.Forms.DataGridView dataGridViewFaktury;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClone;
        private System.Windows.Forms.Button btnPrintSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxInvNo;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog2;
        private System.Drawing.Printing.PrintDocument printDocument2;
    }
}
