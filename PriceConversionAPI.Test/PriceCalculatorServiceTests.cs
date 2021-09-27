using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceConversionAPI.Services;

namespace PriceConversionAPI.Test
{
    [TestClass]
    public class PriceCalculatorServiceTests
    {
        [TestMethod]
        public void CalculatePrice_ZeroPrices_ReturnsZero()
        {
            // Arrange
            PriceCalculatorService service = new PriceCalculatorService();

            // Act
            double result = service.CalculatePrice(0, 0);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CalculatePrice_MaxDoubles_ReturnsInfinitity()
        {
            // Arrange
            PriceCalculatorService service = new PriceCalculatorService();

            // Act
            double result = service.CalculatePrice(double.MaxValue, double.MaxValue);

            // Assert
            Assert.IsTrue(double.IsInfinity(result));
        }
    }
}
