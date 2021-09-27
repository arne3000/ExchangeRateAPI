using System.Threading.Tasks;

namespace PriceConversionAPI.Services
{
    /// <summary>
    ///     The price conversion service.
    /// </summary>
    public class PriceConversionService : IPriceConversionService
    {
        private readonly IExchangeRateService exchangeRateService;
        private readonly IPriceCalculatorService priceCalculatorService;

        /// <summary>
        ///     Initialise the price conversion service.
        /// </summary>
        /// <param name="exchangeRateService">The exchange rate service.</param>
        /// <param name="priceCalculatorService">The price calculator service.</param>
        public PriceConversionService(IExchangeRateService exchangeRateService, IPriceCalculatorService priceCalculatorService)
        {
            this.exchangeRateService = exchangeRateService;
            this.priceCalculatorService = priceCalculatorService;
        }

        /// <summary>
        ///     Convert a price given a source and target currency.
        /// </summary>
        /// <param name="sourceCurrency">The source currency to convert from.</param>
        /// <param name="targetCurrency">The target currency to convert to.</param>
        /// <param name="price">The price to convert.</param>
        /// <returns>A converted price or null if it cannot be converted.</returns>
        public async Task<double?> ConvertPriceAsync(string sourceCurrency, string targetCurrency, double price)
        {
            double? rate = await this.exchangeRateService.GetExchangeRateAsync(sourceCurrency, targetCurrency);

            if (rate.HasValue)
            {
                return this.priceCalculatorService.CalculatePrice(price, rate.Value);
            }
            else
            {
                return null;
            }
        }
    }
}
