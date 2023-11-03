using System.Net;

namespace BachorzLibrary.Common.Tools.API
{
    public class InvokeResult
    {
        public string ResponseString { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }

        public InvokeResult(string responseString, HttpStatusCode httpStatusCode)
        {
            ResponseString = responseString;
            HttpStatusCode = httpStatusCode;
        }

        public override string ToString() => $"{ResponseString} ({HttpStatusCode})";
    }
}
