using System.Collections.Generic;

namespace ExchangesApi.Exchanges.CryptoCompareApi.ApiCalls
{
    public class GenericResponse
    {
        public string Response { get; set; }
        public int Type { get; set; }
        public bool Aggregated { get; set; }
        public IEnumerable<Ticker> Data { get; set; }
        public int TimeTo { get; set; }
        public int TimeFrom { get; set; }
        public bool FirstValueInArray { get; set; }
        public ConversionType ConversionType { get; set; }
    }

    public class ConversionType
    {
        public string Type { get; set; }
        public string ConversionSymbol { get; set; }
    }
}