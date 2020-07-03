using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangesApi.Exchanges.CoinbaseProApi.Model
{
    public class SubscribeMessage
    {
        public string Type { get; set; }

        [JsonProperty("product_ids")]
        public List<string> ProductsIds { get; set; }

        public List<string> Channels { get; set; }
    }
}
