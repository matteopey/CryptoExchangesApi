using ExchangesApi.Exchanges.CoinbaseProApi.ApiCalls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ExchangesApi.Exchanges.CoinbaseProApi
{
    public class CandlesConverter : JsonConverter<Candles>
    {
        public override bool CanWrite => false;

        public override Candles ReadJson(JsonReader reader, Type objectType, Candles existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            JArray externalArray = JArray.Load(reader);

            var candles = new Candles();

            foreach (JToken arr in externalArray)
            {
                var candleArray = arr as JArray;

                candles.Add(new Candle
                {
                    Time = candleArray[0].ToObject<long>(),
                    Low = candleArray[1].ToObject<double>(),
                    High = candleArray[2].ToObject<double>(),
                    Open = candleArray[3].ToObject<double>(),
                    Close = candleArray[4].ToObject<double>(),
                    Volume = candleArray[5].ToObject<double>(),
                });
            }

            return candles;
        }

        public override void WriteJson(JsonWriter writer, Candles value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
