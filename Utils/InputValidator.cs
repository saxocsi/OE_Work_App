using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OE_Work_App.Utils
{
    public static class InputValidator
    {
        public static bool IsValidText(string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }

        public static bool IsPositiveDouble(double value)
        {
            return value > 0;
        }

        public static bool IsPositiveInt(int value)
        {
            return value > 0;
        }
    }
}