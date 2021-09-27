namespace PriceConversionAPI.Services
{
    public class PriceCalculatorService : IPriceCalculatorService
    {
        public double CalculatePrice(double price, double exchangeRate)
        {
            return price * exchangeRate;
        }
    }
}
