using BachorzLibrary.Common.Extensions;
using System;
using System.Collections.Generic;

namespace BachorzLibrary.Common.Tools.API
{
    public class ApiResponseException : Exception
    {
        public ApiResponseException(IEnumerable<ApiError> apiErrors) 
            : base("Błąd" + 
                  (apiErrors.MessagesToString(ApiError.DefaultErrorConnector).HasValue() 
                  ? $": {apiErrors.MessagesToString(ApiError.DefaultErrorConnector)}" 
                  : string.Empty))
        {

        }
        
        public ApiResponseException(string message) : base(message)
        {

        }
    }
}
