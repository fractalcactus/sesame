using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
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
        //public IEnumerable<WayPoint> GetWayPoint(float lat, float lng)
        //{

        //    IEnumerable<WayPoint> allPoints = db.WayPoints.ToList(); //get all points from db

        //    //create radius object
        //    Radius radius = new Radius(); //currently putting in a threshold radius of 


        //    return allPoints.Where(p => radius.isInRadius(p.Latitude, p.Longitude, lat, lng));

        //}
        public WayPoint GetWayPoint(float lat, float lng)
        {

            IEnumerable<WayPoint> allPoints = db.WayPoints.ToList(); //get all points from db

            WayPoint toReturn = new WayPoint();
            toReturn.Latitude = 0;
            toReturn.Longitude = 0;
            toReturn.URL = null;

            //create radius object
            Radius radius = new Radius(); //currently putting in a threshold radius of 


            return allPoints.FirstOrDefault(p => radius.isInRadius(p.Latitude, p.Longitude, lat, lng)) ?? toReturn;
        }

        //returns a waypoint given the id
        // GET: api/WayPoints?id=5
        //[ResponseType(typeof(WayPoint))]
        public WayPoint GetWayPoint(int id)
        {
            //  int checkId = int.Parse(id);
            //  WayPoint pointToReturn = new WayPoint();
            // IQueryable<WayPoint> allPoints = db.WayPoints; //get all points from db

            // return   db.WayPoints.Find(id);

            return db.WayPoints.FirstOrDefault(p => p.Id == id);

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
        public IHttpActionResult PostWayPoint([FromBody] WayPoint waypoint) // before string previously 
        {



            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                return BadRequest(message);
            }

            db.WayPoints.Add(waypoint);
            db.SaveChanges();
            return Ok(waypoint);

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