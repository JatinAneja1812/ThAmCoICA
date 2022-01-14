using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.ViewModels
{
    public class EventIndexViewModel
    {
        public int EventId { get; set; }
        [Required]
        [Display(Name = "Event's Description")]
        public string EventTitle { get; set; }

        [Required]
        [Display(Name = "Event's Type")]
        public string EventTypeTitle { get; set; }
        public string EventTypeId { get; set; }

        [Display(Name = "Event's Date&Time")]
        public DateTime EventDateTime { get; set; }

        public IEnumerable<GuestBooking> GuestBookings { get; set; }

        public int TotalGuestcount { get; set; }

        public int? FoodBookingId { get; set; }
    }
}
