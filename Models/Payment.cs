using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Payment
    {
        public int paymentId { get; set; }
        public int passengerId { get; set; }
        public DateTime paymentDate { get; set; }
        public long amount { get; set; }
        public string paymentStatus { get; set; }
    }
}
