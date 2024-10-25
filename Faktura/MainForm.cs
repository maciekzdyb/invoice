using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Faktura
{
    public partial class MainForm : Form
    {
        private List<UserControl> list;
        public MainForm()
        {
            InitializeComponent();
            list = initializeControlsList();
            buyersControl1.UpdateText += new EventHandler<BuyerEventArgs>(buyersControl1_UpdateText);
            orderControl1.UpdateText += new EventHandler<OrderEventArgs>(orderControl1_UpdateText);
            sellerControl1.UpdateText += new EventHandler<SellerEventArgs>(sellerControl1_UpdateText);
            invoicesListControl1.UpdateText += new EventHandler<InvoiceEventArgs>(invoicesListControl1_UpdateText);
            invoiceControl1.UpdateInvoicesList += new EventHandler(invoiceControl1_UpdateInvoicesList);
            invoiceControl1.ShowBuyers += new EventHandler(invoiceControl1_ShowBuyers);
            invoiceControl1.ShowOrders += new EventHandler(orderControl1_ShowOrders);
        }

        void invoiceControl1_ShowBuyers(object sender, EventArgs e)
        {
            showUserControl(buyersControl1);
        }

        void orderControl1_ShowOrders(object sender, EventArgs e)
        {
            showUserControl(orderControl1);
        }

        void invoicesListControl1_ShowInvoice(object sender, EventArgs e)
        {
            showUserControl(invoiceControl1);
        }

        void sellerControl1_UpdateText(object sender, SellerEventArgs e)
        {
            Seller seller = new Seller();
            seller.id = e.id;
            seller.name = e.name;
            seller.address = e.address;
            seller.city = e.city;
            seller.nip = e.nip;
            seller.postCode = e.postCode;
            seller.rachunek = e.rachunek;
            invoiceControl1.updateInvoiceSeller = seller;
        }

        void buyersControl1_UpdateText(object sender, BuyerEventArgs e)
        {
            Buyer buyer = new Buyer();
            buyer.id = e.id;
            buyer.name = e.name;
            buyer.address = e.address;
            buyer.city = e.city;
            buyer.nip = e.nip;
            buyer.postCode = e.postCode;
            invoiceControl1.updateInvoiceBuyer = buyer;
            showUserControl(invoiceControl1);
        }

        void invoiceControl1_UpdateInvoicesList(object sender, EventArgs e)
        {
            invoicesListControl1.fillDataGridFaktury();
        }

        void orderControl1_UpdateText(object sender, OrderEventArgs e)
        {
            Order order = new Order();
            order.id = e.id;
            order.name = e.name;
            invoiceControl1.updateOrder = order;
            showUserControl(invoiceControl1);
        }

        void invoicesListControl1_UpdateText(object sender, InvoiceEventArgs e)
        {
            Invoice invoice = new Invoice();
            SQLiteDatabase db = new SQLiteDatabase();
            Buyer buyer = db.getBuyer(e.buyer_id);
            SQLiteDatabase db1 = new SQLiteDatabase();
            Order order = db1.getOrder(e.order_id);
            invoice.buyer_id = e.buyer_id;
            invoice.order_id = e.order_id;
            invoice.payment_method = e.payment_method;
            invoice.vat = e.vat;
            invoice.net = e.net;
            invoiceControl1.updateInvoice = invoice;
            invoiceControl1.updateInvoiceBuyer = buyer;
            invoiceControl1.updateOrder = order;
            showUserControl(invoiceControl1);
        }

        public void showUserControl(UserControl control)
        {
            list.ForEach(c => {
                if (c.Name == control.Name)
                {
                    c.Show();
                }
                else
                {
                    c.Hide();
                }
            });
        }

        private List<UserControl> initializeControlsList()
        {
            invoiceControl1.Hide();
            invoicesListControl1.Hide();
            sellerControl1.Hide();
            buyersControl1.Hide();
            orderControl1.Hide();
            List<UserControl> list = new List<UserControl>();
            list.Add(this.invoiceControl1);
            list.Add(this.invoicesListControl1);
            list.Add(this.sellerControl1);
            list.Add(this.buyersControl1);
            list.Add(this.orderControl1);
            return list;
        }

        private void nowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showUserControl(this.invoiceControl1);
        }

        private void sprzedawcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showUserControl(this.sellerControl1);
        }

        private void wystawioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showUserControl(this.invoicesListControl1);
        }

        private void nabywcyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showUserControl(this.buyersControl1);
        }

        private void usługaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showUserControl(this.orderControl1);
        }

    }
}
