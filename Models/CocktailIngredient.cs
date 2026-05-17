using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OE_Work_App.Models
{
    public class CocktailIngredient
    {
        public Ingredient Ingredient { get; set; } = new();

        public double Cl { get; set; }
    }
}