using OE_Work_App.Models;
using OE_Work_App.Utils;
using OE_Work_App.ViewModels;
using System.Windows;

namespace OE_Work_App.Views
{
    public partial class IngredientEditorWindow : Window
    {
        public IngredientEditorViewModel ViewModel { get; }

        public IngredientEditorWindow()
        {
            InitializeComponent();

            ViewModel = new IngredientEditorViewModel();
            DataContext = ViewModel;
        }

        public IngredientEditorWindow(Ingredient ingredient)
        {
            InitializeComponent();

            ViewModel = new IngredientEditorViewModel(ingredient);
            DataContext = ViewModel;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!InputValidator.IsValidText(ViewModel.IngredientName))
            {
                MessageBox.Show("Az alapanyag neve kötelező.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!InputValidator.IsPositiveDouble(ViewModel.Cl))
            {
                MessageBox.Show("A cl érték legyen nagyobb mint 0.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!InputValidator.IsPositiveInt(ViewModel.Price))
            {
                MessageBox.Show("Az ár legyen nagyobb mint 0.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
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
