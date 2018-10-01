namespace ExchangesApi.Exchanges.BinanceApi.Data
{
    public class Ticker
    {
        public string Symbol { get; set; }
        public double BidPrice { get; set; }
        public double BidQty { get; set; }
        public double AskPrice { get; set; }
        public double AskQty { get; set; }
    }
}