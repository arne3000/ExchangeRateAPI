using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PriceConversionAPI
{
    /// <summary>
    ///     The exchange rate model.
    /// </summary>
    public class ExchangeRate
    {
        /// <summary>
        ///     The date of the last update.
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        ///     The last updated timestamp.
        /// </summary>
        [JsonPropertyName("time_last_updated")]
        public long LastUpdated { get; set; }

        /// <summary>
        ///     The base currency.
        /// </summary>
        [JsonPropertyName("base")]
        public string BaseCurrency { get; set; }

        /// <summary>
        ///     The key-value of rates.
        /// </summary>
        [JsonPropertyName("rates")]
        public IDictionary<string, double> ExchangeRates { get; set; }
    }
}
