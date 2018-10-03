using System;
using System.Collections.Generic;
using System.Text;
using ExchangesApi.Exchanges.BittrexApi;
using Xunit;

namespace ExchangesApi.Tests
{
    public class BittrexTests
    {
        private readonly Maybe<IDownloadData> reader;
        private readonly Bittrex bittrex;

        public BittrexTests()
        {
            reader = new Maybe<IDownloadData>(new LocalDownloader("BittrexData"));
            bittrex = new Bittrex(reader);
        }

        [Fact]
        public async void Currencies()
        {
            var res = await bittrex.GetCurrencies();
            Assert.NotEmpty(res.Result);
        }

        [Fact]
        public async void Markets()
        {
            var res = await bittrex.GetMarkets();
            Assert.NotEmpty(res.Result);
        }

        [Fact]
        public async void TickerInvalidOnline()
        {
            var r = new Maybe<IDownloadData>();
            var b = new Bittrex(r);
            var res = await b.GetTicker("NotValid");
            Assert.Equal("INVALID_MARKET", res.Message);
        }

        [Fact]
        public async void MarketSummaries()
        {
            var res = await bittrex.GetMarketSummaries();
            Assert.NotEmpty(res.Result);
        }

        [Fact]
        public async void MarketSummaryInvalidOnline()
        {
            var r = new Maybe<IDownloadData>();
            var b = new Bittrex(r);
            var res = await b.GetMarketSummary("NotValid");
            Assert.Equal("INVALID_MARKET", res.Message);
        }

        [Fact]
        public async void MarketHistoryInvalidOnline()
        {
            var r = new Maybe<IDownloadData>();
            var b = new Bittrex(r);
            var res = await b.GetMarketHistory("NotValid");
            Assert.Equal("INVALID_MARKET", res.Message);
        }

        [Fact]
        public async void OrderbookBuyOnlyOnline()
        {
            var r = new Maybe<IDownloadData>();
            var b = new Bittrex(r);
            var res = await b.GetOrderbook("BTC-LTC", "buy");
            Assert.NotEmpty(res.Result.buy);
            Assert.Empty(res.Result.sell);
        }

        [Fact]
        public async void OrderbookBothOnline()
        {
            var r = new Maybe<IDownloadData>();
            var b = new Bittrex(r);
            var res = await b.GetOrderbook("BTC-LTC", "both");
            Assert.NotEmpty(res.Result.buy);
            Assert.NotEmpty(res.Result.sell);
        }
    }
}
