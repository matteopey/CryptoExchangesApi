using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangesApi.Exchanges.BinanceApi.ApiCalls
{
    public class BaseWebsocketResponse
    {
        [JsonProperty("stream")]
        public string StreamName { get; set; }
    }
}
