using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OE_Work_App.Models;
using System.Collections.Generic;

namespace OE_Work_App.Services
{
    public class CocktailService : ICocktailService
    {
        public List<Cocktail> Cocktails { get; set; }

        public CocktailService()
        {
            Glass smallGlass = new("0.3 liter", 30);

            Glass mediumGlass = new("0.5 liter", 50);

            Ingredient vodka = new("Vodka", 4, 600);

            Ingredient jager = new("Jagermeister", 4, 700);

            Ingredient cola = new("Cola", 10, 250);

            Ingredient orangeJuice = new("Orange Juice", 10, 300);

            Cocktail vodkaCola = new("Vodka Cola", mediumGlass);

            vodkaCola.Ingredients.Add(
                new CocktailIngredient(vodka, 2)
            );

            vodkaCola.Ingredients.Add(
                new CocktailIngredient(cola, 2)
            );

            Cocktail jagerOrange = new("Jager Orange", mediumGlass);

            jagerOrange.Ingredients.Add(
                new CocktailIngredient(jager, 2)
            );

            jagerOrange.Ingredients.Add(
                new CocktailIngredient(orangeJuice, 2)
            );

            Cocktail strongShot = new("Strong Shot", smallGlass);

            strongShot.Ingredients.Add(
                new CocktailIngredient(vodka, 3)
            );

            strongShot.Ingredients.Add(
                new CocktailIngredient(jager, 2)
            );

            Cocktails = new List<Cocktail>()
            {
                vodkaCola,
                jagerOrange,
                strongShot
            };
        }
    }
}