namespace ExchangesApi.Exchanges.CryptoCompareApi.ApiCalls
{
    public class Ticker
    {
        public int Time { get; set; }
        public double Close { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double VolumeFrom { get; set; }
        public double VolumeTo { get; set; }
    }
}
