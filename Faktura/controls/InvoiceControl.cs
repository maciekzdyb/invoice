using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Globalization;
using System.Drawing;

namespace Faktura
{
    public partial class InvoiceControl : UserControl
    {
        public event EventHandler ShowBuyers;
        public event EventHandler ShowOrders;
        public event EventHandler UpdateInvoicesList;
        private Invoice invoice;
        private Buyer buyer;
        private Order order;
        private Seller seller;

        public InvoiceControl()
        {
            InitializeComponent();
            invoice = new Invoice();
            if (platnoscComboBox.Text.Equals("przelew"))
            {
                platnoscNumericUpDown1.Value = 7;
                invoice.payment_deadline = "7";
            }
            invoice.payment_method = platnoscComboBox.Text;
            invoice.payment_deadline = platnoscNumericUpDown1.Value.ToString(); 
            seller = new Seller();
            buyer = new Buyer();
            order = new Order();
            domyslny_sprzedawca();
            nr_faktury();
            
        }

        public Seller updateInvoiceSeller
        {
            get { return seller; }
            set
            {
                seller = value;
                nazwaSprzedtextBox.Text = seller.name;
                kodSprzedtextBox.Text = seller.postCode;
                miejscSprzedtextBox.Text = seller.city;
                adresSprzedtextBox.Text = seller.address;
                nipSprzedtextBox.Text = seller.nip;
                rachunekSprzedBox.Text = seller.rachunek;
                invoice.seller_id = seller.id;
            }
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
                if(uslugaTextBox.Text.Length > 46)
                {
                    //  Size size = TextRenderer.MeasureText(uslugaTextBox.Text, uslugaTextBox.Font);
                    //uslugaTextBox.Width = size.Width;
                    //uslugaTextBox.Height = 40;
                }
                
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
                invoice.issueDate = oldInv.issueDate;
                invoice.sell_date = oldInv.sell_date;
                invoice.sellDate = oldInv.sellDate;
                cenaNettoTextBox.Text = invoice.net;
                //invoice.net = oldInv.net;
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
                invoice.issue_date = wystawdateTimePicker.Value.ToString("dd.MM.yyyy");
                invoice.issueDate = wystawdateTimePicker.Value;
                invoice.sell_date = sprzedazDateTimePicker.Value.ToString("dd.MM.yyyy");
                invoice.sellDate = sprzedazDateTimePicker.Value;
                invoice.payment_deadline = platnoscNumericUpDown1.Value.ToString();
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
                string query = "SELECT * FROM sprzedawca WHERE domyslny = 1";
                //string query = "SELECT * FROM sprzedawca WHERE id =7";
                tablica = db.GetDataTable(query);

                foreach (DataRow r in tablica.Rows)
                {
                    seller.id = int.Parse(r["id"].ToString());
                    nazwaSprzedtextBox.Text = r["nazwa"].ToString();
                    seller.name = r["nazwa"].ToString(); 
                    kodSprzedtextBox.Text = r["kod"].ToString();
                    seller.postCode = r["kod"].ToString();
                    miejscSprzedtextBox.Text = r["miasto"].ToString();
                    seller.city = r["miasto"].ToString();
                    adresSprzedtextBox.Text = r["adres"].ToString();
                    seller.address = r["adres"].ToString();
                    nipSprzedtextBox.Text = r["nip"].ToString();
                    seller.nip = r["nip"].ToString();
                    rachunekSprzedBox.Text = r["rachunek"].ToString();
                    seller.rachunek = r["rachunek"].ToString();
                    seller.signature = r["podpis"].ToString();
                }
                invoice.seller_id = seller.id;
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
                printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

                printDocument1.PrinterSettings.Copies = 2;
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
        protected virtual void OnUpdateInvoicesList(EventArgs e)
        {
            EventHandler eh = UpdateInvoicesList;
            eh?.Invoke(this, e);
        }

        protected void NrFVtextBox_TextChanged(object sender, EventArgs e)
        {
            invoice.no = nrFVtextBox.Text;
        }

        protected void amount_TextChanged(object sender, EventArgs e)
        {
            textBoxBrutto.TextChanged -= amount_TextChanged;
            cenaNettoTextBox.TextChanged -= amount_TextChanged;
            TextBox textBox = (TextBox)sender;
            if(textBox.Text.Length > 0)
            {
                string last = textBox.Text.Substring(textBox.Text.Length - 1);
                if (!last.Equals(","))
                {
                    decimal number;
                    if (Decimal.TryParse(textBox.Text,out number))
                    {
                        if (textBox.Name.Equals("cenaNettoTextBox"))
                        {
                            countAmount(number, true);
                            updateAmounts(true);

                        } else
                        {
                            countAmount(number, false);
                            updateAmounts(false);
                        }

                    } else
                    {
                        if (textBox.Name.Equals("cenaNettoTextBox"))
                        {
                            cenaNettoTextBox.Text = textBox.Text.Remove(textBox.Text.Length - 1,1);
                            cenaNettoTextBox.SelectionStart = cenaNettoTextBox.Text.Length;
                            cenaNettoTextBox.SelectionLength = 0;
                        } else
                        {
                            textBoxBrutto.Text = textBox.Text.Remove(textBox.Text.Length - 1, 1);
                            textBoxBrutto.SelectionStart = textBoxBrutto.Text.Length;
                            textBoxBrutto.SelectionLength = 0;
                        }
                    }
                }
            } else
            {
                clearAmounts();
            }

            textBoxBrutto.TextChanged += amount_TextChanged;
            cenaNettoTextBox.TextChanged += amount_TextChanged;
        }
        private void countAmount(decimal value, bool isNet)
        {
            decimal net;
            decimal gross;
            decimal vat;
            if (isNet)
            {
                net = Decimal.Round(value, 2);
                vat = net * 0.23m;
                vat = Decimal.Round(vat, 2);
                gross = net + vat;
            } else
            {
                gross = Decimal.Round(value, 2);
                net = gross / 1.23m;
                net = Decimal.Round(net, 2);
                vat = gross - net;
            }
            invoice.net = Convert.ToString(net, new CultureInfo("pl-PL"));
            invoice.gross = Convert.ToString(gross, new CultureInfo("pl-PL"));
            invoice.vat = Convert.ToString(vat, new CultureInfo("pl-PL"));
        }

        protected void platnoscComboBox_TextChanged(object sender, EventArgs e)
        {
            invoice.payment_method = platnoscComboBox.Text;
            if (platnoscComboBox.Text.Equals("gotówka"))
            {
                platnoscNumericUpDown1.Value = 0;
                invoice.payment_deadline = "0";
            } else
            {
                platnoscNumericUpDown1.Value = 7;
                invoice.payment_deadline = "7";
            }
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
            invoice.seller_id = seller.id;
            invoice.buyer_id = buyer.id;
            invoice.order_id = order.id;
            invoice.sell_date = sprzedazDateTimePicker.Value.ToString("dd.MM.yyyy");
            invoice.sellDate = sprzedazDateTimePicker.Value;
            invoice.payment_deadline = platnoscNumericUpDown1.Value.ToString();
            invoice.issue_date = wystawdateTimePicker.Value.ToString("dd.MM.yyyy");
            invoice.issueDate = wystawdateTimePicker.Value;
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
                        clearAmounts();
                        clearBuyer();
                        OnUpdateInvoicesList(e);

                    } else
                    {
                        MessageBox.Show(result);
                    }
                } else
                {
                    MessageBox.Show("Numer faktury już istnieje w bazie. Faktura nie została zapisana.");
                }
            } else
            {
                MessageBox.Show("Faktura niekompletna");
            }
        }

        private void updateAmounts(Boolean isNet)
        {
            cenaNettoTextBox.Text = invoice.net;
            textBoxBrutto.Text = invoice.gross;
            textBoxVAT.Text = invoice.vat;
            if (isNet)
            {
                cenaNettoTextBox.SelectionStart = cenaNettoTextBox.Text.Length;
                cenaNettoTextBox.SelectionLength = 0;
            } else
            {
                textBoxBrutto.SelectionStart = textBoxBrutto.Text.Length;
                textBoxBrutto.SelectionLength = 0;
            }
        }
        private void clearAmounts()
        {
            cenaNettoTextBox.Clear();
            textBoxBrutto.Clear();
            textBoxVAT.Clear();
            invoice.net = "";
            invoice.vat = "";
            invoice.gross = "";
        }

        private void clearBuyer()
        {
            nazwaNabtextBox.Clear();
            kodNabtextBox.Clear();
            miejscNabtextBox.Clear();
            adresNabtextBox.Clear();
            nipNabtextBox.Clear();

            invoice.buyer_id = 0;
        }
    }
}
