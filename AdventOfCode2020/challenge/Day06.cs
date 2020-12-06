using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.challenge
{
    class Day06: Challenge
    {
        public static int Solve1()
        {
            return GetInputAsStringList(6).Aggregate((x, y) => x + ":" + y).Split("::").Where(s => s.Length > 0).Select(s => s.Replace(":", "").Distinct().Count()).Sum();
        }

        public static int Solve2()
        {
            return GetInputAsStringList(6).Aggregate((x, y) => x + ":" + y).Split("::").Where(s => s.Length > 0).Select(s => s.Split(':').Aggregate((x, y) => string.Concat(x.Intersect(y))).Count()).Sum();
        }
    }
}
