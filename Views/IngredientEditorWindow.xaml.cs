using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OE_Work_App.Models;
using System.Windows;

namespace OE_Work_App.Views
{
    public partial class IngredientEditorWindow : Window
    {
        public string Name { get; set; }

        public double Cl { get; set; }

        public int Price { get; set; }

        public IngredientEditorWindow()
        {
            InitializeComponent();

            Name = string.Empty;

            DataContext = this;
        }

        public IngredientEditorWindow(Ingredient ingredient)
        {
            InitializeComponent();

            Name = ingredient.Name;

            Cl = ingredient.Cl;

            Price = ingredient.Price;

            DataContext = this;
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