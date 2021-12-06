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

        public Staff(string Fname , String Lname, String title)
        {
            FirstName = Fname;
            LastName = Lname;
            StaffType = title;
        }

        public int Staffid { get; set; }

        [Required]
        [Display(Name = "Staff's First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Staff's Last Name")]
        public string LastName { get; set; }

        
        [Display(Name = "Staff's Full-Name")]
        public string FullName { get { return FirstName + " " + LastName; }}

        [Required]
        [Display(Name = "Staff's Title")]
        public string StaffType { get; set; }

        [Display(Name = "Staff Availibility")]
        public bool CheckAvailibility { get; set; }
    }
}
