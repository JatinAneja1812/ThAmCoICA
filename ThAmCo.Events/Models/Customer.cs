using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class Customer
    {
        public Customer(){}

        public Customer(string fname, string lname, string email) : this()
        {
            FirstName = fname;
            EmailId = email;
        }
        public Customer(string fname, string lname, string cellnumber, string email) :this()
        {
            FirstName = fname;
            LastName = lname;
            PhoneNumber = cellnumber;
            EmailId = email;
        }
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName  { get; set; }

        [Display(Name = "Last Name")]
        [DisplayFormat(NullDisplayText = "-")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email ID")]
        public string EmailId { get; set; }

        [Display(Name = "FullName")]
        public string FullName { get { return FirstName + " " + LastName; } }
    } 

   

}
