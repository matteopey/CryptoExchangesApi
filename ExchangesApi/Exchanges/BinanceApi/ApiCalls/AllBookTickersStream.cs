using Newtonsoft.Json;

namespace ExchangesApi.Exchanges.BinanceApi.ApiCalls
{
    public class AllBookTickersStream : BaseWebsocketResponse
    {
        public StreamBookTicker Data { get; set; }
    }

    public class StreamBookTicker
    {
        [JsonProperty("u")]
        public long UpdateId { get; set; }

        [JsonProperty("s")]
        public string Symbol { get; set; }

        [JsonProperty("b")]
        public double BidPrice { get; set; }

        [JsonProperty("B")]
        public double BidQuantity { get; set; }

        [JsonProperty("a")]
        public double AskPrice { get; set; }

        [JsonProperty("A")]
        public double AskQuantity { get; set; }
    }
}
