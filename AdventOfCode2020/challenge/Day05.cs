using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.challenge
{
    class Day05 : Challenge
    {
        public static int Solve1()
        {
            return GetBoardingPasses(GetInputAsStringList(5)).Max();
        }

        public static int Solve2()
        {
            var passes = GetBoardingPasses(GetInputAsStringList(5));
            return passes.Where(p => !passes.Contains(p + 1) && passes.Contains(p + 2)).Select(p => p + 1).First();
        }

        private static List<int> GetBoardingPasses(IEnumerable<string> input)
        {
            var results = new List<int>();
            foreach (string boardingPass in input)
            {
                int lowest = 0,
                    highest = 127;
                for (int i = 0; i < 6; i++)
                {
                    if (boardingPass[i] == 'F')
                        highest -= (highest - lowest + 1) / 2;
                    else if (boardingPass[i] == 'B')
                        lowest += (highest - lowest + 1) / 2;
                }

                int row = boardingPass[6] == 'F' ? lowest : highest;

                lowest = 0;
                highest = 7;
                for (int i = 7; i < 9; i++)
                {
                    if (boardingPass[i] == 'L')
                        highest -= (highest - lowest + 1) / 2;
                    else if (boardingPass[i] == 'R')
                        lowest += (highest - lowest + 1) / 2;
                }

                int column = boardingPass[9] == 'L' ? lowest : highest;
                results.Add(row * 8 + column);
            }

            return results;
        }
    }
}