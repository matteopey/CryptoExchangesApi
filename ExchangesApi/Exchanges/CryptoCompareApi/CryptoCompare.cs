using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangesApi.Exchanges.CryptoCompareApi.ApiCalls;

namespace ExchangesApi.Exchanges.CryptoCompareApi
{
    public class CryptoCompare
    {
        private Api api;

        public CryptoCompare(Maybe<IDownloadData> downloader)
        {
            // If a downloader is not provided, create the default
            if (!downloader.Any())
                downloader = new Maybe<IDownloadData>(
                    new DownloadData(Constants.Endpoint, Constants.AbsolutePath)
                );

            api = new Api(downloader.Single());
        }

        public async Task<GenericResponse> HistoDay(string fromSymbol, string toSymbol,
            Maybe<string> exchange,
            Maybe<int> aggregate, Maybe<int> limit, Maybe<int> toTs, Maybe<string> allData)
        {
            return await api.HistoDay(fromSymbol, toSymbol, exchange, aggregate, limit, toTs,
                allData);
        }

        public async Task<GenericResponse> HistoHour(string fromSymbol, string toSymbol,
            Maybe<string> exchange,
            Maybe<int> aggregate, Maybe<int> limit, Maybe<int> toTs)
        {
            return await api.HistoHour(fromSymbol, toSymbol, exchange, aggregate, limit, toTs);
        }
    }
}
