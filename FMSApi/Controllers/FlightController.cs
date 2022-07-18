using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using BusinessLayer;

namespace FMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private FlightBo flightBo;
        public FlightController()
        {
            flightBo = new FlightBo();
        }
        [HttpPost, Route("AddFlight")]
        public IActionResult AddFlight(Flight flight)
        {
            try
            {
                flightBo.AddFlight(flight);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("SearchFlight")]
        public IActionResult SearchFlight(Flight flight)
        {
            try
            {
                var flights = flightBo.SearchFlight(flight.sourceAddress,flight.destinationAddress);
                return StatusCode(200, flights);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

    }
}

