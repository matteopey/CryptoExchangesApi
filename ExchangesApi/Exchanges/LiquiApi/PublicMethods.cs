using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExchangesApi.Exchanges.BinanceApi.ApiCalls;
using ExchangesApi.Exchanges.LiquiApi.Data;
using Newtonsoft.Json;

namespace ExchangesApi.Exchanges.LiquiApi
{
    class PublicMethods
    {
        private readonly IDownloadData downloader;

        public PublicMethods(IDownloadData downloader)
        {
            this.downloader = downloader;
        }

        public async Task<MarketsInfo> MarketsInfo()
        {
            try
            {
                var response =
                    await downloader.Get("info", new Maybe<FormUrlEncodedContent>());
                return JsonConvert.DeserializeObject<MarketsInfo>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<MarketsTicker> MarketsTicker(List<string> marketsName)
        {
            try
            {
                if (marketsName.Count == 0)
                {
                    throw new Exception("Markets list can't be empty");
                }

                var dic = new Dictionary<string, string>();
                foreach (var market in marketsName)
                {
                    dic.Add(market, market);
                }

                var parameters = new Maybe<FormUrlEncodedContent>(new FormUrlEncodedContent(dic));

                var response =
                    await downloader.Get("ticker", parameters);
                return JsonConvert.DeserializeObject<MarketsTicker>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<MarketsOrderBook> MarketsOrderBook(List<string> marketsName,
            Maybe<int> limit)
        {
            try
            {
                if (marketsName.Count == 0)
                {
                    throw new Exception("Markets list can't be empty");
                }

                var dic = new Dictionary<string, string>();
                foreach (var market in marketsName)
                {
                    dic.Add(market, market);
                }

                if (limit.Any())
                    dic.Add("limit", limit.Single().ToString());

                var parameters = new Maybe<FormUrlEncodedContent>(new FormUrlEncodedContent(dic));

                var response =
                    await downloader.Get("depth", parameters);
                return JsonConvert.DeserializeObject<MarketsOrderBook>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<MarketsTrades> MarketsTrades(List<string> marketsName, Maybe<int> limit)
        {
            try
            {
                if (marketsName.Count == 0)
                {
                    throw new Exception("Markets list can't be empty");
                }

                var dic = new Dictionary<string, string>();
                foreach (var market in marketsName)
                {
                    dic.Add(market, market);
                }

                if (limit.Any())
                    dic.Add("limit", limit.Single().ToString());

                var parameters = new Maybe<FormUrlEncodedContent>(new FormUrlEncodedContent(dic));

                var response =
                    await downloader.Get("trades", parameters);
                return JsonConvert.DeserializeObject<MarketsTrades>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}