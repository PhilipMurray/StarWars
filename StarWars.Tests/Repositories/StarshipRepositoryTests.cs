using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StarWars.Domain.Models;
using StarWars.Infrastructure.DTO;
using StarWars.Infrastructure.Interfaces;
using StarWars.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Infrastructure.Repositories.Tests
{
    [TestClass()]
    public class StarshipRepositoryTests
    {
        private readonly Mock<IApiContext> _apiContextMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly StarshipRepository _starshipRepository;

        public StarshipRepositoryTests()
        {
            _apiContextMock = new Mock<IApiContext>();
            _mapperMock = new Mock<IMapper>();

            _starshipRepository = new StarshipRepository(_apiContextMock.Object, _mapperMock.Object);
        }

        [TestMethod()]
        public void GetStarshipEntitiesTest()
        {
            //// Arrange
            string jsonData = @"{
                'count': 1,
                'next': null,
                'previous': null,
                'results': [
                ]
            }";
            
            _apiContextMock.Setup(x => x.Get(It.IsAny<string>()))
                .Returns(jsonData);
            _mapperMock.Setup(x => x.Map<List<StarshipDTO>, List<StarshipEntity>>(It.IsAny<List<StarshipDTO>>()))
                .Returns(new List<StarshipEntity>() { new StarshipEntity("Y-wing", "80", "1 week") });

            //// Act
            var response = _starshipRepository.GetStarshipEntities();

            //// Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Count);
            Assert.AreEqual("Y-wing", response[0].GetName());
            Assert.AreEqual("1 week", response[0].GetConsumables());
            Assert.AreEqual(80, response[0].GetMGLT());
        }

        [TestMethod()]
        public void GetStarshipEntityTest()
        {
            //// Arrange
            _apiContextMock.Setup(x => x.Get(It.IsAny<string>()))
                .Returns(string.Empty);
            _mapperMock.Setup(x => x.Map<StarshipEntity>(It.IsAny<object>()))
                .Returns(new StarshipEntity("Y-wing", "80", "1 week"));

            //// Act
            var response = _starshipRepository.GetStarshipEntity(1);

            //// Assert
            Assert.IsNotNull(response);
            Assert.AreEqual("Y-wing", response.GetName());
            Assert.AreEqual("1 week", response.GetConsumables());
            Assert.AreEqual(80, response.GetMGLT());
        }
    }
}