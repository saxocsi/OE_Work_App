using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OE_Work_App.Models;
using OE_Work_App.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using OE_Work_App.Utils;

namespace OE_Work_App.Views
{
    public partial class CocktailEditorWindow : Window
    {
        public ObservableCollection<Ingredient> Ingredients { get; set; }

        public ObservableCollection<Glass> Glasses { get; set; }

        public ObservableCollection<CocktailIngredient> CocktailIngredients { get; set; }

        public Ingredient? SelectedIngredient { get; set; }

        public CocktailIngredient? SelectedCocktailIngredient { get; set; }

        public Glass? SelectedGlass { get; set; }

        public string CocktailName { get; set; }

        public int IngredientAmount { get; set; }

        public double TotalCl
        {
            get
            {
                return CocktailIngredients.Sum(ingredient => ingredient.TotalCl);
            }
        }

        public int TotalPrice
        {
            get
            {
                return CocktailIngredients.Sum(ingredient => ingredient.TotalPrice);
            }
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

        public CocktailEditorWindow(
            ObservableCollection<Ingredient> ingredients,
            ObservableCollection<Glass> glasses
        )
        {
            InitializeComponent();

            Ingredients = ingredients;
            Glasses = glasses;

            CocktailIngredients = new ObservableCollection<CocktailIngredient>();

            CocktailName = string.Empty;

            IngredientAmount = 1;

            SelectedIngredient = Ingredients.FirstOrDefault();

            SelectedGlass = Glasses.FirstOrDefault();

            DataContext = this;
        }

        public CocktailEditorWindow(
            Cocktail cocktail,
            ObservableCollection<Ingredient> ingredients,
            ObservableCollection<Glass> glasses
        )
        {
            InitializeComponent();

            Ingredients = ingredients;
            Glasses = glasses;

            CocktailName = cocktail.Name;

            SelectedGlass = cocktail.Glass;

            CocktailIngredients = new ObservableCollection<CocktailIngredient>(
                cocktail.Ingredients
            );

            IngredientAmount = 1;

            SelectedIngredient = Ingredients.FirstOrDefault();

            DataContext = this;
        }

        private void AddIngredientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedIngredient == null)
            {
                return;
            }

            if (!InputValidator.IsPositiveInt(IngredientAmount))
            {
                MessageBox.Show("Amount must be greater than 0.");

                return;
            }

            CocktailIngredient cocktailIngredient = new(
                SelectedIngredient,
                IngredientAmount
            );

            CocktailIngredients.Add(cocktailIngredient);

            RefreshUi();
        }

        private void DeleteIngredientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCocktailIngredient == null)
            {
                return;
            }

            CocktailIngredients.Remove(SelectedCocktailIngredient);

            RefreshUi();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!InputValidator.IsValidText(CocktailName))
            {
                MessageBox.Show("Cocktail name is required.");

                return;
            }

            if (SelectedGlass == null)
            {
                MessageBox.Show("Glass is required.");

                return;
            }

            if (CocktailIngredients.Count == 0)
            {
                MessageBox.Show("Cocktail must contain at least one ingredient.");

                return;
            }

            DialogResult = true;

            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;

            Close();
        }

        private void RefreshUi()
        {
            DataContext = null;

            DataContext = this;
        }
    }
}