using BachorzLibrary.Common.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace BachorzLibrary.Common.Tools.API
{
    /// <summary>
    /// Klasa do obsługi żądań API
    /// </summary>
    /// <typeparam name="R">Klasa danych wyjściowych (domyślnie JSON)</typeparam>
    public class ApiConnection<R>
    {
        public string WareHouseName { get; set; } = string.Empty;
        public string Host { get; set; }
        public string Token { get; set; }
        public NetworkCredential Credential { get; set; }
        public ContentType InputContentType { get; set; } = ContentType.json;
        public virtual Func<string, R> ResultDataInterpreter { get; set; }
        public ApiResponseStatus ApiResponseStatus { get; set; } = ApiResponseStatus.None;


        public R Get(string methodName, string inputBody = null, ApiValidator<R> validator = null, string urlConnector = "/") 
            => ValidatedResultData(GetString(methodName, inputBody, urlConnector), validator);
        public R Post(string methodName, string inputBody = null, ApiValidator<R> validator = null, string urlConnector = "/") 
            => ValidatedResultData(PostString(methodName, inputBody, urlConnector), validator);
        public R Put(string methodName, string inputBody = null, ApiValidator<R> validator = null, string urlConnector = "/") 
            => ValidatedResultData(PutString(methodName, inputBody, urlConnector), validator);
        public R Delete(string methodName, string inputBody = null, ApiValidator<R> validator = null, string urlConnector = "/") 
            => ValidatedResultData(DeleteString(methodName, inputBody, urlConnector), validator);

        public string GetString(string methodName, string inputBody = null, string urlConnector = "/") 
            => InvokeAndGetResult(methodName, "GET", inputBody, urlConnector);
        public string PostString(string methodName, string inputBody = null, string urlConnector = "/") 
            => InvokeAndGetResult(methodName, "POST", inputBody, urlConnector);
        public string PutString(string methodName, string inputBody = null, string urlConnector = "/") 
            => InvokeAndGetResult(methodName, "PUT", inputBody, urlConnector);
        public string DeleteString(string methodName, string inputBody = null, string urlConnector = "/") 
            => InvokeAndGetResult(methodName, "DELETE", inputBody, urlConnector);

        // Tymczasowo nieużywane
        //public R GetFromFullUri (Uri uri, string inputBody = null, ApiValidator<R> validator = null) 
        //    => ValidatedResultData(InvokeAndGetResult(uri, "GET", inputBody), validator);
        //public R PostFromFullUri (Uri uri, string inputBody = null, ApiValidator<R> validator = null) 
        //    => ValidatedResultData(InvokeAndGetResult(uri, "POST", inputBody), validator);
        //public R PutFromFullUri (Uri uri, string inputBody = null, ApiValidator<R> validator = null) 
        //    => ValidatedResultData(InvokeAndGetResult(uri, "PUT", inputBody), validator);
        //public R DeleteFromFullUri (Uri uri, string inputBody = null, ApiValidator<R> validator = null) 
        //    => ValidatedResultData(InvokeAndGetResult(uri, "DELETE", inputBody), validator);

        protected string InvokeAndGetResult(Uri uri, string methodType, string inputBody = null)
        {
            HttpWebResponse response = null;
            try
            {
                var request = WebRequest.Create(uri) as HttpWebRequest;

                if (Credential != null)
                {
                    if (Token.HasNotValue())
                    {
                        Token = Credential.BuildBase64Token();
                    }
                    request.PreAuthenticate = true;
                    request.Credentials = Credential;
                }
                else
                {
                    request.UseDefaultCredentials = true;
                    request.Credentials = CredentialCache.DefaultCredentials;
                }

                if (Token.HasValue())
                {
                    request.Headers[HttpRequestHeader.Authorization] = Token; 
                }

                request.Method = methodType;
                request.ContentType = InputContentType.Description();

                if (inputBody.HasValue())
                {
                    byte[] data = Encoding.UTF8.GetBytes(inputBody);
                    request.ContentLength = data.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }

                response = request.GetResponse() as HttpWebResponse;
                var result = new StreamReader(response.GetResponseStream()).ReadToEnd();
                ApiResponseStatus = ApiResponseStatus.SuccessUnvalidated;
                return result;
            }
            catch (Exception ex)
            {
                ApiResponseStatus = ApiResponseStatus.TechnicalError;
                //MyLogi.Add(TypLogEnum.ZamowienieDostawca, $"{GetType().Name}({WareHouseName}) - {ex.FullMessage()}");
                throw;
            }
        }

        protected string InvokeAndGetResult(string methodName, string methodType, string inputBody = null, string urlConnector = "/")
        {
            var url = FixAndBuildFullUrl(methodName, urlConnector);
            return InvokeAndGetResult(new Uri(url, UriKind.Absolute), methodType, inputBody);
        }

        protected R ValidatedResultData(string resultData, ApiValidator<R> validator = null)
        {
            if (ResultDataInterpreter == null)
            {
                //MyLogi.Add(TypLogEnum.ZamowienieDostawca, $"{GetType().Name}({WareHouseName}) - Nie ustawiono interpretera");
                throw new ArgumentNullException(nameof(ResultDataInterpreter), "Nie ustawiono interpretera");
            }

            R result = ResultDataInterpreter(resultData);

            ApiResponseStatus = ApiResponseStatus.ValidationError;
            validator?.VerifyErrorList(result);

            ApiResponseStatus = validator == null ? ApiResponseStatus.SuccessUnvalidated : ApiResponseStatus.Success;
            return result;
        }

        protected string FixAndBuildFullUrl(string methodName, string connector = "/")
        {
            if (!Host.EndsWith(connector))
            {
                Host += connector;
            }

            return $"{Host}{(methodName.EndsWith(connector) ? methodName.Substring(1) : methodName)}";
        }

        public static Func<string, string> DefaultStringToStringInterpreter => stringResult => stringResult;
        //
    }

    /// <summary>
    /// Klasa do obsługi żądań API. Domyślny typ danych wyjściowych - JSON
    /// </summary>
    public class ApiConnection : ApiConnection<JObject>
    {
        public override Func<string, JObject> ResultDataInterpreter => result => JObject.Parse(result);
    }
}
