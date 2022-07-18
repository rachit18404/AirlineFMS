using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Booking
    {
        public int bookingId { set; get; }
        public int flightId { set; get; }
        public int passengerId { get;set; }
      
        public string className { set; get; }
        public int seatNo { set; get; }
        public DateTime flightDate { set; get; }
        
}
}
