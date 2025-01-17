﻿using System;
using System.Windows.Forms;

namespace Faktura
{
    partial class BuyersControl
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
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.btnUsunOdbiorce = new System.Windows.Forms.Button();
            this.btnDodajOdbiorce = new System.Windows.Forms.Button();
            this.textBoxNipNabywcy = new System.Windows.Forms.TextBox();
            this.textBoxAdresNabywcy = new System.Windows.Forms.TextBox();
            this.textBoxMisatoNabywcy = new System.Windows.Forms.TextBox();
            this.textBoxKodNabywcy = new System.Windows.Forms.TextBox();
            this.textBoxNazwaNabywcy = new System.Windows.Forms.TextBox();
            this.btnEdytujOdbiorce = new System.Windows.Forms.Button();
            this.btnDodajDoFaktury = new System.Windows.Forms.Button();
            this.dataGridViewOdbiorcy = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOdbiorcy)).BeginInit();
            this.SuspendLayout();
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(398, 513);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(25, 13);
            this.label34.TabIndex = 53;
            this.label34.Text = "NIP";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 513);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(34, 13);
            this.label33.TabIndex = 52;
            this.label33.Text = "Adres";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(398, 485);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(38, 13);
            this.label32.TabIndex = 51;
            this.label32.Text = "Miasto";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(299, 485);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(26, 13);
            this.label31.TabIndex = 50;
            this.label31.Text = "Kod";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(0, 485);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(40, 13);
            this.label30.TabIndex = 49;
            this.label30.Text = "Nazwa";
            // 
            // btnUsunOdbiorce
            // 
            this.btnUsunOdbiorce.Location = new System.Drawing.Point(757, 508);
            this.btnUsunOdbiorce.Name = "btnUsunOdbiorce";
            this.btnUsunOdbiorce.Size = new System.Drawing.Size(94, 23);
            this.btnUsunOdbiorce.TabIndex = 48;
            this.btnUsunOdbiorce.Text = "Usuń z bazy";
            this.btnUsunOdbiorce.UseVisualStyleBackColor = true;
            this.btnUsunOdbiorce.Click += new System.EventHandler(this.btnUsunOdbiorce_Click);
            // 
            // btnDodajOdbiorce
            // 
            this.btnDodajOdbiorce.Location = new System.Drawing.Point(757, 479);
            this.btnDodajOdbiorce.Name = "btnDodajOdbiorce";
            this.btnDodajOdbiorce.Size = new System.Drawing.Size(94, 23);
            this.btnDodajOdbiorce.TabIndex = 47;
            this.btnDodajOdbiorce.Text = "Dodaj do bazy";
            this.btnDodajOdbiorce.UseVisualStyleBackColor = true;
            this.btnDodajOdbiorce.Click += new System.EventHandler(this.btnDodajOdbiorce_Click);
            // 
            // textBoxNipNabywcy
            // 
            this.textBoxNipNabywcy.Location = new System.Drawing.Point(431, 510);
            this.textBoxNipNabywcy.Name = "textBoxNipNabywcy";
            this.textBoxNipNabywcy.Size = new System.Drawing.Size(77, 20);
            this.textBoxNipNabywcy.TabIndex = 46;
            // 
            // textBoxAdresNabywcy
            // 
            this.textBoxAdresNabywcy.Location = new System.Drawing.Point(49, 510);
            this.textBoxAdresNabywcy.Name = "textBoxAdresNabywcy";
            this.textBoxAdresNabywcy.Size = new System.Drawing.Size(234, 20);
            this.textBoxAdresNabywcy.TabIndex = 45;
            // 
            // textBoxMisatoNabywcy
            // 
            this.textBoxMisatoNabywcy.Location = new System.Drawing.Point(442, 482);
            this.textBoxMisatoNabywcy.Name = "textBoxMisatoNabywcy";
            this.textBoxMisatoNabywcy.Size = new System.Drawing.Size(66, 20);
            this.textBoxMisatoNabywcy.TabIndex = 44;
            // 
            // textBoxKodNabywcy
            // 
            this.textBoxKodNabywcy.Location = new System.Drawing.Point(331, 482);
            this.textBoxKodNabywcy.Name = "textBoxKodNabywcy";
            this.textBoxKodNabywcy.Size = new System.Drawing.Size(51, 20);
            this.textBoxKodNabywcy.TabIndex = 43;
            // 
            // textBoxNazwaNabywcy
            // 
            this.textBoxNazwaNabywcy.Location = new System.Drawing.Point(49, 482);
            this.textBoxNazwaNabywcy.Name = "textBoxNazwaNabywcy";
            this.textBoxNazwaNabywcy.Size = new System.Drawing.Size(234, 20);
            this.textBoxNazwaNabywcy.TabIndex = 42;
            this.textBoxNazwaNabywcy.TextChanged += new System.EventHandler(this.textBoxNazwaNabywcy_TextChanged);
            // 
            // btnEdytujOdbiorce
            // 
            this.btnEdytujOdbiorce.Location = new System.Drawing.Point(657, 508);
            this.btnEdytujOdbiorce.Name = "btnEdytujOdbiorce";
            this.btnEdytujOdbiorce.Size = new System.Drawing.Size(94, 23);
            this.btnEdytujOdbiorce.TabIndex = 41;
            this.btnEdytujOdbiorce.Text = "Uaktualnij";
            this.btnEdytujOdbiorce.UseVisualStyleBackColor = true;
            this.btnEdytujOdbiorce.Click += new System.EventHandler(this.btnEdytujOdbiorce_Click);
            // 
            // btnDodajDoFaktury
            // 
            this.btnDodajDoFaktury.Location = new System.Drawing.Point(657, 479);
            this.btnDodajDoFaktury.Name = "btnDodajDoFaktury";
            this.btnDodajDoFaktury.Size = new System.Drawing.Size(94, 23);
            this.btnDodajDoFaktury.TabIndex = 40;
            this.btnDodajDoFaktury.Text = "Dodaj do faktury";
            this.btnDodajDoFaktury.UseVisualStyleBackColor = true;
            this.btnDodajDoFaktury.Click += new System.EventHandler(this.btnDodajDoFaktury_Click);
            // 
            // dataGridViewOdbiorcy
            // 
            this.dataGridViewOdbiorcy.AllowUserToAddRows = false;
            this.dataGridViewOdbiorcy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOdbiorcy.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewOdbiorcy.Name = "dataGridViewOdbiorcy";
            this.dataGridViewOdbiorcy.ReadOnly = true;
            this.dataGridViewOdbiorcy.RowHeadersVisible = false;
            this.dataGridViewOdbiorcy.Size = new System.Drawing.Size(875, 473);
            this.dataGridViewOdbiorcy.TabIndex = 39;
            this.dataGridViewOdbiorcy.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOdbiorcy_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(544, 508);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 54;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BuyersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.btnUsunOdbiorce);
            this.Controls.Add(this.btnDodajOdbiorce);
            this.Controls.Add(this.textBoxNipNabywcy);
            this.Controls.Add(this.textBoxAdresNabywcy);
            this.Controls.Add(this.textBoxMisatoNabywcy);
            this.Controls.Add(this.textBoxKodNabywcy);
            this.Controls.Add(this.textBoxNazwaNabywcy);
            this.Controls.Add(this.btnEdytujOdbiorce);
            this.Controls.Add(this.btnDodajDoFaktury);
            this.Controls.Add(this.dataGridViewOdbiorcy);
            this.Name = "BuyersControl";
            this.Size = new System.Drawing.Size(884, 537);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOdbiorcy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btnUsunOdbiorce;
        private System.Windows.Forms.Button btnDodajOdbiorce;
        private System.Windows.Forms.TextBox textBoxNipNabywcy;
        private System.Windows.Forms.TextBox textBoxAdresNabywcy;
        private System.Windows.Forms.TextBox textBoxMisatoNabywcy;
        private System.Windows.Forms.TextBox textBoxKodNabywcy;
        private System.Windows.Forms.TextBox textBoxNazwaNabywcy;
        private System.Windows.Forms.Button btnEdytujOdbiorce;
        private System.Windows.Forms.Button btnDodajDoFaktury;
        private System.Windows.Forms.DataGridView dataGridViewOdbiorcy;
        private System.Windows.Forms.Button button1;
    }
}
