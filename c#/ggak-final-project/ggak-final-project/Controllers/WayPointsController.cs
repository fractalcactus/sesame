using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;
using System.Web.Http.Description;
using ggak_final_project.Controllers.business_logic;
using ggak_final_project.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ggak_final_project.Controllers
{
    public class WayPointsController : ApiController
    {
        private IWorldPlaygroundDBContext db;

        public WayPointsController()
        {
            this.db = new WorldPlaygroundDBContext();
        }

        public WayPointsController(IWorldPlaygroundDBContext fakeDb)
        {
            this.db = fakeDb;
        }

        //gets all the WayPoints
        //GET: api/WayPoints
        public IQueryable<WayPoint> GetWayPoints()
        {
            return db.WayPoints;

        }

        //a check method to see if you're at a WayPoint
        // GET: api/WayPoints/5
        //[ResponseType(typeof(WayPoint))]
        public WayPoint GetWayPoint(string lat, string lng)
        {
            float checkLat = float.Parse(lat); //get the Lat and Lng from the Json object
            float checklng = float.Parse(lng);

            Dictionary<string, string> jsonToReturn = new Dictionary<string, string>();
            jsonToReturn.Add("Id", "0");
            jsonToReturn.Add("URL", "");

            WayPoint pointToReturn = new WayPoint();
            IQueryable<WayPoint> allPoints = db.WayPoints; //get all points from db

            //create radius object
            Radius radius = new Radius(); //currently putting in a threshold radius of 


            return allPoints.ToList().FirstOrDefault(p => radius.isInRadius(p.Latitude, p.Longitude, checkLat, checklng));
            //?? pointToReturn;
            //foreach (WayPoint point in allPoints)
            //{
            //    if (radius.isInRadius(point.Latitude, point.Longitude, checkLat,checklng)) {
            //        pointToReturn = point;
            //        break;

            //    }
            //}

            //return pointToReturn;
        }

        // PUT: api/WayPoints/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutWayPoint(int id, WayPoint wayPoint)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != wayPoint.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(wayPoint).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!WayPointExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/WayPoints
        //store lat and long and url in db
        //  [HttpPost]
        [ResponseType(typeof(WayPoint))]
        public WayPoint PostWayPoint([FromBody] WayPoint waypoint) // before string previously 
        {
            if (ModelState.IsValid)
            {
                db.WayPoints.Add(waypoint);
                db.SaveChanges();
                return waypoint;
            }

            return null;
        }

        // DELETE: api/WayPoints/5
        [ResponseType(typeof(WayPoint))]
        public IHttpActionResult DeleteWayPoint(int id)
        {
            WayPoint wayPoint = db.WayPoints.Find(id);
            if (wayPoint == null)
            {
                return NotFound();
            }

            db.WayPoints.Remove(wayPoint);
            db.SaveChanges();

            return Ok(wayPoint);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WayPointExists(int id)
        {
            return db.WayPoints.Count(e => e.Id == id) > 0;
        }
    }
}