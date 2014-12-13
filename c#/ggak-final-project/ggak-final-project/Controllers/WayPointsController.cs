using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        //GET: api/WayPoints
        public IQueryable<WayPoint> GetWayPoints()
        {
            return db.WayPoints;
        }

        // GET: api/WayPoints/5
        [ResponseType(typeof(WayPoint))]
        public String GetWayPoint(String lat, String lng)
            //takes a lat and a long as params
            //checks to see if that lat and long is in the database *ALEX LOCATION CODE HERE*
            
        {
            //Debug.WriteLine(input);
            ////return id and url IF the lat and long is in the DB
            //WayPoint wayPoint = db.WayPoints.Find(id);
            //if (wayPoint == null)
            //{
            //    return NotFound();
            //}

            //return Ok(wayPoint);
            return lat + " " + lng;
        }

        // PUT: api/WayPoints/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWayPoint(int id, WayPoint wayPoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wayPoint.Id)
            {
                return BadRequest();
            }

            db.Entry(wayPoint).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WayPointExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/WayPoints
        //store lat and long and url in db
        [HttpPost]
        [ResponseType(typeof(WayPoint))]
        public string PostWayPoint([FromBody]string value)
        {
            WayPoint waypoint = JsonConvert.DeserializeObject<WayPoint>(value);

            return waypoint.Lat.ToString();
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