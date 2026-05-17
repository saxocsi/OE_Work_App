using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OE_Work_App.Services;
using OE_Work_App.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace OE_Work_App.ViewModels
{
    public class MainViewModel
    {
        public IIngredientService IngredientService { get; set; }

        public ICocktailService CocktailService { get; set; }

        public GlassService GlassService { get; set; }

        public ObservableCollection<Ingredient> Ingredients { get; set; }

        public ObservableCollection<Glass> Glasses { get; set; }

        public ObservableCollection<CocktailIngredient> CurrentCocktailIngredients { get; set; }

        public string NewIngredientName { get; set; } = string.Empty;

        public double NewIngredientCl { get; set; }

        public int NewIngredientPrice { get; set; }

        public string NewCocktailName { get; set; } = string.Empty;

        public Glass? SelectedGlass { get; set; }

        public Ingredient? SelectedIngredient { get; set; }

        public int SelectedIngredientAmount { get; set; } = 1;

        public double CurrentCocktailCl
        {
            get
            {
                return CurrentCocktailIngredients.Sum(ingredient => ingredient.TotalCl);
            }
        }

        public int CurrentCocktailPrice
        {
            get
            {
                return CurrentCocktailIngredients.Sum(ingredient => ingredient.TotalPrice);
            }
        }

        public string CurrentCocktailStatus
        {
            get
            {
                if (SelectedGlass == null)
                {
                    return "No glass selected.";
                }

                if (CurrentCocktailCl <= SelectedGlass.CapacityCl)
                {
                    return "Fits in glass.";
                }

                return "Does not fit in glass.";
            }
        }

        public MainViewModel()
        {
            IngredientService = new IngredientService();

            CocktailService = new CocktailService();

            GlassService = new GlassService();

            Ingredients = new ObservableCollection<Ingredient>(
                IngredientService.Ingredients
            );

            Glasses = new ObservableCollection<Glass>(
                GlassService.Glass
            );

            CurrentCocktailIngredients = new ObservableCollection<CocktailIngredient>();

            SelectedGlass = Glasses.FirstOrDefault();

            SelectedIngredient = Ingredients.FirstOrDefault();
        }

        public void AddIngredient()
        {
            Ingredient ingredient = new(
                NewIngredientName,
                NewIngredientCl,
                NewIngredientPrice
            );

            Ingredients.Add(ingredient);

            IngredientService.Ingredients.Add(ingredient);

            NewIngredientName = string.Empty;

            NewIngredientCl = 0;

            NewIngredientPrice = 0;
        }

        public void AddIngredientToCocktail()
        {
            if (SelectedIngredient == null)
            {
                return;
            }

            if (SelectedIngredientAmount <= 0)
            {
                return;
            }

            CocktailIngredient cocktailIngredient = new(
                SelectedIngredient,
                SelectedIngredientAmount
            );

            CurrentCocktailIngredients.Add(cocktailIngredient);
        }
    }
}