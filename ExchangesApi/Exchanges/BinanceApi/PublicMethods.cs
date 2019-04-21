using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ExchangesApi.Exchanges.BinanceApi.ApiCalls;
using ExchangesApi.Exchanges.BinanceApi.Data;
using Newtonsoft.Json;

namespace ExchangesApi.Exchanges.BinanceApi
{
    class PublicMethods
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

        public async Task<List<Ticker>> BookTicker(Maybe<string> symbol)
        {
            try
            {
                Maybe<FormUrlEncodedContent> content;

                if (!symbol.Any())
                {
                    content = new Maybe<FormUrlEncodedContent>();
                }
                else
                    content = new Maybe<FormUrlEncodedContent>(new FormUrlEncodedContent(
                        new Dictionary<string, string>()
                        {
                            {"symbol", symbol.Single()}
                        }
                    ));

                var response = await downloader.Get("ticker/bookTicker", content);
                return JsonConvert.DeserializeObject<List<Ticker>>(response,
                    new SingleOrArrayConverter<Ticker>());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
