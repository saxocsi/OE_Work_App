using OE_Work_App.Models;

namespace OE_Work_App.Services
{
    public class IngredientService : IIngredientService
    {
        public List<Ingredient> Ingredients { get; set; } = new()
        {
            new Ingredient("Vodka", 4, 500),
            new Ingredient("Gin", 4, 500),
            new Ingredient("Rum", 4, 500),
            new Ingredient("Tequila", 4, 500),
            new Ingredient("Triple sec", 2, 400),
            new Ingredient("Coca-Cola", 10, 200),
        };
    }
}
