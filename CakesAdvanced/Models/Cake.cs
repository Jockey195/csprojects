﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakesAdvanced.Models
{
    internal class Cake
    {
        public string Name { get; }
        public decimal Price { get; }

        public List<Ingredient> _ingredients = new List<Ingredient>();
        public Cake(string name, List<Ingredient> ingredients)
        {
            Name = name;
            _ingredients = ingredients;
            Price = _ingredients.Sum(i => (i.Cost * 0.5m) * i.Quantity);
        }
    }
}