using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThAmCo.Events.EventDTOs;

namespace ThAmCo.Events.Models
{

    public class Event
    {
        public Event()
        {

        }
        public int EventId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime EventDateTime { get; set; }

        [Required]
        public string EventTitle { get; set; }

        //[MinLength(3), MaxLength(3)]
        public string EventTypeId { get; set; }

        public string ReservationId { get; set; }

        //public ICollection<VenueDTO> EventVenues { get; set; }

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
