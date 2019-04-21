using System.Collections.Generic;

namespace ExchangesApi.Exchanges.BinanceApi.ApiCalls
{
    public class ExchangeInfo
    {
        public string Timezone { get; set; }
        public long ServerTime { get; set; }
        public IList<RateLimits> RateLimits { get; set; }
        public IList<SymbolTicker> Symbols { get; set; }
    }

    public class RateLimits
    {
        public string RateLimitType { get; set; }
        public string Interval { get; set; }
        public int Limit { get; set; }
    }

    public class SymbolTicker
    {
        public string Symbol { get; set; }
        public string Status { get; set; }
        public string BaseAsset { get; set; }
        public int BaseAssetPrecision { get; set; }
        public string QuoteAsset { get; set; }
        public int QuotePrecision { get; set; }
        public string[] OrderTypes { get; set; }
        public bool IcebergAllowed { get; set; }
        public Filter[] filters { get; set; }
    }

    public class Filter
    {
        public string FilterType { get; set; }
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
        public string TickSize { get; set; }
        public string MinQty { get; set; }
        public string MaxQty { get; set; }
        public string StepSize { get; set; }
        public string MinNotional { get; set; }
    }
}
