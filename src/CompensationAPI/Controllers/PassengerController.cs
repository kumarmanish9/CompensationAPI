using Microsoft.AspNetCore.Mvc;

namespace CompensationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PassengerController : ControllerBase
    {
        [HttpGet(Name = "Passenger")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Passenger 1", "Passenger 2" };
        }
    }
}
