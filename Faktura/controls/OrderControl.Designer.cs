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
            this.btnUslDodajDoFV.Location = new System.Drawing.Point(493, 176);
            this.btnUslDodajDoFV.Name = "btnUslDodajDoFV";
            this.btnUslDodajDoFV.Size = new System.Drawing.Size(97, 23);
            this.btnUslDodajDoFV.TabIndex = 17;
            this.btnUslDodajDoFV.Text = "Dodaj do faktury";
            this.btnUslDodajDoFV.UseVisualStyleBackColor = true;
            this.btnUslDodajDoFV.Click += new EventHandler(btnUslDodajDoFV_Click);
            // 
            // btnUslDel
            // 
            this.btnUslDel.Location = new System.Drawing.Point(641, 215);
            this.btnUslDel.Name = "btnUslDel";
            this.btnUslDel.Size = new System.Drawing.Size(97, 23);
            this.btnUslDel.TabIndex = 16;
            this.btnUslDel.Text = "Usuń";
            this.btnUslDel.UseVisualStyleBackColor = true;
            // 
            // btnUslRefresh
            // 
            this.btnUslRefresh.Location = new System.Drawing.Point(641, 253);
            this.btnUslRefresh.Name = "btnUslRefresh";
            this.btnUslRefresh.Size = new System.Drawing.Size(94, 23);
            this.btnUslRefresh.TabIndex = 15;
            this.btnUslRefresh.Text = "Odśwież tabelę";
            this.btnUslRefresh.UseVisualStyleBackColor = true;
            // 
            // textBoxUslNazwa
            // 
            this.textBoxUslNazwa.Location = new System.Drawing.Point(484, 24);
            this.textBoxUslNazwa.Name = "textBoxUslNazwa";
            this.textBoxUslNazwa.Size = new System.Drawing.Size(274, 20);
            this.textBoxUslNazwa.TabIndex = 14;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(405, 27);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(73, 13);
            this.label28.TabIndex = 13;
            this.label28.Text = "nazwa usługi:";
            // 
            // btnUslugaDodaj
            // 
            this.btnUslugaDodaj.Location = new System.Drawing.Point(641, 176);
            this.btnUslugaDodaj.Name = "btnUslugaDodaj";
            this.btnUslugaDodaj.Size = new System.Drawing.Size(97, 23);
            this.btnUslugaDodaj.TabIndex = 12;
            this.btnUslugaDodaj.Text = "Dodaj";
            this.btnUslugaDodaj.UseVisualStyleBackColor = true;
            // 
            // dataGridViewUslugi
            // 
            this.dataGridViewUslugi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUslugi.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewUslugi.Name = "dataGridViewUslugi";
            this.dataGridViewUslugi.Size = new System.Drawing.Size(333, 531);
            this.dataGridViewUslugi.TabIndex = 11;
            this.dataGridViewUslugi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridViewUslugi_CellContentClick);
            // 
            // OrderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUslDodajDoFV);
            this.Controls.Add(this.btnUslDel);
            this.Controls.Add(this.btnUslRefresh);
            this.Controls.Add(this.textBoxUslNazwa);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.btnUslugaDodaj);
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
