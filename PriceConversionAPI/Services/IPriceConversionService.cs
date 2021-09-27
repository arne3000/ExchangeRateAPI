using System.Threading.Tasks;

namespace PriceConversionAPI.Services
{
    public interface IPriceConversionService
    {
        Task<double?> ConvertPriceAsync(string sourceCurrency, string targetCurrency, double price);
    }
}