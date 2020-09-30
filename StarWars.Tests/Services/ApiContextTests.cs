using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using StarWars.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace StarWars.Infrastructure.Services.Tests
{
    [TestClass()]
    public class ApiContextTests
    {
        private readonly Mock<IRestClient> _clientMock;
        private readonly ApiContext _apiContext;

        public ApiContextTests()
        {
            _clientMock = new Mock<IRestClient>();

            _apiContext = new ApiContext(_clientMock.Object);
        }

        [TestMethod()]
        public void GetTest_OK()
        {
            //// Arrange
            _clientMock.Setup(x => x.Execute(It.IsAny<RestRequest>()))
                .Returns(new RestResponse() { StatusCode = HttpStatusCode.OK, Content = "OK" });

            //// Act
            var response = _apiContext.Get("starships/");

            //// Assert
            Assert.AreEqual("OK", response);
        }

        [TestMethod()]
        public void GetTest_NotFound()
        {
            //// Arrange
            _clientMock.Setup(x => x.Execute(It.IsAny<RestRequest>()))
                .Returns(new RestResponse() { StatusCode = HttpStatusCode.NotFound});

            //// Act
            var response = _apiContext.Get("spaceships/");

            //// Assert
            Assert.AreEqual(string.Empty, response);
        }
    }
}