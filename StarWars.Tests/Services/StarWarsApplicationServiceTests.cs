using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StarWars.Application.Interfaces;
using StarWars.Application.Models;
using StarWars.Application.Services;
using StarWars.Domain.Interfaces;
using StarWars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Application.Services.Tests
{
    [TestClass()]
    public class StarWarsApplicationServiceTests
    {
        private readonly IStarWarsApplicationService _applicationService;
        private readonly Mock<IStarshipRepository> _starshipRepositoryMock;
        private readonly Mock<IStarshipResupplyCalculation> _starshipResupplyCalculationMock;

        public StarWarsApplicationServiceTests()
        {
            _starshipRepositoryMock = new Mock<IStarshipRepository>();
            _starshipResupplyCalculationMock = new Mock<IStarshipResupplyCalculation>();

            _applicationService = new StarWarsApplicationService(_starshipRepositoryMock.Object, _starshipResupplyCalculationMock.Object);
        }

        [TestMethod]
        public void GetStarshipsEnduranceTest()
        {
            ////Arrange
            _starshipRepositoryMock.Setup(x => x.GetStarshipEntities())
                .Returns(new List<StarshipEntity>() { new StarshipEntity("entity1", "80", "1 week") })
                .Verifiable();
            _starshipResupplyCalculationMock.Setup(x => x.CalculateNumberOfResupplyStopsNeeded(It.IsAny<StarshipEntity>(), It.IsAny<int>()))
                .Returns(new KeyValuePair<string, string>("entity1", "5"));

            var request = new GetStarshipEnduranceRequest(1000000);

            ////Act
            var response = _applicationService.GetStarshipsEndurance(request);
            var details = response.GetStarshipsEnduranceDetails();

            ////Assert
            Assert.AreEqual(1, details.Count);
            Assert.AreEqual("entity1", details[0].Key);
            Assert.AreEqual("5", details[0].Value);

        }
    }
}