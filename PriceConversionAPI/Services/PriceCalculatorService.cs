namespace PriceConversionAPI.Services
{
    /// <summary>
    ///     The price calculator service.
    /// </summary>
    public class PriceCalculatorService : IPriceCalculatorService
    {
        /// <summary>
        ///     Calculate the price using an exchange rate.
        /// </summary>
        /// <param name="price">The price to convert.</param>
        /// <param name="exchangeRate">The exchange rate to use.</param>
        /// <returns>The calculated new price based on the exchange rate.</returns>
        public double CalculatePrice(double price, double exchangeRate)
        {
            return price * exchangeRate;
        }
    }
}
