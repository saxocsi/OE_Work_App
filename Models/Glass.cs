using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OE_Work_App.Models
{
    public class Glass
    {
        public string Name { get; set; }

        public double CapacityCl { get; set; }

        public Glass(string name, double capacityCl)
        {
            Name = name;
            CapacityCl = capacityCl;
        }
    }
}