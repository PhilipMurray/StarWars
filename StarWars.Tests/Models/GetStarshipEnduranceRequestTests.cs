using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWars.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Application.Models.Tests
{
    [TestClass()]
    public class GetStarshipEnduranceRequestTests
    {
        private GetStarshipEnduranceRequest _getStarshipEnduranceRequest;

        [TestInitialize()]
        public void Init()
        {
            _getStarshipEnduranceRequest = new GetStarshipEnduranceRequest();
        }

        [TestMethod()]
        public void GetMegalightsToTravelTest()
        {
            //// Arrange
            _getStarshipEnduranceRequest = new GetStarshipEnduranceRequest(100);

            //// Act
            var response = _getStarshipEnduranceRequest.GetMegalightsToTravel();

            //// Assert
            Assert.AreEqual(100, response);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        public void GetStarshipEnduranceRequest_ErrorIfPassedValueLessThanZero(int value)
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => new GetStarshipEnduranceRequest(value));

            Assert.AreEqual("megalightsToTravel must be greater than 0.", ex.Message);
        }
    }
}