using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace SimbirWebApiTask
{
    [Route("api/[controller]")]
    public class GreetingController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Index()
        {
            return new List<int> { 1, 2, 3, 4, 5, 6 };
        }
    }
}
