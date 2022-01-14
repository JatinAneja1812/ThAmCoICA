using System.ComponentModel.DataAnnotations;

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
