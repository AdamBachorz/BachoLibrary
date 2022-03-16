﻿using BachoLibrary.Common;
using BachoLibrary.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BachoLibrary.Web.API.Extensions
{
    public static class ApiErrorExtensions
    {
        public static string ErrorString(this IEnumerable<ApiError> apiErrors, string separator = Consts.DefaultStringEnumerator)
        {
            return apiErrors.Select(ae => ae.ToString()).WithoutEmptyValues().Join(separator);
        }
    }
}