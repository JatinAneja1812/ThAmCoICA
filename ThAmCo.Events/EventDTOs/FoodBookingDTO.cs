using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.EventDTOs
{
    public class FoodBookingDTO
    {
        [Key]
        [DisplayFormat(NullDisplayText = "N/A")]
        public int FoodBookingId { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [Display(Name = "Event Id")]
        public int ClientReferenceId { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        public int NumberOfGuests { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [Display(Name = "Menu Name")]
        public int MenuId { get; set; }

        public MenusDTO Menu { get; set; }
    }
}
