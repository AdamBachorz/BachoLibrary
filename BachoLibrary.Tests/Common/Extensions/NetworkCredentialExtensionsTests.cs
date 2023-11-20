using System.Net;
using NUnit.Framework;
using BachorzLibrary.Common.Extensions;

namespace BachoLibrary.Tests.Common.Extensions
{
    [TestFixture]
    public class NetworkCredentialExtensionsTests
    {
        [Test]
        public void ShouldReturnToken_BuildBase64Token()
        {
            var credentials = new NetworkCredential("user", "pass");
            
            var token = credentials.BuildBase64Token();

            Assert.Multiple(() =>
            {
                Assert.That(token, Is.Not.Null.Or.Empty);
                Assert.That(token, Is.Not.Empty);
            });
        }
    }
}
