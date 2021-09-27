using System.Threading.Tasks;

namespace PriceConversionAPI.Services
{
    public class PriceConversionService : IPriceConversionService
    {
        private readonly IExchangeRateService exchangeRateService;
        private readonly IPriceCalculatorService priceCalculatorService;

        public PriceConversionService(IExchangeRateService exchangeRateService, IPriceCalculatorService priceCalculatorService)
        {
            this.exchangeRateService = exchangeRateService;
            this.priceCalculatorService = priceCalculatorService;
        }

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
