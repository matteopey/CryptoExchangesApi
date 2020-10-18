using ExchangesApi.Exchanges.MXC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangesApi.Exchanges.MXC
{
    public class Mxc
    {
        private readonly PublicMethods _publicApi;

        public Mxc(Maybe<IDownloadData> downloader, MxcSecrets mxcSecrets)
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
            _publicApi = new PublicMethods(downloader.Single(), mxcSecrets);
        }

        public async Task<Ticker> Ticker(string symbol)
        {
            try
            {
                TickerDto orderBookDto = await _publicApi.Ticker(symbol);

                var res = new Ticker()
                {
                    Code = orderBookDto.Code,
                    Data = new List<Tick>()
                };

                foreach (var order in orderBookDto.Data)
                {
                    res.Data.Add(new Tick
                    {
                        Ask = ParseDecimal(order.Ask),
                        Bid = ParseDecimal(order.Bid),
                        ChangeRate = order.ChangeRate,
                        High = ParseDecimal(order.High),
                        Last = ParseDecimal(order.Last),
                        Low = ParseDecimal(order.Low),
                        Open = ParseDecimal(order.Open),
                        Symbol = order.Symbol,
                        Time = order.Time,
                        Volume = ParseDecimal(order.Volume),
                    });
                }

                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<OrderBook> OrderBook(string symbol, int depth)
        {
            if (depth <= 0 || depth > 2000)
            {
                throw new Exception($"Depth {depth} is outside bounds");
            }

            try
            {
                OrderBookDto orderBookDto = await _publicApi.OrderBook(symbol, depth);

                var res = new OrderBook()
                {
                    Code = orderBookDto.Code,
                    Orders = new OrderBook.Order()
                    {
                        Asks = new List<OrderBook.Ask>(),
                        Bids = new List<OrderBook.Bid>()
                    }
                };

                foreach (var order in orderBookDto.Data.Asks)
                {
                    res.Orders.Asks.Add(new OrderBook.Ask
                    {
                        Price = ParseDecimal(order.Price),
                        Quantity = ParseDecimal(order.Quantity),
                    });
                }

                foreach (var order in orderBookDto.Data.Bids)
                {
                    res.Orders.Bids.Add(new OrderBook.Bid
                    {
                        Price = ParseDecimal(order.Price),
                        Quantity = ParseDecimal(order.Quantity),
                    });
                }

                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
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
