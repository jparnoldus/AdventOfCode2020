using System.Linq;

namespace AdventOfCode2020.challenge
{
    class Day03 : Challenge
    {
        public static int Solve1()
        {
            int position = 0;
            return GetInputAsStringList(3).Sum(s =>
            {
                int tree = s[position] == '#' ? 1 : 0;
                position = (position + 3 >= s.Length ? position - s.Length : position) + 3;
                return tree;
            });
        }

        public static double Solve2()
        {
            return new int[][] {
                new int[] { 1, 1 },
                new int[] { 3, 1 },
                new int[] { 5, 1 },
                new int[] { 7, 1 },
                new int[] { 1, 2 },
            }.ToList().Sum(slope =>
            {
                int position = 0;
                return (double)GetInputAsStringList(3).Select((s, i) =>
                {
                    int tree = i % slope[1] == 0 && s[position] == '#' ? 1 : 0;
                    position = i % slope[1] == 0 ? (position + slope[0] >= s.Length ? position - s.Length : position) + slope[0] : position;
                    return tree;
                }).Sum();
            });
        }
    }
}