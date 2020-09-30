using Microsoft.Extensions.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StarWars.Domain.Models.Tests
{
    [TestClass()]
    public class MegalightsPerHourTests
    {
        [TestMethod()]
        public void MegalightsPerHourTest()
        {
            var megalightsPerHour = new MegalightsPerHour("80");

            Assert.AreEqual("80", megalightsPerHour.Value);
        }

        [DataTestMethod]
        [DataRow("unknown")]
        [DataRow("UnKnOwn")]
        [DataRow("n/a")]
        [DataRow("N/a")]
        [DataRow("n/A")]
        public void MegalightsPerHour_IfPassedUnknownTest(String value)
        {
            var megalightsPerHour = new MegalightsPerHour(value);

            Assert.AreEqual(string.Empty, megalightsPerHour.Value);
        }
    }
}