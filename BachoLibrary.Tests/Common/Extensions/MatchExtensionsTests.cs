using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using BachorzLibrary.Common.Extensions;
using BachorzLibrary.Common;

namespace BachoLibrary.Tests.Common.Extensions
{
    [TestFixture]
    public class MatchExtensionsTests
    {
        [Test]
        public void ShouldReturnValueFromGroup_ValueOrDefault()
        {
            const string IpPattern = @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}";
            const string DefaultIp = "0.0.0.0";
            var match = Regex.Match("Lorem ipsum 192.168.1.1 etc etc", IpPattern);
            var nonMatch = Regex.Match("Lorem ipsum xxx etc etc", IpPattern);

            var groupValue = match.ValueOrDefault(DefaultIp);
            var groupValueDefault = nonMatch.ValueOrDefault(DefaultIp);

            Assert.That(groupValue, Is.EqualTo("192.168.1.1"));
            Assert.That(groupValueDefault, Is.EqualTo(DefaultIp));
        }

        [Test]
        public void ShouldReturnValueFromGroup_ValueOrEmpty()
        {
            const string IpPattern = @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}";
            var match = Regex.Match("Lorem ipsum 192.168.1.1 etc etc", IpPattern);
            var nonMatch = Regex.Match("Lorem ipsum xxx etc etc", IpPattern);

            var groupValue = match.ValueOrEmpty();
            var groupValueDefault = nonMatch.ValueOrEmpty();

            Assert.That(groupValue, Is.EqualTo("192.168.1.1"));
            Assert.That(groupValueDefault, Is.EqualTo(string.Empty));
        }

        [Test]
        public void ShouldReturnValueFromGroup_GroupOrDefault()
        {
            const string IpPattern = @".*\s+(?<email>\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}).*";
            const string DefaultIp = "0.0.0.0";
            var match = Regex.Match("Lorem ipsum 192.168.1.1 etc etc", IpPattern);
            var nonMatch = Regex.Match("Lorem ipsum xxx etc etc", IpPattern);

            var groupValue = match.GroupOrDefault("email", DefaultIp);
            var groupValueDefault = nonMatch.GroupOrDefault("email", DefaultIp);

            Assert.That(groupValue, Is.EqualTo("192.168.1.1"));
            Assert.That(groupValueDefault, Is.EqualTo(DefaultIp));
        }

        [Test]
        public void ShouldReturnValueFromGroup_GroupOrEmpty()
        {
            const string IpPattern = @".*\s+(?<email>\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}).*";
            var match = Regex.Match("Lorem ipsum 192.168.1.1 etc etc", IpPattern);
            var nonMatch = Regex.Match("Lorem ipsum xxx etc etc", IpPattern);

            var groupValue = match.GroupOrEmpty("email");
            var groupValueDefault = nonMatch.GroupOrEmpty("email");

            Assert.That(groupValue, Is.EqualTo("192.168.1.1"));
            Assert.That(groupValueDefault, Is.EqualTo(string.Empty));
        }
    }
}
