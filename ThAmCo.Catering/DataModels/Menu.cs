using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.DataModels
{
    public class Menu
    {

        public Menu()
        {

        }

        public int MenuId { get; set; }

        public string MenuName { get; set; }

        public ICollection<MenuFoodItem> MenuFoods { get; set; }

    }
}
