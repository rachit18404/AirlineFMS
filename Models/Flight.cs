using System;

namespace Models
{
    public class Flight
    {
        public int flightId { set; get; }
        public string flightName { set; get; }
        public string sourceAddress { set; get; }
        public string destinationAddress { set; get; }
        public  string departuretTime { set; get; }
        public string arrivalTime { set; get; }
        public long price { set; get; }
        public long business_seat_price { get; set; }
        public long economy_seat_price { get; set; }
        public int business_seat { get; set; }
        public int economy_seat { get; set; }

    

    }
}
