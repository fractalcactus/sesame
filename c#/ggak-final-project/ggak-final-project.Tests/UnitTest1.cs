using System;
using ggak_final_project.BusinessLogic;
using ggak_final_project.Models;
using ggak_final_project.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ggak_final_project.Tests
{
    [TestClass]
    public class UnitTest1
    {

        private double radusThreshold = 0.001;

        [TestMethod]
        public void Radius_TwoPointsAreClose_WhenOnTopOfEachOrher()
        {
            //arrange
            Radius radius = new Radius();
            double firstLat = -41.288402;
            double firstLong = 174.776165;
            double secondLat = firstLat;
            double secondLong = firstLong;

            //act
            bool actual = radius.AreTwoPointsClose(firstLat, firstLong,secondLat,secondLong);
            //assert
            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void Radius_TwoPointsAreClose_WhenLatudeIsSame_AND_LongisOffByExactlyOne_radusThreshold()
        {
            //arrange
            Radius radius = new Radius();
            double firstLat = -41.288402;
            double firstLong = 174.776165;
            double secondLat = firstLat ;
            double secondLong = firstLong - radusThreshold;

            //act
            bool actual = radius.AreTwoPointsClose(firstLat, firstLong,secondLat,secondLong);
            //assert
            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void Radius_TwoPointsAreNOTClose_WhenLatudeIsSame_AND_LongisOffBy_TWO_radusThreshold()
        {
            //arrange
            Radius radius = new Radius();
            double firstLat = -41.288402;
            double firstLong = 174.776165;
            double secondLat = firstLat;
            double secondLong = firstLong - (radusThreshold * 2);

            //act
            bool actual = radius.AreTwoPointsClose(firstLat, firstLong, secondLat, secondLong);
            //assert
            Assert.IsFalse(actual);

        }

        [TestMethod]
        public void Radius_TwoPointsAreNOTClose_WhenLAT_isOffBy_ONE_AND_LONGisOffBy_ONE_radusThreshold()
        {
            //arrange
            Radius radius = new Radius();
            double firstLat = -41.288402;
            double firstLong = 174.776165;
            double secondLat = firstLat - (radusThreshold * 1);
            double secondLong = firstLong - (radusThreshold * 1);

                //act
            bool actual = radius.AreTwoPointsClose(firstLat, firstLong, secondLat, secondLong);
            //assert
            Assert.IsFalse(actual);

        }

        [TestMethod]
        public void Radius_TwoPointsAreNOTClose_WhenLatude_isOffBy_sin45_AND_LongisOffBy_sin45_radusThreshold()
        {
            //arrange
            Radius radius = new Radius();
            double firstLat = -41.288402;
            double firstLong = 174.776165;
            double secondLat = firstLat - (radusThreshold * Math.Sin(45 * (Math.PI / 180)));
            double secondLong = firstLong - (radusThreshold * Math.Sin(45 * (Math.PI / 180)));

            //act
            bool actual = radius.AreTwoPointsClose(firstLat, firstLong, secondLat, secondLong);
            //assert
            Assert.IsTrue(actual);

        }




        [TestMethod]
        public void Radius_TwoPointsAreClose_WhenLatudeIsSame_AND_LongisGreaterByExactlyOne_radusThreshold()
        {
            //arrange
            Radius radius = new Radius();
            double firstLat = -41.288402;
            double firstLong = 174.776165;
            double secondLat = firstLat;
            double secondLong = firstLong + radusThreshold;

            //act
            bool actual = radius.AreTwoPointsClose(firstLat, firstLong, secondLat, secondLong);
            //assert
            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void Radius_TwoPointsAreNOTClose_WhenLatudeIsSame_AND_LongisGreaterBy_TWO_radusThreshold()
        {
            //arrange
            Radius radius = new Radius();
            double firstLat = -41.288402;
            double firstLong = 174.776165;
            double secondLat = firstLat;
            double secondLong = firstLong + (radusThreshold * 2);

            //act
            bool actual = radius.AreTwoPointsClose(firstLat, firstLong, secondLat, secondLong);
            //assert
            Assert.IsFalse(actual);

        }

        [TestMethod]
        public void Radius_TwoPointsAreNOTClose_WhenLAT_isGreaterBy_ONE_AND_LONGisGreaterBy_ONE_radusThreshold()
        {
            //arrange
            Radius radius = new Radius();
            double firstLat = -41.288402;
            double firstLong = 174.776165;
            double secondLat = firstLat + (radusThreshold * 1);
            double secondLong = firstLong + (radusThreshold * 1);

            //act
            bool actual = radius.AreTwoPointsClose(firstLat, firstLong, secondLat, secondLong);
            //assert
            Assert.IsFalse(actual);

        }

        [TestMethod]
        public void Radius_TwoPointsAreNOTClose_WhenLatude_isGreaterBy_sin45_AND_LongisGreaterBy_sin45_radusThreshold()
        {
            //arrange
            Radius radius = new Radius();
            double firstLat = -41.288402;
            double firstLong = 174.776165;
            double secondLat = firstLat + (radusThreshold * Math.Sin(45 * (Math.PI / 180)));
            double secondLong = firstLong + (radusThreshold * Math.Sin(45 *(Math.PI / 180)));

            //act
            bool actual = radius.AreTwoPointsClose(firstLat, firstLong, secondLat, secondLong);
            //assert
            Assert.IsTrue(actual);

        }



    }
}
