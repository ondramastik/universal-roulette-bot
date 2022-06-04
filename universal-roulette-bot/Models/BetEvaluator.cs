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
                Config = new BetEvaluationFileConfig();
            else
                Config = evaluationConfig;
        }

        public Bet[] getSuggestions(int[] numbers)
        {
            List<Bet> bets = new List<Bet>();

           
            if (Config.ThreeOfFour)
                bets.AddRange(getThreeOfFourBet(numbers));
            if (Config.TwoColorsInRow)
                bets.AddRange(getTwoColorsInRowBet(numbers));
            if (Config.ColorSwitching)
                bets.AddRange(getColorsSwitchingBet(numbers));
            if (Config.RedAfterZero)
                bets.AddRange(getAfterZeroBet(numbers));
            if (Config.SixlineBet)
                bets.AddRange(getSixLinesBet(numbers));
            if (Config.SecondSixlineBet)
                bets.AddRange(getSixLinesBet(numbers, true));
            if (Config.FirstFiveBlack)
                bets.AddRange(getFirstFiveBlackBet(numbers));
            if (Config.ColorStreakAfterZero)
                bets.AddRange(getSameColorStreakAfterZeroBet(numbers));
            if (Config.LongTimeNoSee)
                bets.AddRange(getLongTimeNoSeeBet(numbers));

            if (bets.Count == 0 && Config.EnableNeutralBet)
            {
                // If no bet is suggested, bet neutral.
                bets.Add(new ColorBet(true) { RuleName = "NeutralBet", isVirtualBet = false});
                bets.Add(new ColorBet(false) { RuleName = "NeutralBet", isVirtualBet = false });
            }


            return bets.ToArray();
        }

        public Bet[] getFirstFiveBlackBet(int[] numbers)
        {
            for (int i = numbers.Length - 1; i >= numbers.Length - Math.Min(numbers.Length, 3); i--)
            {
                if(numbers[i] <= 10 && numbers[i] != 0 && numbers[i] % 2 == 0)
                {
                    List<Bet> bets = new List<Bet>();

                    for (int y = 2; y <= 10; y += 2)
                    {
                        bets.Add(new NumberBet(y) { RuleName = "FirstFiveBlack", Multiplier = Config.FirstFiveBlackAmount } );
                    }

                    return bets.ToArray();
                }
            }

            return new Bet[0];
        }

        private Bet[] getThreeOfFourBet(int[] numbers)
        {
            if(numbers.Length < 2) return new Bet[0];

            int[] lastThree = numbers.Skip(Math.Max(0, numbers.Count() - Math.Min(numbers.Length, 3))).ToArray();


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
                            bets.Add(new NumberBet(j) { RuleName = "ThreeOfFour", Multiplier = Config.ThreeOfFourAmount });
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
                return new Bet[1] { new ColorBet(!isRed(lastThree[2])) { RuleName = "TwoColorsInRow", Multiplier = Config.TwoColorsInRowAmount } };

            } else return new Bet[0];

        }

        private Bet[] getAfterZeroBet(int[] numbers)
        {
            if (numbers.Length < 1 || numbers.Last() != 0)
                return new Bet[0];
            else
                return new Bet[1] { new ColorBet(true) { Multiplier = Config.RedAfterZeroAmount, RuleName = "AfterZero" } };
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
                return new Bet[1] { new ColorBet(!isRed(lastFive[4])) { RuleName = "ColorsSwitching", Multiplier = Config.ColorSwitchingAmount } };
            } else return new Bet[0];

        }

        private Bet[] getSameColorStreakAfterZeroBet(int[] numbers)
        {
            if (numbers.Length < 3) return new Bet[0];

            List<bool> colorsAfterZero = new List<bool>();
            bool hasZero = false;

            foreach(int number in numbers)
            {
                if (number == 0) {
                    if (hasZero)
                    {
                        colorsAfterZero.Clear();
                    }
                    else
                    {
                        hasZero = true;
                    }
                } 
                else if(hasZero)
                {
                    colorsAfterZero.Add(isRed(number));
                }
            }

            bool[] distinctValues = colorsAfterZero.Distinct().ToArray();

            if(colorsAfterZero.Count >= 2 && distinctValues.Length == 1)
                return new Bet[1]{ new ColorBet(distinctValues[0]) { RuleName = "SameColorStreakAfterZero", Multiplier = Config.ColorStreakAfterZeroAmount } };
            
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

                int[] lastTwo = lastSix.Skip(lastSix.Count() - 2).ToArray();
                var idxs = findIndexes(lastTwo);

                int previousNumberX = lastTwo[0] == 0 ? 1 : idxs[0].X;
                if(previousNumberX == idxs[1].X || previousNumberX - 1 == idxs[1].X  || previousNumberX + 1 == idxs[1].X)
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
                int checkX = last.X == 0 ? 1 : last.X;
                if (indexes[i].X == checkX || indexes[i].X == checkX + 1 || indexes[i].X == checkX - 1)
                {
                    return new Bet[0];
                }
            }

            List<Bet> result = new List<Bet>();


            if((!secondTry && Config.SixlineBet) || (secondTry && Config.SecondSixlineBet))
            {
                int multiplier = secondTry ? Config.SecondSixlineBetAmount : Config.SixlineBetAmount;

                if (last.X == 12)
                {
                    result.Add(new SixLineBet(last.X) { Multiplier = 2 * multiplier, RuleName = ruleName });
                }
                else if (last.X == 1 || last.X == 0)
                {
                    result.Add(new NumberBet(0) { RuleName = ruleName, Multiplier = multiplier });
                    result.Add(new SixLineBet(2) { Multiplier = multiplier * 2, RuleName = ruleName });
                }
                else if (last.X == 2)
                {
                    result.Add(new NumberBet(0) { RuleName = ruleName, Multiplier = multiplier });
                    result.Add(new SixLineBet(last.X) { Multiplier = multiplier, RuleName = ruleName });
                    result.Add(new SixLineBet(last.X + 1) { Multiplier = multiplier, RuleName = ruleName });
                }
                else
                {
                    result.Add(new SixLineBet(last.X) { Multiplier = multiplier, RuleName = ruleName });
                    result.Add(new SixLineBet(last.X + 1) { Multiplier = multiplier, RuleName = ruleName });
                }
            }


            int numberBeforeMultiplier = secondTry ? Config.SecondSixlineBetNumberBeforeAmount : Config.SixlineBetNumberBeforeAmount;
            int numberToBet = secondTry ? lastFive[4] : lastFive[3];
            for (int i = last.X - 1; i <= last.X + 1; i++)
            {
                if (i >= 0 && i < grid[0].Length)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (grid[j][i] % 10 == numberToBet % 10)
                        {
                            result.Add(new NumberBet(grid[j][i]) { Multiplier = (last.X == 12 || last.X == 1 ? numberBeforeMultiplier * 2 : numberBeforeMultiplier), RuleName = ruleName } );
                            break;
                        }
                    }
                }
            }
            

            return result.ToArray();


        }

        private Bet[] getLongTimeNoSeeBet(int[] numbers)
        {
            var lastSeeNumbers = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int lastOccurance = RouletteHelper.GetLastOccurance(numbers, numbers[i]);

                if(lastSeeNumbers.ContainsKey(numbers[i]))
                {
                    lastSeeNumbers[numbers[i]] = lastOccurance;
                }
                else
                {
                    lastSeeNumbers.Add(numbers[i], lastOccurance);
                }
            }

            lastSeeNumbers = lastSeeNumbers.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            var bets = new List<Bet>();

            foreach(var number in lastSeeNumbers.Skip(Math.Max(0, lastSeeNumbers.Count() - 3)))
            {
                if (number.Key >= 0 && number.Value >= Config.LongTimeNoSeeFrom && number.Value <= Config.LongTimeNoSeeTo)
                {
                    int seriesWithoutSee = (number.Value + 1 - Config.LongTimeNoSeeFrom) / 33;
                    int multiplier = Convert.ToInt32(Math.Pow(2, Convert.ToDouble(seriesWithoutSee)));
                    bets.Add(new NumberBet(number.Key) { RuleName = "LongTimeNoSee", Multiplier = multiplier * Config.LongTimeNoSeeAmount });
                }
            }

            return bets.ToArray();
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
