using Microsoft.AspNetCore.Mvc;
using PriceConversionAPI.Services;
using System.Threading.Tasks;

namespace PriceConversionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceConversionController : ControllerBase
    {
        private readonly IPriceConversionService priceConversionService;

        public PriceConversionController(IPriceConversionService priceConversionService)
        {
            this.priceConversionService = priceConversionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string source, string target, double price)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return BadRequest("Source currency must be supplied");
            }

            if (string.IsNullOrWhiteSpace(target))
            {
                return BadRequest("target currency must be supplied");
            }

            double? priceConverted = await this.priceConversionService.ConvertPriceAsync(source, target, price);

            if (priceConverted.HasValue)
            {
                return Ok(new PriceConversion
                {
                    TargetCurrency = target,
                    Price = priceConverted.Value
                });
            }
            else
            {
                return NotFound();
            }
        }
    }
}
