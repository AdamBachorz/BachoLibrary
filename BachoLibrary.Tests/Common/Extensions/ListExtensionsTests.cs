using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BachorzLibrary.Common.Extensions;

namespace BachoLibrary.Tests.Common.Extensions
{
    [TestFixture]
    public class ListExtensionsTests
    {
        [Test]
        public void ShouldSwap_SwapByIndex()
        {
            var originalList = new List<int> { 1,2,3,4 };
            var listSwaped = new List<int>(originalList);

            listSwaped.SwapByIndex(1, 2);

            Assert.Multiple(() =>
            {
                Assert.False(originalList.SequenceEqual(listSwaped));
                Assert.That(listSwaped[1], Is.EqualTo(3));
                Assert.That(listSwaped[2], Is.EqualTo(2));
            });

        }

        [Test]
        public void ShouldSwap_SwapByElement()
        {
            var originalList = new List<string> { "aaa", "bbb", "ccc", "ddd", "eee" };
            var listSwaped = new List<string>(originalList);
            
            listSwaped.SwapByElement("aaa", "eee");

            Assert.Multiple(() =>
            {
                Assert.False(originalList.SequenceEqual(listSwaped));
                Assert.That(listSwaped.First(), Is.EqualTo("eee"));
                Assert.That(listSwaped.Last(), Is.EqualTo("aaa"));
            });

        }

        [Test]
        public void ShouldThrowError_ElementsAreTheSame_SwapByElement()
        {
            var originalList = new List<string> { "aaa", "bbb", "ccc", "ddd", "eee" };
            var listSwaped = new List<string>(originalList);

            Assert.Throws<ArgumentException>(() => listSwaped.SwapByElement("ccc", "ccc"), "Both elements are the same");
        }

        [Test]
        public void ShouldShuffle()
        {
            var originalList = new List<int> { 1, 2, 3, 4 };
            var listShuffled = new List<int>(originalList);

            listShuffled.Shuffle();

            Assert.False(originalList.SequenceEqual(listShuffled));
        }

        [Test]
        public void ShouldPickRandomElement_RandomChoice()
        {
            var list = new List<string> { "aaa", "bbb", "ccc", "ddd", "eee" };
            string randomElement = null;

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => randomElement = list.RandomChoice());
                Assert.That(randomElement, Is.Not.Null);
                Assert.That(list, Does.Contain(randomElement));
            });
        }

        [Test]
        public void ShouldThrowException_RandomChoices()
        {
            var list = new List<string> { "aaa", "bbb", "ccc", "ddd", "eee" };
            IList<string> randomElements = null;

            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentException>(() => randomElements = list.RandomChoices(list.Count + 1));
                Assert.DoesNotThrow(() => randomElements = list.RandomChoices(list.Count - 1));
            });
        }


    }
}
