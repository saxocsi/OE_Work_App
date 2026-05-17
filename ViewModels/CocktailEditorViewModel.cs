using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OE_Work_App.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace OE_Work_App.ViewModels
{
    public class CocktailEditorViewModel : BaseViewModel
    {
        public ObservableCollection<Ingredient> Ingredients { get; set; }

        public ObservableCollection<Glass> Glasses { get; set; }

        public ObservableCollection<CocktailIngredient> CocktailIngredients { get; set; }

        private Ingredient? _selectedIngredient;

        public Ingredient? SelectedIngredient
        {
            get { return _selectedIngredient; }
            set
            {
                _selectedIngredient = value;
                OnPropertyChanged();
            }
        }

        private CocktailIngredient? _selectedCocktailIngredient;

        public CocktailIngredient? SelectedCocktailIngredient
        {
            get { return _selectedCocktailIngredient; }
            set
            {
                _selectedCocktailIngredient = value;
                OnPropertyChanged();
            }
        }

        private Glass? _selectedGlass;

        public Glass? SelectedGlass
        {
            get { return _selectedGlass; }
            set
            {
                _selectedGlass = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FitMessage));
            }
        }

        private string _cocktailName = string.Empty;

        public string CocktailName
        {
            get { return _cocktailName; }
            set
            {
                _cocktailName = value;
                OnPropertyChanged();
            }
        }

        private int _ingredientAmount = 1;

        public int IngredientAmount
        {
            get { return _ingredientAmount; }
            set
            {
                _ingredientAmount = value;
                OnPropertyChanged();
            }
        }

        public double TotalCl
        {
            get { return CocktailIngredients.Sum(ingredient => ingredient.TotalCl); }
        }

        public int TotalPrice
        {
            get { return CocktailIngredients.Sum(ingredient => ingredient.TotalPrice); }
        }

        public string FitMessage
        {
            get
            {
                if (SelectedGlass == null)
                {
                    return "No glass selected.";
                }

                if (TotalCl <= SelectedGlass.CapacityCl)
                {
                    return "Fits in glass.";
                }

                return "Does not fit in glass.";
            }
        }

        public CocktailEditorViewModel(
            ObservableCollection<Ingredient> ingredients,
            ObservableCollection<Glass> glasses
        )
        {
            Ingredients = ingredients;
            Glasses = glasses;
            CocktailIngredients = new ObservableCollection<CocktailIngredient>();

            SelectedIngredient = Ingredients.FirstOrDefault();
            SelectedGlass = Glasses.FirstOrDefault();
        }

        public CocktailEditorViewModel(
            Cocktail cocktail,
            ObservableCollection<Ingredient> ingredients,
            ObservableCollection<Glass> glasses
        )
        {
            Ingredients = ingredients;
            Glasses = glasses;

            CocktailName = cocktail.Name;
            SelectedGlass = cocktail.Glass;

            CocktailIngredients = new ObservableCollection<CocktailIngredient>(
                cocktail.Ingredients
            );

            SelectedIngredient = Ingredients.FirstOrDefault();
        }

        public void AddIngredient()
        {
            if (SelectedIngredient == null || IngredientAmount <= 0)
            {
                return;
            }

            CocktailIngredient cocktailIngredient = new(
                SelectedIngredient,
                IngredientAmount
            );

            CocktailIngredients.Add(cocktailIngredient);

            RefreshTotals();
        }

        public void DeleteIngredient()
        {
            if (SelectedCocktailIngredient == null)
            {
                return;
            }

            CocktailIngredients.Remove(SelectedCocktailIngredient);

            RefreshTotals();
        }

        private void RefreshTotals()
        {
            OnPropertyChanged(nameof(TotalCl));
            OnPropertyChanged(nameof(TotalPrice));
            OnPropertyChanged(nameof(FitMessage));
        }
    }
}