using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Globalization;

namespace Faktura
{
    public partial class InvoiceControl : UserControl
    {
        public event EventHandler ShowBuyers;
        public event EventHandler ShowOrders;
        private Invoice invoice;
        private Buyer buyer;
        private Order order;
        private Seller seller;

        public InvoiceControl()
        {
            InitializeComponent();
            invoice = new Invoice();
            invoice.payment_method = platnoscComboBox.Text;
            invoice.payment_deadline = platnoscNumericUpDown1.Value.ToString(); 
            seller = new Seller();
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

        public Invoice updateInvoice
        {
            get { return invoice; }
            set
            {
                Invoice oldInv = invoice;
                invoice = value;
                invoice.no = oldInv.no;
                invoice.seller_id = oldInv.seller_id;
                invoice.issue_date = oldInv.issue_date;
                invoice.sell_date = oldInv.sell_date;
                //TODO
            }
        }

        private bool validate()
        {
            if (nrFVtextBox.Text == "" || nazwaSprzedtextBox.Text == "" || nazwaNabtextBox.Text == "" || uslugaTextBox.Text == "" || cenaNettoTextBox.Text == "")
            {
                return false;
            }
            else
            {
                invoice.issue_date = wystawdateTimePicker.Text;
                invoice.sell_date = sprzedazDateTimePicker.Text;
                invoice.payment_deadline = platnoscDateTimePicker.Text;
                invoice.net = cenaNettoTextBox.Text;
                return true;
            }
        }

        void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Printing printing = new Printing();
            printing.printContent(e, this, invoice, seller, buyer, order);
        }

        private void domyslny_sprzedawca()
        {
            try
            {
                SQLiteDatabase db = new SQLiteDatabase();
                DataTable tablica;
                //query += "from sprzedawca;";
                string query = "SELECT id \"Id\", nazwa \"Nazwa\", kod \"Kod\", miasto \"Miasto\", adres \"Adres\", nip \"Nip\", rachunek \"Rachunek\", podpis \"Podpis\" FROM sprzedawca WHERE id = 9;";
                tablica = db.GetDataTable(query);

                foreach (DataRow r in tablica.Rows)
                {
                    seller.id = int.Parse(r["Id"].ToString());
                    nazwaSprzedtextBox.Text = r["Nazwa"].ToString();
                    seller.name = r["Nazwa"].ToString(); 
                    kodSprzedtextBox.Text = r["Kod"].ToString();
                    seller.postCode = r["Kod"].ToString();
                    miejscSprzedtextBox.Text = r["Miasto"].ToString();
                    seller.city = r["Miasto"].ToString();
                    adresSprzedtextBox.Text = r["Adres"].ToString();
                    seller.address = r["Adres"].ToString();
                    nipSprzedtextBox.Text = r["Nip"].ToString();
                    seller.nip = r["Nip"].ToString();
                    rachunekSprzedBox.Text = r["Rachunek"].ToString();
                    seller.rachunek = r["Rachunek"].ToString();
                    seller.signature = r["Podpis"].ToString();
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
            int actYear = wystawdateTimePicker.Value.Year;

            if (db.ExecuteScalar(sql) != "0")
            {
                sql = "SELECT MAX(id) FROM faktura";
                snumer = db.ExecuteScalar(sql);

                sql = "SELECT nr from faktura WHERE id =" + snumer;
                string snr = db.ExecuteScalar(sql);

                char delimiter = '/';
                String[] substrings = snr.Split(delimiter);
                int numer = int.Parse(substrings[0]);
                int invYear = int.Parse(substrings[1]);
                int year = invYear;
                if (actYear> invYear)
                {
                    invoice.no = "01/" + actYear;
                } else
                {
                    numer++;
                    if (numer < 10)
                    {
                        invoice.no = "0" + numer.ToString() + "/" + substrings[1];
                    }
                    else
                    {
                        invoice.no = numer.ToString() + "/" + substrings[1];
                    }
                }
                
            }
            else
            {
                
                invoice.no = "01/" + actYear;

                string resetQUery = "UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE NAME = 'faktura'";
                db.ExecuteScalar(resetQUery);
            }
            nrFVtextBox.Text = invoice.no;

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


        protected void NrFVtextBox_TextChanged(object sender, EventArgs e)
        {
            invoice.no = nrFVtextBox.Text;
        }

        protected void CenaNettoTextBox_TextChanged(object sender, EventArgs e)
        {   
            if (cenaNettoTextBox.Text != "")
            {            
                invoice.net = cenaNettoTextBox.Text;
                decimal netto = Convert.ToDecimal(invoice.net, new CultureInfo("en-US"));
                decimal vat = netto * 0.23m;
                vat = Decimal.Round(vat, 2);
                decimal cenabrutto = netto + vat;
                cenabrutto = Decimal.Round(cenabrutto, 2);

                textBoxVAT.Text = Convert.ToString(vat, new CultureInfo("en-US"));
                textBoxBrutto.Text = Convert.ToString(cenabrutto, new CultureInfo("en-US"));
                invoice.gross = textBoxBrutto.Text;
                invoice.vat = textBoxVAT.Text;
            } else
            {
                textBoxVAT.Clear();
                textBoxBrutto.Clear();
                invoice.gross = "";
                invoice.vat = "";
            }
        }

        protected void platnoscComboBox_TextChanged(object sender, EventArgs e)
        {
            invoice.payment_method = platnoscComboBox.Text;
        }

        protected void platnoscNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            invoice.payment_deadline = platnoscNumericUpDown1.Value.ToString();
            DateTime sellDate = sprzedazDateTimePicker.Value;
            Decimal days = platnoscNumericUpDown1.Value;
            platnoscDateTimePicker.Value = invoice.getDateDiff(sellDate, days);
        }

        protected void platnoscDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime deadLineDate = platnoscDateTimePicker.Value;
            DateTime sellDate = sprzedazDateTimePicker.Value;
            Decimal diff = invoice.getDateDiff(sellDate, deadLineDate);
            platnoscNumericUpDown1.Value = diff;
            invoice.payment_deadline = diff.ToString();
        }

        private void btnSafeInvoice_Click(object sender, EventArgs e)
        {
            if (invoice.IsCompleted())
            {
                SQLiteDatabase db = new SQLiteDatabase();
                string sql = String.Format("SELECT COUNT(*) FROM {0} WHERE nr = '{1}'", "faktura", invoice.no);
                if (db.ExecuteScalar(sql) == "0")
                {
                    string result = db.InsertInvoice(invoice);
                    if (result.Equals("ok"))
                    {
                        MessageBox.Show("faktura zapisana pomyślnie");
                        invoice = new Invoice();
                        seller = new Seller();
                        buyer = new Buyer();
                        order = new Order();
                        domyslny_sprzedawca();
                        nr_faktury();

                    } else
                    {
                        MessageBox.Show(result);
                    }
                } else
                {
                    MessageBox.Show("Numer faktury już istnieje w bazie. Faktura nie została zapisana.");
                }
            }
        }
    }
}
