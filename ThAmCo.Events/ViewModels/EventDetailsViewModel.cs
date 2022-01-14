using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ThAmCo.Events.EventDTOs;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.ViewModels
{
    public class EventDetailsViewModel
    {
        // events Models
        public int EventId { get; set; }

        public DateTime EventDateTime { get; set; }

        public string EventTitle { get; set; }

        public string EventTypeId { get; set; }

        public int TotalGuestCount { get; set; }

        public int GuestAssignedtoStaffCount { get; set; }

        // Venue Reservation 
        [DisplayFormat(NullDisplayText = "No Reservations")]
        public string ReservationID { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        public string Description { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        public string Code { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        public string Name { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        public double? CostPerHour { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        public int? Capacity { get; set; }

        // Some Lists 
        public IEnumerable<ReservationDTO> Reservation { get; set; }
        public IEnumerable<GuestBooking> GuestBookings { get; set; }
        public IEnumerable<Staffing> Staffings { get; set; }

        // Food Booking Models

        public int? FoodBooingId { get; set; }

        public IEnumerable<FoodBookingDTO> FoodBookings { get; set; }
        public IEnumerable<MenuFoodItemsDTO> Foods { get; set; }
    }
}
