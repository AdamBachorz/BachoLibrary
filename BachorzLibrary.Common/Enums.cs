using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BachorzLibrary.Common
{
    public enum FileExtensions
    {
        [Description(".csv")]
        Csv,
        [Description(".xml")]
        Xml,
        [Description(".json")]
        Json,
        [Description(".zip")]
        Zip,
        [Description(".pdf")]
        Pdf,
        [Description(".docx")]
        DocX,
    }

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
        [Description("text/xml")]
        textXml = 6,
        [Description("application/zip")]
        zip = 7,
    }

    public enum Country
    {
        Unknown = 0,
        [Description("PL")]
        Poland = 1,
        [Description("DE")]
        Germany = 2,
        [Description("FR")]
        France = 3,
        [Description("AT")]
        Austria = 4,
        [Description("NL")]
        Netherlands = 5,
        [Description("BE")]
        Belgium = 6,
        [Description("LU")]
        Luxemburg = 7,
        [Description("IT")]
        Italy = 8,
        [Description("ES")]
        Spain = 9,
        [Description("CZ")]
        Czech = 10,
        [Description("SK")]
        Slovakia = 11,
    }
}
