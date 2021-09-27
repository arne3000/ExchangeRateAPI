using System.Threading.Tasks;

namespace PriceConversionAPI.Services
{
    public interface IExchangeRateService
    {
        Task<double?> GetExchangeRateAsync(string sourceCurrency, string targetCurrency);
    }
}