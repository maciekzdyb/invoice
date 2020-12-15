using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Faktura
{
    public partial class InvoiceControl : UserControl
    {
        public event EventHandler ShowBuyers;
        public event EventHandler ShowOrders;
        private Invoice invoice;
        private Buyer buyer;
        private Order order;

        public InvoiceControl()
        {
            InitializeComponent();
            invoice = new Invoice();
            buyer = new Buyer();
            order = new Order();
            domyslny_sprzedawca();
            nr_faktury();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }

        public Buyer updateInvoiceBuyer
        {
            get { return buyer; }
            set
            {
                buyer = value;
                nazwaNabtextBox.Text = buyer.name;
                kodNabtextBox.Text = buyer.postCode;
                miejscNabtextBox.Text = buyer.city;
                adresNabtextBox.Text = buyer.address;
                nipNabtextBox.Text = buyer.nip;
                invoice.buyer_id = buyer.id;
            }
        }

        public Order updateOrder
        {
            get { return order; }
            set
            {
                order = value;
                uslugaTextBox.Text = order.name;
            }
        }

        private bool validate()
        {
            if (this.nrFVtextBox.Text == "" || this.nazwaSprzedtextBox.Text == "" || this.nazwaNabtextBox.Text == "" || this.uslugaTextBox.Text == "" || this.cenaNettoTextBox.Text == "")
            {
                return false;
            }
            else return true;
        }

        private void rysujBox(string text, int x, int y, int w, int h, Font font, StringFormat sf, string kolor, PrintPageEventArgs e)
        {
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            Rectangle rect = new Rectangle(x, y, w, h);
            e.Graphics.DrawString(text, font, solidBrush, rect, sf);
            if (kolor == "w")
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
            e.Graphics.DrawLine(myPen, 60, 200 + stringSize.Height, 350, 200 + stringSize.Height);
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

            string razemdozaplaty = "Razem do zapłaty: " + Convert.ToString(cenabrutto) + " zł";
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
            slownie += Formatowanie.LiczbaSlownie(zlote) + " " + Formatowanie.WalutaSlownie(zlote, "PLN") + " " + Formatowanie.LiczbaSlownie(grosze) + " " + Formatowanie.WalutaSlownie(grosze, "gr");
            //TextRenderer.DrawText(e.Graphics, slownie, Arial8, rect_slownie, Color.Black, flags);
            e.Graphics.DrawString(slownie, Arial9, solidBrush, rect_slownie, stringFormatLeft);
            //e.Graphics.DrawRectangle(Pens.Black, rect_slownie);

            rysujBox("Forma płatności: " + platnoscComboBox.Text, 60, 550 + y, 160, 15, Arial9, stringFormatLeft, "w", e);
            rysujBox("Termin płatności: " + platnoscDateTimePicker.Text, 60, 565 + y, 160, 15, Arial8b, stringFormatLeft, "w", e);

            string aga = "Agata Pijanowska-Zdyb";
            e.Graphics.DrawString(aga, Arial9, solidBrush, new PointF(130, 680 + y));

            rysujBox("imię, nazwisko i podpis osoby upoważnionej do wystawienia dokumentu", 90, 710 + y, 220, 30, Arial9, stringFormat, "w", e);
            rysujBox("imię, nazwisko i podpis osoby upoważnionej do odbioru dokumentu", 490, 710 + y, 200, 30, Arial9, stringFormat, "w", e);

            myPen.Dispose();
            formGraphics.Dispose();
        }

        private void domyslny_sprzedawca()
        {
            try
            {
                SQLiteDatabase db = new SQLiteDatabase();
                DataTable tablica;
                //query += "from sprzedawca;";
                string query = "SELECT nazwa \"Nazwa\", kod \"Kod\", miasto \"Miasto\", adres \"Adres\", nip \"Nip\", rachunek \"Rachunek\" FROM sprzedawca WHERE id = 9;";
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
                //this.Close();
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

                string resetQUery = "UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE NAME = 'faktura'";
                db.ExecuteScalar(resetQUery);
            }

        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("uzupełnij pola");
            }
        }

        private void uslugaTextBox_Click(object sender, EventArgs e)
        {
            this.Hide();
            OnShowOrders(e);
        }

        private void nazwaNabtextBox_Click(object sender, EventArgs e)
        {
            this.Hide();
            OnShowBuyers(e);
        }

        protected virtual void OnShowBuyers(EventArgs e)
        {
            EventHandler eh = ShowBuyers;
            eh?.Invoke(this,e);
        }
        protected virtual void OnShowOrders(EventArgs e)
        {
            EventHandler eh = ShowOrders;
            eh?.Invoke(this, e);
        }

    }
}
