using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.EventDTOs
{
    public class ReservationPostDTO
    {
        
        [Required, DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        [Required, MinLength(5), MaxLength(5)]
        public string VenueCode { get; set; }

        public IEnumerable<Staff> allstaffs { get; set; }
        [Required]
        [Display(Name = "Staff's Name")]
        public string StaffId { get; set; }
    }
}
