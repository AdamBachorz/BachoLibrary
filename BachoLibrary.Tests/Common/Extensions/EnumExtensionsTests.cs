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
            SomeValue1,
            SomeValue2,
            SomeValue3,
        }

        [TestCase(MyEnum.WithDescription, ExpectedResult = "This is Description")]
        [TestCase(MyEnum.WithoutDescription, ExpectedResult = "")]
        public string ShouldReturnDescriptionOrEmptyString_Description(MyEnum myEnum) => myEnum.Description();

        [TestCase(MyEnum.SomeValue2, new[] { MyEnum.SomeValue1, MyEnum.SomeValue2, MyEnum.SomeValue3 }, ExpectedResult = true)]
        [TestCase(MyEnum.SomeValue2, new[] { MyEnum.WithDescription, MyEnum.WithoutDescription }, ExpectedResult = false)]
        public bool ShouldReturn_True_IsAnyOf(MyEnum myEnum, params MyEnum[] enums) => myEnum.IsAnyOf(enums);

    }
}
