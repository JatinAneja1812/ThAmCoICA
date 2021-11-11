using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.DataModels
{
    public class FoodBooking
    { 
        public FoodBooking()
        {

        }
        public int FoodBookingId { get; set; }

        public int ClientReferenceId { get; set; }

        public int NumberOfGuests { get; set; }


        public int MenuId { get; set; }

        public Menu Menu { get; set; }
        
    }

}
