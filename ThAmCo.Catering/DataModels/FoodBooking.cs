using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.DataModels
{
    public class FoodBooking
    {
        public FoodBooking()
        {

        }
        [Required]
        public int FoodBookingId { get; set; }
        // ClientReferenceId = EventId
        public int? ClientReferenceId { get; set; }

        public int NumberOfGuests { get; set; }

        public int MenuId { get; set; }

        public Menu Menu { get; set; }

    }

}
