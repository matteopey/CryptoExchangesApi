using System;
using System.Collections.Generic;
using System.Text;
using ExchangesApi.Exchanges.LiquiApi;
using Xunit;

namespace ExchangesApi.Tests
{
    public class LiquiTests
    {
        private readonly Maybe<IDownloadData> reader;
        private readonly Liqui liqui;

        public LiquiTests()
        {
            reader = new Maybe<IDownloadData>(new LocalDownloader("LiquiData"));
            liqui = new Liqui(reader);
        }

        [Fact]
        public async void MarketsInfoOnline()
        {
            var l = new Liqui(new Maybe<IDownloadData>());
            var res = await l.MarketsInfo();

            Assert.NotEmpty(res.Pairs);
        }

        [Fact]
        public async void MarketsTickerEmptyOnline_Throws()
        {
            var l = new Liqui(new Maybe<IDownloadData>());

            await Assert.ThrowsAsync<Exception>(() => l.MarketsTicker(new List<string>()));
        }

        [Fact]
        public async void MarketsTickerSingleOnline()
        {
            var l = new Liqui(new Maybe<IDownloadData>());
            var res = await l.MarketsTicker(new List<string> {"eth_btc"});

            Assert.Single(res);
        }

        [Fact]
        public async void MarketsTickerMultipleOnline()
        {
            var l = new Liqui(new Maybe<IDownloadData>());
            var res = await l.MarketsTicker(new List<string> {"eth_btc", "ltc_btc"});

            Assert.Equal(2, res.Count);
        }

        [Fact]
        public async void MarketsOrderBookOnline()
        {
            var l = new Liqui(new Maybe<IDownloadData>());
            var res = await l.MarketsOrderBook(new List<string> {"eth_btc", "ltc_btc"},
                new Maybe<int>());

            Assert.Equal(2, res.Count);
        }

        [Fact]
        public async void MarketsOrderBookLimitOnline()
        {
            var l = new Liqui(new Maybe<IDownloadData>());
            var res = await l.MarketsOrderBook(new List<string> { "eth_btc", "ltc_btc" },
                new Maybe<int>(10));

            Assert.Equal(10, res["eth_btc"]["asks"].Count);
            Assert.Equal(10, res["eth_btc"]["bids"].Count);
        }
    }
}
