using OE_Work_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OE_Work_App.Services
{
    public class IngredientService : IIngredientService
    {
        public List<Ingredient> Ingredients { get; set; } = new()
        {
           //short drinks
           new Ingredient("Vodka", 4, 50),
           new Ingredient("Gin", 4, 50),
           new Ingredient("Rum", 4, 50),
           new Ingredient("Tequila", 4, 50),
           new Ingredient("Triple sec", 2, 30),

           //long drinks
            new Ingredient("Corona", 10, 20),
            new Ingredient("Steffl", 10, 20),
            new Ingredient("Lowenbrau", 10, 20),

           //soft drinks
            new Ingredient("Coca-cola", 10, 20),
            new Ingredient("Tonic water", 10, 20),
            new Ingredient("Lemonade", 10, 20),
            new Ingredient("Orange juice", 10, 20),

        };
    }
}