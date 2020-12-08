using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.challenge
{
    class Day07 : Challenge
    {
        public static int Solve1()
        {
            return SearchContaining("shiny gold", GetInputAsStringList(7).ToDictionary(s => s.Substring(0, s.IndexOf("contain")).Replace("bags", "").Trim(), s => s.Substring(s.IndexOf("contain") + "contain".Length).TrimEnd('.').Split(',').Select(c => c.Trim().Substring(2).Replace("bags", "").Replace("bag", "").Trim()))).Count();
        }

        private static IEnumerable<string> SearchContaining(string needle, Dictionary<string, IEnumerable<string>> stack) 
        {
            var needles = stack.Where(i => i.Value.Any(s => s.Equals(needle))).Select(i => i.Key).ToList();
            var results = needles.SelectMany(n => SearchContaining(n, stack)).ToList();
            results.ForEach(r => needles.Add(r));
            return needles.Distinct();
        }

        public static int Solve2()
        {
            return CountBagsInside("shiny gold", GetInputAsStringList(7).ToDictionary(s => s.Substring(0, s.IndexOf("contain")).Replace("bags", "").Trim(), s => s.Substring(s.IndexOf("contain") + "contain".Length).TrimEnd('.').Split(',').Select(c => c.Trim().Replace("bags", "").Replace("bag", "").Trim())));
        }

        private static int CountBagsInside(string needle, Dictionary<string, IEnumerable<string>> stack)
        {
            return stack[needle].Sum(c => !c.Equals("no other") ? int.Parse(c[0].ToString()) + int.Parse(c[0].ToString()) * CountBagsInside(c.Substring(2), stack) : 0);
        }
    }
}
