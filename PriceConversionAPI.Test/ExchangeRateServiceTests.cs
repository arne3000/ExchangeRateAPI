using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PriceConversionAPI.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceConversionAPI.Test
{
    [TestClass]
    public class ExchangeRateServiceTests
    {
        [TestMethod]
        public async Task GetExchangeRateAsync_ExistingTargetCurrency_ReturnsExchangeRate()
        {
            // Arrange
            Mock<IExchangeRateApiService> mockApiService = new Mock<IExchangeRateApiService>();
            
            mockApiService.Setup(x => x.GetExchangeRateAsync("a")).ReturnsAsync(new ExchangeRate
            {
                Date = new DateTime(2000, 01, 01, 01, 01, 01),
                LastUpdated = 0,
                BaseCurrency = "a",
                ExchangeRates = new Dictionary<string, double>
                {
                    ["b"] = 1
                }
            });

            ExchangeRateService service = new ExchangeRateService(mockApiService.Object);

            // Act
            double? result = await service.GetExchangeRateAsync("a", "b");

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public async Task GetExchangeRateAsync_NonExistingTargetCurrency_ReturnsNull()
        {
            // Arrange
            Mock<IExchangeRateApiService> mockApiService = new Mock<IExchangeRateApiService>();

            mockApiService.Setup(x => x.GetExchangeRateAsync("a")).ReturnsAsync(new ExchangeRate
            {
                Date = new DateTime(2000, 01, 01, 01, 01, 01),
                LastUpdated = 0,
                BaseCurrency = "a",
                ExchangeRates = new Dictionary<string, double>
                {
                    ["a"] = 1
                }
            });

            ExchangeRateService service = new ExchangeRateService(mockApiService.Object);

            // Act
            double? result = await service.GetExchangeRateAsync("a", "b");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task GetExchangeRateAsync_NullExchangeRates_ReturnsNull()
        {
            // Arrange
            Mock<IExchangeRateApiService> mockApiService = new Mock<IExchangeRateApiService>();

            mockApiService.Setup(x => x.GetExchangeRateAsync("a")).ReturnsAsync(new ExchangeRate
            {
                Date = new DateTime(2000, 01, 01, 01, 01, 01),
                LastUpdated = 0,
                BaseCurrency = "a",
                ExchangeRates = null
            });

            ExchangeRateService service = new ExchangeRateService(mockApiService.Object);

            // Act
            double? result = await service.GetExchangeRateAsync("a", "b");

            // Assert
            Assert.IsNull(result);
        }
    }
}
