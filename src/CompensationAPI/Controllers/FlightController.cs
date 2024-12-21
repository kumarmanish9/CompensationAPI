using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace CompensationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController(IFlightService flightService) : ControllerBase
    {
        [HttpGet(Name = "Flights")]
        public async Task<List<Flight>?> Get()
        {
            var flights = await flightService.GetFlights();
            return flights;
        }
    }
}
