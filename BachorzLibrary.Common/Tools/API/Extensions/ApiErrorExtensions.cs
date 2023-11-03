using BachorzLibrary.Common.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace BachorzLibrary.Common.Tools.API.Extensions
{
    public static class ApiErrorExtensions
    {
        public static string ErrorString(this IEnumerable<ApiError> apiErrors, string separator = ", ")
        {
            return apiErrors.Select(ae => ae.ToString()).WithoutEmptyValues().Join(separator);
        }
    }
}
