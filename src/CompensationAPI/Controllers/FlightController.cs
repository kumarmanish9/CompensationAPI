using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;
using AirlineCoreLibrary.Utility;
using Microsoft.AspNetCore.Mvc;

namespace CompensationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController(IFlightService flightService) : ControllerBase
    {
        [HttpGet(Name = "Flights")]
        public async Task<List<Flight>?> Get()
        {
            AppLogger.LogInfo($"Retrieving flight.");
            var flights = await flightService.GetFlights();
            return flights;
        }
    }
}
