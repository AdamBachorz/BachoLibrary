using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace BachorzLibrary.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string Description(this Enum @enum)
        {
            var enumType = @enum
                .GetType()
                .GetField(@enum.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), true)
                .FirstOrDefault() as DescriptionAttribute;

            return enumType?.Description ?? string.Empty;
        }

        public static bool IsAnyOf<E>(this E @enum, ICollection<E> enums) where E : struct, IConvertible 
        {
            foreach (var item in enums)
            {
                if (@enum.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
