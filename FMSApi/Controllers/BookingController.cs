using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Authorization;

namespace FMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private BookingBo bookingBo;
        public BookingController()
        {
            bookingBo = new BookingBo();
        }
        [HttpPost, Route("AddBooking")]
        public IActionResult AddBooking(Booking booking)
        {
            try
            {
                bookingBo.AddBooking(booking);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("GetAllBookings")]
        public IActionResult GetAllBookings()
        {
            try
            {
                return StatusCode(200, bookingBo.GetAllBookings());
            }
            catch (Exception ex)
            {

                return StatusCode(200, ex.Message);
            }
        }
        [HttpGet, Route("GetBookingsByPassengerId/{passengerId}")]
        public IActionResult GetBookingsByPassengerId(int passengerId)
        {
            try
            {
                return StatusCode(200, bookingBo.GetBookingsByPassengerId(passengerId));
            }
            catch (Exception ex)
            {

                return StatusCode(200, ex.Message);
            }
        }
    }
}
