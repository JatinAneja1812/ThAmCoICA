using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class GuestBooking
    {
        public int GuestBookingID { get; set; }

        public int CustomerId { get; set; }


        public int EventId { get; set; }
        
        public Event Events { get;set; }

        public Customer Customers { get; set; }

        
        public string GuestAttendence { get; set; }
    }
}
