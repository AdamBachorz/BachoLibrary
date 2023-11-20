using BachorzLibrary.Common.Tools;
using BachorzLibrary.Common.Extensions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BachoLibrary.Tests.Common.Extensions
{
    class MyClass
    {        
        public int Number { get; set; }
        public string Text { get; set; }

        public MyClass(int number, string text)
        {
            Number = number;
            Text = text;
        }

        public static IList<MyClass> RandomList(int elementCount) =>
            Enumerable.Range(1, elementCount).Select(x => new MyClass(RandomFactory.RandomNumber(1, elementCount, true), "Text " + RandomFactory.RandomNumber(1, elementCount, true))).ToList();
    }

    public class CollectionExtensionsTests
    {
        [Test]
        public void ShouldAddIfNotExist_AddIfNotExists()
        {
            const int InitialSizeList = 10;
            const int AddedElementNumber = 15;
            var list = MyClass.RandomList(InitialSizeList);
            var existingElement = new MyClass(AddedElementNumber, "Existing");
            list.Add(existingElement);
            list.AddIfNotExists(existingElement);

            Assert.That(list.Where(x => x.Number == AddedElementNumber).ToList(), Has.Count.EqualTo(1));          
        }
        
        [TestCase(true)]
        [TestCase(false)]
        public void ShouldGetMinimumOrMaximumValue_PickOneWithMinimum_PickOneWithMaximum(bool pickMinimum)
        {
            var list = MyClass.RandomList(10);

            var result = pickMinimum ? list.PickOneWithMinimum(x => x.Number) : list.PickOneWithMaximum(x => x.Number);

            Assert.Multiple(() =>
            {
                foreach (var item in list)
                {
                    Assert.That(result.Number, pickMinimum ? Is.LessThanOrEqualTo(item.Number) : Is.GreaterThanOrEqualTo(item.Number));
                }
            });
        }
    }
}
