using System;
using System.Collections.Generic;
using System.Linq;

namespace BachorzLibrary.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<E>(this IEnumerable<E> enumerable) => enumerable?.Any() != true;
        public static bool IsNotNullOrEmpty<E>(this IEnumerable<E> enumerable) => !IsNullOrEmpty(enumerable);

        public static string Join(this IEnumerable<string> enumerable, string separator = "", bool endWithSeparator = false) 
            => enumerable.IsNotNullOrEmpty() ? string.Join(separator, enumerable.ToArray()) + (endWithSeparator ? separator : string.Empty) : string.Empty;
        public static string Join(this IEnumerable<string> enumerable, char separator, bool endWithSeparator = false) 
            => Join(enumerable, separator.ToString() ?? "", endWithSeparator);

        public static IEnumerable<string> WithoutEmptyValues(this IEnumerable<string> enumerable) => enumerable.Where(value => value.HasValue());

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T item in source)
            {
                action(item);
            }
        }

    }
}
