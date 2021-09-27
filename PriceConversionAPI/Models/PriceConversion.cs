using System.Text.Json.Serialization;

namespace PriceConversionAPI
{
    public class PriceConversion
    {
        [JsonPropertyName("target")]
        public string TargetCurrency { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }
    }
}
