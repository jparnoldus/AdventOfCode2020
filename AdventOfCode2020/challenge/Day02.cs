using System.Linq;

namespace AdventOfCode2020.challenge
{
    class Day02: Challenge
    {
        public static int Solve1()
        {
            return GetInputAsStringList(2).Count(s => Enumerable.Range(int.Parse(s.Substring(0, s.IndexOf(' ')).Split('-')[0]), int.Parse(s.Substring(0, s.IndexOf(' ')).Split('-')[1])-int.Parse(s.Substring(0, s.IndexOf(' ')).Split('-')[0])+1).Contains(s.Split(':')[1].Trim().Count(t => t.Equals(s[s.IndexOf(':') - 1]))));
        }

        public static int Solve2()
        {
            return GetInputAsStringList(2).Count(s => s.Split(':')[1].Trim()[int.Parse(s.Substring(0, s.IndexOf(' ')).Split('-')[0])-1].Equals(s[s.IndexOf(':') - 1]) ^ s.Split(':')[1].Trim()[int.Parse(s.Substring(0, s.IndexOf(' ')).Split('-')[1])-1].Equals(s[s.IndexOf(':') - 1]));
        }
    }
}
