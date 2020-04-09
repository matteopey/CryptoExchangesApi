using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ExchangesApi.Exchanges.BittrexApi.ApiCalls;
using ExchangesApi.Exchanges.BittrexApi.Data;
using Newtonsoft.Json;

namespace ExchangesApi.Exchanges.BittrexApi
{
    class PublicMethods
    {
        // Download data handler
        IDownloadData downloader;
        private JsonSerializerSettings jsonSettings;

        public PublicMethods(IDownloadData downloader)
        {
            this.downloader = downloader;

            jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public async Task<Markets> Markets()
        {
            try
            {
                var result = await downloader.Get("getmarkets", new Maybe<FormUrlEncodedContent>());

                return JsonConvert.DeserializeObject<Markets>(result, jsonSettings);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Currencies> Currencies()
        {
            try
            {
                var result =
                    await downloader.Get("getcurrencies", new Maybe<FormUrlEncodedContent>());

                return JsonConvert.DeserializeObject<Currencies>(result, jsonSettings);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Ticker> Ticker(string market)
        {
            try
            {
                var parameters = new Maybe<FormUrlEncodedContent>(new FormUrlEncodedContent(
                    new Dictionary<string, string>()
                    {
                        {"market", market}
                    }
                ));

                var result = await downloader.Get("getticker", parameters);

                return JsonConvert.DeserializeObject<Ticker>(result, jsonSettings);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Summaries> MarketSummaries()
        {
            try
            {
                var result = await downloader.Get("getmarketsummaries",
                    new Maybe<FormUrlEncodedContent>());

                return JsonConvert.DeserializeObject<Summaries>(result, jsonSettings);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Summaries> MarketSummary(string market)
        {
            try
            {
                var parameters = new Maybe<FormUrlEncodedContent>(new FormUrlEncodedContent(
                    new Dictionary<string, string>()
                    {
                        {"market", market}
                    }
                ));

                var result = await downloader.Get("getmarketsummary", parameters);

                return JsonConvert.DeserializeObject<Summaries>(result, jsonSettings);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Orderbook> Orderbook(string market, string type)
        {
            try
            {
                var parameters = new Maybe<FormUrlEncodedContent>(new FormUrlEncodedContent(
                    new Dictionary<string, string>()
                    {
                        {"market", market},
                        {"type", type}
                    }
                ));

                var result = await downloader.Get("getorderbook", parameters);

                // Need to split cases.
                // If the type is not both, API return only an array.
                if (type.Equals("both"))
                {
                    return JsonConvert.DeserializeObject<Orderbook>(result, jsonSettings);
                }

                if (type.Equals("buy"))
                {
                    // Set up
                    var orderbook = new Orderbook();
                    orderbook.Result = new Book();

                    // Deserialize
                    var response =
                        JsonConvert.DeserializeObject<GenericResponse<IList<Book.Tick>>>(result, jsonSettings);

                    // Craft object
                    orderbook.Message = response.Message;
                    orderbook.Success = response.Success;
                    orderbook.Result.buy = response.Result;
                    orderbook.Result.sell = new List<Book.Tick>();
                    return orderbook;
                }

                if (type.Equals("sell"))
                {
                    // Set up
                    var orderbook = new Orderbook();
                    orderbook.Result = new Book();

                    // Deserialize
                    var response =
                        JsonConvert.DeserializeObject<GenericResponse<IList<Book.Tick>>>(result, jsonSettings);

                    // Craft object
                    orderbook.Message = response.Message;
                    orderbook.Success = response.Success;
                    orderbook.Result.buy = new List<Book.Tick>();
                    orderbook.Result.sell = response.Result;
                    return orderbook;
                }

                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<MarketHistory> MarketHistory(string market)
        {
            try
            {
                var parameters = new Maybe<FormUrlEncodedContent>(new FormUrlEncodedContent(
                    new Dictionary<string, string>()
                    {
                        {"market", market}
                    }
                ));

                var result = await downloader.Get("getmarkethistory", parameters);

                return JsonConvert.DeserializeObject<MarketHistory>(result, jsonSettings);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
