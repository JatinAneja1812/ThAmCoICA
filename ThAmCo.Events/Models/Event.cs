using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{

    public class Event
    {
        public Event()
        {

        }
        public int EventId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime EventDateTime { get; set; }

        [Required]
        public string EventTitle { get; set; }

        //[MinLength(3), MaxLength(3)]
        public string EventTypeId { get; set; }

    }
}
