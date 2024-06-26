﻿using System.ComponentModel;

namespace BachorzLibrary.Common.Tools.API
{
    public enum ContentType
    {
        [Description("application/xml")]
        xml = 1,
        [Description("application/json")]
        json = 2,
        [Description("text/csv")]
        csv = 3,
        txt = 4,
        [Description("application/x-www-form-urlencoded")]
        xwwwFormUrlencoded = 5,
    }

    public enum ApiResponseStatus
    {
        None,
        ValidationError,
        TechnicalError,
        Unknown,
        Success,
        SuccessUnvalidated
    }

    public enum MethodType
    {
        Get,
        Post,
        Put,
        Delete
    }

    public enum AuthenticationType
    {
        NoAuth = 0,
        ApiKey = 1,
        BearerToken = 2,
        BasicAuth = 3,
        DigestAuth = 4,
        OAuth1 = 5,
        OAuth2 = 6,
        HawkAuthentication = 7,
        AwsSignature = 8,
        NtlmAuthentication = 9,
        AkamaiEdgeGrid = 10
    }
}
