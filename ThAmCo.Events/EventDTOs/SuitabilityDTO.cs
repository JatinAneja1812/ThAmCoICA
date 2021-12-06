using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.EventDTOs
{
    public class SuitabilityDTO

    {
        public string EventTypeId { get; set; }
        [ForeignKey(nameof(EventTypeId))]
        public EventTypeDTO EventType { get; set; }

        [MinLength(5), MaxLength(5)]
        public string VenueCode { get; set; }
        [ForeignKey(nameof(VenueCode))]
        public VenueDTO Venue { get; set; }
    }
}
