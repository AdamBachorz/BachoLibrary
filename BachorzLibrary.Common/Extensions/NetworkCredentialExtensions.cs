using System;
using System.Net;
using System.Text;

namespace BachorzLibrary.Common.Extensions
{
    public static class NetworkCredentialExtensions
    {
        public static string BuildBase64Token(this NetworkCredential credential)
            => "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes($"{credential.UserName}:{credential.Password}"));
    }
}
