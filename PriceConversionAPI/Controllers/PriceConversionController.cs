using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PriceConversionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceConversionController : ControllerBase
    {
        private readonly ILogger<PriceConversionController> _logger;

        public PriceConversionController(ILogger<PriceConversionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public PriceConversion Get(string source, string target, double price)
        {
            return new PriceConversion
            {
                TargetCurrency = target,
                Price = price
            };
        }
    }
}
