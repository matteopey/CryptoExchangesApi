using ExchangesApi.Exchanges.CoinbaseProApi;
using ExchangesApi.Exchanges.CoinbaseProApi.ApiCalls;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ExchangesApi.Tests
{
    public class CoinbaseProOnlineTests
    {
        private readonly Maybe<IDownloadData> _reader;
        private readonly CoinbasePro _coinbase;

        public CoinbaseProOnlineTests()
        {
            _reader = new Maybe<IDownloadData>();
            _coinbase = new CoinbasePro(_reader);
        }

        [Fact]
        public async void GetCurrencies()
        {
            var res = await _coinbase.GetCurrenciesAsync();

            Assert.NotEmpty(res);

            var first = res.First();

            Assert.NotNull(first.Details);
            Assert.NotNull(first.Id);
            Assert.NotNull(first.Name);
        }

        [Fact]
        public async void GetProducts()
        {
            var res = await _coinbase.GetProductsAsync();

            Assert.NotEmpty(res);
        }

        [Fact]
        public async void GetProductTicker()
        {
            var res = await _coinbase.GetProductTickerAsync("ETH-EUR");

            Assert.NotNull(res);
        }

        [Fact]
        public async void GetCandles_Default()
        {
            var res = await _coinbase.GetCandlesAsync(
                "ETH-EUR",
                new Maybe<string>(),
                new Maybe<string>(),
                new Maybe<string>());

            Assert.NotNull(res);
        }

        [Fact]
        public async void GetCandles_1H()
        {
            var res = await _coinbase.GetCandlesAsync(
                "ETH-EUR",
                new Maybe<string>(),
                new Maybe<string>(),
                new Maybe<string>("3600"));

            Assert.NotNull(res);
        }

        public async void GetCandles_AbuseApi()
        {
            var results = new List<Candles>();

            int i = 10;
            while (i > 0)
            {
                var candle = await Task.Run(() => _coinbase.GetCandlesAsync("ETH-EUR", new Maybe<string>(), new Maybe<string>(), new Maybe<string>()));

                results.Add(candle);

                i--;
            }

            results.ForEach(c => Assert.NotNull(c));
            results.ForEach(c => Debug.WriteLine(c.First().Time));
        }
    }
}
