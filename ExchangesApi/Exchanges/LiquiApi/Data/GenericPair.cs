namespace ExchangesApi.Exchanges.LiquiApi.Data
{
    public class GenericPair
    {
        public int DecimalPlaces { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public double MinAmount { get; set; }
        public double MaxAmount { get; set; }
        public double MinTotal { get; set; }
        public int Hidden { get; set; }
        public double Fee { get; set; }
    }
}