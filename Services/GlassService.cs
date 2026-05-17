using OE_Work_App.Models;

namespace OE_Work_App.Services
{
    public class GlassService
    {
        public List<Glass> Glasses { get; set; } = new()
        {
            new Glass("0,3 literes pohár", 30),
            new Glass("0,5 literes pohár", 50),
            new Glass("1 literes pohár", 100)
        };
    }
}
