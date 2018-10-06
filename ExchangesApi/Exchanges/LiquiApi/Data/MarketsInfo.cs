using System.Collections.Generic;

namespace ExchangesApi.Exchanges.LiquiApi.Data
{
    public class MarketsInfo
    {
        public int server_time { get; set; }
        public IDictionary<string, GenericPair> Pairs { get; set; }
    }
}