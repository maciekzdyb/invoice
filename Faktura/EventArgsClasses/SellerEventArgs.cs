using System;

namespace Faktura
{
    public class SellerEventArgs : EventArgs
    {
        public int id { get; }
        public string name { get; }
        public string postCode { get; }
        public string city { get; }
        public string address { get; }
        public string nip { get; }
        public string rachunek { get; }

        public SellerEventArgs(Seller seller)
        {
            this.id = seller.id;
            this.name = seller.name;
            this.postCode = seller.postCode;
            this.city = seller.city;
            this.address = seller.address;
            this.nip = seller.nip;
            this.rachunek = seller.rachunek;
        }
    }
}
