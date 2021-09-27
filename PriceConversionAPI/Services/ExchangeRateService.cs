using System.Threading.Tasks;

namespace PriceConversionAPI.Services
{
    /// <summary>
    ///     The exchange rate service.
    /// </summary>
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IExchangeRateApiService apiService;

        /// <summary>
        ///     Initialise the exchange rate service.
        /// </summary>
        /// <param name="apiService">The api service to get exchange information from.</param>
        public ExchangeRateService(IExchangeRateApiService apiService)
        {
            this.apiService = apiService;
        }

        /// <summary>
        ///     Get the exchange rate of the target currency.
        /// </summary>
        /// <param name="sourceCurrency">The source currency to convert from.</param>
        /// <param name="targetCurrency">The target currency to convert to.</param>
        /// <returns>The exchange rate of the currency conversion.</returns>
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
