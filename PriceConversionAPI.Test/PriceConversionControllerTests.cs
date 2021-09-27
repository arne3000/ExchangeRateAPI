using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PriceConversionAPI.Controllers;
using PriceConversionAPI.Services;

namespace PriceConversionAPI.Test
{
    [TestClass]
    public class PriceConversionControllerTests
    {
        [TestMethod]
        public void Get_DefaultParameters_ReturnsOk()
        {
            // Arrange
            Mock<IPriceConversionService> mockService = new Mock<IPriceConversionService>();

            mockService.Setup(x => x.ConvertPrice("a", "a", 1)).Returns(new PriceConversion
            {
                Price = 1,
                TargetCurrency = "a"
            });

            PriceConversionController controller = new PriceConversionController(mockService.Object);

            // Act
            IActionResult response = controller.Get("a", "a", 1);

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            OkObjectResult okActionResult = response as OkObjectResult;

            Assert.IsInstanceOfType(okActionResult.Value, typeof(PriceConversion));
            PriceConversion resultResponse = okActionResult.Value as PriceConversion;

            Assert.AreEqual("a", resultResponse.TargetCurrency);
            Assert.AreEqual(1, resultResponse.Price);
        }

        [TestMethod]
        public void Get_NullSourceParameter_ReturnsBadRequest()
        {
            // Arrange
            Mock<IPriceConversionService> mockService = new Mock<IPriceConversionService>();
            PriceConversionController controller = new PriceConversionController(mockService.Object);

            // Act
            IActionResult response = controller.Get(null, "a", 1);

            // Assert
            Assert.IsInstanceOfType(response, typeof(BadRequestObjectResult));
            BadRequestObjectResult actionResult = response as BadRequestObjectResult; 

            Assert.AreEqual(400, actionResult.StatusCode);
        }

        [TestMethod]
        public void Get_EmptySourceParameter_ReturnsBadRequest()
        {
            // Arrange
            Mock<IPriceConversionService> mockService = new Mock<IPriceConversionService>();
            PriceConversionController controller = new PriceConversionController(mockService.Object);

            // Act
            IActionResult response = controller.Get("", "a", 1);

            // Assert
            Assert.IsInstanceOfType(response, typeof(BadRequestObjectResult));
            BadRequestObjectResult actionResult = response as BadRequestObjectResult;

            Assert.AreEqual(400, actionResult.StatusCode);
        }

        [TestMethod]
        public void Get_NullTargetParameter_ReturnsBadRequest()
        {
            // Arrange
            Mock<IPriceConversionService> mockService = new Mock<IPriceConversionService>();
            PriceConversionController controller = new PriceConversionController(mockService.Object);

            // Act
            IActionResult response = controller.Get("a", null, 1);

            // Assert
            Assert.IsInstanceOfType(response, typeof(BadRequestObjectResult));
            BadRequestObjectResult actionResult = response as BadRequestObjectResult;

            Assert.AreEqual(400, actionResult.StatusCode);
        }

        [TestMethod]
        public void Get_SourceTargetParameter_ReturnsBadRequest()
        {
            // Arrange
            Mock<IPriceConversionService> mockService = new Mock<IPriceConversionService>();
            PriceConversionController controller = new PriceConversionController(mockService.Object);

            // Act
            IActionResult response = controller.Get("a", "", 1);

            // Assert
            Assert.IsInstanceOfType(response, typeof(BadRequestObjectResult));
            BadRequestObjectResult actionResult = response as BadRequestObjectResult;

            Assert.AreEqual(400, actionResult.StatusCode);
        }
    }
}
