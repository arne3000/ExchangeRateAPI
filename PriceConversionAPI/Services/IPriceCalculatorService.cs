namespace PriceConversionAPI.Services
{
    public interface IPriceCalculatorService
    {
        double CalculatePrice(double price, double exchangeRate);
    }
}