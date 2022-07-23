using System;

namespace Models
{
    public class Flight
    {
        public int flightId { set; get; }
        public string name { set; get; }
        public string source { set; get; }
        public string destination { set; get; }
        public  string departureTime { set; get; }
        public string arrivalTime { set; get; }
     
        public long businessPrice { get; set; }
        public long economyPrice { get; set; }
        public int businessSeat { get; set; }
        public int economySeat { get; set; }

    

    }
}
