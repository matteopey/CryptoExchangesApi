using ExchangesApi.Exchanges.MXC.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangesApi.Exchanges.MXC
{
    public class PublicMethods
    {
        private readonly IDownloadData _downloader;
        private readonly MxcSecrets _mxcSecrets;

        public PublicMethods(IDownloadData downloader, MxcSecrets mxcSecrets)
        {
            _downloader = downloader;
            _mxcSecrets = mxcSecrets;
        }

        internal async Task<TickerDto> Ticker(string symbol)
        {
            try
            {
                var param = new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                    { "symbol", symbol },
                    { "api_key", _mxcSecrets.ApiKey }
                });

                var response = await _downloader.Get("market/ticker", new Maybe<FormUrlEncodedContent>(param));

                return JsonConvert.DeserializeObject<TickerDto>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        internal async Task<OrderBookDto> OrderBook(string symbol, int depth)
        {
            var param = new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                    { "symbol", symbol },
                    { "depth", depth.ToString() },
                    { "api_key", _mxcSecrets.ApiKey }
                });

            var response = await _downloader.Get("market/depth", new Maybe<FormUrlEncodedContent>(param));

            return JsonConvert.DeserializeObject<OrderBookDto>(response);
        }
    }
}
