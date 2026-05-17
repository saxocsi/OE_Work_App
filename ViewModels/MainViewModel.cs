using OE_Work_App.Models;
using OE_Work_App.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace OE_Work_App.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Ingredient> ingredients;
        private ObservableCollection<Cocktail> cocktails;
        private string message = string.Empty;
        private Ingredient? selectedIngredient;
        private Cocktail? selectedCocktail;

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

        public Ingredient? SelectedIngredient
        {
            get { return selectedIngredient; }
            set
            {
                selectedIngredient = value;
                OnPropertyChanged();
            }
        }

        public Cocktail? SelectedCocktail
        {
            get { return selectedCocktail; }
            set
            {
                selectedCocktail = value;
                OnPropertyChanged();
            }
        }

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
            GlassService = new GlassService();
            CocktailService = new CocktailService(IngredientService, GlassService);

            ingredients = new ObservableCollection<Ingredient>(IngredientService.Ingredients);
            cocktails = new ObservableCollection<Cocktail>(CocktailService.Cocktails);
            Glasses = new ObservableCollection<Glass>(GlassService.Glasses);
        }

        public void AddIngredient(string name, double cl, int price)
        {
            Ingredient ingredient = new(name, cl, price);

            IngredientService.Ingredients.Add(ingredient);
            Ingredients.Add(ingredient);

            Message = "Alapanyag hozzáadva.";
        }

        public void EditIngredient(Ingredient ingredient, string name, double cl, int price)
        {
            ingredient.Name = name;
            ingredient.Cl = cl;
            ingredient.Price = price;

            RefreshCocktailRows();

            Message = "Alapanyag módosítva.";
        }

        public void DeleteSelectedIngredient()
        {
            if (SelectedIngredient == null)
            {
                Message = "Nincs kiválasztott alapanyag.";
                return;
            }

            bool isUsed = Cocktails.Any(cocktail =>
                cocktail.Ingredients.Any(cocktailIngredient =>
                    cocktailIngredient.Ingredient.Id == SelectedIngredient.Id
                )
            );

            if (isUsed)
            {
                Message = "Ez az alapanyag koktélban van használva, nem törölhető.";
                return;
            }

            IngredientService.Ingredients.Remove(SelectedIngredient);
            Ingredients.Remove(SelectedIngredient);

            SelectedIngredient = null;

            Message = "Alapanyag törölve.";
        }

        public void AddCocktail(Cocktail cocktail)
        {
            if (!cocktail.FitsInGlass)
            {
                Message = "A koktél nem fér bele a pohárba, nem menthető.";
                return;
            }

            CocktailService.Cocktails.Add(cocktail);
            Cocktails.Add(cocktail);

            Message = "Koktél hozzáadva.";
        }

        public void EditCocktail(
            Cocktail cocktail,
            string name,
            Glass glass,
            List<CocktailIngredient> ingredients)
        {
            double totalCl = ingredients.Sum(i => i.TotalCl);

            if (totalCl > glass.CapacityCl)
            {
                Message = "A koktél nem fér bele a pohárba, nem menthető.";
                return;
            }

            cocktail.Name = name;
            cocktail.Glass = glass;
            cocktail.Ingredients = ingredients;

            Message = "Koktél módosítva.";
        }

        public void DeleteSelectedCocktail()
        {
            if (SelectedCocktail == null)
            {
                Message = "Nincs kiválasztott koktél.";
                return;
            }

            CocktailService.Cocktails.Remove(SelectedCocktail);
            Cocktails.Remove(SelectedCocktail);

            SelectedCocktail = null;

            Message = "Koktél törölve.";
        }

        private void RefreshCocktailRows()
        {
            foreach (Cocktail cocktail in Cocktails)
            {
                cocktail.Ingredients = cocktail.Ingredients.ToList();
            }
        }
    }
}
