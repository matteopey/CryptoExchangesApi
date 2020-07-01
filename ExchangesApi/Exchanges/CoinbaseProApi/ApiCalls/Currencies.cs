using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExchangesApi.Exchanges.CoinbaseProApi.ApiCalls
{
    public class Currencies : List<Currency> { }

    public class Currency
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [JsonProperty("min_size")]
        public string MinSize { get; set; }

        public string Status { get; set; }
        public string Message { get; set; }
        public Details Details { get; set; }

        [JsonProperty("max_precision")]
        public string MaxPrecision { get; set; }
    }

    public class Details
    {
        public string Type { get; set; }
        public string Symbol { get; set; }

        [JsonProperty("network_confirmations")]
        public int NetworkConfirmations { get; set; }

        [JsonProperty("sort_order")]
        public int SortOrder { get; set; }

        [JsonProperty("crypto_address_link")]
        public string CryptoAddressLink { get; set; }

        [JsonProperty("crypto_transaction_link")]
        public string CryptoTransactionLink { get; set; }

        [JsonProperty("push_payment_methods")]
        public List<string> PushPaymentMethods { get; set; }

        [JsonProperty("processing_time_seconds")]
        public int ProcessingTimeSeconds { get; set; }

        [JsonProperty("min_withdrawal_amount")]
        public float MinWithdrawalAmount { get; set; }
    }

}
