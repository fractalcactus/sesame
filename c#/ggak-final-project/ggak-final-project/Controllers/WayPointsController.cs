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
using ggak_final_project.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ggak_final_project.Controllers
{
    public class WayPointsController : ApiController
    {
        private WorldPlaygroundDBContext db = new WorldPlaygroundDBContext();
     
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

            foreach (WayPoint point in allPoints)
            {
                if (point.Lat.Equals(checkLat) && point.Lng.Equals(checklng))
                {
                    pointToReturn = point;
                    break;

                }
            }

            return pointToReturn;
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
        [HttpPost]
        [ResponseType(typeof(WayPoint))]
        public WayPoint PostWayPoint([FromBody]string input)
        {
            WayPoint waypoint = JsonConvert.DeserializeObject<WayPoint>(input); //convert the input from Json to a WayPoint Object


            //WayPoint newWayPoint = new WayPoint();
            //newWayPoint.Lat = waypoint.Lat;
            //newWayPoint.Lng = waypoint.Lng;
            //newWayPoint.URL = waypoint.URL;

            db.WayPoints.Add(waypoint);
            db.SaveChanges();
            return waypoint;
            //WayPoint pointToReturn = new WayPoint();
            //IQueryable<WayPoint> allPoints = db.WayPoints; //get all points from db
            //foreach (WayPoint point in allPoints)
            //{
            //    if (point.Lat.Equals(newWayPoint.Lat) && point.Lng.Equals(newWayPoint.Lng))
            //    {
            //        pointToReturn = point;
            //        break;

            //    }
            //}

            //return pointToReturn;
            //Dictionary<string, string> jsonToReturn = new Dictionary<string, string>();
            //jsonToReturn.Add("Id","0");
            //jsonToReturn.Add("URL","");

            //WayPoint pointToReturn = new WayPoint();
            //IQueryable<WayPoint> allPoints = db.WayPoints; //get all points from db

            //foreach (WayPoint point in allPoints)
            //{
            //    if (point.Lat.Equals(checkLat) && point.Lng.Equals(checklng))
            //    {
            //        pointToReturn = point;
            //        break;

            //    }
            //}

            //return pointToReturn;sfdfdf 


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