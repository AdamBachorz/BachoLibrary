using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace BachoLibrary.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool HasValue(this string text) => !string.IsNullOrWhiteSpace(text);
        public static bool HasNotValue(this string text) => !HasValue(text);

        public static bool IsDigit(this string text) => Regex.IsMatch(text, @"^\d+$");
        public static bool IsNotDigit(this string text) => !IsDigit(text);

        public static int ToInt(this string text)
        {
            int result = 0;

            if (string.IsNullOrEmpty(text)) text = "";
            text = text.Replace(",", ".");
            int.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out result);
            return result;
        }
        public static long ToLong(this string text)
        {
            long result = 0;

            if (string.IsNullOrEmpty(text)) text = "";
            text = text.Replace(",", ".");
            long.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out result);
            return result;
        }
        public static decimal ToSaveDecimal(this string text, decimal defaultValue = 0)
        {
            decimal result;

            // Try parsing in the current culture
            if (!decimal.TryParse(text, NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                // Then try in US english
                !decimal.TryParse(text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
                // Then in neutral language
                !decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                result = defaultValue;
            }

            return result;
        }

        public static bool IsIn(this string text, bool caseSensitive, params string[] strings)
            => strings?.Any(s => caseSensitive ? s.Equals(text) : s.Equals(text, StringComparison.OrdinalIgnoreCase)) == true;
        public static bool IsIn(this string text, params string[] strings) => IsIn(text, false, strings);

        public static bool ContainsPhrase(this string text, string phrase)
            => text?.IndexOf(phrase, StringComparison.OrdinalIgnoreCase) >= 0;
        public static bool ContainsAny(this string text, params string[] strings)
            => strings?.Any(s => text.ContainsPhrase(s)) == true;

        public static XCData ToXCData(this string ob) => new XCData(ob);

        public static string OrDefault(this string text, string defaultValue) => text.HasValue() ? text : defaultValue;
        public static string OrEmpty(this string text) => text.OrDefault(string.Empty);
        
        public static string ToCamelCase(this string text) => char.ToLowerInvariant(text[0]) + text.Substring(1);
        public static string ToCapital(this string text) => text.Substring(0, 1).ToUpper() + text.Substring(1);

        public static string RemoveText(this string text, string value)
        {
            string result = string.Empty;

            if (!string.IsNullOrEmpty(text))
                result = text.Replace(value, "");

            return result;
        }
        public static string RemoveSingleSpaces(this string text) => RemoveText(text, " ");
        public static string ReplaceMatchPattern(this string text, string pattern, string replacement) => Regex.Replace(text, pattern, replacement);
        public static string RemoveMatchPattern(this string text, string pattern) => ReplaceMatchPattern(text, pattern, string.Empty);
        public static string RemoveAllSpaces(this string text) => RemoveMatchPattern(text, @"\s+");

        public static string Encrypt(this string text)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            SHA256Managed sha256hasher = new SHA256Managed();
            byte[] hashedDataBytes = sha256hasher.ComputeHash(encoder.GetBytes(text));
            return Convert.ToBase64String(hashedDataBytes);
        }
    }
}