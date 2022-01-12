using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.EventDTOs
{
    public class MenuFoodItemsDTO
    {
       
        [Key]
        [Required]
        [DisplayFormat(NullDisplayText = "N/A")]
        public int MenuId { get; set; }
        [Key]
        [Required]
        [DisplayFormat(NullDisplayText = "N/A")]
        public int FoodItemId { get; set; }

        public MenusDTO Menu { get; set; }

        public FoodItemDTO FoodItem { get; set; }
    }
}
