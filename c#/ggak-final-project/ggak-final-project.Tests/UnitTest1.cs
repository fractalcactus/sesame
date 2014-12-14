using System;
using ggak_final_project.Models;
using ggak_final_project.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ggak_final_project.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RadiusReturnsTrue()
        {
            //arrange
            RadiusController radius = new RadiusController();
            //act
            bool actual = radius.pointRadius(-41.288402, 174.776165, -41.288402, 174.776165);
            //assert
            Assert.AreEqual(true,actual);

        }

        [TestMethod]
        public void RadiusReturnsFalse()
        {
            //arrange
            RadiusController radius = new RadiusController();
            bool actual = radius.pointRadius(-41.288402, 174.776165, -41.289188, 174.775961);

            //Assert
            Assert.AreEqual(false,actual);
        }



    }
}
