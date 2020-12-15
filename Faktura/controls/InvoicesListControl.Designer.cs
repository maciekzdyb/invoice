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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxCountVat = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxCountNetto = new System.Windows.Forms.TextBox();
            this.textBoxCountInv = new System.Windows.Forms.TextBox();
            this.dataGridViewFaktury = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFaktury)).BeginInit();
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
            this.groupBox1.Location = new System.Drawing.Point(639, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 103);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podsumowanie bazy";
            // 
            // textBoxCountVat
            // 
            this.textBoxCountVat.Location = new System.Drawing.Point(144, 68);
            this.textBoxCountVat.Name = "textBoxCountVat";
            this.textBoxCountVat.ReadOnly = true;
            this.textBoxCountVat.Size = new System.Drawing.Size(94, 20);
            this.textBoxCountVat.TabIndex = 6;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(67, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "il. wyst. faktur";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(37, 45);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 13);
            this.label18.TabIndex = 3;
            this.label18.Text = "łączna kwota netto";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(75, 71);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "łączny VAT";
            // 
            // textBoxCountNetto
            // 
            this.textBoxCountNetto.Location = new System.Drawing.Point(144, 42);
            this.textBoxCountNetto.Name = "textBoxCountNetto";
            this.textBoxCountNetto.ReadOnly = true;
            this.textBoxCountNetto.Size = new System.Drawing.Size(94, 20);
            this.textBoxCountNetto.TabIndex = 5;
            // 
            // textBoxCountInv
            // 
            this.textBoxCountInv.Location = new System.Drawing.Point(144, 15);
            this.textBoxCountInv.Name = "textBoxCountInv";
            this.textBoxCountInv.ReadOnly = true;
            this.textBoxCountInv.Size = new System.Drawing.Size(94, 20);
            this.textBoxCountInv.TabIndex = 2;
            // 
            // dataGridViewFaktury
            // 
            this.dataGridViewFaktury.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFaktury.Location = new System.Drawing.Point(2, 7);
            this.dataGridViewFaktury.Name = "dataGridViewFaktury";
            this.dataGridViewFaktury.Size = new System.Drawing.Size(628, 522);
            this.dataGridViewFaktury.TabIndex = 8;
            // 
            // InvoicesListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewFaktury);
            this.Name = "InvoicesListControl";
            this.Size = new System.Drawing.Size(884, 537);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFaktury)).EndInit();
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
    }
}
