using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.DataModels
{
    public class FoodItem
    {
        public int FoodItemId { get; set; }

        public string Description { get; set; }

        public float UnitPrice { get; set; }

        //public ICollection<MenuFoodItem> Foods { get; set; }
        public ICollection<FoodItem> foodItms { get; set; }

    }
}
