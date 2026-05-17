using OE_Work_App.Models;

namespace OE_Work_App.ViewModels
{
    public class IngredientEditorViewModel : BaseViewModel
    {
        private string ingredientName = string.Empty;
        private double cl;
        private int price;

        public string IngredientName
        {
            get { return ingredientName; }
            set
            {
                ingredientName = value;
                OnPropertyChanged();
            }
        }

        public double Cl
        {
            get { return cl; }
            set
            {
                cl = value;
                OnPropertyChanged();
            }
        }

        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }

        public IngredientEditorViewModel()
        {
        }

        public IngredientEditorViewModel(Ingredient ingredient)
        {
            IngredientName = ingredient.Name;
            Cl = ingredient.Cl;
            Price = ingredient.Price;
        }
    }
}
