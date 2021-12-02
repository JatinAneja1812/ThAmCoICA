using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.EventDTOs
{
    public class VenueDTO
    {
        [Key, MaxLength(5)]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, Int32.MaxValue)]
        public int Capacity { get; set; }

        public List<SuitabilityDTO> SuitableEventTypes { get; set; }

     //   public List<AvailabilityDTO> AvailableDates { get; set; }
    }
}
