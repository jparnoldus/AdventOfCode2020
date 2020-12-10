using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.challenge
{
    class Day10 : Challenge
    {
        public static int Solve1()
        {
            return GetInputAsIntList(10).Append(0).OrderBy(s => s).Zip(GetInputAsIntList(10).Append(GetInputAsIntList(10).Max() + 3).OrderBy(s => s)).Select(s => s.Second - s.First).GroupBy(s => s).Select(s => s.Count()).Aggregate((x, y) => x * y);
        }

        public static long Solve2()
        {
            var adapters = new Dictionary<int, long>
            {
                [0] = 1
            };

            return GetInputAsIntList(10).Append(GetInputAsIntList(10).Max() + 3).OrderBy(s => s).Max(i => adapters[i] = Enumerable.Range(i - 3, 3).Intersect(adapters.Keys).Select(s => adapters[s]).Sum());
        }
    }
}
