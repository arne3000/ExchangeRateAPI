using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PriceConversionAPI.Services;

namespace PriceConversionAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices(services => {
                    services.AddScoped<IPriceConversionService, PriceConversionService>();
                    services.AddScoped<IExchangeRateService, ExchangeRateService>();
                    services.AddScoped<IPriceCalculatorService, PriceCalculatorService>();
                });
    }
}
