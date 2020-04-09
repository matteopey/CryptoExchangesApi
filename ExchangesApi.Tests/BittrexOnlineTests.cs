using ExchangesApi.Exchanges.BittrexApi;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ExchangesApi.Tests
{
    public class BittrexOnlineTests
    {
        private readonly Maybe<IDownloadData> reader;
        private readonly Bittrex bittrex;

        public BittrexOnlineTests()
        {
            reader = new Maybe<IDownloadData>();
            bittrex = new Bittrex(reader);
        }

        [Fact]
        public async void GetCurrencies()
        {
            var res = await bittrex.GetCurrencies();
            Assert.NotEmpty(res.Result);
        }

        [Fact]
        public async void GetMarkets()
        {
            var res = await bittrex.GetMarkets();
            Assert.NotEmpty(res.Result);
        }

        [Fact]
        public async void GetMarketSummaries()
        {
            var res = await bittrex.GetMarketSummaries();

            Assert.NotEmpty(res.Result);
        }

        [Fact]
        public async void GetTicker()
        {
            var res = await bittrex.GetTicker("BTC-ETH");

            Assert.NotNull(res.Result);
        }

        [Fact]
        public async void GetMarketSummary()
        {
            var res = await bittrex.GetMarketSummary("BTC-ETH");

            Assert.NotNull(res.Result);
        }

        [Fact]
        public async void GetOrderbook()
        {
            var res = await bittrex.GetOrderbook("BTC-ETH", "buy");

            Assert.NotNull(res.Result);
        }

        [Fact]
        public async void GetMarketHistory()
        {
            var res = await bittrex.GetMarketHistory("BTC-ETH");

            Assert.NotNull(res.Result);
        }
    }
}
