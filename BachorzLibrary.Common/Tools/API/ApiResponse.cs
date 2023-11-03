using System.Net;

namespace BachorzLibrary.Common.Tools.API
{
    public class ApiResponse<T> where T : class
    {
        public string ResponseString { get; set; }
        public T Response { get; set; }
        public ApiResponseStatus Status { get; set; } = ApiResponseStatus.None;
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
