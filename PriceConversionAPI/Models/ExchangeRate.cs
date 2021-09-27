using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PriceConversionAPI
{
    public class ExchangeRate
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("time_last_updated")]
        public long LastUpdated { get; set; }

        [JsonPropertyName("base")]
        public string BaseCurrency { get; set; }

        [JsonPropertyName("rates")]
        public IDictionary<string,string> ExchangeRates { get; set; }
    }
}
