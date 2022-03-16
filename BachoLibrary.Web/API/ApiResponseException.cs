﻿using BachoLibrary.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BachoLibrary.Web.API
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
