namespace PriceConversionAPI.Services
{
    public interface IPriceConversionService
    {
        PriceConversion ConvertPrice(string sourceCurrency, string targetCurrency, double price);
    }
}