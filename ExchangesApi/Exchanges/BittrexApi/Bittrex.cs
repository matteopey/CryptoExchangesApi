using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangesApi.Exchanges.BittrexApi.ApiCalls;
using ExchangesApi.Exchanges.BittrexApi.Data;
using Newtonsoft.Json;

namespace ExchangesApi.Exchanges.BittrexApi
{
    public class Bittrex
    {
        PublicMethods PublicApi;
        PrivateMethods PrivateApi;

        public Bittrex(Maybe<IDownloadData> downloader)
        {
            // If a downloader is not provided, create the default
            if (!downloader.Any())
                downloader = new Maybe<IDownloadData>(
                    new DownloadData(Constants.Endpoint, Constants.PathPublic)
                );

            // We can call Single() safely because we are sure there is only one
            // instance of IDownloadData inside the Maybe
            PublicApi = new PublicMethods(downloader.Single());
            PrivateApi = new PrivateMethods();
        }

        public async Task<Markets> GetMarkets()
        {
            try
            {
                return await PublicApi.Markets();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Currencies> GetCurrencies()
        {
            try
            {
                return await PublicApi.Currencies();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Ticker> GetTicker(string market)
        {
            try
            {
                return await PublicApi.Ticker(market);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Summaries> GetMarketSummaries()
        {
            try
            {
                return await PublicApi.MarketSummaries();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Summaries> GetMarketSummary(string market)
        {
            try
            {
                return await PublicApi.MarketSummary(market);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Orderbook> GetOrderbook(string market, string type)
        {
            try
            {
                return await PublicApi.Orderbook(market, type);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<MarketHistory> GetMarketHistory(string market)
        {
            try
            {
                return await PublicApi.MarketHistory(market);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
