﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakesAdvanced.Models
{
    public class Ingredient
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }

        public Ingredient()
        {

        }
    }
}
