
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace PriceConversionAPI.Services
{
    public class ExchangeRateApiService : IExchangeRateApiService
    {
        private readonly HttpClient httpClient;

        public ExchangeRateApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

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
