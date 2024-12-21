using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;
using AirlineCoreLibrary.Utility;
using Microsoft.AspNetCore.Mvc;

namespace CompensationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PassengerController(IPassengerService passengerService) : ControllerBase
    {
        [HttpGet(Name = "Passenger")]
        public async Task<List<Passenger>?> Get(string flightKey)
        {
            AppLogger.LogInfo($"Retrieving passengers for flight {flightKey}.");
            var flights = await passengerService.GetPassengers(flightKey);
            return flights;
        }
    }



}
