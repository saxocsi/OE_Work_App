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

namespace OE_Work_App.Views
{
    public partial class CocktailEditorWindow : Window
    {
        public CocktailEditorViewModel CocktailEditorViewModel { get; set; }

        public CocktailEditorWindow(
            ObservableCollection<Ingredient> ingredients,
            ObservableCollection<Glass> glasses
        )
        {
            InitializeComponent();

            CocktailEditorViewModel = new CocktailEditorViewModel(
                ingredients,
                glasses
            );

            DataContext = CocktailEditorViewModel;
        }

        public CocktailEditorWindow(
            Cocktail cocktail,
            ObservableCollection<Ingredient> ingredients,
            ObservableCollection<Glass> glasses
        )
        {
            InitializeComponent();

            CocktailEditorViewModel = new CocktailEditorViewModel(
                cocktail,
                ingredients,
                glasses
            );

            DataContext = CocktailEditorViewModel;
        }

        private void AddIngredientBtn_Click(object sender, RoutedEventArgs e)
        {
            CocktailEditorViewModel.AddIngredient();
        }

        private void DeleteIngredientBtn_Click(object sender, RoutedEventArgs e)
        {
            CocktailEditorViewModel.DeleteIngredient();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
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