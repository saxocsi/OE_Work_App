using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OE_Work_App.Models;
using System.Collections.Generic;

namespace OE_Work_App.Services
{
    public class GlassService
    {
        public List<Glass> Glasses { get; set; } = new()
        {
            new Glass("0.3 liter", 30),
            new Glass("0.5 liter", 50),
            new Glass("1 liter", 100)
        };
    }
}