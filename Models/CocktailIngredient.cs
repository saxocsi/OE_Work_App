using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OE_Work_App.Models
{
    public class CocktailIngredient
    {
        public Ingredient Ingredient { get; set; }

        public int Amount { get; set; }

        public double TotalCl
        {
            get
            {
                return Ingredient.Cl * Amount;
            }
        }

        public int TotalPrice
        {
            get
            {
                return Ingredient.Price * Amount;
            }
        }

        public CocktailIngredient(Ingredient ingredient, int amount)
        {
            Ingredient = ingredient;

            Amount = amount;
        }
    }
}