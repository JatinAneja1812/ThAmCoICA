using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.EventDTOs
{
    public class FoodItemDTO
    {

        [Key]
        [DisplayFormat(NullDisplayText = "N/A")]
        public int FoodItemId { get; set; }

        [Required]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Description { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        public float UnitPrice { get; set; }
    }
}
