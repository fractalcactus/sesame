﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ggak_final_project.Controllers
{
    public class CheckPointController : ApiController
    {
        // GET: api/CheckPoint
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CheckPoint/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CheckPoint
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CheckPoint/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CheckPoint/5
        public void Delete(int id)
        {
        }
    }
}
