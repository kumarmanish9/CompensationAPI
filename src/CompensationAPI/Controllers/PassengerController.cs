using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;
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
            var flights = await passengerService.GetPassengers(flightKey);
            return flights;
        }
    }



}
