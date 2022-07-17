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
    public class PassengerController : ControllerBase
    {
        private PassengerBo passengerBo;
        public PassengerController()
        {
            passengerBo = new PassengerBo();
        }
        [HttpPost,Route("AddPassenger")]
        public IActionResult AddPassenger(Passenger passenger)
        {
            try
            {
                passengerBo.AddPassenger(passenger);
                return StatusCode(200);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("GetAllPassengers")]
        public IActionResult GetAllPassengers()
        {
            try
            {
                return StatusCode(200, passengerBo.GetAllPassengers());
            }
            catch (Exception ex)
            {

                return StatusCode(200, ex.Message);
            }
        }

    }
}
