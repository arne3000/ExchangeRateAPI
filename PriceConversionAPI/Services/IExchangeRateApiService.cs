using System.Threading.Tasks;

namespace PriceConversionAPI.Services
{
    public interface IExchangeRateApiService
    {
        Task<ExchangeRate> GetExchangeRateAsync(string sourceCurrency);
    }
}