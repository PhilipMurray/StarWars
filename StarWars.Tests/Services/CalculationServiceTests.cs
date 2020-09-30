using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWars.Domain.Interfaces;
using StarWars.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Domain.Services.Tests
{
    [TestClass()]
    public class CalculationServiceTests
    {
        private ICalculationService _calculationService;

        [TestInitialize()]
        public void Init()
        {
            _calculationService = new CalculationService();
        }

        [DataTestMethod]
        [DataRow("1 year", 8760)]
        [DataRow("2 years", 17520)]
        [DataRow("1 month", 720)]
        [DataRow("2 months", 1440)]
        [DataRow("1 week", 168)]
        [DataRow("2 weeks", 336)]
        [DataRow("1 day", 24)]
        [DataRow("2 days", 48)]
        public void GetConsumablesInHoursTest(string input, int expected)
        {
            //// Act
            var response = _calculationService.GetConsumablesInHours(input);

            //// Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(expected, response.Value);
        }

        [TestMethod()]
        public void GetConsumablesInHoursTest_InputIsNotListed()
        {
            //// Arrange
            string consumable = "2 wookies";

            //// Act
            var response = _calculationService.GetConsumablesInHours(consumable);

            //// Assert
            Assert.IsNull(response);
        }

        [TestMethod()]
        public void GetConsumablesInHoursTest_InputIsNull()
        {
            //// Arrange
            string consumable = null;

            //// Act
            var response = _calculationService.GetConsumablesInHours(consumable);

            //// Assert
            Assert.IsNull(response);
        }

        [TestMethod()]
        public void GetConsumablesInHoursTest_InputDoesNotMatch()
        {
            //// Arrange
            string consumable = "qwerty";

            //// Act
            var response = _calculationService.GetConsumablesInHours(consumable);

            //// Assert
            Assert.IsNull(response);
        }

        [TestMethod()]
        public void GetTotalHoursToTravelTest()
        {
            //// Arrange
            int distance = 1000000;
            int distancePerHour = 60;

            //// Act
            var response = _calculationService.GetTotalHoursToTravel(distance, distancePerHour);

            //// Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(16666, response.Value);
        }

        [TestMethod()]
        public void GetTotalHoursToTravelTest_DistancePerHourIsNull()
        {
            //// Arrange
            int distance = 1000000;

            //// Act
            var response = _calculationService.GetTotalHoursToTravel(distance, null);

            //// Assert
            Assert.IsNull(response);
        }
    }
}