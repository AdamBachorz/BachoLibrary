using System.Collections.Generic;
using NUnit.Framework;

namespace BachoLibrary.Tests.Common.Extensions
{
    [TestFixture]
    public class DictionaryExtensionsTests
    {
        [Test]
        public void ShouldReturnValueOrDefault_GetValueIfExists()
        {
            var _dictionary = new Dictionary<int, string>()
            {
                { 1, "Number 1" },
                { 2, "Number 2" },
                { 3, "Number 3" },
            };

            const string NoValueIndicator = "No value";

            var valueFromDictionary = _dictionary.GetValueOrDefault(1, NoValueIndicator);
            var defaultValue = _dictionary.GetValueOrDefault(10, NoValueIndicator);
            var defaultEmptyValue = _dictionary.GetValueOrDefault(10);

            Assert.Multiple(() =>
            {
                Assert.That(valueFromDictionary, Is.Not.Null);
                Assert.That(valueFromDictionary, Is.Not.Empty);
                Assert.That(valueFromDictionary, Is.EqualTo("Number 1"));
                Assert.That(defaultValue, Is.EqualTo(NoValueIndicator));
                Assert.That(defaultEmptyValue, Is.Null);
            });
        }
    }
}
