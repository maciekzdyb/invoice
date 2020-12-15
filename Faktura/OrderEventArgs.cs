using System;

namespace Faktura
{
    public class OrderEventArgs : EventArgs
    {
        public int id;
        public string name;

        public OrderEventArgs(Order order)
        {
            this.id = order.id;
            this.name = order.name;
        }
    }
}
