using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OE_Work_App.Models;

namespace OE_Work_App.Services
{
    public interface ICocktailService
    {
        List<Cocktail> Cocktails { get; set; }
    }
}