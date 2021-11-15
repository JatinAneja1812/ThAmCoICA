﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.DataModels
{
    public class FoodItem
    {
        public FoodItem()
        {

        }

        public FoodItem(string Desc, float up) : this()
        {
            Description = Desc;
            UnitPrice = up;
        }
        public int FoodItemId { get; set; }

        [Required]
        public string Description { get; set; }

        public float UnitPrice { get; set; }


    }
}
