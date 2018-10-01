using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ExchangesApi.Exchanges.BinanceApi.ApiCalls;
using Newtonsoft.Json;

namespace ExchangesApi.Exchanges.BinanceApi
{
    public class PublicMethods
    {
        private readonly IDownloadData downloader;

        public PublicMethods(IDownloadData downloader)
        {
            this.downloader = downloader;
        }

        public async Task<ExchangeInfo> ExchangeInfo()
        {
            try
            {
                var response =
                    await downloader.Get("exchangeInfo", new Maybe<FormUrlEncodedContent>());
                return JsonConvert.DeserializeObject<ExchangeInfo>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Orderbook> Depth(string symbol, string limit = "100")
        {
            try
            {
                var content = new Maybe<FormUrlEncodedContent>(new FormUrlEncodedContent(
                    new Dictionary<string, string>()
                    {
                        {"symbol", symbol},
                        {"limit", limit}
                    }
                ));

                var response = await downloader.Get("depth", content);
                return JsonConvert.DeserializeObject<Orderbook>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}