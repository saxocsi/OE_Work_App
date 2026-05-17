using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace OE_Work_App.Models
{
    public class Cocktail : INotifyPropertyChanged
    {
        private static int nextId = 1;

        private string name = string.Empty;
        private Glass glass = null!;
        private List<CocktailIngredient> ingredients = new();

        public int Id { get; private set; }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyChanged();
            }
        }

        public Glass Glass
        {
            get { return glass; }
            set
            {
                glass = value;
                NotifyChanged();
                NotifyChanged(nameof(FitsInGlass));
            }
        }

        public List<CocktailIngredient> Ingredients
        {
            get { return ingredients; }
            set
            {
                ingredients = value;
                NotifyChanged();
                NotifyChanged(nameof(TotalCl));
                NotifyChanged(nameof(Price));
                NotifyChanged(nameof(FitsInGlass));
            }
        }

        public double TotalCl
        {
            get { return Ingredients.Sum(ingredient => ingredient.TotalCl); }
        }

        public int Price
        {
            get { return Ingredients.Sum(ingredient => ingredient.TotalPrice); }
        }

        public bool FitsInGlass
        {
            get { return TotalCl <= Glass.CapacityCl; }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Cocktail(string name, Glass glass)
        {
            Id = nextId++;
            Name = name;
            Glass = glass;
        }

        private void NotifyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
