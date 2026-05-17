using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OE_Work_App.Models
{
    public class Cocktail
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Price { get; set; }

        public List<CocktailIngredient> Ingredients { get; set; } = new();
    }
}