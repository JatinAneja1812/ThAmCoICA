﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.ViewModels
{
    public class StaffDetailsViewModel 
    {
        public int Staffid { get; set; }
 
        [Display(Name = "Staff's First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Staff's Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Staff's Full-Name")]
        public string FullName { get { return FirstName + " " + LastName; } }

        [Display(Name = "Staff's Title")]
        public string StaffType { get; set; }

        [Display(Name = "Staff Availibility")]
        public bool CheckAvailibility { get; set; }

       // public IEnumerable<Event> Events { get; set; }

        public IEnumerable<Staffing> staffings { get; set; }
    }
}
