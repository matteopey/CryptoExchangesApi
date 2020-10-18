using ExchangesApi.Exchanges.Hotbit.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangesApi.Exchanges.Hotbit
{
    public class PublicMethods
    {
        private readonly IDownloadData _downloader;

        public PublicMethods(IDownloadData downloader)
        {
            _downloader = downloader;
        }

        internal async Task<OrderBookDto> OrderBook(string market, int limit, int side, int offset = 0)
        {
            var param = new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                { "market", market },
                { "limit", limit.ToString() },
                { "side", side.ToString() },
                { "offset", offset.ToString() },
            });


            var response = await _downloader.Get("order.book", new Maybe<FormUrlEncodedContent>(param));

            return JsonConvert.DeserializeObject<OrderBookDto>(response);
        }
    }
}
