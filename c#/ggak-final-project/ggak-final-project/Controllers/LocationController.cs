using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Ajax.Utilities;

namespace ggak_final_project.Controllers
{
    public class LocationController : ApiController
    {
        // GET: api/Location
        public DateTime Get()
        {
           DateTime currentTime =  DateTime.UtcNow;
            return currentTime;
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
