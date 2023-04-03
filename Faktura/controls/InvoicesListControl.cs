using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Faktura
{
    public partial class InvoicesListControl : UserControl
    {
        private Invoice invoice;
        private Buyer buyer;
        private Seller seller;
        private Order order;
        public event EventHandler<InvoiceEventArgs> UpdateText;
        public InvoicesListControl()
        {
            InitializeComponent();
            fillDataGridFaktury();
            printDocument2.PrintPage += new PrintPageEventHandler(printDocument2_PrintPage);
        }

        public void fillDataGridFaktury()
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
                if (count == "0")
                {
                    string resetQUery = "UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE NAME = 'faktura'";
                    db.ExecuteScalar(resetQUery);
                }
                else
                {
                    //string query = "SELECT * FROM faktura";
                    string query = "SELECT faktura.nr \"NrFV\", nabywca.nazwa \"Nabywca\", usluga.nazwa \"Usługa\", faktura.netto \"Netto\", faktura.vat \"VAT\", faktura.brutto \"Brutto\", faktura.data_wyst \"Wystawiona\" FROM faktura,nabywca,usluga";
                    query += " WHERE ((nabywca.id = faktura.id_nabywca) AND (usluga.id = faktura.id_usluga)) ORDER BY faktura.id DESC";
                    recipe = db.GetDataTable(query);
                    //dataGridViewFaktury.Update();
                    dataGridViewFaktury.Refresh();
                    dataGridViewFaktury.DataSource = recipe;

                    dataGridViewFaktury.Columns[0].Visible = false;
                    dataGridViewFaktury.Columns[1].Width = 294;
                    dataGridViewFaktury.Columns[2].Width = 310;
                    dataGridViewFaktury.Columns[3].Width = 60;
                    dataGridViewFaktury.Columns[4].Width = 60;
                    dataGridViewFaktury.Columns[5].Width = 65;
                    dataGridViewFaktury.Columns[6].Width = 70;
                }
            }
            catch (Exception fail)
            {
                MessageBox.Show("Fail: " + fail.Message);
            }
        }

        private void dataGridViewFaktury_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridViewFaktury.CurrentCell.RowIndex;
            string invoiceNo = dataGridViewFaktury[0, row].Value.ToString();
            SQLiteDatabase db = new SQLiteDatabase();
            invoice = db.getInvoice(invoiceNo);
            invoice.issueDate = invoice.convert2DateTime(invoice.issue_date);
            invoice.sellDate = invoice.convert2DateTime(invoice.sell_date);
            textBoxInvNo.Text = invoice.no;
        }

        private void btnPrintSelected_Click(object sender, EventArgs e)
        {
            if(textBoxInvNo.Text != "")
            {
                SQLiteDatabase db = new SQLiteDatabase();
                buyer = db.getBuyer(invoice.buyer_id);
                seller = db.getSeller(invoice.seller_id);
                order = db.getOrder(invoice.order_id);
                printPreviewDialog2.Document = printDocument2;
                printPreviewDialog2.ShowDialog();

            }

        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            Printing printing = new Printing();
            printing.printContent(e, this, invoice, seller, buyer, order);
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            if (textBoxInvNo.Text != "")
            {
                this.Hide();
                OnUpdateText(new InvoiceEventArgs(invoice));
            }
        }

        protected virtual void OnUpdateText(InvoiceEventArgs e)
        {
            EventHandler<InvoiceEventArgs> eh = UpdateText;
            if (eh != null)
                eh(this, e);
        }

    }
}
