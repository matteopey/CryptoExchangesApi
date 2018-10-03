using System.Collections.Generic;
using Newtonsoft.Json;

namespace ExchangesApi.Exchanges.BittrexApi.Data
{
    public class Book
    {
        [JsonProperty("buy")]
        public IList<Tick> buy { get; set; }

        [JsonProperty("sell")]
        public IList<Tick> sell { get; set; }

        public class Tick
        {
            public float Quantity { get; set; }
            public float Rate { get; set; }
        }
    }
}