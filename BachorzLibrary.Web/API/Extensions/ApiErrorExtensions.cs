using BachorzLibrary.Common;
using BachorzLibrary.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BachorzLibrary.Web.API.Extensions
{
    public static class ApiErrorExtensions
    {
        public static string ErrorString(this IEnumerable<ApiError> apiErrors, string separator = ", ")
        {
            return apiErrors.Select(ae => ae.ToString()).WithoutEmptyValues().Join(separator);
        }
    }
}
