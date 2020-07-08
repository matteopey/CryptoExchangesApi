using ExchangesApi.Exchanges.CoinbaseProApi.ApiCalls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangesApi.Exchanges.CoinbaseProApi
{
    class PublicMethods
    {
        private readonly IDownloadData _downloadData;

        public PublicMethods(IDownloadData downloadData)
        {
            _downloadData = downloadData;
        }

        public async Task<Currencies> GetCurrencies()
        {
            try
            {
                var req = await GetRequestMessage("currencies", new Maybe<FormUrlEncodedContent>());

                var result = await _downloadData.Send(req);

                return JsonConvert.DeserializeObject<Currencies>(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Products> GetProducts()
        {
            try
            {
                var req = await GetRequestMessage("products", new Maybe<FormUrlEncodedContent>());

                var result = await _downloadData.Send(req);

                return JsonConvert.DeserializeObject<Products>(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ProductTicker> GetProductTicker(string tickerId)
        {
            try
            {
                var req = await GetRequestMessage($"products/{tickerId}/ticker", new Maybe<FormUrlEncodedContent>());

                var result = await _downloadData.Send(req);

                return JsonConvert.DeserializeObject<ProductTicker>(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Candles> GetCandles(
            string productId,
            Maybe<string> startTime,
            Maybe<string> endTime,
            Maybe<string> granaularity)
        {
            try
            {
                var queryParams = new Dictionary<string, string>();

                if (startTime.Any()) queryParams.Add("start", startTime.Single());
                if (endTime.Any()) queryParams.Add("end", endTime.Single());
                if (granaularity.Any()) queryParams.Add("granularity", granaularity.Single());

                var query = new FormUrlEncodedContent(queryParams);

                var req = await GetRequestMessage($"products/{productId}/candles", new Maybe<FormUrlEncodedContent>(query));

                var result = await _downloadData.Send(req);

                return JsonConvert.DeserializeObject<Candles>(result, new CandlesConverter());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<HttpRequestMessage> GetRequestMessage(string method, Maybe<FormUrlEncodedContent> parameters)
        {
            var uri = await _downloadData.CreateUrl(method, parameters);
            var req = new HttpRequestMessage(HttpMethod.Get, uri);

            req.Headers.Add("User-Agent", "xxx");
            req.Headers.Add("Accept", "application/json");

            return req;
        }
    }
}
