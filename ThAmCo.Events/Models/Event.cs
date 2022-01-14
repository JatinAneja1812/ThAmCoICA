using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Models
{
    // its an important datamodel to carry Event details
    public class Event
    {
        public Event(){ }
        public int EventId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime EventDateTime { get; set; }

        [Required]
        public string EventTitle { get; set; }

        public string EventTypeId { get; set; }

        public string ReservationId { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public double? CostPerHour { get; set; }

        public int? Capacity { get; set; }

        public bool IsDeleted { get; set; }

        public int? FoodBookingId { get; set; }

        public ICollection<GuestBooking> Guests { get; set; }

    }
}
