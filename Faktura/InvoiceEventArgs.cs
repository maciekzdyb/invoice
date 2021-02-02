using System;

namespace Faktura
{
    public class InvoiceEventArgs : EventArgs
    {
        public int buyer_id { get; }
        public int order_id { get; }
        public string payment_method { get; }
        public string net { get; }
        public string vat { get; }

        public InvoiceEventArgs(Invoice invoice)
        {
            buyer_id = invoice.buyer_id;
            order_id = invoice.order_id;
            payment_method = invoice.payment_method;
            net = invoice.net;
            vat = invoice.vat;
        }
    }
}
