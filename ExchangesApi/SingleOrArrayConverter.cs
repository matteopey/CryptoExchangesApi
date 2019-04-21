using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExchangesApi
{
    /// <summary>
    /// Helper method to allow Json.NET to deserialize an array or a single object
    /// for the same property.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingleOrArrayConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                return token.ToObject<List<T>>();
            }
            return new List<T> { token.ToObject<T>() };
        }

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<T>));
        }
    }
}
