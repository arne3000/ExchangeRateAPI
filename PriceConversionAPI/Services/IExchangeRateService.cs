using System.Threading.Tasks;

namespace PriceConversionAPI.Services
{
    /// <summary>
    ///     The exchange rate service.
    /// </summary>
    public interface IExchangeRateService
    {
        /// <summary>
        ///     Get the exchange rate of the target currency.
        /// </summary>
        /// <param name="sourceCurrency">The source currency to convert from.</param>
        /// <param name="targetCurrency">The target currency to convert to.</param>
        /// <returns>The exchange rate of the currency conversion.</returns>
        Task<double?> GetExchangeRateAsync(string sourceCurrency, string targetCurrency);
    }
}