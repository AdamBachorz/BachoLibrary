using BachorzLibrary.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BachorzLibrary.Common.Extensions
{
    public static class ListExtensions
    {
        public static void SwapByIndex<E>(this IList<E> list, int index1, int index2)
        {
            var tmp = list[index1];
            list[index1] = list[index2];
            list[index2] = tmp;
        }

        public static void SwapByElement<E>(this IList<E> list, E element1, E element2)
        {
            var index1 = list.IndexOf(element1);
            var index2 = list.IndexOf(element2);

            if (index1 == -1)
            {
                throw new ArgumentException("Element1 does not exists");
            }
            if (index2 == -1)
            {
                throw new ArgumentException("Element2 does not exists");
            }
            if (index1 == index2)
            {
                throw new ArgumentException("Both elements are the same");
            }

            SwapByIndex(list, index1, index2);
        }

        public static void Shuffle<E>(this IList<E> list, int shuffleDepth = 10)
        {
            for (int i = 0; i < shuffleDepth; i++)
            {
                var randomPair = RandomFactory.RandomUniqueNumbers(0, list.Count - 1, 2);
                SwapByIndex(list, randomPair.First(), randomPair.Last());
            }
        }

        public static E RandomChoice<E>(this IList<E> list) => list[RandomFactory.RandomNumber(0, list.Count, false)];

        public static IList<E> RandomChoices<E>(this IList<E> list, int count)
        {
            if (count > list.Count)
            {
                throw new ArgumentException("Cannot pick more elements, that list contains");
            }

            return RandomFactory.RandomUniqueNumbers(0, list.Count - 1, count).Select(i => list[i]).ToList();
        }
    }
}
