namespace ExchangesApi.Exchanges.BinanceApi.Data
{
    public class Candle
    {
        public long OpenTime { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
        public long CloseTime { get; set; }
        public double QuoteAssetVolume { get; set; }
        public long NumberOfTrades { get; set; }
        public double TakeBuyBaseAssetVolume { get; set; }
        public double TakeBuyQuoteAssetVolume { get; set; }
    }
}
