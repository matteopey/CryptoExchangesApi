using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangesApi.Exchanges.LiquiApi.Data;

namespace ExchangesApi.Exchanges.LiquiApi
{
    public class Liqui
    {
        PublicMethods PublicApi;
        PrivateMethods PrivateApi;

        public Liqui(Maybe<IDownloadData> downloader)
        {
            // If a downloader is not provided, create the default
            if (!downloader.Any())
                downloader = new Maybe<IDownloadData>(
                    new DownloadDataLiqui(Constants.Endpoint, Constants.AbsolutePath)
                );

            PublicApi = new PublicMethods(downloader.Single());
            PrivateApi = new PrivateMethods();
        }

        public async Task<MarketsInfo> MarketsInfo()
        {
            try
            {
                return await PublicApi.MarketsInfo();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<MarketsTicker> MarketsTicker(List<string> markets)
        {
            try
            {
                return await PublicApi.MarketsTicker(markets);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<MarketsOrderBook> MarketsOrderBook(List<string> markets,
            Maybe<int> limit)
        {
            try
            {
                return await PublicApi.MarketsOrderBook(markets, limit);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<MarketsTrades> MarketsTrades(List<string> markets,
            Maybe<int> limit)
        {
            try
            {
                return await PublicApi.MarketsTrades(markets, limit);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}