using System;
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
        /// <summary>
        /// This is the summary of this method
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CheckPoint/5
        /// <summary>
        /// Creates checkpoint with a specific Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CheckPoint
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CheckPoint/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CheckPoint/5
        /// <summary>
        /// Deletes checkpoint from the map
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
        }
    }
}
