
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PriceConversionAPI.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly HttpClient httpClient;

        public ExchangeRateService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<double?> GetExchangeRateAsync(string sourceCurrency, string targetCurrency)
        {
            HttpResponseMessage response = await this.httpClient.GetAsync($"api/latest/{sourceCurrency}.json");

            response.EnsureSuccessStatusCode();

            ExchangeRate exchangeRate;

            using (Stream responseStream = await response.Content.ReadAsStreamAsync())
            {
                exchangeRate = await JsonSerializer.DeserializeAsync<ExchangeRate>(responseStream);
            }

            return this.GetTargetExchangeRate(exchangeRate, targetCurrency);
        }

        public double? GetTargetExchangeRate(ExchangeRate exchangeRate, string targetCurrency)
        {
            if (exchangeRate.ExchangeRates != null && exchangeRate.ExchangeRates.TryGetValue(targetCurrency, out double rate))
            {
                return rate;
            }

            return null;
        }
    }
}
