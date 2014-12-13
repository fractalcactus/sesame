using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ggak_final_project.Models;


namespace ggak_final_project.Controllers
{
    public class LocationController : ApiController
    {
        // GET: api/Location
        public DateTime Get(String json)
        {
          //expect a geometry
            //If you have a hit a checkpoint in the DB: return the pointID and the matching URL

            WayPoint check = new WayPoint();
           //WorldPlaygroundDBContext.
            //// Create and save a new Blog 
            //Console.Write("Enter a name for a new Blog: ");
            //var name = Console.ReadLine();

            //var blog = new Blog { Name = name };
            //db.Blogs.Add(blog);
            //db.SaveChanges(); 

            return  DateTime.UtcNow; 
        }

        // GET: api/Location/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Location
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Location/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Location/5
        public void Delete(int id)
        {
        }
    }
}
