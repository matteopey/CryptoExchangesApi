using Newtonsoft.Json;
using System;

namespace ExchangesApi.Exchanges.CoinbaseProApi.ApiCalls
{
    public class ProductTicker
    {
        [JsonProperty("trade_id")]
        public int TradeId { get; set; }

        public string Price { get; set; }
        public string Size { get; set; }
        public DateTime Time { get; set; }
        public string Bid { get; set; }
        public string Ask { get; set; }
        public string Volume { get; set; }
    }

}
