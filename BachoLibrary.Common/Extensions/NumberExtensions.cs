using System;
using System.Collections.Generic;
using System.Text;

namespace BachoLibrary.Common.Extensions
{
    public static class NumberExtensions
    {
        public static bool IsBetween(this int number, int min, int max, bool includeBounds) 
            => includeBounds ? number >= min && number <= max : number > min && number < max;
        public static bool IsBetween(this decimal number, decimal min, decimal max, bool includeBounds) 
            => includeBounds ? number >= min && number <= max : number > min && number < max;
        public static string ToFixedString(this decimal number) => number.ToString("F2").Replace(",", ".");
    }
}
