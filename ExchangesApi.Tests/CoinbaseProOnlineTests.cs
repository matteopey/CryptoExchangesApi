using ExchangesApi.Exchanges.CoinbaseProApi;
using System.Linq;
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
    }
}
