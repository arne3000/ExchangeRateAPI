using System.Threading.Tasks;

namespace PriceConversionAPI.Services
{
    /// <summary>
    ///     The exchange rate api service.
    /// </summary>
    public interface IExchangeRateApiService
    {
        /// <summary>
        ///     Get the exchange rates for the source currency.
        /// </summary>
        /// <param name="sourceCurrency">The source currency.</param>
        /// <returns>The exchange rate information.</returns>
        Task<ExchangeRate> GetExchangeRateAsync(string sourceCurrency);
    }
}