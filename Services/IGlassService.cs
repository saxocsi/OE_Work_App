using OE_Work_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OE_Work_App.Services
{
    internal interface IGlassService
    {
        List<Glass> Glass { get; set; }
    }
}
