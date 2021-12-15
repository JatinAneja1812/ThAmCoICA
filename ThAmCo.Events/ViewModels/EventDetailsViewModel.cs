using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThAmCo.Events.EventDTOs;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.ViewModels
{
    public class EventDetailsViewModel
    {
        public int EventId { get; set; }

        public DateTime EventDateTime { get; set; }

        public string EventTitle { get; set; }

        public string EventTypeId { get; set; }

        public int TotalGuestCount { get; set; }

        public string  ReservationID { get; set; }


        public string Description { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public double? CostPerHour { get; set; }

        public int? Capacity { get; set; }
        public IEnumerable<ReservationDTO> Reservation { get; set; }
        public IEnumerable<GuestBooking> GuestBookings { get; set; }

        public IEnumerable<Staffing> Staffings { get; set; }


    }
}
