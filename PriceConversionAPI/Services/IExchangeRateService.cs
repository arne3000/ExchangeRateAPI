namespace PriceConversionAPI.Services
{
    public interface IExchangeRateService
    {
        double GetExchangeRate(string sourceCurrency, string targetCurrency);
    }
}