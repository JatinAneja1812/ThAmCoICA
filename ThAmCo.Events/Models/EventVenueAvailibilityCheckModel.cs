using System;

namespace ThAmCo.Events.Models
{
    public class EventVenueAvailibilityCheckModel
    {
        public string EventTypeId { get; set; }

        public DateTime Getdate { get; set; }
        public string BeginDate { get; set; }

        public string EndDate { get; set; }
    }
}
