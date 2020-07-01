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
        private readonly PublicMethods _publicApi;
        private readonly PrivateMethods _privateApi;

        public Bittrex(Maybe<IDownloadData> downloader)
        {
            // If a downloader is not provided, create the default
            if (!downloader.Any())
                downloader = new Maybe<IDownloadData>(
                    new DownloadData(Constants.Endpoint, Constants.PathPublic)
                );

            // We can call Single() safely because we are sure there is only one
            // instance of IDownloadData inside the Maybe
            _publicApi = new PublicMethods(downloader.Single());
            _privateApi = new PrivateMethods();
        }

        public async Task<Markets> GetMarkets()
        {
            try
            {
                return await _publicApi.Markets();
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
                return await _publicApi.Currencies();
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
                return await _publicApi.Ticker(market);
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
                return await _publicApi.MarketSummaries();
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
                return await _publicApi.MarketSummary(market);
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
                return await _publicApi.Orderbook(market, type);
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
                return await _publicApi.MarketHistory(market);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
