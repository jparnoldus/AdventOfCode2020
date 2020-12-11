using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.challenge
{
    class Day11 : Challenge
    {
        public static int Solve1()
        {
            List<int> seats = new List<int>();
            var input = GetInputAsStringList(11).Select(s => s.ToList()).ToList();

            while (true)
            {
                var copy = input.Select(y => y.ToArray().ToList()).ToList();
                int yMax = input.Count;
                for (int y = 0; y < yMax; y++)
                {
                    int xMax = input[y].Count;
                    for (int x = 0; x < xMax; x++)
                    {
                        var directions = new List<List<int>>
                        {
                            new List<int>{ x - 1, y},
                            new List<int>{ x, y - 1},
                            new List<int>{ x + 1, y},
                            new List<int>{ x, y + 1},
                            new List<int>{ x - 1, y - 1},
                            new List<int>{ x + 1, y - 1},
                            new List<int>{ x + 1, y + 1},
                            new List<int>{ x - 1, y + 1},
                        }.Where(i => i[0] >= 0 && i[0] < xMax && i[1] >= 0 && i[1] < yMax);

                        if (input[y][x] == 'L')
                        {
                            if (directions.All(d => input[d[1]][d[0]] == 'L' || input[d[1]][d[0]] == '.'))
                            {
                                copy[y][x] = '#';
                            }
                        }
                        else if (input[y][x] == '#')
                        {
                            if (directions.Count(d => input[d[1]][d[0]] == '#') >= 4)
                            {
                                copy[y][x] = 'L';
                            }
                        }
                    }
                }

                var temp = copy.Sum(y => y.Count(x => x == '#'));
                if (seats.Count > 0 && seats.Last() == temp)
                    break;
                seats.Add(temp);
                input = copy;
            }

            return seats.Last();
        }

        public static int Solve1Compact()
        {
            List<int> seats = new List<int>();
            var test = GetInputAsStringList(11).Select((y, yi) => new KeyValuePair<int, List<KeyValuePair<int, char>>>(yi, y.Select((x, xi) => new KeyValuePair<int, char>(xi, x)).ToList())).Select(y => y.Value.Select(x => new KeyValuePair<int, char>(y.Key * 100 + x.Key, x.Value))).SelectMany(s => s).ToDictionary(s => s.Key, s => s.Value);
            do
            {
                test = test.Keys.Zip(test.ToList().Select(i => test[i.Key] == 'L' ? (new List<List<int>>{ new List<int>{ -1, 0}, new List<int>{ 0, -1}, new List<int>{ 1, 0}, new List<int>{ 0, 1}, new List<int>{ -1, -1}, new List<int>{ 1, -1}, new List<int>{ 1, 1}, new List<int>{ -1, 1} }.Select(s => new int[] { s[0] + i.Key / 100, s[1] + i.Key % 100 }).Where(i => i[0] >= 0 && i[0] < test.Keys.Max(i => i / 100) + 1 && i[1] >= 0 && i[1] < test.Keys.Max(i => i % 100) + 1).Select(s => s[0] * 100 + s[1]).All(d => "L.".Contains(test[d])) ? '#' : test[i.Key]) : (test[i.Key] == '#' ? (new List<List<int>>{ new List<int>{ -1, 0}, new List<int>{ 0, -1}, new List<int>{ 1, 0}, new List<int>{ 0, 1}, new List<int>{ -1, -1}, new List<int>{ 1, -1}, new List<int>{ 1, 1}, new List<int>{ -1, 1} }.Select(s => new int[] { s[0] + i.Key / 100, s[1] + i.Key % 100 }).Where(i => i[0] >= 0 && i[0] < test.Keys.Max(i => i / 100) + 1 && i[1] >= 0 && i[1] < test.Keys.Max(i => i % 100) + 1).Select(s => s[0] * 100 + s[1]).Count(d => "#".Contains(test[d])) >= 4 ? 'L' : test[i.Key]) : test[i.Key]))).ToDictionary(s => s.First, s => s.Second);
                seats.Add(test.Count(s => s.Value == '#'));
            } while (seats.Count < 2 || seats[seats.Count - 2] != test.Count(s => s.Value == '#'));
            return seats.Last();
        }

        public static int Solve2()
        {
            List<int> seats = new List<int>();
            var input = GetInputAsStringList(11).Select(s => s.ToList()).ToList();
            do
            {
                var copy = input.Select(y => y.ToArray().ToList()).ToList();
                int yMax = input.Count;
                for (int y = 0; y < yMax; y++)
                {
                    int xMax = input[y].Count;
                    for (int x = 0; x < xMax; x++)
                    {
                        var directions = new List<List<int>>
                        {
                            new List<int>{ -1, 0},
                            new List<int>{ 0, -1},
                            new List<int>{ 1, 0},
                            new List<int>{ 0, +1},
                            new List<int>{ -1, -1},
                            new List<int>{ 1, -1},
                            new List<int>{ 1, 1},
                            new List<int>{ -1, 1},
                        }.ToList();

                        int empties = 0, occupieds = 0;
                        directions.ForEach(d =>
                        {
                            int xt = x, yt = y;
                            while (true)
                            {
                                xt += d[0];
                                yt += d[1];
                                if (xt >= 0 && xt < xMax && yt >= 0 && yt < yMax)
                                {

                                    if (input[yt][xt] == 'L')
                                    {
                                        empties++;
                                        break;
                                    }
                                    else if (input[yt][xt] == '#')
                                    {
                                        occupieds++;
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        });

                        if (input[y][x] == 'L')
                        {
                            if (occupieds == 0)
                            {
                                copy[y][x] = '#';
                            }
                        }
                        else if (input[y][x] == '#')
                        {
                            if (occupieds >= 5)
                            {
                                copy[y][x] = 'L';
                            }
                        }
                    }
                }

                seats.Add(copy.Sum(y => y.Count(x => x == '#')));
                input = copy;
            } while (seats.Count <= 2 || seats.Last() != seats[seats.Count - 2]);

            return seats[0];
        }
    }
}
