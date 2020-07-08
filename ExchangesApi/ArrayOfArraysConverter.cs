using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace ExchangesApi
{
    public class ArrayOfArraysConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<T>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            JArray externalArray = JArray.Load(reader);

            var result = new List<T>();

            foreach (JToken arr in externalArray)
            {
                var internalArray = arr as JArray;

                result.Add(Parse(internalArray));
            }

            return result;
        }

        private T Parse(JArray internalArray)
        {
            // T is a Candle
            var returnType = typeof(T);

            // Create an instance of T
            var returnObject = Activator.CreateInstance(returnType);

            // Get all the properties of T
            var properties = returnType.GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                var property = properties[i];

                // JToken.ToObject(Type type) method
                var toObjectMethod = typeof(JToken).GetMethod("ToObject", new[] { typeof(Type) });

                // Invoke JToken method on the element at the corresponding index of T (i)
                // and pass the type of the property of T
                var value = toObjectMethod.Invoke(internalArray[i], new[] { property.PropertyType });

                // Set the parsed value
                property.SetValue(returnObject, value);
            }

            // Cast is safe
            return (T)returnObject;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
