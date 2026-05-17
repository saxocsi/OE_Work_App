using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace OE_Work_App.Models
{
    public class Cocktail
    {
        private static int id = 1;

        public int Id { get; private set; }

        public string Name { get; set; }

        public Glass Glass { get; set; }

        public List<CocktailIngredient> Ingredients { get; set; }

        public double TotalCl
        {
            get
            {
                return Ingredients.Sum(ingredient => ingredient.TotalCl);
            }
        }

        public int Price
        {
            get
            {
                return Ingredients.Sum(ingredient => ingredient.TotalPrice);
            }
        }

        public bool FitsInGlass
        {
            get
            {
                return TotalCl <= Glass.CapacityCl;
            }
        }

        public Cocktail(string name, Glass glass)
        {
            Id = id++;

            Name = name;

            Glass = glass;

            Ingredients = new List<CocktailIngredient>();
        }
    }
}