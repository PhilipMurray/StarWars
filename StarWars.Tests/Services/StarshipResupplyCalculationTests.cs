using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StarWars.Domain.Interfaces;
using StarWars.Domain.Models;
using StarWars.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Domain.Services.Tests
{
    [TestClass()]
    public class StarshipResupplyCalculationTests
    {
        private readonly Mock<ICalculationService> _calculationServiceMock;
        private readonly StarshipResupplyCalculation _starshipResupplyCalculation;

        public StarshipResupplyCalculationTests()
        {
            _calculationServiceMock = new Mock<ICalculationService>();
            _starshipResupplyCalculation = new StarshipResupplyCalculation(_calculationServiceMock.Object);
        }

        [TestMethod]
        public void CalculateNumberOfResupplyStopsNeededTest()
        {
            ////Arrange
            StarshipEntity starshipEntity = new StarshipEntity("Test1", string.Empty, string.Empty);

            _calculationServiceMock.Setup(x => x.GetConsumablesInHours(It.IsAny<string>()))
                                   .Returns(5)
                                   .Verifiable();
            _calculationServiceMock.Setup(x => x.GetTotalHoursToTravel(It.IsAny<int>(), It.IsAny<int?>()))
                                   .Returns(10)
                                   .Verifiable();

            ////Act
            var response = _starshipResupplyCalculation.CalculateNumberOfResupplyStopsNeeded(starshipEntity, 1000);

            ////Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(starshipEntity.GetName(), response.Key);
            Assert.AreEqual("2", response.Value);
        }

        [TestMethod]
        public void CalculateNumberOfResupplyStopsNeededTest_ComsumeablesReturnsNull()
        {
            ////Arrange
            _calculationServiceMock.Setup(x => x.GetConsumablesInHours(It.IsAny<string>()))
                                   .Returns<int?>(null)
                                   .Verifiable();
            _calculationServiceMock.Setup(x => x.GetTotalHoursToTravel(It.IsAny<int>(), It.IsAny<int?>()))
                                   .Returns(10)
                                   .Verifiable();

            StarshipEntity starshipEntity = new StarshipEntity("Test1", string.Empty, string.Empty);

            ////Act
            var response = _starshipResupplyCalculation.CalculateNumberOfResupplyStopsNeeded(starshipEntity, 1000);

            ////Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(starshipEntity.GetName(), response.Key);
            Assert.AreEqual("unknown", response.Value);
        }

        [TestMethod]
        public void CalculateNumberOfResupplyStopsNeededTest_TotalHoursToTravelReturnsNull()
        {
            ////Arrange
            _calculationServiceMock.Setup(x => x.GetConsumablesInHours(It.IsAny<string>()))
                                   .Returns(10)
                                   .Verifiable();
            _calculationServiceMock.Setup(x => x.GetTotalHoursToTravel(It.IsAny<int>(), It.IsAny<int?>()))
                                   .Returns<int?>(null)
                                   .Verifiable();

            StarshipEntity starshipEntity = new StarshipEntity("Test1", string.Empty, string.Empty);

            ////Act
            var response = _starshipResupplyCalculation.CalculateNumberOfResupplyStopsNeeded(starshipEntity, 1000);

            ////Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(starshipEntity.GetName(), response.Key);
            Assert.AreEqual("unknown", response.Value);
        }
    }
}