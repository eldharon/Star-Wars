using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Star_Wars.Controllers
{
    public class EpisodesController : ApiController
    {
        // GET: api/Episodes
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Episodes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Episodes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Episodes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Episodes/5
        public void Delete(int id)
        {
        }
    }
}
