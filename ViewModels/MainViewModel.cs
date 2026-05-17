using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OE_Work_App.Services;

namespace OE_Work_App.ViewModels
{
    public class MainViewModel
    {
        public IIngredientService IngredientService { get; set; }

        public ICocktailService CocktailService { get; set; }

        public MainViewModel()
        {
            IngredientService = new IngredientService();

            CocktailService = new CocktailService();
        }
    }
}