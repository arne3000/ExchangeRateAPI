using Microsoft.AspNetCore.Mvc;
using PriceConversionAPI.Services;
using System.Threading.Tasks;

namespace PriceConversionAPI.Controllers
{
    /// <summary>
    ///     The price conversion controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PriceConversionController : ControllerBase
    {
        private readonly IPriceConversionService priceConversionService;

        /// <summary>
        ///     Initialise the price conversion controller.
        /// </summary>
        /// <param name="priceConversionService">The price conversion service.</param>
        public PriceConversionController(IPriceConversionService priceConversionService)
        {
            this.priceConversionService = priceConversionService;
        }

        /// <summary>
        ///     Get the converted price to an exchange rate target.
        /// </summary>
        /// <param name="source">The source currency to convert from.</param>
        /// <param name="target">The target currency to convert to.</param>
        /// <param name="price">The price to convert.</param>
        /// <returns>The converted price and the currency it was converted to.</returns>
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
                return NotFound("The target currency is not supported.");
            }
        }
    }
}
