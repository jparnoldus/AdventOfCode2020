using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.challenge
{
    class Day12 : Challenge
    {
        public static int Solve1()
        {
            var ship = new Ship();
            GetInputAsStringList(12).Select(s => new KeyValuePair<char, long>(s[0], long.Parse(s.Substring(1)))).ToList().ForEach(s => ship.Move(s.Key, s.Value));
            return Math.Abs(int.Parse(ship.x.ToString())) + Math.Abs(int.Parse(ship.y.ToString()));
        }

        public static int Solve2()
        {
            var ship = new Ship();
            GetInputAsStringList(12).Select(s => new KeyValuePair<char, int>(s[0], int.Parse(s.Substring(1)))).ToList().ForEach(m => ship.MoveByWaypoint(m.Key, m.Value));
            return Math.Abs(int.Parse(ship.x.ToString())) + Math.Abs(int.Parse(ship.y.ToString()));
        }

        class Ship
        {
            public long x;
            public long y;
            public char direction;
            public long xWaypoint;
            public long yWaypoint;

            public Ship()
            {
                this.x = 0;
                this.y = 0;
                this.direction = 'E';
                this.xWaypoint = 10;
                this.yWaypoint = -1;
            }

            public void Move(char move, long amount)
            {
                if (amount == 0)
                    return;
                switch (move) 
                {
                    case 'N':
                        this.y += amount;
                        break;
                    case 'S':
                        this.y -= amount;
                        break;
                    case 'E':
                        this.x += amount;
                        break;
                    case 'W':
                        this.x -= amount;
                        break;
                    case 'L':
                        switch (this.direction)
                        {
                            case 'N':
                                this.direction = 'W';
                                break;
                            case 'E':
                                this.direction = 'N';
                                break;
                            case 'S':
                                this.direction = 'E';
                                break;
                            case 'W':
                                this.direction = 'S';
                                break;
                        }
                        this.Move(move, amount - 90);
                        break;
                    case 'R':
                        switch (this.direction)
                        {
                            case 'N':
                                this.direction = 'E';
                                break;
                            case 'E':
                                this.direction = 'S';
                                break;
                            case 'S':
                                this.direction = 'W';
                                break;
                            case 'W':
                                this.direction = 'N';
                                break;
                        }
                        this.Move(move, amount - 90);
                        break;
                    case 'F':
                        this.Move(this.direction, amount);
                        break;
                }
            }

            public void MoveByWaypoint(char move, long amount)
            {
                switch (move)
                {
                    case 'N':
                        this.yWaypoint -= amount;
                        break;
                    case 'S':
                        this.yWaypoint += amount;
                        break;
                    case 'E':
                        this.xWaypoint += amount;
                        break;
                    case 'W':
                        this.xWaypoint -= amount;
                        break;
                    case 'R':
                        this.MoveByWaypoint('L', 360 - amount);
                        break;
                    case 'L':
                        for (int i = 0; i < amount / 90; i++)
                        { 
                            var temp = -this.xWaypoint;
                            this.xWaypoint = this.yWaypoint;
                            this.yWaypoint = temp;
                        }
                        break;
                    case 'F':
                        this.x += this.xWaypoint * amount;
                        this.y += this.yWaypoint * amount;
                        break;
                }
            }
        }
    }
}
