using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.EventDTOs
{
    public class AvailabilityDTO
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [MinLength(5), MaxLength(5)]
        public string VenueCode { get; set; }

        [ForeignKey(nameof(VenueCode))]
        public VenueDTO Venue { get; set; }

        [Range(0.0, Double.MaxValue)]
        public double CostPerHour { get; set; }

        public ReservationDTO Reservation { get; set; }
    }
}
