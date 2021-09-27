using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PriceConversionAPI.Services;

namespace PriceConversionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceConversionController : ControllerBase
    {
        //private readonly ILogger<PriceConversionController> logger;
        private readonly IPriceConversionService priceConversionService;

        public PriceConversionController(IPriceConversionService priceConversionService)
        {
            this.priceConversionService = priceConversionService;
        }

        [HttpGet]
        public IActionResult Get(string source, string target, double price)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return BadRequest("Source currency must be supplied");
            }

            if (string.IsNullOrWhiteSpace(target))
            {
                return BadRequest("target currency must be supplied");
            }

            PriceConversion priceConverted = this.priceConversionService.ConvertPrice(source, target, price);
            
            return Ok(priceConverted);
        }
    }
}
