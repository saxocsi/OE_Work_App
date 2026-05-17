using OE_Work_App.Models;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace OE_Work_App.ViewModels
{
    public class CocktailEditorViewModel : BaseViewModel
    {
        private Ingredient? selectedIngredient;
        private CocktailIngredient? selectedCocktailIngredient;
        private Glass? selectedGlass;
        private string cocktailName = string.Empty;
        private int ingredientAmount = 1;

        public ObservableCollection<Ingredient> Ingredients { get; }

        public ObservableCollection<Glass> Glasses { get; }

        public ObservableCollection<CocktailIngredient> CocktailIngredients { get; }

        public Ingredient? SelectedIngredient
        {
            get { return selectedIngredient; }
            set
            {
                selectedIngredient = value;
                OnPropertyChanged();
            }
        }

        public CocktailIngredient? SelectedCocktailIngredient
        {
            get { return selectedCocktailIngredient; }
            set
            {
                selectedCocktailIngredient = value;
                OnPropertyChanged();
            }
        }

        public Glass? SelectedGlass
        {
            get { return selectedGlass; }
            set
            {
                selectedGlass = value;
                OnPropertyChanged();
                RefreshTotals();
            }
        }

        public string CocktailName
        {
            get { return cocktailName; }
            set
            {
                cocktailName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanSave));
            }
        }

        public int IngredientAmount
        {
            get { return ingredientAmount; }
            set
            {
                ingredientAmount = value;
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

        public double RemainingCl
        {
            get
            {
                if (SelectedGlass == null)
                {
                    return 0;
                }

                return SelectedGlass.CapacityCl - TotalCl;
            }
        }

        public bool FitsInGlass
        {
            get
            {
                return SelectedGlass != null && TotalCl <= SelectedGlass.CapacityCl;
            }
        }

        public bool CanSave
        {
            get
            {
                return SelectedGlass != null
                    && !string.IsNullOrWhiteSpace(CocktailName)
                    && CocktailIngredients.Count > 0
                    && FitsInGlass;
            }
        }

        public string FitMessage
        {
            get
            {
                if (SelectedGlass == null)
                {
                    return "Nincs pohár kiválasztva.";
                }

                if (FitsInGlass)
                {
                    return $"Belefér a pohárba. (marad: {RemainingCl:0.#} cl)";
                }

                return $"Nem fér bele! ({TotalCl:0.#} cl / {SelectedGlass.CapacityCl:0.#} cl)";
            }
        }

        public CocktailEditorViewModel(
            ObservableCollection<Ingredient> ingredients,
            ObservableCollection<Glass> glasses)
        {
            Ingredients = ingredients;
            Glasses = glasses;
            CocktailIngredients = new ObservableCollection<CocktailIngredient>();
            CocktailIngredients.CollectionChanged += CocktailIngredients_CollectionChanged;

            SelectedIngredient = Ingredients.FirstOrDefault();
            SelectedGlass = Glasses.FirstOrDefault();
        }

        public CocktailEditorViewModel(
            Cocktail cocktail,
            ObservableCollection<Ingredient> ingredients,
            ObservableCollection<Glass> glasses)
        {
            Ingredients = ingredients;
            Glasses = glasses;
            CocktailIngredients = new ObservableCollection<CocktailIngredient>();
            CocktailIngredients.CollectionChanged += CocktailIngredients_CollectionChanged;

            foreach (CocktailIngredient item in cocktail.Ingredients)
            {
                Ingredient? sharedIngredient = ingredients.FirstOrDefault(i => i.Id == item.Ingredient.Id);

                if (sharedIngredient != null)
                {
                    CocktailIngredients.Add(new CocktailIngredient(sharedIngredient, item.Amount));
                }
            }

            CocktailName = cocktail.Name;
            SelectedGlass = glasses.FirstOrDefault(g => g.CapacityCl == cocktail.Glass.CapacityCl)
                ?? cocktail.Glass;
            SelectedIngredient = Ingredients.FirstOrDefault();
        }

        public string? TryAddIngredient()
        {
            if (SelectedIngredient == null)
            {
                return "Válassz alapanyagot.";
            }

            if (IngredientAmount <= 0)
            {
                return "Az adag száma legyen nagyobb mint 0.";
            }

            if (SelectedGlass == null)
            {
                return "Válassz poharat.";
            }

            double addedCl = SelectedIngredient.Cl * IngredientAmount;

            if (TotalCl + addedCl > SelectedGlass.CapacityCl)
            {
                int maxAdag = GetMaxAmountThatFits(SelectedIngredient);

                if (maxAdag <= 0)
                {
                    return "A pohár már tele van, nem fér bele több alapanyag.";
                }

                return $"Nem fér bele a pohárba! Maximum még {maxAdag} adag fér bele eből az alapanyagból.";
            }

            CocktailIngredients.Add(new CocktailIngredient(SelectedIngredient, IngredientAmount));
            return null;
        }

        public void DeleteIngredient()
        {
            if (SelectedCocktailIngredient == null)
            {
                return;
            }

            CocktailIngredients.Remove(SelectedCocktailIngredient);
        }

        public int GetMaxAmountThatFits(Ingredient ingredient)
        {
            if (SelectedGlass == null || ingredient.Cl <= 0)
            {
                return 0;
            }

            double remaining = SelectedGlass.CapacityCl - TotalCl;

            if (remaining <= 0)
            {
                return 0;
            }

            return (int)Math.Floor(remaining / ingredient.Cl);
        }

        private void CocktailIngredients_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            RefreshTotals();
        }

        private void RefreshTotals()
        {
            OnPropertyChanged(nameof(TotalCl));
            OnPropertyChanged(nameof(TotalPrice));
            OnPropertyChanged(nameof(RemainingCl));
            OnPropertyChanged(nameof(FitsInGlass));
            OnPropertyChanged(nameof(CanSave));
            OnPropertyChanged(nameof(FitMessage));
        }
    }
}
