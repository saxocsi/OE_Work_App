using OE_Work_App.Models;
using OE_Work_App.ViewModels;
using OE_Work_App.Views;
using System.Windows;

namespace OE_Work_App
{
    public partial class MainWindow : Window
    {
        public MainViewModel MainViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            MainViewModel = new MainViewModel();
            DataContext = MainViewModel;
        }

        private void AddIngredientBtn_Click(object sender, RoutedEventArgs e)
        {
            IngredientEditorWindow window = new();
            window.Owner = this;

            if (window.ShowDialog() == true)
            {
                MainViewModel.AddIngredient(
                    window.ViewModel.IngredientName,
                    window.ViewModel.Cl,
                    window.ViewModel.Price
                );
            }
        }

        private void EditIngredientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainViewModel.SelectedIngredient == null)
            {
                MainViewModel.Message = "Nincs kiválasztott alapanyag.";
                return;
            }

            IngredientEditorWindow window = new(MainViewModel.SelectedIngredient);
            window.Owner = this;

            if (window.ShowDialog() == true)
            {
                MainViewModel.EditIngredient(
                    MainViewModel.SelectedIngredient,
                    window.ViewModel.IngredientName,
                    window.ViewModel.Cl,
                    window.ViewModel.Price
                );
            }
        }

        private void DeleteIngredientBtn_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.DeleteSelectedIngredient();
        }

        private void AddCocktailBtn_Click(object sender, RoutedEventArgs e)
        {
            CocktailEditorWindow window = new(
                MainViewModel.Ingredients,
                MainViewModel.Glasses
            );
            window.Owner = this;

            if (window.ShowDialog() == true && window.ViewModel.SelectedGlass != null)
            {
                Cocktail cocktail = new(
                    window.ViewModel.CocktailName,
                    window.ViewModel.SelectedGlass
                );

                cocktail.Ingredients = window.ViewModel.CocktailIngredients.ToList();

                MainViewModel.AddCocktail(cocktail);
            }
        }

        private void EditCocktailBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainViewModel.SelectedCocktail == null)
            {
                MainViewModel.Message = "Nincs kiválasztott koktél.";
                return;
            }

            CocktailEditorWindow window = new(
                MainViewModel.SelectedCocktail,
                MainViewModel.Ingredients,
                MainViewModel.Glasses
            );
            window.Owner = this;

            if (window.ShowDialog() == true && window.ViewModel.SelectedGlass != null)
            {
                MainViewModel.EditCocktail(
                    MainViewModel.SelectedCocktail,
                    window.ViewModel.CocktailName,
                    window.ViewModel.SelectedGlass,
                    window.ViewModel.CocktailIngredients.ToList()
                );
            }
        }

        private void DeleteCocktailBtn_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.DeleteSelectedCocktail();
        }
    }
}
