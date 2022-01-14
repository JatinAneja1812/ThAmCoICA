using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Models
{
    public class GuestBooking
    {

        public int GuestBookingID { get; set; }

        [Display(Name = "Guest-Id")]
        public int CustomerId { get; set; }
        [Display(Name = "Event-Id")]
        public int EventId { get; set; }

        public Event Events { get; set; }

        [Display(Name = "Guests")]
        public Customer Custs { get; set; }
        [Display(Name = "Guest-Attendence")]
        public string GuestAttendence { get; set; }
    }
}
