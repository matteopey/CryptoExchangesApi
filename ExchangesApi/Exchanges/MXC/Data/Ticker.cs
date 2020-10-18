using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExchangesApi.Exchanges.MXC.Data
{
    public class Ticker
    {
        public int Code { get; set; }
        public List<Tick> Data { get; set; }
    }

    public class Tick
    {
        public string Symbol { get; set; }
        public decimal Volume { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public decimal Open { get; set; }
        public decimal Last { get; set; }
        public long Time { get; set; }

        [JsonProperty("change_rate")]
        public string ChangeRate { get; set; }
    }
}
