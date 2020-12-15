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

        void orderControl1_UpdateText(object sender, OrderEventArgs e)
        {
            Order order = new Order();
            order.id = e.id;
            order.name = e.name;
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
            this.invoiceControl1.Hide();
            this.invoicesListControl1.Hide();
            this.sellerControl1.Hide();
            this.buyersControl1.Hide();
            this.orderControl1.Hide();
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
