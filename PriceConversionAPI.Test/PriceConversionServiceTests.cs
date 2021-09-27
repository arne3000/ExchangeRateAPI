using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PriceConversionAPI.Services;
using System.Threading.Tasks;

namespace PriceConversionAPI.Test
{
    [TestClass]
    public class PriceConversionServiceTests
    {
        [TestMethod]
        public async Task ConvertPriceAsync_SimpleConversion_ReturnsConvertedPrice()
        {
            // Arrange
            Mock<IExchangeRateService> mockExchangeService = new Mock<IExchangeRateService>();
            Mock<IPriceCalculatorService> mockCalculateService = new Mock<IPriceCalculatorService>();

            mockExchangeService.Setup(x => x.GetExchangeRateAsync("a", "b")).ReturnsAsync(2);
            mockCalculateService.Setup(x => x.CalculatePrice(1, 2)).Returns(3);

            PriceConversionService service = new PriceConversionService(mockExchangeService.Object, mockCalculateService.Object);

            // Act
            double? result = await service.ConvertPriceAsync("a", "b", 1);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public async Task ConvertPriceAsync_NoExchangeRate_ReturnsNull()
        {
            // Arrange
            Mock<IExchangeRateService> mockExchangeService = new Mock<IExchangeRateService>();
            Mock<IPriceCalculatorService> mockCalculateService = new Mock<IPriceCalculatorService>();

            mockExchangeService.Setup(x => x.GetExchangeRateAsync("a", "a")).ReturnsAsync((double?)null);

            PriceConversionService service = new PriceConversionService(mockExchangeService.Object, mockCalculateService.Object);

            // Act
            double? result = await service.ConvertPriceAsync("a", "b", 1);

            // Assert;
            Assert.IsNull(result);
        }
    }
}
