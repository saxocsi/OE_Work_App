using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OE_Work_App.Services;
using OE_Work_App.Models;
using System.Collections.ObjectModel;

namespace OE_Work_App.ViewModels
{
    public class MainViewModel
    {
        public IIngredientService IngredientService { get; set; }

        public ICocktailService CocktailService { get; set; }

        public ObservableCollection<Ingredient> Ingredients { get; set; }

        public string NewIngredientName { get; set; } = string.Empty;

        public double NewIngredientCl { get; set; }

        public int NewIngredientPrice { get; set; }

        public MainViewModel()
        {
            IngredientService = new IngredientService();

            CocktailService = new CocktailService();

            Ingredients = new ObservableCollection<Ingredient>(
                IngredientService.Ingredients
            );
        }

        public void AddIngredient()
        {
            Ingredient ing = new(
                NewIngredientName,
                NewIngredientCl,
                NewIngredientPrice
            );

            Ingredients.Add(ing);

            IngredientService.Ingredients.Add(ing);

            NewIngredientName = string.Empty;

            NewIngredientCl = 0;

            NewIngredientPrice = 0;
        }
    }
}