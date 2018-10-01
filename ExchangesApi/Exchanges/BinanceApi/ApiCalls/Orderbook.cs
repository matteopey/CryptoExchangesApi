using System.Collections.Generic;
using System.Globalization;
using ExchangesApi.Exchanges.BinanceApi.Data;
using Newtonsoft.Json;

namespace ExchangesApi.Exchanges.BinanceApi.ApiCalls
{
    public interface IOrderBook
    {
        IList<Order> Asks { get; }
        IList<Order> Bids { get; }
    }

    public class Orderbook : IOrderBook
    {
        public int LastUpdateId { get; set; }

        [JsonProperty("asks")]
        private IList<object[]> AsksInternal
        {
            set { Asks = ParseOrders(value); }
        }

        public IList<Order> Asks { get; private set; }

        [JsonProperty("bids")]
        private IList<object[]> BidsInternal
        {
            set { Bids = ParseOrders(value); }
        }

        public IList<Order> Bids { get; private set; }

        private static IList<Order> ParseOrders(IList<object[]> orders)
        {
            var output = new List<Order>(orders.Count);
            for (var i = 0; i < orders.Count; i++)
            {
                var ps = (string) orders[i][0];
                var qs = (string) orders[i][1];

                output.Add(
                    new Order(
                        double.Parse(ps, CultureInfo.InvariantCulture),
                        double.Parse(qs, CultureInfo.InvariantCulture)
                    )
                );
            }

            return output;
        }
    }
}