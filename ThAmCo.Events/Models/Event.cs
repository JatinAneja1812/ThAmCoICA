using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class Event
    {
        public int EventId { get; set; }
        [Required]
        [Display(Name = "Event's Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Event's Date&Time")]
        public DateTime EventDateTime { get; set; }

        [Required]
        [MinLength(3), MaxLength(3)]
        public string EventTypeId { get; set; }

        public int FoodBookingId { get; set; }

        public int StaffId { get; set; }
        public int ReservationId { get; set; }
        public int CustomerId{ get; set; }

        

    }
}
