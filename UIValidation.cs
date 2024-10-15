using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HomeAssignment_LiorSaid
{
    public class UIValidation
    {
        public static bool CheckEmptyString(string? i_StringToCheck)
        {
            return string.IsNullOrWhiteSpace(i_StringToCheck);
        }

        public static bool IsValidNumber(string? i_StringToCheck, out int o_Number)
        {
            return int.TryParse(i_StringToCheck, out o_Number);
        }
        
        public static bool IsLessThanTen(int i_Number)
        {
            return i_Number < 10;
        }
    }
}
