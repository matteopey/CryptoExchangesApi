using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExchangesApi.Exchanges.Hotbit.Data
{
    internal class OrderBookDto
    {
        public string Error { get; set; }
        public int Id { get; set; }
        public ResultDto Result { get; set; }
    }

    internal class ResultDto
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public List<OrderDto> Orders { get; set; }
        public int Total { get; set; }
    }

    internal class OrderDto
    {
        public string Amount { get; set; }
        public float Ctime { get; set; }

        [JsonProperty("Deal_money")]
        public string DealMoney { get; set; }

        [JsonProperty("Deal_stock")]
        public string DealStock { get; set; }

        [JsonProperty("Fee_stock")]
        public string FeeStock { get; set; }

        public long Id { get; set; }
        public string Left { get; set; }
        public string Market { get; set; }
        public float Mtime { get; set; }
        public string Price { get; set; }
        public int Side { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
    }
}
