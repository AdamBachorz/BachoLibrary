using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using BachorzLibrary.Common.Extensions;

namespace BachoLibrary.Tests.Common.Extensions
{
    [TestFixture]
    public class EnumExtensionsTests
    {
        public enum MyEnum
        {
            [System.ComponentModel.Description("This is Description")]
            WithDescription,
            WithoutDescription,
        }

        [TestCase(MyEnum.WithDescription, ExpectedResult = "This is Description")]
        [TestCase(MyEnum.WithoutDescription, ExpectedResult = "")]
        public string ShouldReturnDescriptionOrEmptyString_Description(MyEnum myEnum) => myEnum.Description();

    }
}
