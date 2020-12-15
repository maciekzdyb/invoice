
namespace Faktura
{
    public class Invoice
    {
        public int id { get; set; }
        public string no { get; set; }
        public int seller_id { get; set; }
        public int buyer_id { get; set; }
        public int order_id { get; set; }
        public string issue_date { get; set; }
        public string sell_date { get; set; }
        public string payment_method { get; set; }
        public string payment_deadline { get; set; }
        public string net { get; set; }
        public string vat { get; set; }
        public string gross { get; set; }
    }
}
