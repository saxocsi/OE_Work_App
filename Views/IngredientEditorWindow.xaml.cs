using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OE_Work_App.Models;
using System.Windows;
using OE_Work_App.Utils;

namespace OE_Work_App.Views
{
    public partial class IngredientEditorWindow : Window
    {
        public string IngredientName { get; set; }

        public double Cl { get; set; }

        public int Price { get; set; }

        public IngredientEditorWindow()
        {
            InitializeComponent();

            IngredientName = string.Empty;

            DataContext = this;
        }

        public IngredientEditorWindow(Ingredient ingredient)
        {
            InitializeComponent();

            IngredientName = ingredient.Name;

            Cl = ingredient.Cl;

            Price = ingredient.Price;

            DataContext = this;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!InputValidator.IsValidText(IngredientName))
            {
                MessageBox.Show("Ingredient name is required.");

                return;
            }

            if (!InputValidator.IsPositiveDouble(Cl))
            {
                MessageBox.Show("CL must be greater than 0.");

                return;
            }

            if (!InputValidator.IsPositiveInt(Price))
            {
                MessageBox.Show("Price must be greater than 0.");

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