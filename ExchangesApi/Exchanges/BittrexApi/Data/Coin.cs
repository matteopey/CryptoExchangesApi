namespace ExchangesApi.Exchanges.BittrexApi.Data
{
    public class Coin
    {
        public string Currency { get; set; }
        public string CurrencyLong { get; set; }
        public int MinConfirmation { get; set; }
        public float TxFee { get; set; }
        public bool IsActive { get; set; }
        public string CoinType { get; set; }
        public object BaseAddress { get; set; }
    }
}
