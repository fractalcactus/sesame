using System;
using ggak_final_project.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ggak_final_project.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private WorldPlaygroundDBContext db = new WorldPlaygroundDBContext();
        [TestMethod]
        public void testGettingEverythingFromWaypointsDb()
        {
            db.WayPoints;
        }
    }
}
