
using System;

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
        

        public bool IsCompleted()
        {
            if (no !="" && seller_id >0 && buyer_id > 0 && order_id >0 && issue_date !="" && 
                sell_date !="" && payment_method !="" && payment_deadline !="" && net !="" && vat!="" && gross !="")
            {
                return true;
            }
            return false;
        }

        public decimal getDateDiff(DateTime date1, DateTime date2)
        {
            TimeSpan result = date2 - date1;            
            return Convert.ToDecimal(result.TotalDays);
        }

        public DateTime getDateDiff(DateTime date1, decimal days)
        {
            Double ddays = Convert.ToDouble(days);
            return date1.AddDays(ddays);
        }
    }
}
