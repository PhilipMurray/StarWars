using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWars.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Application.Models.Tests
{
    [TestClass()]
    public class GetStarshipsEnduranceResponseTests
    {
        private GetStarshipsEnduranceResponse _getStarshipsEnduranceResponse;

        [TestInitialize()]
        public void Init()
        {
            _getStarshipsEnduranceResponse = new GetStarshipsEnduranceResponse(new List<KeyValuePair<string, string>>());
        }


        [TestMethod()]
        public void GetStarshipsEnduranceDetailsTest()
        {
            //// Arrange
            var details = new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("entity1", "100") };
            _getStarshipsEnduranceResponse = new GetStarshipsEnduranceResponse(details);

            //// Act
            var response = _getStarshipsEnduranceResponse.GetStarshipsEnduranceDetails();

            //// Assert
            Assert.AreEqual(details.Count, response.Count);
            Assert.AreEqual(details[0].Key, response[0].Key);
            Assert.AreEqual(details[0].Value, response[0].Value);
        }
    }
}