using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.challenge
{
    class Day09 : Challenge
    {
        public static long Solve1()
        {
            return GetInputAsLongList(9).Skip(25).SkipWhile((n, i) => GetInputAsLongList(9).Skip(i).Take(25).SelectMany(s => GetInputAsLongList(9).Skip(i).Take(25).Select(p => p + s)).Any(s => s.Equals(n))).First();
        }

        public static long Solve2()
        {
            var crawler = new List<long>();
            var answer = GetInputAsLongList(9).Skip(25).SkipWhile((n, i) => GetInputAsLongList(9).Skip(i).Take(25).SelectMany(s => GetInputAsLongList(9).Skip(i).Take(25).Select(p => p + s)).Any(s => s.Equals(n))).First();
            GetInputAsLongList(9).TakeWhile(n => !n.Equals(answer)).Reverse().ToList().ForEach(i =>
            {
                if (i < answer && crawler.Sum() != answer)
                {
                    crawler.Add(i);
                    while (crawler.Sum() > answer)
                        crawler.RemoveAt(0);
                }
            });

            return crawler.Min() + crawler.Max();
        }
    }
}
