using System;
using System.Collections.Generic;
using System.Linq;

namespace BachorzLibrary.Common.Tools
{
    public static class RandomFactory
    {
        public static Random Random = new Random();

        public static int RandomNumber(int min, int max, bool includeBound) => Random.Next(min, includeBound ? max + 1 : max);
        public static IEnumerable<int> RandomNumbers(int min, int max, int count, bool includeBound)
            => Enumerable.Range(1, count).Select(n => RandomNumber(min, max, includeBound));
        public static IList<int> RandomUniqueNumbers(int min, int max, int count)
        {
            if (max - min < count)
            {
                throw new ArgumentException("Range too small");
            }

            var numbers = new List<int>();

            while (numbers.Count < count)
            {
                var randomNumber = RandomNumber(min, max, includeBound: true);

                if (!numbers.Contains(randomNumber))
                {
                    numbers.Add(randomNumber);
                }
            }

            return numbers;
        }
        public static bool TryLuck(double chance) => Random.NextDouble() <= chance;
    }
}
