using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MinesweepR.Api.Controllers
{
    public class MineCordinatesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public int[] Get(int count,int min, int max)
        {
            return new org.random.JSONRPC.RandomJSONRPC("d2319b89-8389-4d24-b1eb-4dbd80009153").GenerateIntegers(count, min, max,false);
           
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
