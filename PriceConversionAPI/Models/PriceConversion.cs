using System.Text.Json.Serialization;

namespace PriceConversionAPI
{
    /// <summary>
    ///     The price conversion model.
    /// </summary>
    public class PriceConversion
    {
        /// <summary>
        ///     The target currency.
        /// </summary>
        [JsonPropertyName("target")]
        public string TargetCurrency { get; set; }

        /// <summary>
        ///     The price.
        /// </summary>
        [JsonPropertyName("price")]
        public double Price { get; set; }
    }
}
