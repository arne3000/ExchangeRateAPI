
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace PriceConversionAPI.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IExchangeRateApiService apiService;

        public ExchangeRateService(IExchangeRateApiService apiService)
        {
            this.apiService = apiService;
        }

        public async Task<double?> GetExchangeRateAsync(string sourceCurrency, string targetCurrency)
        {
            ExchangeRate exchangeRate = await this.apiService.GetExchangeRateAsync(sourceCurrency);

            if (exchangeRate.ExchangeRates != null && exchangeRate.ExchangeRates.TryGetValue(targetCurrency, out double rate))
            {
                return rate;
            }

            return null;
        }
    }
}
