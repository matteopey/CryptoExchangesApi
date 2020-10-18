using ExchangesApi.Exchanges.Hotbit;
using System.IO;
using Xunit;

namespace ExchangesApi.Tests
{
    public class HotbitTests
    {
        private readonly Maybe<IDownloadData> reader;
        private readonly HotBit hotbit;

        public HotbitTests()
        {
            hotbit = new HotBit(new Maybe<IDownloadData>());
        }

        [Fact]
        public async void GetOrderBook()
        {
            var res = await hotbit.OrderBook("ETH/USDT", 10);
            Assert.Equal(10, res.Bids.Count);
            Assert.Equal(10, res.Asks.Count);
        }
    }
}
