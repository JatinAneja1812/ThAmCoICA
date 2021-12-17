using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
