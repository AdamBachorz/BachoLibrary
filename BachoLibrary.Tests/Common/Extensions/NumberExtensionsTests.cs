using NUnit.Framework;
using BachorzLibrary.Common.Extensions;

namespace BachoLibrary.Tests.Common.Extensions
{
    [TestFixture]
    public class NumberExtensionsTests
    {
        [TestCase(34, 5, 50, true, ExpectedResult = true)]
        [TestCase(50, 5, 50, true, ExpectedResult = true)]
        [TestCase(50, 5, 50, false, ExpectedResult = false)]
        [TestCase(5, 5, 50, true, ExpectedResult = true)]
        [TestCase(5, 5, 50, false, ExpectedResult = false)]
        public bool ShouldReturnTrueOrFalse_IsBetween(int value, int minValue, int maxValue, bool includeBounds) => value.IsBetween(minValue, maxValue, includeBounds);

        [TestCase(0, ExpectedResult = "0.00")]
        [TestCase(1.5, ExpectedResult = "1.50")]
        [TestCase(3.14, ExpectedResult = "3.14")]
        [TestCase(3.144, ExpectedResult = "3.14")]
        [TestCase(3.147, ExpectedResult = "3.15")]
        public string ShouldReturnFixedStringValue_ToFixedString(decimal value) => value.ToFixedString();
    }
}
