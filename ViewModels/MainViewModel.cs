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
    public class MainViewModel : BaseViewModel
    {
        public IIngredientService IngredientService { get; set; }

        public ICocktailService CocktailService { get; set; }

        public GlassService GlassService { get; set; }

        public ObservableCollection<Ingredient> Ingredients { get; set; }

        public ObservableCollection<Cocktail> Cocktails { get; set; }

        public ObservableCollection<Glass> Glasses { get; set; }

        private Ingredient? _selectedIngredient;

        public Ingredient? SelectedIngredient
        {
            get
            {
                return _selectedIngredient;
            }
            set
            {
                _selectedIngredient = value;

                OnPropertyChanged();
            }
        }

        private Cocktail? _selectedCocktail;

        public Cocktail? SelectedCocktail
        {
            get
            {
                return _selectedCocktail;
            }
            set
            {
                _selectedCocktail = value;

                OnPropertyChanged();
            }
        }

        private string _message = string.Empty;

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;

                OnPropertyChanged();
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

            Cocktails = new ObservableCollection<Cocktail>(
                CocktailService.Cocktails
            );

            Glasses = new ObservableCollection<Glass>(
                GlassService.Glass
            );
        }

        public void AddIngredient(string name, double cl, int price)
        {
            Ingredient ingredient = new(name, cl, price);

            Ingredients.Add(ingredient);

            IngredientService.Ingredients.Add(ingredient);

            Message = "Ingredient added.";
        }

        public void EditIngredient(Ingredient ingredient, string name, double cl, int price)
        {
            ingredient.Name = name;

            ingredient.Cl = cl;

            ingredient.Price = price;

            OnPropertyChanged(nameof(Ingredients));

            Message = "Ingredient edited.";
        }

        public void DeleteSelectedIngredient()
        {
            if (SelectedIngredient == null)
            {
                Message = "No ingredient selected.";

                return;
            }

            bool isUsed = Cocktails.Any(cocktail =>
                cocktail.Ingredients.Any(cocktailIngredient =>
                    cocktailIngredient.Ingredient.Id == SelectedIngredient.Id
                )
            );

            if (isUsed)
            {
                Message = "This ingredient is used in a cocktail, so it cannot be deleted.";

                return;
            }

            IngredientService.Ingredients.Remove(SelectedIngredient);

            Ingredients.Remove(SelectedIngredient);

            SelectedIngredient = null;

            Message = "Ingredient deleted.";
        }
    }
}