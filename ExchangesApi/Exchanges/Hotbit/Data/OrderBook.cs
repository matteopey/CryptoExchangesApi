using System.Collections.Generic;

namespace ExchangesApi.Exchanges.Hotbit.Data
{
    public class OrderBook
    {
        public string Error { get; set; }
        public int Id { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Total { get; set; }
        public List<Order> Asks { get; set; }
        public List<Order> Bids { get; set; }
    }

    public class Order
    {
        public decimal Amount { get; set; }
        public float Ctime { get; set; }
        public decimal DealMoney { get; set; }
        public decimal DealStock { get; set; }
        public long Id { get; set; }
        public decimal Left { get; set; }
        public string Market { get; set; }
        public float Mtime { get; set; }
        public decimal Price { get; set; }
        public int Side { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
    }
}
