using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.EventDTOs
{
    public class FoodBookingDTO
    {
        [Key]
        [DisplayFormat(NullDisplayText = "N/A")]
        public int FoodBookingId { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        public int ClientReferenceId { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        public int NumberOfGuests { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        public int MenuId { get; set; }

        public MenusDTO Menu { get; set; }
    }
}
