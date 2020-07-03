using ExchangesApi.Exchanges.CoinbaseProApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebSocket4Net;
using Xunit;

namespace ExchangesApi.Tests
{
    public class CoinbaseProWebsocketTests
    {
        private readonly CoinbaseProWebsocket _coinbaseWs;
        private List<string> _channels;

        public CoinbaseProWebsocketTests()
        {
            _coinbaseWs = new CoinbaseProWebsocket(HandleOpen, HandleClose, HandleMessage);
        }

        [Fact]
        public async void Websocket()
        {
            _coinbaseWs.StartWebSocket();

            await Task.Delay(1000);

            await _coinbaseWs.StopWebSocket(_channels);
        }

        private void HandleMessage(object sender, MessageReceivedEventArgs e)
        {
            Assert.NotEmpty(e.Message);
        }

        private void HandleOpen(object sender, EventArgs e)
        {
            _channels = new List<string>
            {
                 "ticker"
            };

            var productIds = new List<string>
            {
                "ETH-USD",
                "ETH-EUR"
            };

            _coinbaseWs.Subscribe(_channels, productIds);
        }

        private void HandleClose(object sender, EventArgs e)
        {
            Assert.IsType<ClosedEventArgs>(e);
        }
    }
}
