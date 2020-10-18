using System.Collections.Generic;

namespace ExchangesApi.Exchanges.MXC.Data
{
    internal class OrderBookDto
    {
        public int Code { get; set; }
        public Datum Data { get; set; }

        internal class Datum
        {
            public List<Ask> Asks { get; set; }
            public List<Bid> Bids { get; set; }
        }

        internal class Ask
        {
            public string Price { get; set; }
            public string Quantity { get; set; }
        }

        internal class Bid
        {
            public string Price { get; set; }
            public string Quantity { get; set; }
        }
    }
}
