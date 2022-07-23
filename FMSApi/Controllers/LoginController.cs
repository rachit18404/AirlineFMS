using BusinessLayer;
using FMSApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService loginService;
        public LoginController()
        {
            loginService = new LoginService();
        }
        [HttpPost, Route("passenger")]
        public IActionResult login(Passenger passenger)
        {
            var response = loginService.PassengerLogin(passenger.email, passenger.password);
            if (response == null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }
    }
}
