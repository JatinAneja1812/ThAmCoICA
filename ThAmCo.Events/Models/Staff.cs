using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class Staff
    {

        public Staff()
        {

        }

        public int Staffid { get; set; }

        [Display(Name = "Staff's FullName")]
        public string StaffFullName { get; set; }

        public string Description { get; set; }
    }
}
