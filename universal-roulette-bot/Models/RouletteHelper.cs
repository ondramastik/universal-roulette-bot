﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace RouletteBot.Models
{
    public class RouletteHelper
    {
        public static int[][] getNumbersGrid()
        {
            int[] first = new int[13] { -1, 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };
            int[] second = new int[13] { 0, 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
            int[] third = new int[13] { -1, 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };

            return new[] { first, second, third };
        }

        public static int[] getRedNumbers()
        {
            return new int[18] { 3, 9, 12, 18, 21, 27, 30, 36, 5, 14, 23, 32, 1, 7, 16, 19, 25, 34 };
        }

        public static Point getNumberGridIndex(int number)
        {
            var grid = getNumbersGrid();

            for (int y = 0; y < grid.Length; y++)
            {
                for (int x = 0; x < grid[y].Length; x++)
                {
                    if (grid[y][x] == number) return new Point(x, y);
                }
            }

            throw new ArgumentException(
                String.Format("Input must be number from 0 to 36. Got '{0}'", number));
        }

        public static int GetLastOccurance(int[] numbers, int number, bool previous = false)
        {
            int roundsWithoutSee = 0;

            for (int i = 0; i < numbers.Length - (previous ? 1 : 0); i++)
            {
                if (numbers[i] != number)
                {
                    roundsWithoutSee++;
                }
                else if (numbers[i] == number)
                {
                    roundsWithoutSee = 0;
                }
            }

            return roundsWithoutSee;
        }

        public static List<Point> FindIndexes(IEnumerable<int> numbers)
        {
            var grid = getNumbersGrid();

            var indexes = new List<Point>();

            foreach (var number in numbers)
            {
                for (var y = 0; y < grid.Length; y++)
                {
                    for (var x = 0; x < grid[y].Length; x++)
                    {
                        if (grid[y][x] == number)
                        {
                            indexes.Add(new Point(x, y));
                        }
                    }
                }
            }

            return indexes;
        }
    }
}