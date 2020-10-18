using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExchangesApi.Exchanges.MXC.Data
{
    internal class TickerDto
    {
        public int Code { get; set; }
        public List<Datum> Data { get; set; }
    }

    internal class Datum
    {
        public string Symbol { get; set; }
        public string Volume { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Bid { get; set; }
        public string Ask { get; set; }
        public string Open { get; set; }
        public string Last { get; set; }
        public long Time { get; set; }

        [JsonProperty("change_rate")]
        public string ChangeRate { get; set; }
    }

}
