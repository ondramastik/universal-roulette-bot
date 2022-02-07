using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace RouletteBot.Models
{
    public class BetEvaluator
    {

        private BetEvaluationConfig Config;

        public BetEvaluator(BetEvaluationConfig evaluationConfig = null)
        {
            if(evaluationConfig == null)
                Config = new BetEvaluationConfig();
            else
                Config = evaluationConfig;
        }

        public Bet[] getSuggestions(int[] numbers)
        {
            List<Bet> bets = new List<Bet>();

           
            bets.AddRange(getThreeOfFourBet(numbers));
            bets.AddRange(getTwoColorsInRowBet(numbers));
            bets.AddRange(getColorsSwitchingBet(numbers));
            bets.AddRange(getAfterZeroBet(numbers));
            bets.AddRange(getSixLinesBet(numbers));
            bets.AddRange(getSixLinesBet(numbers, true));
            //bets.AddRange(getSameColorStreakAfterZeroBet(numbers));

            if(bets.Count == 0 && Config.NeutralBetOnEmpty)
            {
                // If no bet is suggested, bet neutral.
                bets.Add(new ColorBet(true) { RuleName = "NeutralBet" });
                bets.Add(new ColorBet(false) { RuleName = "NeutralBet" });
            }


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

                    for (int j = 0; j <= 36; j++)
                    {
                        if(j % 10 == i)
                        {
                            bets.Add(new NumberBet(j) { RuleName = "ThreeOfFour", Multiplier = 2 });
                        }
                    }
                }
            }

            return bets.ToArray();
        }

        private Bet[] getTwoColorsInRowBet(int[] numbers)
        {
            if (numbers.Length < 3) return new Bet[0];

            int[] lastThree = numbers.Skip(Math.Max(0, numbers.Count() - 3)).ToArray();

            if (lastThree.Where(number => number == 0).Count() == 0 && isRed(lastThree[0]) != isRed(lastThree[1]) && isRed(lastThree[1]) == isRed(lastThree[2]))
            {
                return new Bet[1] { new ColorBet(!isRed(lastThree[2])) { RuleName = "TwoColorsInRow" } };

            } else return new Bet[0];

        }

        private Bet[] getAfterZeroBet(int[] numbers)
        {
            if (numbers.Length < 1 || numbers.Last() != 0)
                return new Bet[0];
            else
                return new Bet[1] { new ColorBet(true) { Multiplier = 3, RuleName = "AfterZero" } };
        }

        private Bet[] getColorsSwitchingBet(int[] numbers)
        {
            if (numbers.Length < 5) return new Bet[0];

            int[] lastFive = numbers.Skip(Math.Max(0, numbers.Count() - 5)).ToArray();

            if (!lastFive.Contains(0)
                && isRed(lastFive[0]) != isRed(lastFive[1])
                && isRed(lastFive[1]) != isRed(lastFive[2])
                && isRed(lastFive[2]) != isRed(lastFive[3])
                && isRed(lastFive[3]) != isRed(lastFive[4]) && lastFive[4] != 0)
            {
                return new Bet[1] { new ColorBet(!isRed(lastFive[4])) { RuleName = "ColorsSwitching" } };
            } else return new Bet[0];

        }

        private Bet[] getSameColorStreakAfterZeroBet(int[] numbers)
        {
            if (numbers.Length < 3) return new Bet[0];

            List<bool> colorsAfterZero = new List<bool>();
            bool hasZero = false;

            foreach(int number in numbers)
            {
                if(number == 0) hasZero = true;
                else if(hasZero)
                {
                    if(number == 0) return new Bet[0];
                    else colorsAfterZero.Add(isRed(number));
                }
            }

            bool[] distinctValues = colorsAfterZero.Distinct().ToArray();

            if(distinctValues.Length == 1)
                return new Bet[1]{ new ColorBet(distinctValues[0]) { RuleName = "SameColorStreakAfterZero" } };
            
            else return new Bet[0];

        }

        private Bet[] getSixLinesBet(int[] numbers, bool secondTry = false)
        {
            if (numbers.Length < 5) return new Bet[0];
            var grid = RouletteHelper.getNumbersGrid();

            string ruleName = secondTry ? "SixLinesSecondTry" : "SixLines";


            int[] lastFive;
            if(!secondTry)
            {
                lastFive = numbers.Skip(Math.Max(0, numbers.Count() - 5)).ToArray();
            }
            else if(numbers.Length > 5)
            {
                int[] lastSix = numbers.Skip(numbers.Count() - 6).ToArray();

                var idxs = findIndexes(lastSix.Skip(lastSix.Count() - 2).ToArray());
                
                if(idxs[0].X == idxs[1].X || idxs[0].X - 1 == idxs[1].X  || idxs[0].X + 1 == idxs[1].X)
                {
                    return new Bet[0];
                }

                lastFive = lastSix.Take(5).ToArray();
            }
            else return new Bet[0];

            List<Point> indexes = findIndexes(lastFive);

            Point last = indexes.Last();
            for(int i = 0; i < indexes.Count - 1; i++)
            {
                if (indexes[i].X == last.X || indexes[i].X == last.X + 1 || indexes[i].X == last.X - 1)
                {
                    return new Bet[0];
                }
            }

            List<Bet> result = new List<Bet>();


            int multiplier = (Config.DoubleSixLineBets ? 2 : 1);
            if (last.X == 0 || last.X == 12)
            {
                result.Add(new SixLineBet(last.X) { Multiplier = 2 * multiplier, RuleName = ruleName });
            }
            else if (last.X == 1)
            {
                result.Add(new NumberBet(0) { RuleName = ruleName });
                result.Add(new SixLineBet(last.X + 1) { Multiplier = multiplier * 2, RuleName = ruleName });
            }
            else if(last.X == 2)
            {
                result.Add(new NumberBet(0) { RuleName = ruleName });
                result.Add(new SixLineBet(last.X) { Multiplier = multiplier, RuleName = ruleName });
                result.Add(new SixLineBet(last.X + 1) { Multiplier = multiplier, RuleName = ruleName });
            }
            else
            {
                result.Add(new SixLineBet(last.X) { Multiplier = multiplier, RuleName = ruleName });
                result.Add(new SixLineBet(last.X + 1) { Multiplier = multiplier, RuleName = ruleName });
            }


            int numberToBet = secondTry ? lastFive[4] : lastFive[3];
            for (int i = last.X - 1; i <= last.X + 1; i++)
            {
                if (i >= 0 && i < grid[0].Length)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (grid[j][i] % 10 == numberToBet % 10)
                        {
                            result.Add(new NumberBet(grid[j][i]) { Multiplier = (last.X == 12 || last.X == 1 ? 4 : 2), RuleName = ruleName } );
                            break;
                        }
                    }
                }
            }
            

            return result.ToArray();


        }

        private List<Point> findIndexes(int[] numbers)
        {
            var grid = RouletteHelper.getNumbersGrid();

            var indexes = new List<Point>();

            foreach (int number in numbers)
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

            return indexes;
        }

        private static bool isRed(int number)
        {
            return RouletteHelper.getRedNumbers().Contains(number);
        }
    }
}
