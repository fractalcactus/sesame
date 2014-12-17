using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ggak_final_project.Models;

namespace ggak_final_project.Controllers
{
    public class MetricsController : ApiController
    {
        private WorldPlaygroundDBContext db = new WorldPlaygroundDBContext();

        // GET: api/Metrics
        public IQueryable<WayPoint> GetWayPoints()
        {
            return db.WayPoints;
        }

        // GET: api/Metrics/5
        [ResponseType(typeof(WayPoint))]
        public IHttpActionResult GetWayPoint(int id)
        {
            WayPoint wayPoint = db.WayPoints.Find(id);
            if (wayPoint == null)
            {
                return NotFound();
            }

            return Ok(wayPoint);
        }

        // PUT: api/Metrics/5
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

        // POST: api/Metrics
        [ResponseType(typeof(WayPoint))]
        public IHttpActionResult PostWayPoint(WayPoint wayPoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WayPoints.Add(wayPoint);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wayPoint.Id }, wayPoint);
        }

        // DELETE: api/Metrics/5
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