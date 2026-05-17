using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OE_Work_App.Models
{
    public class Ingredient : INotifyPropertyChanged
    {
        private static int nextId = 1;

        private string name = string.Empty;
        private double cl;
        private int price;

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

        public double Cl
        {
            get { return cl; }
            set
            {
                cl = value;
                NotifyChanged();
            }
        }

        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                NotifyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Ingredient(string name, double cl, int price)
        {
            Id = nextId++;
            Name = name;
            Cl = cl;
            Price = price;
        }

        private void NotifyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
