using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OE_Work_App.Models
{
    public class Ingredient
    {
        private static int id = 1;

        public int Id { get; private set; }

        public string Name { get; set; }

        public double Cl { get; set; }

        public int Price { get; set; }

        public Ingredient(string name, double cl, int price)
        {
            Id = id++;
            Name = name;
            Cl = cl;
            Price = price;
        }
    }
}
