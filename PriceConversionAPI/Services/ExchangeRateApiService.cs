
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace PriceConversionAPI.Services
{
    /// <summary>
    ///     The exchange rate api service.
    /// </summary>
    public class ExchangeRateApiService : IExchangeRateApiService
    {
        private readonly HttpClient httpClient;

        /// <summary>
        ///     Initialise the exchange rate api service.
        /// </summary>
        /// <param name="httpClient">The http client.</param>
        public ExchangeRateApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        ///     Get the exchange rates for the source currency.
        /// </summary>
        /// <param name="sourceCurrency">The source currency.</param>
        /// <returns>The exchange rate information.</returns>
        public async Task<ExchangeRate> GetExchangeRateAsync(string sourceCurrency)
        {
            string sourceCurrencyCode = HttpUtility.UrlEncode(sourceCurrency);

            HttpResponseMessage response = await this.httpClient.GetAsync($"exchangerates/api/latest/{sourceCurrencyCode}.json");

            response.EnsureSuccessStatusCode();

            using (Stream responseStream = await response.Content.ReadAsStreamAsync())
            {
                return await JsonSerializer.DeserializeAsync<ExchangeRate>(responseStream);
            }
        }
    }
}
