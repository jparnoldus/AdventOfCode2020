﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.challenge
{
    class Challenge
    {
        protected static string GetPath(int day)
        {
            return String.Format("{0}/day{1}.txt", Program.INPUT_FILE_DIR, day.ToString().PadLeft(2, '0'));
        }

        public static List<string> GetInputAsStringList(int day)
        {
            List<string> list = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(GetPath(day)))
                {
                    while (!sr.EndOfStream)
                    {
                        list.Add(sr.ReadLine());
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }

        public static List<int> GetInputAsIntList(int day)
        {
            List<int> list = new List<int>();

            try
            {
                using (StreamReader sr = new StreamReader(GetPath(day)))
                {
                    while (!sr.EndOfStream)
                    {
                        list.Add(int.Parse(sr.ReadLine()));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }

        public static List<long> GetInputAsLongList(int day)
        {
            List<long> list = new List<long>();

            try
            {
                using (StreamReader sr = new StreamReader(GetPath(day)))
                {
                    while (!sr.EndOfStream)
                    {
                        list.Add(long.Parse(sr.ReadLine()));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }

        public static List<List<int>> GetInputAsCsIntListList(int day)
        {
            List<List<int>> list = new List<List<int>>();

            try
            {
                using (StreamReader sr = new StreamReader(GetPath(day)))
                {
                    while (!sr.EndOfStream)
                    {
                        list.Add((from string item in sr.ReadLine().Split(',') select int.Parse(item)).ToList<int>());
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }

        public static List<List<long>> GetInputAsCsFloatListList(int day)
        {
            List<List<long>> list = new List<List<long>>();

            try
            {
                using (StreamReader sr = new StreamReader(GetPath(day)))
                {
                    while (!sr.EndOfStream)
                    {
                        list.Add((from string item in sr.ReadLine().Split(',') select long.Parse(item)).ToList<long>());
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }

        public static List<List<string>> GetInputAsCsStringListList(int day)
        {
            List<List<string>> list = new List<List<string>>();

            try
            {
                using (StreamReader sr = new StreamReader(GetPath(day)))
                {
                    while (!sr.EndOfStream)
                    {
                        list.Add(sr.ReadLine().Split(',').ToList());
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }

        public static List<int> GetInputAsIntRow(int day)
        {
            List<int> list = new List<int>();

            try
            {
                using (StreamReader sr = new StreamReader(GetPath(day)))
                {
                    while (!sr.EndOfStream)
                    {
                        sr.ReadLine().ToList().ForEach(i => list.Add(int.Parse(i.ToString())));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }
    }
}
