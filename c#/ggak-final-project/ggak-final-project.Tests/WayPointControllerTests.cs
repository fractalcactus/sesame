using System;
using System.Threading;
using System.Web.Http;
using Results = System.Web.Http.Results; 
using ggak_final_project.Controllers;
using ggak_final_project.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ggak_final_project.Tests
{
    [TestClass]
    public class WayPointControllerTests
    {

        private IWorldPlaygroundDBContext _context;
        private WayPointsController _controller;
        private float radiusThreshold = (float)0.001;

        [TestInitialize]
        public void SetUp()
        {
            _context = new fakeDataContext();

            WayPoint w1 = new WayPoint();
            w1.Id = 1;
            w1.Latitude = (float)41.234343;
            w1.Longitude = (float)43.234343;
            w1.URL = "W1URL";

            WayPoint w2 = new WayPoint();
            w2.Id = 2;
            w2.Latitude = (float)44.234343;
            w2.Longitude = (float)45.234343;
            w2.URL = "W2URL";

            WayPoint w3 = new WayPoint();
            w3.Id = 3;
            w3.Latitude = (float)49.234343;
            w3.Longitude = (float)48.234343;
            w3.URL = "W3URL";


            _context.WayPoints.Add(w1);
            _context.WayPoints.Add(w2);
            _context.WayPoints.Add(w3);
            _controller = new WayPointsController(_context);

        }
        [TestMethod]
        public void it_returns_a_single_checkpoint()
        {
            WayPoint checkWayPoint = _controller.GetWayPoint(2);
            //assert
            Assert.AreEqual("W2URL", checkWayPoint.URL);
        }

        [TestMethod]
        public void it_responds_with_an_error_with_incorrect_post()
        {

            WayPoint checkWayPoint = new WayPoint() { };
            _controller.Configuration = new HttpConfiguration();
            _controller.Validate(checkWayPoint);

            IHttpActionResult response = _controller.PostWayPoint(checkWayPoint);

            Assert.IsInstanceOfType(response, typeof( Results.BadRequestErrorMessageResult));
           
        }
    }
}
