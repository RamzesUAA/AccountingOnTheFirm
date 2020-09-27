using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingUI.Services
{
    public static class StringExtensions
    {
        public static bool IsDigitsOnly(this string str)
        {
            return str.Any(ch => char.IsDigit(ch));
        }

        public static string FirstLetterToUpper(this string str)
        {
            var result = str.First().ToString().ToUpper() + str.Substring(1).ToLower();
            return result;
        }
    }
}
