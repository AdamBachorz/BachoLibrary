using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BachoLibrary.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<E>(this IEnumerable<E> enumerable) => enumerable?.Any() != true;
        public static bool IsNotNullOrEmpty<E>(this IEnumerable<E> enumerable) => !IsNullOrEmpty(enumerable);
        public static string Join(this IEnumerable<string> enumerable, string separator = "", bool endWithSeparator = false) 
            => enumerable.IsNotNullOrEmpty() ? string.Join(separator, enumerable.ToArray()) + (endWithSeparator ? separator : string.Empty) : string.Empty;
        public static IEnumerable<string> WithoutEmptyValues(this IEnumerable<string> enumerable) => enumerable.Where(value => value.HasValue());
    }
}
