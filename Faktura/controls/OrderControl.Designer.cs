using System;

namespace Faktura
{
    partial class OrderControl
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
            this.btnUslDodajDoFV = new System.Windows.Forms.Button();
            this.btnUslDel = new System.Windows.Forms.Button();
            this.btnUslRefresh = new System.Windows.Forms.Button();
            this.textBoxUslNazwa = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.btnUslugaDodaj = new System.Windows.Forms.Button();
            this.dataGridViewUslugi = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUslugi)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUslDodajDoFV
            // 
            this.btnUslDodajDoFV.Location = new System.Drawing.Point(784, 492);
            this.btnUslDodajDoFV.Name = "btnUslDodajDoFV";
            this.btnUslDodajDoFV.Size = new System.Drawing.Size(97, 23);
            this.btnUslDodajDoFV.TabIndex = 17;
            this.btnUslDodajDoFV.Text = "Dodaj do faktury";
            this.btnUslDodajDoFV.UseVisualStyleBackColor = true;
            this.btnUslDodajDoFV.Click += new System.EventHandler(this.btnUslDodajDoFV_Click);
            // 
            // btnUslDel
            // 
            this.btnUslDel.Location = new System.Drawing.Point(499, 492);
            this.btnUslDel.Name = "btnUslDel";
            this.btnUslDel.Size = new System.Drawing.Size(97, 23);
            this.btnUslDel.TabIndex = 16;
            this.btnUslDel.Text = "Usuń";
            this.btnUslDel.UseVisualStyleBackColor = true;
            this.btnUslDel.Click += new System.EventHandler(this.btnUslDel_Click);
            // 
            // btnUslRefresh
            // 
            this.btnUslRefresh.Location = new System.Drawing.Point(643, 492);
            this.btnUslRefresh.Name = "btnUslRefresh";
            this.btnUslRefresh.Size = new System.Drawing.Size(94, 23);
            this.btnUslRefresh.TabIndex = 15;
            this.btnUslRefresh.Text = "Odśwież tabelę";
            this.btnUslRefresh.UseVisualStyleBackColor = true;
            // 
            // textBoxUslNazwa
            // 
            this.textBoxUslNazwa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUslNazwa.Location = new System.Drawing.Point(91, 494);
            this.textBoxUslNazwa.MinimumSize = new System.Drawing.Size(274, 40);
            this.textBoxUslNazwa.Multiline = true;
            this.textBoxUslNazwa.Name = "textBoxUslNazwa";
            this.textBoxUslNazwa.Size = new System.Drawing.Size(274, 40);
            this.textBoxUslNazwa.TabIndex = 14;
            this.textBoxUslNazwa.TextChanged += new System.EventHandler(this.textBoxUslNazwa_TextChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(3, 497);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(73, 13);
            this.label28.TabIndex = 13;
            this.label28.Text = "nazwa usługi:";
            // 
            // btnUslugaDodaj
            // 
            this.btnUslugaDodaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUslugaDodaj.AutoSize = true;
            this.btnUslugaDodaj.Location = new System.Drawing.Point(396, 492);
            this.btnUslugaDodaj.Name = "btnUslugaDodaj";
            this.btnUslugaDodaj.Size = new System.Drawing.Size(97, 23);
            this.btnUslugaDodaj.TabIndex = 12;
            this.btnUslugaDodaj.Text = "Dodaj";
            this.btnUslugaDodaj.UseVisualStyleBackColor = true;
            this.btnUslugaDodaj.Click += new System.EventHandler(this.btnUslugaDodaj_Click);
            // 
            // dataGridViewUslugi
            // 
            this.dataGridViewUslugi.AllowUserToAddRows = false;
            this.dataGridViewUslugi.AllowUserToDeleteRows = false;
            this.dataGridViewUslugi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewUslugi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUslugi.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewUslugi.Name = "dataGridViewUslugi";
            this.dataGridViewUslugi.ReadOnly = true;
            this.dataGridViewUslugi.RowHeadersVisible = false;
            this.dataGridViewUslugi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUslugi.Size = new System.Drawing.Size(878, 483);
            this.dataGridViewUslugi.TabIndex = 11;
            this.dataGridViewUslugi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUslugi_CellContentClick);
            this.dataGridViewUslugi.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewUslugi_CellContentMouseMove);
            // 
            // OrderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.btnUslugaDodaj);
            this.Controls.Add(this.btnUslDodajDoFV);
            this.Controls.Add(this.btnUslDel);
            this.Controls.Add(this.btnUslRefresh);
            this.Controls.Add(this.textBoxUslNazwa);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.dataGridViewUslugi);
            this.Name = "OrderControl";
            this.Size = new System.Drawing.Size(884, 537);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUslugi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUslDodajDoFV;
        private System.Windows.Forms.Button btnUslDel;
        private System.Windows.Forms.Button btnUslRefresh;
        private System.Windows.Forms.TextBox textBoxUslNazwa;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btnUslugaDodaj;
        private System.Windows.Forms.DataGridView dataGridViewUslugi;
    }
}
