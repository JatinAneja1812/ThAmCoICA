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
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName  { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "TelePhone Numer")]
        public long TelePhoneNumber { get; set; }

        public string EmailId { get; set; }

        [Required]
        public string Address { get; set; }

        [Display(Name = "Events's Date&Time")]
        public DateTime EventdateTime { get; set; }




    }

   

}
