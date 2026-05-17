using OE_Work_App.Models;
using OE_Work_App.Utils;
using OE_Work_App.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace OE_Work_App.Views
{
    public partial class CocktailEditorWindow : Window
    {
        public CocktailEditorViewModel ViewModel { get; }

        public CocktailEditorWindow(
            ObservableCollection<Ingredient> ingredients,
            ObservableCollection<Glass> glasses)
        {
            InitializeComponent();

            ViewModel = new CocktailEditorViewModel(ingredients, glasses);
            DataContext = ViewModel;
        }

        public CocktailEditorWindow(
            Cocktail cocktail,
            ObservableCollection<Ingredient> ingredients,
            ObservableCollection<Glass> glasses)
        {
            InitializeComponent();

            ViewModel = new CocktailEditorViewModel(cocktail, ingredients, glasses);
            DataContext = ViewModel;
        }

        private void AddIngredientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!InputValidator.IsPositiveInt(ViewModel.IngredientAmount))
            {
                MessageBox.Show(
                    "Az adag száma legyen nagyobb mint 0.",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            string? error = ViewModel.TryAddIngredient();

            if (error != null)
            {
                MessageBox.Show(error, "Pohár kapacitás", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteIngredientBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteIngredient();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!InputValidator.IsValidText(ViewModel.CocktailName))
            {
                MessageBox.Show("A koktél neve kötelező.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (ViewModel.SelectedGlass == null)
            {
                MessageBox.Show("Válassz poharat.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (ViewModel.CocktailIngredients.Count == 0)
            {
                MessageBox.Show("A koktélnak legalább egy alapanyag kell.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!ViewModel.FitsInGlass)
            {
                MessageBox.Show(
                    "A koktél nem fér bele a kiválasztott pohárba. Csökkentsd a mennyiséget vagy válassz nagyobb poharat.",
                    "Pohár kapacitás",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
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
    }
}
