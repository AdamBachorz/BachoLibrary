using BachorzLibrary.Common.Tools.Email;
using BachorzLibrary.UnitTestsTools;
using NUnit.Framework;
using System.Threading.Tasks;

namespace BachoLibrary.Tests.Common.Tools.Email
{
    public class EmailSenderTests : BaseTests
    {
        private EmailSender _sut;

        [SetUp]
        public void Setup()
        {
            Setup("TBE");

            var settings = new EmailSenderSettings
            {
                SenderHeader = nameof(BachorzLibrary),
            };
            _sut = new EmailSender(settings);
        }

        [Test]
        [Explicit]
        public async Task ShouldSendEmail_SendEmail()
        {
            await _sut.SendEmailAsync("Testowy temat", "testowa treść <h1>Nagłówek</h1>", "TBE", "TestUser");

            Assert.Pass();
        }
    }
}
