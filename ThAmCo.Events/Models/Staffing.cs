using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class Staffing
    {
        public Staffing()
        {

        }
        public Staffing(int staffid, int eventid, Event evt, Staff sft)  
        {
            this.StaffId = staffid;
            this.EventId = eventid;
            this.Event = evt;
            this.Staff = sft;
        }
        [Required]
        public int StaffId { get; set; }
        [Required]
        public int EventId { get; set; }

        public Event Event { get; set; }

        public Staff Staff { get; set; }

    }
}
