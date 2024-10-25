using System;

namespace Faktura
{
    public class BuyerEventArgs : EventArgs
    {
        public int id { get; }
        public string name { get; }
        public string postCode { get; }
        public string city { get; }
        public string address { get; }
        public string nip { get; }

        public BuyerEventArgs(Buyer buyer)
        {
            this.id = buyer.id;
            this.name = buyer.name;
            this.postCode = buyer.postCode;
            this.city = buyer.city;
            this.address = buyer.address;
            this.nip = buyer.nip;
        } 
        
    }
}
