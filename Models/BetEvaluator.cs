﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Universal_roulette_bot.Models
{
    internal class BetEvaluator
    {

        public Bet[] getSuggestions(int[] numbers)
        {
            List<Bet> bets = new List<Bet>();

           
            bets.AddRange(getThreeOfFourBet(numbers));
            bets.AddRange(getTwoColorsInRowBet(numbers));
            bets.AddRange(getColorsSwitchingBet(numbers));
            bets.AddRange(getAfterZeroBet(numbers));
            bets.AddRange(getSixLinesBet(numbers));


            return bets.ToArray();
        }

        private Bet[] getThreeOfFourBet(int[] numbers)
        {
            if(numbers.Length < 3) return new Bet[0];

            int[] lastThree = numbers.Skip(Math.Max(0, numbers.Count() - 3)).ToArray();


            int[] counts = new int[10];
            foreach (int i in lastThree)
            {
                counts[i % 10]++;
            }

            List<Bet> bets = new List<Bet>();


            for (int i = 0; i < counts.Length; i++)
            {
                if(counts[i] >= 2)
                {
                    Bet bet = new Bet();

                    for (int j = 0; j <= 36; j++)
                    {
                        if(j % 10 == i)
                        {
                            bet.betNumber(j);
                        }
                    }

                    bets.Add(bet);
                }
            }

            return bets.ToArray();
        }

        private Bet[] getTwoColorsInRowBet(int[] numbers)
        {
            if (numbers.Length < 3) return new Bet[0];

            int[] lastThree = numbers.Skip(Math.Max(0, numbers.Count() - 3)).ToArray();

            if (lastThree[0] != 0 && isRed(lastThree[0]) != isRed(lastThree[1]) && isRed(lastThree[1]) == isRed(lastThree[2]))
            {
                Bet bet = new Bet();

                bet.betColor(!isRed(lastThree[2]));

                return new Bet[1] {bet};

            } else return new Bet[0];

        }

        private Bet[] getAfterZeroBet(int[] numbers)
        {
            if (numbers.Length < 1) return new Bet[0];


            if (numbers.Last() == 0)
            {
                Bet bet = new Bet();

                bet.betColor(true);

                return new Bet[1] { bet };

            }
            else return new Bet[0];

        }

        private Bet[] getColorsSwitchingBet(int[] numbers)
        {
            if (numbers.Length < 5) return new Bet[0];

            int[] lastFive = numbers.Skip(Math.Max(0, numbers.Count() - 5)).ToArray();

            if (isRed(lastFive[0]) != isRed(lastFive[1])
                && !isRed(lastFive[1]) != isRed(lastFive[2])
                && !isRed(lastFive[2]) != isRed(lastFive[3])
                && !isRed(lastFive[3]) != isRed(lastFive[4]))
            {
                Bet bet = new Bet();

                bet.betColor(!isRed(lastFive[4]));

                return new Bet[1] {bet};
            } else return new Bet[0];

        }

        private Bet[] getSixLinesBet(int[] numbers)
        {
            if (numbers.Length < 5) return new Bet[0];
            var grid = RouletteConstants.getNumbersGrid();


            int[] lastFive = numbers.Skip(Math.Max(0, numbers.Count() - 5)).ToArray();
            List<Point> indexes = new List<Point>();


            foreach (int number in lastFive)
            {
                for (int y = 0; y < grid.Length; y++)
                {
                    for (int x = 0; x < grid[y].Length; x++)
                    {
                        if (grid[y][x] == number)
                        {
                            indexes.Add(new Point(x, y));
                        }
                    }
                }
            }

            Point last = indexes.Last();
            foreach (Point point in indexes)
            {
                if (last != point)
                {
                    if (point.X == last.X || point.X + 1 == last.X || point.X - 1 == last.X)
                    {
                        return new Bet[0];
                    }
                }
            }


            Bet bet = new Bet();
            bet.betSixline(last.X);


            int beforeLast = lastFive[3];
            for(int i = last.X - 1; i <= last.X + 1; i++)
            {
                if(i >= 0 && i < grid[0].Length)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        if(grid[j][i] % 10 == beforeLast % 10)
                        {
                            bet.betNumber(grid[j][i]);
                            break;
                        }
                    }
                }
            }

            return new Bet[] { bet };


        }

        private bool isRed(int number)
        {
            int[] redNumbers = new int[18] {3, 9, 12, 18, 21, 27, 30, 36, 5, 14, 23, 32, 1, 7, 16, 19, 25, 34};

            return redNumbers.Contains(number);
        }
    }
}
