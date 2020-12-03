using System.Linq;

namespace AdventOfCode2020.challenge
{
    class Day01: Challenge
    {
        public static int Solve1()
        {
            return GetInputAsIntList(1).Max(i => GetInputAsIntList(1).Find(j => j + i == 2020) * i);
        }

        public static int Solve2()
        {
            return GetInputAsIntList(1).SelectMany(i => GetInputAsIntList(1).SelectMany(j => GetInputAsIntList(1).Select(k => i + j + k == 2020 ? i * j * k : 0))).Max();
        }
    }
}
