using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Booking
    {
        public int bookingId { set; get; }
        public int flightId { set; get; }
        public int userId { set; get; }
        public string className { set; get; }
        public int seatNo { set; get; }
        public DateTime date { set; get; }
        public int noOfSeats { set; get; }
        public int payment { set; get; }




    }
}
