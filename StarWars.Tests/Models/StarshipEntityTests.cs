using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Domain.Models.Tests
{
    [TestClass()]
    public class StarshipEntityTests
    {
        [TestMethod()]
        public void StarshipEntityTest()
        {
            //// Arrange
            string name = "test1";
            string mglt = "100";
            string consumables = "1 day";

            //// Act
            var starshipEntity = new StarshipEntity(name, mglt, consumables);

            //// Assert
            Assert.AreEqual(name, starshipEntity.GetName());
            Assert.AreEqual(consumables, starshipEntity.GetConsumables());
            Assert.AreEqual(Convert.ToInt32(mglt), starshipEntity.GetMGLT());
        }

        [TestMethod()]
        public void StarshipEntityTest_NameIsNull()
        {
            //// Arrange
            string name = null;
            string mglt = "100";
            string consumables = "1 day";

            //// Act
            var starshipEntity = new StarshipEntity(name, mglt, consumables);

            //// Assert
            Assert.AreEqual(string.Empty, starshipEntity.GetName());
            Assert.AreEqual(consumables, starshipEntity.GetConsumables());
            Assert.AreEqual(Convert.ToInt32(mglt), starshipEntity.GetMGLT());
        }

        [TestMethod()]
        public void StarshipEntityTest_NameIsStringEmpty()
        {
            //// Arrange
            string name = string.Empty;
            string mglt = "100";
            string consumables = "1 day";

            //// Act
            var starshipEntity = new StarshipEntity(name, mglt, consumables);

            //// Assert
            Assert.AreEqual(string.Empty, starshipEntity.GetName());
            Assert.AreEqual(consumables, starshipEntity.GetConsumables());
            Assert.AreEqual(Convert.ToInt32(mglt), starshipEntity.GetMGLT());
        }

        [DataTestMethod]
        [DataRow("unknown")]
        [DataRow("UnKnOwn")]
        [DataRow("n/a")]
        [DataRow("N/a")]
        [DataRow("n/A")]
        public void StarshipEntityTest_NameIsUnkown(string value)
        {
            //// Arrange
            string name = value;
            string mglt = "100";
            string consumables = "1 day";

            //// Act
            var starshipEntity = new StarshipEntity(name, mglt, consumables);

            //// Assert
            Assert.AreEqual(string.Empty, starshipEntity.GetName());
            Assert.AreEqual(consumables, starshipEntity.GetConsumables());
            Assert.AreEqual(Convert.ToInt32(mglt), starshipEntity.GetMGLT());
        }

        [TestMethod()]
        public void StarshipEntityTest_ConsumablesIsNull()
        {
            //// Arrange
            string name = "test1";
            string mglt = "100";
            string consumables = null;

            //// Act
            var starshipEntity = new StarshipEntity(name, mglt, consumables);

            //// Assert
            Assert.AreEqual(name, starshipEntity.GetName());
            Assert.AreEqual(string.Empty, starshipEntity.GetConsumables());
            Assert.AreEqual(Convert.ToInt32(mglt), starshipEntity.GetMGLT());
        }

        [DataTestMethod]
        [DataRow("unknown")]
        [DataRow("UnKnOwn")]
        [DataRow("n/a")]
        [DataRow("N/a")]
        [DataRow("n/A")]
        public void StarshipEntityTest_ConsumablesIsUnknown(string value)
        {
            //// Arrange
            string name = "test1";
            string mglt = "100";
            string consumables = value;

            //// Act
            var starshipEntity = new StarshipEntity(name, mglt, consumables);

            //// Assert
            Assert.AreEqual(name, starshipEntity.GetName());
            Assert.AreEqual(string.Empty, starshipEntity.GetConsumables());
            Assert.AreEqual(Convert.ToInt32(mglt), starshipEntity.GetMGLT());
        }


        [TestMethod()]
        public void GetNameTest()
        {
            //// Arrange
            string name = "test1";
            string mglt = "100";
            string consumables = "1 day";
            var starshipEntity = new StarshipEntity(name, mglt, consumables);

            //// Act
            var starshipEntityName = starshipEntity.GetName();

            //// Assert
            Assert.AreEqual(name, starshipEntityName);
        }

        [TestMethod()]
        public void GetMGLTTest()
        {
            //// Arrange
            string name = "test1";
            string mglt = "100";
            string consumables = "1 day";
            var starshipEntity = new StarshipEntity(name, mglt, consumables);

            //// Act
            var starshipEntityMGLT = starshipEntity.GetMGLT();

            //// Assert
            Assert.AreEqual(100, starshipEntityMGLT);
        }

        [TestMethod()]
        public void GetMGLTTest_MgltIsNull()
        {
            //// Arrange
            string name = "test1";
            string mglt = null;
            string consumables = "1 day";
            var starshipEntity = new StarshipEntity(name, mglt, consumables);

            //// Act
            var starshipEntityMGLT = starshipEntity.GetMGLT();

            //// Assert
            Assert.AreEqual(mglt, starshipEntityMGLT);
        }

        [TestMethod()]
        public void GetMGLTTest_MgltIsStringEmpty()
        {
            //// Arrange
            string name = "test1";
            string mglt = string.Empty;
            string consumables = "1 day";
            var starshipEntity = new StarshipEntity(name, mglt, consumables);

            //// Act
            var starshipEntityMGLT = starshipEntity.GetMGLT();

            //// Assert
            Assert.AreEqual(null, starshipEntityMGLT);
        }

        [TestMethod()]
        public void GetConsumablesTest()
        {
            //// Arrange
            string name = "test1";
            string mglt = "100";
            string consumables = "1 day";
            var starshipEntity = new StarshipEntity(name, mglt, consumables);

            //// Act
            var starshipEntityConsumables = starshipEntity.GetConsumables();

            //// Assert
            Assert.AreEqual(consumables, starshipEntityConsumables);
        }
    }
}