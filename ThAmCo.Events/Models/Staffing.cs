using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class Staffing
    {
        [Required]
        public int StaffId { get; set; }
        [Required]
        public int EventId { get; set; }

        public Event envent { get; set; }

        public Staff staff { get; set; }

    }
}
