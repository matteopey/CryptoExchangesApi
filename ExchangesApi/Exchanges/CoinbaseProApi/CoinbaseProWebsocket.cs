using ExchangesApi.Exchanges.CoinbaseProApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSocket4Net;

namespace ExchangesApi.Exchanges.CoinbaseProApi
{
    public class CoinbaseProWebsocket
    {
        private readonly WebSocket _webSocketFeed;

        public CoinbaseProWebsocket(
            EventHandler onOpen,
            EventHandler onClose,
            EventHandler<MessageReceivedEventArgs> onMessage)
        {
            _webSocketFeed = new WebSocket(Constants.WebSocketUrl);
            _webSocketFeed.MessageReceived += onMessage;
            _webSocketFeed.Opened += onOpen;
            _webSocketFeed.Closed += onClose;
        }

        public void StartWebSocket()
        {
            _webSocketFeed.Open();
        }

        public void Subscribe(List<string> channels, List<string> productIds)
        {
            var subscribeMessage = new SubscribeMessage
            {
                Channels = channels,
                ProductsIds = productIds,
                Type = "subscribe"
            };

            _webSocketFeed.Send(JsonConvert.SerializeObject(subscribeMessage));
        }

        public async Task StopWebSocket(List<string> channels)
        {
            var json = JsonConvert.SerializeObject(new SubscribeMessage
            {
                Type = "unsubscribe",
                Channels = channels
            });

            _webSocketFeed.Send(json);
            await _webSocketFeed.CloseAsync();
        }
    }
}
