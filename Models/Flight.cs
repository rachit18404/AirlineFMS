using System;

namespace Models
{
    public class Flight
    {
        public int flightId { set; get; }
        public int flightName { set; get; }
        public string from { set; get; }
        public string to { set; get; }
        public DateTime departTime { set; get; }
        public DateTime arrivalTime { set; get; }
        public int price { set; get; }

    }
}
