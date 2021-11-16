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
            LastName = lname;
            EmailId = email;
        }
        public Customer(string fname, string lname, long cellnumber, string email) :this()
        {
            FirstName = fname;
            LastName = lname;
            TelePhoneNumber = cellnumber;
            EmailId = email;
        }
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName  { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        
        [Display(Name = "TelePhone Number")]
        public long? TelePhoneNumber { get; set; }

        [Required]
        public string EmailId { get; set; }


    }

   

}
