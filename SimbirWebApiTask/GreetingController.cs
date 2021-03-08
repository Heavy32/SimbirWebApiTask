using Microsoft.AspNetCore.Mvc;

namespace SimbirWebApiTask
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "Hello, Leha!";
        }
    }
}
