using OE_Work_App.Models;

namespace OE_Work_App.Services
{
    public class CocktailService : ICocktailService
    {
        public List<Cocktail> Cocktails { get; set; }

        public CocktailService(IIngredientService ingredientService, GlassService glassService)
        {
            Glass mediumGlass = glassService.Glasses.First(g => g.CapacityCl == 50);

            Ingredient vodka = FindIngredient(ingredientService, "Vodka");
            Ingredient gin = FindIngredient(ingredientService, "Gin");
            Ingredient rum = FindIngredient(ingredientService, "Rum");
            Ingredient tequila = FindIngredient(ingredientService, "Tequila");
            Ingredient tripleSec = FindIngredient(ingredientService, "Triple sec");
            Ingredient cola = FindIngredient(ingredientService, "Coca-Cola");

            Cocktail longIsland = new("Long Island", mediumGlass);
            longIsland.Ingredients.Add(new CocktailIngredient(vodka, 1));
            longIsland.Ingredients.Add(new CocktailIngredient(gin, 1));
            longIsland.Ingredients.Add(new CocktailIngredient(rum, 1));
            longIsland.Ingredients.Add(new CocktailIngredient(tequila, 1));
            longIsland.Ingredients.Add(new CocktailIngredient(tripleSec, 1));
            longIsland.Ingredients.Add(new CocktailIngredient(cola, 2));

            Cocktail rumCola = new("Rum-Cola", mediumGlass);
            rumCola.Ingredients.Add(new CocktailIngredient(rum, 2));
            rumCola.Ingredients.Add(new CocktailIngredient(cola, 3));

            Cocktails = new List<Cocktail>
            {
                longIsland,
                rumCola
            };
        }

        private static Ingredient FindIngredient(IIngredientService service, string name)
        {
            return service.Ingredients.First(i => i.Name == name);
        }
    }
}
