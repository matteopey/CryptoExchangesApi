using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangesApi.Exchanges.MXC.Data
{
    public class OrderBook
    {
        public int Code { get; set; }
        public Order Orders { get; set; }

        public class Order
        {
            public List<Ask> Asks { get; set; }
            public List<Bid> Bids { get; set; }
        }

        public class Ask
        {
            public decimal Price { get; set; }
            public decimal Quantity { get; set; }
        }

        public class Bid
        {
            public decimal Price { get; set; }
            public decimal Quantity { get; set; }
        }
    }
}
