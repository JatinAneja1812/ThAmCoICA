using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ThAmCo.Events.DTOs
{
    public class FoodItemDTO
    {
 
        [Key]
        public int FoodItemId { get; set; }

        public string Description { get; set; }

        public float UnitPrice { get; set; }
        //public ICollection<MenuFoodItem> Foods { get; set; }
        public ICollection<FoodItemDTO> foodItms { get; set; }
    }
}
