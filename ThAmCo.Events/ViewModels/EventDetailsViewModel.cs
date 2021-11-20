using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThAmCo.Events.EventDTOs;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.ViewModels
{
    public class EventDetailsViewModel
    {

        public int EventId { get; set; }
        

        [Required]
        [Display(Name = "Event's Description")]
        public string EventTitle { get; set; }

        [Required]
        [Display(Name = "Event's Type")]
        public string EventTypeTitle { get; set; }
        public string EventTypeId { get; set; }
        [Display(Name = "Event's Date&Time")]
        public DateTime EventDateTime { get; set; }

    }
}
