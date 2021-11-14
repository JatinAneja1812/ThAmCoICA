using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.DataModels
{
    public class MenuFoodItem
    {
        public MenuFoodItem()
        {

        }

        [Required]
        public int MenuId { get; set; }
        [Required]
        public int FoodItemId { get; set; }

        public Menu Menu { get; set; }

        public FoodItem FoodItem { get; set; }


    }
}
