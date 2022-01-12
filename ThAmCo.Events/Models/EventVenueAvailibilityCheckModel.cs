using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
