using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ExchangesApi.Exchanges.CryptoCompareApi.ApiCalls;
using Newtonsoft.Json;

namespace ExchangesApi.Exchanges.CryptoCompareApi
{
    class Api
    {
        private readonly IDownloadData downloader;

        public Api(IDownloadData downloader)
        {
            this.downloader = downloader;
        }

        public async Task<HistoDay> HistoDay(string fromSymbol, string toSymbol,
            Maybe<string> exchange,
            Maybe<int> aggregate, Maybe<int> limit, Maybe<int> toTs, Maybe<string> allData)
        {
            try
            {
                var parameters = new Dictionary<string, string>()
                {
                    {"fsym", fromSymbol},
                    {"tsym", toSymbol}
                };

                if (exchange.Any())
                {
                    parameters.Add("e", exchange.Single());
                }

                if (aggregate.Any())
                {
                    parameters.Add("aggregate", aggregate.Single().ToString());
                }

                if (limit.Any())
                {
                    parameters.Add("limit", limit.Single().ToString());
                }

                if (toTs.Any())
                {
                    parameters.Add("toTs", toTs.Single().ToString());
                }

                if (allData.Any())
                {
                    parameters.Add("allData", allData.Single());
                }

                var content = new Maybe<FormUrlEncodedContent>(
                    new FormUrlEncodedContent(parameters));

                var response = await downloader.Get("histoday", content);

                return JsonConvert.DeserializeObject<HistoDay>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<HistoHour> HistoHour(string fromSymbol, string toSymbol,
            Maybe<string> exchange,
            Maybe<int> aggregate, Maybe<int> limit, Maybe<int> toTs)
        {
            try
            {
                var parameters = new Dictionary<string, string>()
                {
                    {"fsym", fromSymbol},
                    {"tsym", toSymbol}
                };

                if (exchange.Any())
                {
                    parameters.Add("e", exchange.Single());
                }

                if (aggregate.Any())
                {
                    parameters.Add("aggregate", aggregate.Single().ToString());
                }

                if (limit.Any())
                {
                    parameters.Add("limit", limit.Single().ToString());
                }

                if (toTs.Any())
                {
                    parameters.Add("toTs", toTs.Single().ToString());
                }

                var content = new Maybe<FormUrlEncodedContent>(
                    new FormUrlEncodedContent(parameters));

                var response = await downloader.Get("histohour", content);

                return JsonConvert.DeserializeObject<HistoHour>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}