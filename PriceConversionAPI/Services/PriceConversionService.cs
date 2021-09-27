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

        public PriceConversion ConvertPrice(string sourceCurrency, string targetCurrency, double price)
        {
            double rate = this.exchangeRateService.GetExchangeRate(sourceCurrency, targetCurrency);
            double convertedPrice = this.priceCalculatorService.CalculatePrice(price, rate);

            return new PriceConversion
            {
                TargetCurrency = targetCurrency,
                Price = convertedPrice
            };
        }
    }
}
