using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExchangesApi.Exchanges.CoinbaseProApi.ApiCalls
{
    public class Products : List<Product> { }

    public class Product
    {
        public string Id { get; set; }

        [JsonProperty("base_currency")]
        public string BaseCurrency { get; set; }

        [JsonProperty("quote_currency")]
        public string QuoteCurrency { get; set; }

        [JsonProperty("base_min_size")]
        public string BaseMinSize { get; set; }

        [JsonProperty("base_max_size")]
        public string BaseMaxSize { get; set; }

        [JsonProperty("quote_increment")]
        public string QuoteIncrement { get; set; }

        [JsonProperty("base_increment")]
        public string BaseIncrement { get; set; }

        [JsonProperty("display_name")]
        public string DisplayMame { get; set; }

        [JsonProperty("min_market_funds")]
        public string MinMarketFunds { get; set; }

        [JsonProperty("max_market_funds")]
        public string MaxMarketFunds { get; set; }

        [JsonProperty("margin_enabled")]
        public bool MarginEnabled { get; set; }

        [JsonProperty("post_only")]
        public bool PostOnly { get; set; }

        [JsonProperty("limit_only")]
        public bool LimitOnly { get; set; }

        [JsonProperty("cancel_only")]
        public bool Cancelonly { get; set; }

        [JsonProperty("trading_disabled")]
        public bool TradingDisabled { get; set; }

        public string Status { get; set; }

        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }
    }

}
