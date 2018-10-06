namespace ExchangesApi.Exchanges.LiquiApi.Data
{
    public class GenericTrade
    {
        public string Type { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public int Tid { get; set; }
        public int TimeStamp { get; set; }
    }
}