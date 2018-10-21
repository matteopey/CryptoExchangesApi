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

        public async Task<GenericResponse> HistoDay(string fromSymbol, string toSymbol,
            Maybe<string> exchange,
            Maybe<int> aggregate, Maybe<int> limit, Maybe<int> toTs, Maybe<string> allData)
        {
            try
            {
                var content = CreateUrlEncodedParameters(fromSymbol, toSymbol, exchange, aggregate,
                    limit, toTs);
                var response = await downloader.Get("histoday", content);

                return JsonConvert.DeserializeObject<GenericResponse>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GenericResponse> HistoHour(string fromSymbol, string toSymbol,
            Maybe<string> exchange, Maybe<int> aggregate, Maybe<int> limit, Maybe<int> toTs)
        {
            try
            {
                var content = CreateUrlEncodedParameters(fromSymbol, toSymbol, exchange, aggregate,
                    limit, toTs);
                var response = await downloader.Get("histohour", content);

                return JsonConvert.DeserializeObject<GenericResponse>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private Maybe<FormUrlEncodedContent> CreateUrlEncodedParameters(string fsym, string tsym, 
            Maybe<string> e, Maybe<int> aggregate, Maybe<int> limit, Maybe<int> toTs)
        {
            try
            {
                var parameters = new Dictionary<string, string>()
                {
                    {"fsym", fsym},
                    {"tsym", tsym}
                };

                if (e.Any())
                {
                    parameters.Add("e", e.Single());
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

                return new Maybe<FormUrlEncodedContent>(
                    new FormUrlEncodedContent(parameters));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}