using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.DataModels
{
    public class Menu
    {

        public Menu()
        {

        }
        public Menu(string name): this()
        {
            MenuName = name;
        }

        public int MenuId { get; set; }

        [Required]
        public string MenuName { get; set; }

    }
}
