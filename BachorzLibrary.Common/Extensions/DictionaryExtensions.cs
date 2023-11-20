using System;
using System.Collections.Generic;

namespace BachorzLibrary.Common.Extensions
{
    public static class DictionaryExtensions
    {
        public static V GetValueIfExists<K, V>(this IDictionary<K, V> dictionary, K key, V defaultValue)
        {
            try
            {
                return dictionary.ContainsKey(key) ? dictionary[key] : defaultValue;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
    }
}