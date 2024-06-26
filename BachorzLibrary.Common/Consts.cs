﻿namespace BachorzLibrary.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class Consts
    {
        public struct DateFormat
        {
            public const string DayFirst = "dd-MM-yyyy";
            public const string YearFirst = "yyyy-MM-dd";
            public const string DateFirstWithTime = "yyyy-MM-dd HH:mm:ss";
            public const string DayFirstWithTime = "MM-dd-yyyy HH:mm:ss";
            public const string Compact = "yyyyMMddhhmmss";
        }

        public struct RegexPatterns
        {
            public const string Email = @"^\S+@\S+\.\S+$";
            public const string Nip = @"((\d{3}-\d{3}-\d{2}-\d{2})|(\d{3}-\d{2}-\d{2}-\d{3}))";
        }
    }
}
