using ExchangesApi.Exchanges.MXC;
using System.IO;
using Xunit;

namespace ExchangesApi.Tests
{
    public class MxcTests
    {
        private readonly Maybe<IDownloadData> reader;
        private readonly Mxc mxc;

        public MxcTests()
        {
            mxc = new Mxc(new Maybe<IDownloadData>(), GetSecrets());
        }

        private MxcSecrets GetSecrets()
        {
            using var fileStream = File.OpenRead("MxcApiKey.txt");
            using var reader = new StreamReader(fileStream);
            return new MxcSecrets
            {
                ApiKey = reader.ReadToEnd()
            };
        }

        [Fact]
        public async void GetTicker()
        {
            var res = await mxc.Ticker("ETH_USDT");
            Assert.Equal(200, res.Code);
            Assert.NotEmpty(res.Data);
        }

        [Fact]
        public async void GetOrderBook()
        {
            var res = await mxc.OrderBook("ETH_USDT", 10);
            Assert.Equal(200, res.Code);
            Assert.Equal(10, res.Orders.Asks.Count);
            Assert.Equal(10, res.Orders.Bids.Count);
        }
    }
}
