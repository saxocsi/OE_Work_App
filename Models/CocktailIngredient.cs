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

        public double Cl { get; set; }

        public CocktailIngredient(
            Ingredient ingredient,
            double cl
        )
        {
            Ingredient = ingredient;

            Cl = cl;
        }
    }
}