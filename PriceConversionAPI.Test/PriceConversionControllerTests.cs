using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PriceConversionAPI.Controllers;
using PriceConversionAPI.Services;
using System.Threading.Tasks;

namespace PriceConversionAPI.Test
{
    [TestClass]
    public class PriceConversionControllerTests
    {
        [TestMethod]
        public async Task GetAsync_DefaultParameters_ReturnsOk()
        {
            // Arrange
            Mock<IPriceConversionService> mockService = new Mock<IPriceConversionService>();
            mockService.Setup(x => x.ConvertPriceAsync("a", "a", 1)).ReturnsAsync(1);
            PriceConversionController controller = new PriceConversionController(mockService.Object);

            // Act
            IActionResult response = await controller.GetAsync("a", "a", 1);

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            OkObjectResult okActionResult = response as OkObjectResult;

            Assert.IsInstanceOfType(okActionResult.Value, typeof(PriceConversion));
            PriceConversion resultResponse = okActionResult.Value as PriceConversion;

            Assert.AreEqual("a", resultResponse.TargetCurrency);
            Assert.AreEqual(1, resultResponse.Price);
        }

        [TestMethod]
        public async Task GetAsync_NoConversion_ReturnsNotFound()
        {
            // Arrange
            Mock<IPriceConversionService> mockService = new Mock<IPriceConversionService>();
            mockService.Setup(x => x.ConvertPriceAsync("a", "a", 1)).ReturnsAsync((double?)null);
            PriceConversionController controller = new PriceConversionController(mockService.Object);

            // Act
            IActionResult response = await controller.GetAsync("a", "a", 1);

            // Assert
            Assert.IsInstanceOfType(response, typeof(NotFoundObjectResult));
            NotFoundObjectResult actionResult = response as NotFoundObjectResult;

            Assert.AreEqual(404, actionResult.StatusCode);
        }

        [TestMethod]
        public async Task GetAsync_NullSourceParameter_ReturnsBadRequest()
        {
            // Arrange
            Mock<IPriceConversionService> mockService = new Mock<IPriceConversionService>();
            PriceConversionController controller = new PriceConversionController(mockService.Object);

            // Act
            IActionResult response = await controller.GetAsync(null, "a", 1);

            // Assert
            Assert.IsInstanceOfType(response, typeof(BadRequestObjectResult));
            BadRequestObjectResult actionResult = response as BadRequestObjectResult; 

            Assert.AreEqual(400, actionResult.StatusCode);
        }

        [TestMethod]
        public async Task GetAsync_EmptySourceParameter_ReturnsBadRequest()
        {
            // Arrange
            Mock<IPriceConversionService> mockService = new Mock<IPriceConversionService>();
            PriceConversionController controller = new PriceConversionController(mockService.Object);

            // Act
            IActionResult response = await controller.GetAsync("", "a", 1);

            // Assert
            Assert.IsInstanceOfType(response, typeof(BadRequestObjectResult));
            BadRequestObjectResult actionResult = response as BadRequestObjectResult;

            Assert.AreEqual(400, actionResult.StatusCode);
        }

        [TestMethod]
        public async Task GetAsync_NullTargetParameter_ReturnsBadRequest()
        {
            // Arrange
            Mock<IPriceConversionService> mockService = new Mock<IPriceConversionService>();
            PriceConversionController controller = new PriceConversionController(mockService.Object);

            // Act
            IActionResult response = await controller.GetAsync("a", null, 1);

            // Assert
            Assert.IsInstanceOfType(response, typeof(BadRequestObjectResult));
            BadRequestObjectResult actionResult = response as BadRequestObjectResult;

            Assert.AreEqual(400, actionResult.StatusCode);
        }

        [TestMethod]
        public async Task GetAsync_SourceTargetParameter_ReturnsBadRequest()
        {
            // Arrange
            Mock<IPriceConversionService> mockService = new Mock<IPriceConversionService>();
            PriceConversionController controller = new PriceConversionController(mockService.Object);

            // Act
            IActionResult response = await controller.GetAsync("a", "", 1);

            // Assert
            Assert.IsInstanceOfType(response, typeof(BadRequestObjectResult));
            BadRequestObjectResult actionResult = response as BadRequestObjectResult;

            Assert.AreEqual(400, actionResult.StatusCode);
        }
    }
}
