using global::OE_Work_App.Views;
using OE_Work_App.Models;
using OE_Work_App.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OE_Work_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
                    window.Name,
                    window.Cl,
                    window.Price
                );
            }
        }

        private void EditIngredientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainViewModel.SelectedIngredient == null)
            {
                MainViewModel.Message = "No ingredient selected.";

                return;
            }

            IngredientEditorWindow window = new(MainViewModel.SelectedIngredient);

            window.Owner = this;

            if (window.ShowDialog() == true)
            {
                MainViewModel.EditIngredient(
                    MainViewModel.SelectedIngredient,
                    window.Name,
                    window.Cl,
                    window.Price
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

            if (window.ShowDialog() == true)
            {
                if (window.CocktailEditorViewModel.SelectedGlass == null)
                {
                    return;
                }

                Cocktail cocktail = new(
                    window.CocktailEditorViewModel.CocktailName,
                    window.CocktailEditorViewModel.SelectedGlass
                );

                cocktail.Ingredients = window
                    .CocktailEditorViewModel
                    .CocktailIngredients
                    .ToList();

                MainViewModel.AddCocktail(cocktail);
            }
        }

        private void EditCocktailBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainViewModel.SelectedCocktail == null)
            {
                MainViewModel.Message = "No cocktail selected.";

                return;
            }

            CocktailEditorWindow window = new(
                MainViewModel.SelectedCocktail,
                MainViewModel.Ingredients,
                MainViewModel.Glasses
            );

            window.Owner = this;

            if (window.ShowDialog() == true)
            {
                if (window.CocktailEditorViewModel.SelectedGlass == null)
                {
                    return;
                }

                Cocktail cocktail = new(
                    window.CocktailEditorViewModel.CocktailName,
                    window.CocktailEditorViewModel.SelectedGlass
                );

                cocktail.Ingredients = window
                    .CocktailEditorViewModel
                    .CocktailIngredients
                    .ToList();

                MainViewModel.EditCocktail(
                    MainViewModel.SelectedCocktail,
                    cocktail
                );
            }
        }

        private void DeleteCocktailBtn_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.DeleteSelectedCocktail();
        }
    }
}