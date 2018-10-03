using Xunit;
using ExchangesApi.Exchanges.BinanceApi;

namespace ExchangesApi.Tests
{
    public class BinanceTests
    {
        private readonly Maybe<IDownloadData> reader;
        private readonly Binance binance;

        public BinanceTests()
        {
            reader = new Maybe<IDownloadData>(new LocalDownloader("BinanceData"));
            binance = new Binance(reader);
        }

        [Fact]
        public async void ExchangeInfo()
        {
            var res = await binance.ExchangeInfo();
        }

        [Fact]
        public async void ExchangeInfoOnline()
        {
            var r = new Maybe<IDownloadData>();
            var b = new Binance(r);
            var res = await b.ExchangeInfo();
        }

        [Fact]
        public async void DepthInfoOnline()
        {
            var r = new Maybe<IDownloadData>();
            var b = new Binance(r);
            var res = await b.Depth("ETHBTC");
        }

        [Fact]
        public async void DepthInfoOnlineWithLimit()
        {
            var r = new Maybe<IDownloadData>();
            var b = new Binance(r);
            var res = await b.Depth("ETHBTC", 5);
            Assert.Equal(5, res.Asks.Count);
        }

        [Fact]
        public async void Depth()
        {
            var res = await binance.Depth("ETHBTC");
            Assert.Equal(100, res.Asks.Count);
            Assert.Equal(100, res.Bids.Count);
        }

        [Fact]
        public async void BookTickerOneSymbolOnline()
        {
            var r = new Maybe<IDownloadData>();
            var b = new Binance(r);
            var res = await b.BookTicker(new Maybe<string>("ETHBTC"));
            Assert.Single(res);
        }

        [Fact]
        public async void BookTickerAllOnline()
        {
            var r = new Maybe<IDownloadData>();
            var b = new Binance(r);
            var res = await b.BookTicker(new Maybe<string>());
            Assert.NotEmpty(res);
        }
    }
}