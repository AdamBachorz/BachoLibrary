﻿using BachorzLibrary.Common.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace BachorzLibrary.Common.Tools.API
{
    public class ApiError
    {
        public const string UnknownError = "Nieznany błąd";
        public const string DefaultErrorConnector = ";\n"; 
        public const string TechnicalErrorMessage = "Coś poszło nie tak - powiadom dział IT";

        public string Code { get; set; }
        public string Message { get; set; }

        public ApiError(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public ApiError(string message)
        {
            Message = message;
        }

        public override string ToString()
        {
            var code = Code.HasValue() ? $" (Kod: {Code})" : string.Empty;
            return $"{Message}{code}";
        }

        public static IEnumerable<ApiError> NoErrors => new List<ApiError>();
        public static ApiError TechnicalError => new ApiError(TechnicalErrorMessage);
        public static IEnumerable<ApiError> TechnicalErrorList => new List<ApiError> { TechnicalError };
    }

    public static class ApiErrorExtensions
    {
        public static IEnumerable<ApiError> WithoutEmptyValues(this IEnumerable<ApiError> errors)
            => errors.Where(e => e.Message.HasValue());

        public static string MessagesToString(this IEnumerable<ApiError> errors, string connector, bool endWithConnector = false) 
            => errors.IsNotNullOrEmpty() ? errors.Select(e => e.ToString()).Join(connector, endWithConnector) : null;

        public static void AddError(this IList<ApiError> errors, string code, string message)
            => errors.Add(new ApiError(code, message));

        public static void AddError(this IList<ApiError> errors, string message)
            => errors.Add(new ApiError(message));

        public static string PickErrorMessage(this IDictionary<string, string> errorCodes, string code, string defaultMessage = ApiError.UnknownError)
            => errorCodes.GetValueIfExists(code, defaultMessage);

    }
}
