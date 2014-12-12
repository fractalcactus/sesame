using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ggak_final_project.Controllers
{
    public class LocationController : ApiController
    {
        // GET: api/Location
        public String Get(String data)
        {
          //expect a geometry
            //If you have a hit a checkpoint in the DB: return the pointID and the matching URL

            return "return"; 
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
