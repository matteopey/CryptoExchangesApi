using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangesApi.Exchanges.BinanceApi.ApiCalls
{
    public class AllMarketTickersStream : BaseWebsocketResponse
    {
        public List<StreamTicker> Data { get; set; }
    }

    public class StreamTicker
    {
        [JsonProperty("e")]
        public string EventType { get; set; }

        [JsonProperty("E")]
        public long EventTime { get; set; }

        [JsonProperty("s")]
        public string Symbol { get; set; }

        [JsonProperty("p")]
        public double PriceChange { get; set; }

        [JsonProperty("P")]
        public double PriceChangePercent { get; set; }

        [JsonProperty("w")]
        public double WeightedAveragePrice { get; set; }

        [JsonProperty("x")]
        public double FirstTrade { get; set; }

        [JsonProperty("c")]
        public double LastPrice { get; set; }

        [JsonProperty("Q")]
        public double LastQuantity { get; set; }

        [JsonProperty("b")]
        public double BidPrice { get; set; }

        [JsonProperty("B")]
        public double BidQuantity { get; set; }

        [JsonProperty("a")]
        public double AskPrice { get; set; }

        [JsonProperty("A")]
        public double AskQuantity { get; set; }

        [JsonProperty("o")]
        public double Open { get; set; }

        [JsonProperty("h")]
        public double High { get; set; }

        [JsonProperty("l")]
        public double Low { get; set; }

        [JsonProperty("v")]
        public double TotalTradedBaseAsset { get; set; }

        [JsonProperty("q")]
        public double TotalTradedQuoteAsset { get; set; }

        [JsonProperty("O")]
        public long OpenTime { get; set; }

        [JsonProperty("C")]
        public long CloseTime { get; set; }

        [JsonProperty("F")]
        public long FirstTradeId { get; set; }

        [JsonProperty("L")]
        public long LastTradeId { get; set; }

        [JsonProperty("n")]
        public long TotalNumberOfTrades { get; set; }
    }
}
