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
        private ObservableCollection<Ingredient> ingredients;
        private ObservableCollection<Cocktail> cocktails;
        private string message = string.Empty;

        public IIngredientService IngredientService { get; set; }

        public ICocktailService CocktailService { get; set; }

        public GlassService GlassService { get; set; }

        public ObservableCollection<Ingredient> Ingredients
        {
            get { return ingredients; }
            set
            {
                ingredients = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Cocktail> Cocktails
        {
            get { return cocktails; }
            set
            {
                cocktails = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Glass> Glasses { get; set; }

        public Ingredient? SelectedIngredient { get; set; }

        public Cocktail? SelectedCocktail { get; set; }

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            IngredientService = new IngredientService();
            CocktailService = new CocktailService();
            GlassService = new GlassService();

            ingredients = new ObservableCollection<Ingredient>(IngredientService.Ingredients);
            cocktails = new ObservableCollection<Cocktail>(CocktailService.Cocktails);
            Glasses = new ObservableCollection<Glass>(GlassService.Glasses);
        }

        public void AddIngredient(string name, double cl, int price)
        {
            Ingredient ingredient = new(name, cl, price);

            IngredientService.Ingredients.Add(ingredient);
            Ingredients.Add(ingredient);

            Message = "Ingredient added.";
        }

        public void EditIngredient(Ingredient ingredient, string name, double cl, int price)
        {
            ingredient.Name = name;
            ingredient.Cl = cl;
            ingredient.Price = price;

            Ingredients = new ObservableCollection<Ingredient>(IngredientService.Ingredients);

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
                Message = "This ingredient is used in a cocktail.";
                return;
            }

            IngredientService.Ingredients.Remove(SelectedIngredient);
            Ingredients.Remove(SelectedIngredient);

            SelectedIngredient = null;

            Message = "Ingredient deleted.";
        }

        public void AddCocktail(Cocktail cocktail)
        {
            CocktailService.Cocktails.Add(cocktail);
            Cocktails.Add(cocktail);

            Message = "Cocktail added.";
        }

        public void EditCocktail(Cocktail oldCocktail, Cocktail newCocktail)
        {
            oldCocktail.Name = newCocktail.Name;
            oldCocktail.Glass = newCocktail.Glass;
            oldCocktail.Ingredients = newCocktail.Ingredients;

            Cocktails = new ObservableCollection<Cocktail>(CocktailService.Cocktails);

            Message = "Cocktail edited.";
        }

        public void DeleteSelectedCocktail()
        {
            if (SelectedCocktail == null)
            {
                Message = "No cocktail selected.";
                return;
            }

            CocktailService.Cocktails.Remove(SelectedCocktail);
            Cocktails.Remove(SelectedCocktail);

            SelectedCocktail = null;

            Message = "Cocktail deleted.";
        }
    }
}