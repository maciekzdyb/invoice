using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.SQLite;
//using Microsoft.Office.Interop.Excel;



namespace faktura_v0
{
    public partial class Form1 : Form
    {

        int idOdbiorcy=0, idUslugi=0, idSprzedawcy=1;

        public Form1()
        {
            InitializeComponent();
            panelFakturyWystawione.Visible = false;
            panelNowaFaktura.Visible = false;
            panelOdbiorcy.Visible = false;
            panelUsluga.Visible = false;
            panelAutor.Visible = false;
            panelSprzedawca.Visible = false;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }

        void rysujBox(string text, int x, int y, int w, int h, Font font, StringFormat sf, string kolor, PrintPageEventArgs e)
        {
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            Rectangle rect = new Rectangle(x, y, w, h);
            e.Graphics.DrawString(text, font, solidBrush, rect, sf);
            if (kolor=="w")
                e.Graphics.DrawRectangle(Pens.White, rect);
            else
                e.Graphics.DrawRectangle(Pens.Black, rect);

        }

        void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {            
      
            Font arial12b = new Font("Arial", 12, FontStyle.Bold);
            Font arial17 = new Font("Arial", 17, FontStyle.Bold);
            Font Times9 = new Font("Times New Roman", 9);
            Font Arial9 = new Font("Arial", 8);
            Font Arial6 = new Font("Arial", 6);
            Font Arial8b = new Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point);

            SolidBrush solidBrush = new SolidBrush(Color.Black);                    //kolor pędzla
            Pen myPen = new Pen(Color.DarkGray);
            Graphics formGraphics = this.CreateGraphics();

            SizeF stringSize = new SizeF();

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            StringFormat stringFormatLeft = new StringFormat();
            stringFormatLeft.Alignment = StringAlignment.Near;
            stringFormatLeft.LineAlignment = StringAlignment.Near;

            rysujBox("Faktura VAT", 330, 50, 180, 30, arial12b, stringFormat, "w", e);
            rysujBox("Nr " + nrFVtextBox.Text, 330, 82, 180, 40, arial17, stringFormat, "w", e);
            rysujBox("Oryginał/Kopia", 340, 110, 160, 20, Arial9, stringFormat, "w", e);

            rysujBox("Data wystawienia: " + wystawdateTimePicker.Text, 570, 50, 180, 20, Arial9, stringFormat, "w", e);
            rysujBox("Data sprzedaży: " + sprzedazDateTimePicker.Text, 575, 70, 180, 20, Arial9, stringFormat, "w", e);

            //stringSize = e.Graphics.MeasureString(nr_faktury, arial17);
            //e.Graphics.DrawString(nr_faktury, arial17, solidBrush, new PointF(345, 80));
            string sprzedawca = "Sprzedawca";
            e.Graphics.DrawString(sprzedawca, arial12b, solidBrush, new PointF(60, 200));
            e.Graphics.DrawLine(myPen, 60, 200+stringSize.Height, 350, 200+stringSize.Height);
            rysujBox(nazwaSprzedtextBox.Text, 60, 240, 310, 15, Arial9, stringFormatLeft, "w", e);
            rysujBox(adresSprzedtextBox.Text, 60, 255, 310, 15, Arial9, stringFormatLeft, "w", e);
            rysujBox(kodSprzedtextBox.Text, 60, 270, 40, 15, Arial9, stringFormat, "w", e);
            rysujBox(miejscSprzedtextBox.Text, 100, 270, 60, 15, Arial9, stringFormat, "w", e);
            rysujBox("NIP: " + nipSprzedtextBox.Text, 60, 285, 110, 15, Arial9, stringFormatLeft, "w", e);
            rysujBox("Nr rachunku: " + rachunekSprzedBox.Text, 60, 300, 300, 15, Arial8b, stringFormatLeft, "w", e);
            string nabywca = "Nabywca";
            e.Graphics.DrawString(nabywca, arial12b, solidBrush, new PointF(440, 200));
            e.Graphics.DrawLine(myPen, 440, 200 + stringSize.Height, 440 + 300, 200 + stringSize.Height);
            rysujBox(nazwaNabtextBox.Text, 440, 240, 310, 15, Arial9, stringFormatLeft, "w", e);
            rysujBox(adresNabtextBox.Text, 440, 255, 310, 15, Arial9, stringFormatLeft, "w", e);
            rysujBox(kodNabtextBox.Text, 440, 270, 40, 15, Arial9, stringFormat, "w", e);
            rysujBox(miejscNabtextBox.Text, 480, 270, 60, 15, Arial9, stringFormat, "w", e);
            rysujBox("NIP: " + nipNabtextBox.Text, 440, 285, 110, 15, Arial9, stringFormatLeft, "w", e);
     
            rysujBox("Lp.", 60, 350, 20, 30, Arial9, stringFormat, "b", e);
            rysujBox("Nazwa towaru lub usługi", 80, 350, 330, 30, Arial9, stringFormat, "b", e);
            rysujBox("ilość", 410, 350, 30, 30, Arial9, stringFormat, "b", e);
            rysujBox("jm", 440, 350, 20, 30, Arial9, stringFormat, "b", e);
            rysujBox("Cena netto", 460, 350, 60, 30, Arial9, stringFormat, "b", e);
            rysujBox("Wartość netto", 520, 350, 60, 30, Arial9, stringFormat, "b", e);
            rysujBox("Stawka VAT", 580, 350, 50, 30, Arial9, stringFormat, "b", e);
            rysujBox("Kwota   VAT", 630, 350, 60, 30, Arial9, stringFormat, "b", e);
            rysujBox("Wartość brutto", 690, 350, 60, 30, Arial9, stringFormat, "b", e);
          
            int y = 0;
            string text = uslugaTextBox.Text;
            if (text.Length > 50)
            {
                if (text.Length > 90)
                    y = 40;
                else y = 20;
            }

            rysujBox("1", 60, 380, 20, 20 + y, Arial9, stringFormat, "b", e);
            rysujBox(uslugaTextBox.Text, 80, 380, 330, 20 + y, Arial9, stringFormat, "b", e);
            rysujBox("1", 410, 380, 30, 20 + y, Arial9, stringFormat, "b", e);
            rysujBox("szt", 440, 380, 20, 20 + y, Arial9, stringFormat, "b", e);
            rysujBox(cenaNettoTextBox.Text, 460, 380, 60, 20 + y, Arial9, stringFormat, "b", e);
            rysujBox(cenaNettoTextBox.Text, 520, 380, 60, 20 + y, Arial9, stringFormat, "b", e);
            rysujBox("23", 580, 380, 50, 20 + y, Arial9, stringFormat, "b", e);
            decimal netto = Convert.ToDecimal(cenaNettoTextBox.Text);
            decimal vat = netto * 0.23m;
            vat = Decimal.Round(vat, 2);
            rysujBox(Convert.ToString(vat), 630, 380, 60, 20 + y, Arial9, stringFormat, "b", e);
            decimal cenabrutto = netto + vat;
            cenabrutto = Decimal.Round(cenabrutto, 2); 
            rysujBox(Convert.ToString(cenabrutto), 690, 380, 60, 20 + y, Arial9, stringFormat, "b", e);

            rysujBox("RAZEM", 460, 405 + y, 60, 20, Arial9, stringFormat, "b", e);
            rysujBox(cenaNettoTextBox.Text, 520, 405 + y, 60, 20, Arial9, stringFormat, "b", e);
            rysujBox("x", 580, 405 + y, 50, 20, Arial9, stringFormat, "b", e);
            rysujBox(Convert.ToString(vat), 630, 405 + y, 60, 20, Arial9, stringFormat, "b", e);
            rysujBox(Convert.ToString(cenabrutto), 690, 405 + y, 60, 20, Arial9, stringFormat, "b", e);

            rysujBox("W tym", 460, 425 + y, 60, 20, Arial9, stringFormat, "b", e);
            rysujBox(cenaNettoTextBox.Text, 520, 425 + y, 60, 20, Arial9, stringFormat, "b", e);
            rysujBox("23%", 580, 425 + y, 50, 20, Arial9, stringFormat, "b", e);
            rysujBox(Convert.ToString(vat), 630, 425 + y, 60, 20, Arial9, stringFormat, "b", e);
            rysujBox(Convert.ToString(cenabrutto), 690, 425 + y, 60, 20, Arial9, stringFormat, "b", e);

            string razemdozaplaty = "Razem do zapłaty: "+ Convert.ToString(cenabrutto)+" zł";
            Rectangle rect_razemdozaplaty = new Rectangle(60, 500 + y, 300, 20);
            e.Graphics.DrawString(razemdozaplaty, Arial8b, solidBrush, rect_razemdozaplaty, stringFormatLeft);
            e.Graphics.DrawRectangle(Pens.White, rect_razemdozaplaty);
            //-------------------------------------------------------------------------------------------------------------
            //TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
            
            string slownie = "Słownie: ";
            Rectangle rect_slownie = new Rectangle(60, 520 + y, 690, 20);
            decimal kwota = cenabrutto;
            int zlote = (int)kwota;
            int grosze = (int)(100 * kwota) % 100;
            slownie += Formatowanie.LiczbaSlownie(zlote)+" "+Formatowanie.WalutaSlownie(zlote,"PLN") +" "+Formatowanie.LiczbaSlownie(grosze) +" "+Formatowanie.WalutaSlownie(grosze,"gr");
            //TextRenderer.DrawText(e.Graphics, slownie, Arial8, rect_slownie, Color.Black, flags);
            e.Graphics.DrawString(slownie, Arial9, solidBrush, rect_slownie, stringFormatLeft);
            //e.Graphics.DrawRectangle(Pens.Black, rect_slownie);

            rysujBox("Forma płatności: "+ platnoscComboBox.Text, 60, 550 + y, 160, 15, Arial9, stringFormatLeft, "w", e);
            rysujBox("Termin płatności: "+ platnoscDateTimePicker.Text, 60, 565 + y, 160, 15, Arial8b, stringFormatLeft, "w", e);

            string aga = "Agata Pijanowska-Zdyb";
            e.Graphics.DrawString(aga, Arial9, solidBrush, new PointF(130, 680 + y));

            rysujBox("imię, nazwisko i podpis osoby upoważnionej do wystawienia dokumentu", 90, 710 + y, 220, 30, Arial9, stringFormat, "w", e);
            rysujBox("imię, nazwisko i podpis osoby upoważnionej do odbioru dokumentu", 490, 710 + y, 200, 30, Arial9, stringFormat, "w", e);

            myPen.Dispose();
            formGraphics.Dispose();
        }

        private bool FVOk()
        {
            if (nrFVtextBox.Text == "" || nazwaSprzedtextBox.Text == "" || nazwaNabtextBox.Text == "" || uslugaTextBox.Text == "" || cenaNettoTextBox.Text == "")
            {
                return false;
            }
            else return true;
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if (FVOk())
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("uzupełnij pola");
            }
        }

        private void domyslny_sprzedawca()
        {
            try
            {
                SQLiteDatabase db = new SQLiteDatabase();
                DataTable tablica;
                //query += "from sprzedawca;";
                string query = "SELECT nazwa \"Nazwa\", kod \"Kod\", miasto \"Miasto\", adres \"Adres\", nip \"Nip\", rachunek \"Rachunek\" FROM sprzedawca WHERE id = 1;";
                tablica = db.GetDataTable(query);
               
                foreach (DataRow r in tablica.Rows)
                {
                    nazwaSprzedtextBox.Text = r["Nazwa"].ToString();
                    kodSprzedtextBox.Text = r["Kod"].ToString();
                    miejscSprzedtextBox.Text = r["Miasto"].ToString();
                    adresSprzedtextBox.Text = r["Adres"].ToString();
                    nipSprzedtextBox.Text = r["Nip"].ToString();
                    rachunekSprzedBox.Text = r["Rachunek"].ToString();
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
                MessageBox.Show(error);
                this.Close();
            }
        }
 
        private void nr_faktury()
        {
            SQLiteDatabase db = new SQLiteDatabase();
            string sql = "SELECT COUNT(*) FROM faktura";
            string snumer;
            if (db.ExecuteScalar(sql) != "0")
            {
                sql = "SELECT MAX(id) FROM faktura";
                snumer = db.ExecuteScalar(sql);

                sql = "SELECT nr from faktura WHERE id =" + snumer;
                string snr = db.ExecuteScalar(sql);

                char delimiter = '/';
                String[] substrings = snr.Split(delimiter);
                int numer = int.Parse(substrings[0]);
                numer++;
                if (numer < 10)
                {
                    nrFVtextBox.Text = "0" + numer.ToString() + "/" + substrings[1];
                }
                else
                {
                    nrFVtextBox.Text = numer.ToString() + "/" + substrings[1];
                }
            }
            else
            {
                int year = wystawdateTimePicker.Value.Year;
                nrFVtextBox.Text = "01/" + year;

                string resetQUery ="UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE NAME = 'faktura'";
                db.ExecuteScalar(resetQUery);
            }

        }

        private void nowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelFakturyWystawione.Visible = false;
            panelOdbiorcy.Visible = false;
            panelSprzedawca.Visible = false;
            panelUsluga.Visible = false;
            panelAutor.Visible = false;
            panelNowaFaktura.Visible = true;
            domyslny_sprzedawca();
            nr_faktury();
        }

        private void oAutorzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelFakturyWystawione.Visible = false;
            panelNowaFaktura.Visible = false;
            panelOdbiorcy.Visible = false;
            panelSprzedawca.Visible = false;
            panelUsluga.Visible = false;
            panelAutor.Visible = true;
        }

        private void fillDataGrid()
        {
            try
            {
                SQLiteDatabase db = new SQLiteDatabase();
                string sql = "SELECT COUNT(*) FROM nabywca";
                if (db.ExecuteScalar(sql) == "0")
                {
                    string resetQUery = "UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE NAME = 'nabywca'";
                    db.ExecuteScalar(resetQUery);
                    dataGridViewOdbiorcy.DataSource = null;
                    dataGridViewOdbiorcy.Update();
                    dataGridViewOdbiorcy.Refresh();
                }
                else
                {
                    DataTable recipe;
                    string query = "SELECT id \"Id\", nazwa \"Nazwa\", kod \"Kod\", miasto \"Miasto\", adres \"Adres\", nip \"Nip\" FROM nabywca";
                    recipe = db.GetDataTable(query);
                    dataGridViewOdbiorcy.Update();
                    dataGridViewOdbiorcy.Refresh();
                    dataGridViewOdbiorcy.DataSource = recipe;
                    dataGridViewOdbiorcy.Columns[0].Width = 20;
                    dataGridViewOdbiorcy.Columns[1].Width = 160;
                    dataGridViewOdbiorcy.Columns[2].Width = 50;
                    dataGridViewOdbiorcy.Columns[3].Width = 50;
                    dataGridViewOdbiorcy.Columns[4].Width = 130;
                    dataGridViewOdbiorcy.Columns[5].Width = 100;
                }
            }
            catch (Exception fail)
            {
                MessageBox.Show(fail.Message);
                this.Close();
            }
        }

        private void obiorcyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelFakturyWystawione.Visible = false;
            panelNowaFaktura.Visible = false;
            panelAutor.Visible = false;
            panelSprzedawca.Visible = false;
            panelUsluga.Visible = false;
            panelOdbiorcy.Visible = true;
            fillDataGrid();
        }

        private void dataGridViewOdbiorcy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int wiersz = dataGridViewOdbiorcy.CurrentCell.RowIndex;
            idOdbiorcy = int.Parse(dataGridViewOdbiorcy[0, wiersz].Value.ToString());
            textBoxNazwaNabywcy.Text = dataGridViewOdbiorcy[1, wiersz].Value.ToString();
            textBoxKodNabywcy.Text = dataGridViewOdbiorcy[2, wiersz].Value.ToString();
            textBoxMisatoNabywcy.Text = dataGridViewOdbiorcy[3, wiersz].Value.ToString();
            textBoxAdresNabywcy.Text = dataGridViewOdbiorcy[4, wiersz].Value.ToString();
            textBoxNipNabywcy.Text = dataGridViewOdbiorcy[5, wiersz].Value.ToString();
        }

        private void btnDodajDoFaktury_Click(object sender, EventArgs e)
        {
            SQLiteDatabase db = new SQLiteDatabase();
            string checkQuery = "SELECT COUNT(*) FROM nabywca WHERE ";
            checkQuery += "nazwa ='" + textBoxNazwaNabywcy.Text + "' ";
            checkQuery += "AND kod ='" + textBoxKodNabywcy.Text + "' ";
            checkQuery += "AND miasto ='" + textBoxMisatoNabywcy.Text + "' ";
            checkQuery += "AND adres ='" + textBoxAdresNabywcy.Text + "' ";
            checkQuery += "AND nip ='" + textBoxNipNabywcy.Text + "'";
            if (db.ExecuteScalar(checkQuery) == "1")
            {
                panelFakturyWystawione.Visible = false;
                panelAutor.Visible = false;
                panelSprzedawca.Visible = false;
                panelUsluga.Visible = false;
                panelOdbiorcy.Visible = false;
                panelNowaFaktura.Visible = true;
                nazwaNabtextBox.Text = textBoxNazwaNabywcy.Text;
                kodNabtextBox.Text = textBoxKodNabywcy.Text;
                miejscNabtextBox.Text = textBoxMisatoNabywcy.Text;
                adresNabtextBox.Text = textBoxAdresNabywcy.Text;
                nipNabtextBox.Text = textBoxNipNabywcy.Text;
            }
            else
            {
                MessageBox.Show("Nabywca musi być najpierw dodany do bazy!");
            }
        }

        private Dictionary<string, string> data()
        {
            if (textBoxNazwaNabywcy.Text == "" || textBoxKodNabywcy.Text == "" || textBoxMisatoNabywcy.Text == "" ||
                textBoxAdresNabywcy.Text == "" || textBoxNipNabywcy.Text == "")
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione");
            }
            else
            {
                Dictionary<string, string> dane = new Dictionary<string, string>();
                dane.Add("nazwa", textBoxNazwaNabywcy.Text);
                dane.Add("kod", textBoxKodNabywcy.Text);
                dane.Add("miasto", textBoxMisatoNabywcy.Text);
                dane.Add("adres", textBoxAdresNabywcy.Text);
                dane.Add("nip", textBoxNipNabywcy.Text);
                return dane;
            }
            return null;
        }

        private void btnEdytujOdbiorce_Click(object sender, EventArgs e)
        {
            SQLiteDatabase db = new SQLiteDatabase();

            Dictionary<string, string> dane = new Dictionary<string, string>();
            dane = data();
            if (dane!=null)
            {
                string checkQuery = "SELECT COUNT(*) FROM faktura WHERE id_nabywca = " + idOdbiorcy;
                if (db.ExecuteScalar(checkQuery) == "0")
                {
                    string wher = "nabywca.id=" + idOdbiorcy;
                    bool update = db.Update("nabywca", dane, wher);
                    if (update)
                    {
                        MessageBox.Show("Uaktualniono");
                        fillDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("błąd..");
                    }
                }
                else
                {
                    MessageBox.Show("Odmowa. Nabywca jest wykorzystany w poprzednich fakturach");
                }
            }
        }

        private void btnDodajOdbiorce_Click(object sender, EventArgs e)
        {
            SQLiteDatabase db = new SQLiteDatabase();
            Dictionary<string, string> dane = new Dictionary<string, string>();
            dane = data();
            if (dane != null)
            {
                string checkQuery = "SELECT COUNT(*) FROM nabywca WHERE nazwa ='" + dane["nazwa"] + "' AND kod='" + dane["kod"] + "' AND adres='" + dane["adres"] + "' AND nip='" + dane["nip"] + "'";
                if (db.ExecuteScalar(checkQuery) == "0")
                {
                    bool insert = db.Insert("nabywca", dane);
                    if (insert)
                    {
                        MessageBox.Show("Pozycja dodana");
                        textBoxNazwaNabywcy.Clear();
                        textBoxKodNabywcy.Clear();
                        textBoxMisatoNabywcy.Clear();
                        textBoxAdresNabywcy.Clear();
                        textBoxNipNabywcy.Clear();
                        fillDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("błąd..");
                    }
                }
                else
                {
                    MessageBox.Show("Podana pozycja jest już w bazie");
                }
            }
        }

        private void btnUsunOdbiorce_Click(object sender, EventArgs e)
        {
            SQLiteDatabase db = new SQLiteDatabase();
            Dictionary<string, string> dane = new Dictionary<string, string>();
            dane = data();

            if (dane != null)
            {
                string checkQuery = "SELECT COUNT(*) FROM faktura WHERE id_nabywca='" + idOdbiorcy + "'";
                if (db.ExecuteScalar(checkQuery) == "0")
                {
                    string wher = " nip=\"" + dane["nip"] + "\"";
                    bool delete = db.Delete("nabywca", wher);
                    if (delete)
                    {
                        MessageBox.Show("pozycja usunięta");
                        fillDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("błąd..");
                    }
                }
                else
                {
                    MessageBox.Show("Odmowa. Nabywca jest wykorzystany w wystawionych fakturach");
                }
            }
        }

        private void sprzedawcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelFakturyWystawione.Visible = false;
            panelNowaFaktura.Visible = false;
            panelOdbiorcy.Visible = false;
            panelUsluga.Visible = false;
            panelAutor.Visible = false;
            panelSprzedawca.Visible = true;
            try
            {
                SQLiteDatabase db = new SQLiteDatabase();
                DataTable tablica;
                //query += "from sprzedawca;";
                string query = "SELECT nazwa \"Nazwa\", kod \"Kod\", miasto \"Miasto\", adres \"Adres\", nip \"Nip\", rachunek \"Rachunek\" FROM sprzedawca WHERE id = 1;";
                tablica = db.GetDataTable(query);

                foreach (DataRow r in tablica.Rows)
                {
                    textBoxSprzedNaz.Text = r["Nazwa"].ToString();
                    textBoxSprzedKod.Text = r["Kod"].ToString();
                    textBoxSprzedMiasto.Text = r["Miasto"].ToString();
                    textBoxSprzedAdres.Text = r["Adres"].ToString();
                    textBoxSprzedNip.Text = r["Nip"].ToString();
                    textBoxSprzedNrRach.Text = r["Rachunek"].ToString();
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
                MessageBox.Show(error);
                this.Close();
            }
        }

        private void btnUaktualnijSprzed_Click(object sender, EventArgs e)
        {
            if(textBoxSprzedNaz.Text=="" || textBoxSprzedKod.Text=="" || textBoxSprzedMiasto.Text=="" ||
               textBoxSprzedAdres.Text=="" || textBoxSprzedNip.Text=="" || textBoxSprzedNrRach.Text=="")
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione");
            }
            else
            {
                SQLiteDatabase db = new SQLiteDatabase();
                string checkQuery = "SELECT COUNT (*) FROM faktura where id_sprzedawca =" + idSprzedawcy;
                if (db.ExecuteScalar(checkQuery) == "0")
                {
                    Dictionary<string, string> dane = new Dictionary<string, string>();
                    dane.Add("nazwa", textBoxSprzedNaz.Text);
                    dane.Add("kod", textBoxSprzedKod.Text);
                    dane.Add("miasto", textBoxSprzedMiasto.Text);
                    dane.Add("adres", textBoxSprzedAdres.Text);
                    dane.Add("nip", textBoxSprzedNip.Text);
                    dane.Add("rachunek", textBoxSprzedNrRach.Text);
                    string wher = "sprzedawca.id=1";
                    bool update = db.Update("sprzedawca", dane, wher);
                    if (update)
                    {
                        MessageBox.Show("Uaktualniono");
                        fillDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("błąd..");
                    }
                }
                else
                {
                    MessageBox.Show("Odmowa... Aktualny sprzedawca jest wykorzystany w poprzednich fakturach.\n Proszę zmienić bazę");
                }
            }
        }

        private void usługaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelFakturyWystawione.Visible = false;
            panelNowaFaktura.Visible = false;
            panelOdbiorcy.Visible = false;
            panelAutor.Visible = false;
            panelSprzedawca.Visible = false;
            panelUsluga.Visible = true;
            fillDataGridUslugi();
        }

        private void fillDataGridUslugi()
        {
            try
            {
                SQLiteDatabase db = new SQLiteDatabase();
                string sql = "SELECT COUNT(*) FROM usluga";
                if (db.ExecuteScalar(sql) == "0")
                {
                    string resetQUery = "UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE NAME = 'usluga'";
                    db.ExecuteScalar(resetQUery);
                    dataGridViewUslugi.DataSource = null;
                    dataGridViewUslugi.Update();
                    dataGridViewUslugi.Refresh();
                }
                else
                {
                    DataTable recipe;
                    string query = "SELECT id \"Id\", nazwa \"Nazwa\" FROM usluga";
                    recipe = db.GetDataTable(query);
                    dataGridViewUslugi.Update();
                    dataGridViewUslugi.Refresh();
                    dataGridViewUslugi.DataSource = recipe;
                    dataGridViewUslugi.Columns[0].Width = 20;
                    dataGridViewUslugi.Columns[1].Width = 310;
                }
            }
            catch (Exception fail)
            {
                MessageBox.Show(fail.Message);
                this.Close();
            }
        }
        
        private void wystawioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelNowaFaktura.Visible = false;
            panelOdbiorcy.Visible = false;
            panelAutor.Visible = false;
            panelSprzedawca.Visible = false;
            panelUsluga.Visible = false;
            panelFakturyWystawione.Visible = true;
            fillDataGridFaktury();
        }

        private void fillDataGridFaktury()
        {
            try
            {
                SQLiteDatabase db = new SQLiteDatabase();
                DataTable recipe;

                string sql = "SELECT COUNT(*) FROM faktura";
                string count = db.ExecuteScalar(sql);
                textBoxCountInv.Text = count;
                sql = "SELECT SUM(netto) FROM faktura";
                count = db.ExecuteScalar(sql);
                textBoxCountNetto.Text = count;
                sql = "SELECT SUM(vat) FROM faktura";
                count = db.ExecuteScalar(sql);
                textBoxCountVat.Text = count;
                if ( count == "0")
                {
                    string resetQUery = "UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE NAME = 'faktura'";
                    db.ExecuteScalar(resetQUery);
                }
                else
                {
                    //string query = "SELECT * FROM faktura";
                    string query = "SELECT faktura.nr \"NrFV\", nabywca.nazwa \"Nabywca\", netto \"Netto\", data_wyst \"Wystawiona\" FROM faktura,nabywca";
                    query += " WHERE nabywca.id = faktura.id_nabywca";
                    recipe = db.GetDataTable(query);
                    dataGridViewFaktury.Refresh();
                    dataGridViewFaktury.DataSource = recipe;

                    dataGridViewFaktury.Columns[0].Width = 60;
                    dataGridViewFaktury.Columns[1].Width = 240;
                    dataGridViewFaktury.Columns[2].Width = 80;
                    dataGridViewFaktury.Columns[3].Width = 80;
                }
            }
            catch (Exception fail)
            {
                MessageBox.Show(fail.Message);
                this.Close();
            }
        }

        private void btnShowAllInv_Click(object sender, EventArgs e)
        {
            fillDataGridFaktury();
        }

        private void btnUslugaDodaj_Click(object sender, EventArgs e)
        {
            if (textBoxUslNazwa.Text=="")
            {
                MessageBox.Show("pole musi być wypełnione");
            }
            else
            {
                SQLiteDatabase db = new SQLiteDatabase();
                Dictionary<string, string> dane = new Dictionary<string, string>();
                dane.Add("nazwa", textBoxUslNazwa.Text);

                string checkQuery = "SELECT COUNT(*) FROM usluga WHERE nazwa ='" + dane["nazwa"] + "'";
                if (db.ExecuteScalar(checkQuery)=="0")               
                {
                    bool insert = db.Insert("usluga", dane);
                    if (insert)
                    {
                        MessageBox.Show("Pozycja dodana");
                        textBoxUslNazwa.Clear();
                        fillDataGridUslugi();
                    }
                    else MessageBox.Show("błąd..");
                }
                else
                {
                    MessageBox.Show("podana usługa już istnieje w bazie");
                }
            }
        }

        private void btnUslRefresh_Click(object sender, EventArgs e)
        {
            fillDataGridUslugi();
        }

        private void btnUslDel_Click(object sender, EventArgs e)
        {
            if (idUslugi > 0)
            {
                SQLiteDatabase db = new SQLiteDatabase();
                string checkQuery = "SELECT COUNT (*) FROM faktura where id_usluga =" + idUslugi;
                if (db.ExecuteScalar(checkQuery) == "0")
                {
                    string wher = " id=\"" + idUslugi + "\"";
                    bool delete = db.Delete("usluga", wher);
                    if (delete)
                    {
                        MessageBox.Show("pozycja usunięta");
                        fillDataGridUslugi();
                        idUslugi = 0;
                        textBoxUslNazwa.Clear();
                    }
                    else
                    {
                        MessageBox.Show("błąd..");
                    }
                }
                else
                {
                    MessageBox.Show("Odmowa. Dana usługa wykorzystana w fakturze");
                }
             
            }
            else
            {
                MessageBox.Show("Wybierz pozycję do usunięcia");
            }
        }

        private void btnUslDodajDoFV_Click(object sender, EventArgs e)
        {
            SQLiteDatabase db = new SQLiteDatabase();
            string checkQuery = "SELECT COUNT(*) FROM usluga WHERE nazwa = '" + textBoxUslNazwa.Text + "'";
            if (db.ExecuteScalar(checkQuery) == "1")
            {
                panelFakturyWystawione.Visible = false;
                panelAutor.Visible = false;
                panelSprzedawca.Visible = false;
                panelUsluga.Visible = false;
                panelOdbiorcy.Visible = false;
                panelNowaFaktura.Visible = true;
                uslugaTextBox.Text = textBoxUslNazwa.Text;
            }
            else
            {
                MessageBox.Show("Usługa musi być najpierw dodana do bazy!");
            }
        }

        private void btnSafeInvoice_Click(object sender, EventArgs e)
        {
            if (FVOk())
            {
                SQLiteDatabase db = new SQLiteDatabase();
                string checkQuery = "SELECT COUNT(*) FROM faktura WHERE nr='" + nrFVtextBox.Text + "'";
                if (db.ExecuteScalar(checkQuery) == "0")
                {
                    Dictionary<string, string> dane = new Dictionary<string, string>();
                    dane.Add("nr", nrFVtextBox.Text);
                    dane.Add("id_sprzedawca", idSprzedawcy.ToString());
                    dane.Add("id_nabywca", idOdbiorcy.ToString());
                    dane.Add("id_usluga", idUslugi.ToString());
                    dane.Add("data_wyst", wystawdateTimePicker.Value.ToShortDateString());
                    dane.Add("data_sprzed", sprzedazDateTimePicker.Value.ToShortDateString());
                    dane.Add("forma_plat", platnoscComboBox.Text);
                    dane.Add("termin_plat", platnoscDateTimePicker.Value.ToShortDateString());
                    dane.Add("netto", cenaNettoTextBox.Text);

                    decimal netto = Convert.ToDecimal(cenaNettoTextBox.Text);
                    decimal vat = netto * 0.23m;
                    vat = Decimal.Round(vat, 2);
                    dane.Add("vat", vat.ToString());

                    decimal cenabrutto = netto + vat;
                    cenabrutto = Decimal.Round(cenabrutto, 2);
                    dane.Add("brutto", cenabrutto.ToString());
                    if (dane != null)
                    {
                        bool insert = db.Insert("faktura", dane);
                        if (insert)
                        {
                            MessageBox.Show("Pozycja dodana");
                            textBoxUslNazwa.Text = "";
                        }
                        else MessageBox.Show("błąd..");
                    }
                }
                else
                {
                    MessageBox.Show("Błąd. Podany nr faktury został już wykorzystany!!!");
                }
            }
            else
            {
                MessageBox.Show("uzupełnij pola");
            }
        }

        private void dataGridViewUslugi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int wiersz = dataGridViewUslugi.CurrentCell.RowIndex;
            idUslugi = int.Parse(dataGridViewUslugi[0, wiersz].Value.ToString());
            textBoxUslNazwa.Text = dataGridViewUslugi[1, wiersz].Value.ToString();

        }

    }
}
