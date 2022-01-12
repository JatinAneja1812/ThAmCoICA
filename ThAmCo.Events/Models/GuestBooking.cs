using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Guests")]
        public Customer Custs { get; set; }
        public string GuestAttendence { get; set; }
    }
}
