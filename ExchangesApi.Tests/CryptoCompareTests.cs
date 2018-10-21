using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExchangesApi.Exchanges.CryptoCompareApi;
using Xunit;

namespace ExchangesApi.Tests
{
    public class CryptoCompareTests
    {
        private readonly Maybe<IDownloadData> reader;
        private readonly CryptoCompare cc;

        private readonly Maybe<string> emptyStringMaybe = new Maybe<string>();
        private readonly Maybe<int> emptyIntMaybe = new Maybe<int>();

        public CryptoCompareTests()
        {
            reader = new Maybe<IDownloadData>(new LocalDownloader("CryptoCompareData"));
            cc = new CryptoCompare(reader);
        }

        [Fact]
        public async void HistoDayOnline()
        {
            var cc = new CryptoCompare(new Maybe<IDownloadData>());

            var res = await cc.HistoDay("ETH", "BTC", emptyStringMaybe, emptyIntMaybe,
                emptyIntMaybe,
                emptyIntMaybe, emptyStringMaybe);

            Assert.Equal("Success", res.Response);
            Assert.NotEmpty(res.Data);
        }

        [Fact]
        public async void HistoDayWithParametersOnline()
        {
            var cc = new CryptoCompare(new Maybe<IDownloadData>());

            var res = await cc.HistoDay(
                "ETH",
                "BTC",
                new Maybe<string>("Kraken"),
                new Maybe<int>(2),
                new Maybe<int>(10),
                emptyIntMaybe,
                emptyStringMaybe);

            Assert.Equal("Success", res.Response);
            Assert.NotEmpty(res.Data);
            Assert.True(res.Aggregated);
        }

        [Fact]
        public async void HistoHourOnline()
        {
            var cc = new CryptoCompare(new Maybe<IDownloadData>());

            var res = await cc.HistoHour("ETH", "BTC", emptyStringMaybe, emptyIntMaybe,
                emptyIntMaybe,
                emptyIntMaybe);

            Assert.Equal("Success", res.Response);
            Assert.NotEmpty(res.Data);
        }

        [Fact]
        public async void HistoHourWithParametersOnline()
        {
            var cc = new CryptoCompare(new Maybe<IDownloadData>());

            var res = await cc.HistoHour(
                "ETH",
                "BTC",
                new Maybe<string>("Kraken"),
                new Maybe<int>(2),
                new Maybe<int>(10),
                emptyIntMaybe);

            Assert.Equal("Success", res.Response);
            Assert.NotEmpty(res.Data);
            Assert.True(res.Aggregated);
        }
    }
}