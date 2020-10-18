using ExchangesApi.Exchanges.Hotbit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangesApi.Exchanges.Hotbit
{
    public class HotBit
    {
        private readonly PublicMethods _publicApi;

        public HotBit(Maybe<IDownloadData> downloader)
        {
            // If a downloader is not provided, create the default
            if (!downloader.Any())
            {
                downloader = new Maybe<IDownloadData>(
                    new DownloadData(Constants.Endpoint, Constants.AbsolutePath)
                );
            }

            // We can call Single() safely because we are sure there is only one
            // instance of IDownloadData inside the Maybe
            _publicApi = new PublicMethods(downloader.Single());
        }

        public async Task<OrderBook> OrderBook(string market, int limit, int offset = 0)
        {
            try
            {
                OrderBookDto sellOrders = await _publicApi.OrderBook(market, limit, 1, offset);
                OrderBookDto buyOrders = await _publicApi.OrderBook(market, limit, 2, offset);

                var res = new OrderBook()
                {
                    Error = buyOrders.Error,
                    Id = buyOrders.Id,
                    Bids = new List<Order>(),
                    Asks = new List<Order>(),
                    Limit = limit,
                    Offset = offset,
                    Total = sellOrders.Result.Total + buyOrders.Result.Total
                };

                foreach (var order in sellOrders.Result.Orders)
                {
                    res.Asks.Add(ParseOrder(order));
                }

                foreach (var order in buyOrders.Result.Orders)
                {
                    res.Bids.Add(ParseOrder(order));
                }

                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private Order ParseOrder(OrderDto order)
        {
            return new Order
            {
                Amount = ParseDecimal(order.Amount),
                Ctime = order.Ctime,
                DealMoney = ParseDecimal(order.DealMoney),
                DealStock = ParseDecimal(order.DealStock),
                Id = order.Id,
                Left = ParseDecimal(order.Left),
                Market = order.Market,
                Mtime = order.Mtime,
                Price = ParseDecimal(order.Price),
                Side = order.Side,
                Status = order.Status,
                Type = order.Type
            };
        }

        private decimal ParseDecimal(string value)
        {
            if (decimal.TryParse(value, out decimal result))
            {
                return result;
            }

            return 0;
        }
    }
}
