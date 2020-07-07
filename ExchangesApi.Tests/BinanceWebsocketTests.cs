using ExchangesApi.Exchanges.BinanceApi;
using ExchangesApi.Exchanges.BinanceApi.ApiCalls;
using ExchangesApi.Exchanges.BinanceApi.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebSocket4Net;
using Xunit;

namespace ExchangesApi.Tests
{
    public class BinanceWebsocketTests
    {
        private readonly BinanceWebsocket _ws;
        private List<string> _channels;

        public BinanceWebsocketTests()
        {
            _channels = new List<string>
            {
                 BinanceWebsocketStreams.AllMarketTickersStream,
                 BinanceWebsocketStreams.AllBookTickersStream
            };

            _ws = new BinanceWebsocket(HandleClose, _channels);
        }

        [Fact]
        public async void Websocket()
        {
            _ws.SubscribeAllMarketTickersStream(Markets);
            _ws.SubscribeAllBookTickersStream(Tickers);

            var res = await _ws.StartWebSocket();

            Assert.True(res);

            await Task.Delay(1000);

            await _ws.StopWebSocket();
        }

        [Fact]
        public async void Websocket_NotEnoughHandlersRegistered()
        {
            _ws.SubscribeAllMarketTickersStream(Markets);

            var res = await _ws.StartWebSocket();

            Assert.False(res);
        }

        private void Tickers(AllBookTickersStream obj) { }

        private void Markets(AllMarketTickersStream obj) { }

        private void HandleClose(object sender, EventArgs e)
        {
            Assert.IsType<ClosedEventArgs>(e);
        }
    }
}
