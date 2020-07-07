using ExchangesApi.Exchanges.BinanceApi.ApiCalls;
using ExchangesApi.Exchanges.BinanceApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebSocket4Net;

namespace ExchangesApi.Exchanges.BinanceApi
{
    public class BinanceWebsocket
    {
        private readonly WebSocket _webSocketFeed;
        private Action<AllMarketTickersStream> _allMarketTickersStreamCallback;
        private Action<AllBookTickersStream> _allBookTickersStreamCallback;
        private int _subscriptionsToSendCount = 0;
        private readonly List<string> _channels;
        private readonly Random _random;

        public BinanceWebsocket(
            EventHandler onClose,
            List<string> streamNames)
        {
            var url = Constants.WebSocketUrl;
            url += "/stream?streams=";
            foreach (var stream in streamNames)
            {
                url += $"{stream}/";
            }

            url = url.Substring(0, url.Length - 1);

            _webSocketFeed = new WebSocket(url);
            _webSocketFeed.Opened += HandleOpen;
            _webSocketFeed.Closed += onClose;
            _webSocketFeed.MessageReceived += HandleMessage;

            _channels = streamNames;
            _random = new Random();
        }

        // TODO: send pong every 3 minutes

        public async Task StopWebSocket()
        {
            var json = JsonConvert.SerializeObject(new SubscribeMessage
            {
                Id = new Random().Next(),
                Method = "UNSUBSCRIBE",
                Params = _channels
            });

            _webSocketFeed.Send(json);

            await _webSocketFeed.CloseAsync();
        }

        public async Task<bool> StartWebSocket()
        {
            if (_channels.Count != _subscriptionsToSendCount)
            {
                return false;
            }

            return await _webSocketFeed.OpenAsync();
        }

        public void SubscribeAllMarketTickersStream(Action<AllMarketTickersStream> allMarketTickersStreamCallback)
        {
            _allMarketTickersStreamCallback = allMarketTickersStreamCallback;

            _subscriptionsToSendCount++;
        }

        public void SubscribeAllBookTickersStream(Action<AllBookTickersStream> allBookTickersStreamCallback)
        {
            _allBookTickersStreamCallback = allBookTickersStreamCallback;

            _subscriptionsToSendCount++;
        }

        private void Subscribe()
        {
            var subscribeMessage = new SubscribeMessage
            {
                Id = _random.Next(),
                Method = "SUBSCRIBE",
                Params = _channels
            };

            _webSocketFeed.Send(JsonConvert.SerializeObject(subscribeMessage));
        }

        private void HandleMessage(object sender, MessageReceivedEventArgs e)
        {
            var baseMessage = JsonConvert.DeserializeObject<BaseWebsocketResponse>(e.Message);

            switch (baseMessage.StreamName)
            {
                case BinanceWebsocketStreams.AllMarketTickersStream:
                    _allMarketTickersStreamCallback(JsonConvert.DeserializeObject<AllMarketTickersStream>(e.Message));
                    break;
                case BinanceWebsocketStreams.AllBookTickersStream:
                    _allBookTickersStreamCallback(JsonConvert.DeserializeObject<AllBookTickersStream>(e.Message));
                    break;
            }
        }

        private void HandleOpen(object sender, EventArgs e)
        {
            Subscribe();
        }
    }
}
