using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OE_Work_App.Models;

namespace OE_Work_App.Services
{
    public class GlassService : IGlassService   
    {
        public List<Glass> Glass { get; set; } = new()
        {
            new Glass("0.3 liter", 30),

            new Glass("0.5 liter", 50),

            new Glass("1 liter", 100)
        };
    }
}