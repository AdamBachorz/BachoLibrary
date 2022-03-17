using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
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

            Assert.That(token, Is.Not.Null);
            Assert.That(token, Is.Not.Empty);
            Assert.True(token.StartsWith("Basic "));
        }
    }
}
