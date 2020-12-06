using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.challenge
{
    class Day04 : Challenge
    {
        public static int Solve1()
        {
            var input = GetInputAsStringList(4);

            var current = "";
            var passportLines = new List<Passport>();
            foreach (string line in input)
            {
                if (line.Length == 0)
                {
                    Passport passport = Passport.Parse(current);
                    if (passport.CheckValid())
                    {
                        passportLines.Add(passport);
                    }
                    current = "";
                }
                else
                {
                    current += " " + line;
                }
            }

            Passport last = Passport.Parse(current);
            if (last.CheckValid())
            {
                passportLines.Add(last);
            }

            return passportLines.Count;
        }

        public static int Solve2()
        {
            var input = GetInputAsStringList(4);

            var current = "";
            var passportLines = new List<Passport>();
            foreach (string line in input)
            {
                if (line.Length == 0)
                {
                    Passport passport = Passport.Parse(current);
                    if (passport.CheckValid())
                    {
                        passportLines.Add(passport);
                    }
                    current = "";
                }
                else
                {
                    current += " " + line;
                }
            }

            Passport last = Passport.Parse(current);
            if (last.CheckValid())
            {
                passportLines.Add(last);
            }

            return passportLines.Count;
        }

        class Passport
        {
            public int BirthYear;
            public int IssueYear;
            public int ExpirationYear;
            public int Height;
            public string HeightUnit;
            public string HairColor;
            public string EyeColor;
            public double PID;

            public static Passport Parse(string input)
            {
                Passport passport = new Passport();

                var YearRegex = new Regex(@"^\d{4}$");
                var HeightRegex = new Regex(@"^\d*[a-z]{2}$");
                var ColorRegex = new Regex(@"\#([0-9a-f]|[a-f]){6}$");
                var PIDRegex = new Regex(@"^\d{9}$");

                var properties = input.Trim().Split(' ').Select(s => s.Split(':'));
                foreach (var property in properties)
                {
                    string value = property[1];
                    switch (property[0])
                    {
                        case "byr":
                            if (YearRegex.IsMatch(value))
                            {
                                passport.BirthYear = int.Parse(value);
                            }
                            break;
                        case "iyr":
                            if (YearRegex.IsMatch(value))
                            {
                                passport.IssueYear = int.Parse(value);
                            }
                            break;
                        case "eyr":
                            if (YearRegex.IsMatch(value))
                            {
                                passport.ExpirationYear = int.Parse(value);
                            }
                            break;
                        case "hgt":
                            if (HeightRegex.IsMatch(value))
                            {
                                passport.Height = int.Parse(value.Substring(0, value.Length - 2));
                                passport.HeightUnit = string.Concat(value.TakeLast(2));
                            }
                            break;
                        case "hcl":
                            if (ColorRegex.IsMatch(value))
                            {
                                passport.HairColor = value;
                            }
                            break;
                        case "ecl":
                            passport.EyeColor = value;
                            break;
                        case "pid":
                            if (PIDRegex.IsMatch(value))
                            {
                                passport.PID = double.Parse(value);
                            }
                            break;
                    }
                }

                return passport;
            }

            public bool CheckValid()
            {
                if (this.BirthYear < 1920 || this.BirthYear > 2002
                    || this.IssueYear < 2010 || this.IssueYear > 2020
                    || this.ExpirationYear < 2020 || this.ExpirationYear > 2030
                    || this.HeightUnit == null
                    || (this.HeightUnit == "cm" ? (this.Height < 150 || this.Height > 193) : (this.Height < 59 || this.Height > 76))
                    || this.HairColor == null
                    || !new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.ToList().Contains(this.EyeColor)
                    || this.PID == 0.0)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
