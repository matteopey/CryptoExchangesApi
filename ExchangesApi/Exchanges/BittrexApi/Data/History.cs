using System;

namespace ExchangesApi.Exchanges.BittrexApi.Data
{
    public class History
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }
        public float Total { get; set; }
        public string FillType { get; set; }
        public string OrderType { get; set; }
    }
}
