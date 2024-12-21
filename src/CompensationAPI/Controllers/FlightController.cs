using Microsoft.AspNetCore.Mvc;

namespace CompensationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {
        [HttpGet(Name = "Flights")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Flight 1", "Flight 2" };
        }
    }
}
