using System;
using System.Collections.Generic;
using System.Linq;
using RouletteBot.Models.Bets;
using RouletteBot.Models.Rules;

namespace RouletteBot.Models
{
    public class RulesFactory
    {
        private readonly BetEvaluationConfig _config;

        public RulesFactory(BetEvaluationConfig evaluationConfig = null)
        {
            _config = evaluationConfig ?? new BetEvaluationFileConfig();
        }

        public IReadOnlyCollection<Rule> GetApplicableRules(int[] numbers)
        {
            var rules = new List<Rule>();

            if (numbers.Length < 1) return rules;

            var lastNumber = numbers[numbers.Length - 1];
            /*if (_config.ThreeOfFour)
                bets.AddRange(GetThreeOfFourBet(numbers));
            if (_config.TwoColorsInRow)
                bets.AddRange(GetTwoColorsInRowBet(numbers));
            if (_config.ColorSwitching)
                bets.AddRange(GetColorsSwitchingBet(numbers));
            if (_config.RedAfterZero)
                bets.AddRange(GetAfterZeroBet(numbers));*/
            if (_config.SixLineBet)
                rules.Add(new SixLineRule(RouletteHelper.FindIndex(lastNumber), _config));
            /*if (_config.FirstFiveBlack)
                bets.AddRange(GetFirstFiveBlackBet(numbers));*/
            if (_config.ColorStreakAfterZero)
                rules.Add(new SameColorStreakAfterZeroRule(_config));
            /*if (_config.LongTimeNoSee)
                bets.AddRange(GetLongTimeNoSeeBet(numbers));

            if (bets.Count == 0 && _config.EnableNeutralBet)
            {
                // If no bet is suggested, bet neutral.
                bets.Add(new ColorBet(true) { RuleName = "NeutralBet", IsVirtualBet = false });
                bets.Add(new ColorBet(false) { RuleName = "NeutralBet", IsVirtualBet = false });
            }*/


            return rules.Where(rule => rule.IsApplicable(numbers)) as IReadOnlyCollection<Rule>;
        }

        private IEnumerable<Bet> GetFirstFiveBlackBet(IReadOnlyList<int> numbers)
        {
            for (var i = numbers.Count - 1; i >= numbers.Count - Math.Min(numbers.Count, 3); i--)
            {
                if (numbers[i] > 10 || numbers[i] == 0 || numbers[i] % 2 != 0) continue;
                var bets = new List<Bet>();

                for (var y = 2; y <= 10; y += 2)
                {
                    bets.Add(new NumberBet(y)
                        { RuleName = "FirstFiveBlack", Multiplier = _config.FirstFiveBlackAmount });
                }

                return bets.ToArray();
            }

            return Array.Empty<Bet>();
        }

        private IEnumerable<Bet> GetThreeOfFourBet(IReadOnlyCollection<int> numbers)
        {
            if (numbers.Count < 2) return Array.Empty<Bet>();

            var lastThree = numbers.Skip(Math.Max(0, numbers.Count() - Math.Min(numbers.Count, 3))).ToArray();


            var counts = new int[10];
            foreach (var i in lastThree)
            {
                counts[i % 10]++;
            }

            var bets = new List<Bet>();


            for (var i = 0; i < counts.Length; i++)
            {
                if (counts[i] < 2) continue;
                for (var j = 0; j <= 36; j++)
                {
                    if (j % 10 == i)
                    {
                        bets.Add(new NumberBet(j)
                            { RuleName = "ThreeOfFour", Multiplier = _config.ThreeOfFourAmount });
                    }
                }
            }

            return bets.ToArray();
        }

        private IEnumerable<Bet> GetTwoColorsInRowBet(IReadOnlyCollection<int> numbers)
        {
            if (numbers.Count < 3) return Array.Empty<Bet>();

            var lastThree = numbers.Skip(Math.Max(0, numbers.Count - 3)).ToArray();

            if (lastThree.All(number => number != 0) && IsRed(lastThree[0]) != IsRed(lastThree[1]) &&
                IsRed(lastThree[1]) == IsRed(lastThree[2]))
            {
                return new Bet[]
                {
                    new ColorBet(!IsRed(lastThree[2]))
                        { RuleName = "TwoColorsInRow", Multiplier = _config.TwoColorsInRowAmount }
                };
            }

            return Array.Empty<Bet>();
        }

        private IEnumerable<Bet> GetAfterZeroBet(IReadOnlyCollection<int> numbers)
        {
            if (numbers.Count < 1 || numbers.Last() != 0)
                return Array.Empty<Bet>();
            return new Bet[]
                { new ColorBet(true) { Multiplier = _config.RedAfterZeroAmount, RuleName = "AfterZero" } };
        }

        private IEnumerable<Bet> GetColorsSwitchingBet(IReadOnlyCollection<int> numbers)
        {
            if (numbers.Count < 5) return Array.Empty<Bet>();

            var lastFive = numbers.Skip(Math.Max(0, numbers.Count - 5)).ToArray();

            if (!lastFive.Contains(0)
                && IsRed(lastFive[0]) != IsRed(lastFive[1])
                && IsRed(lastFive[1]) != IsRed(lastFive[2])
                && IsRed(lastFive[2]) != IsRed(lastFive[3])
                && IsRed(lastFive[3]) != IsRed(lastFive[4]) && lastFive[4] != 0)
            {
                return new Bet[]
                {
                    new ColorBet(!IsRed(lastFive[4]))
                        { RuleName = "ColorsSwitching", Multiplier = _config.ColorSwitchingAmount }
                };
            }

            return Array.Empty<Bet>();
        }

        private IEnumerable<Bet> GetLongTimeNoSeeBet(int[] numbers)
        {
            var lastSeeNumbers = new Dictionary<int, int>();

            foreach (var t in numbers)
            {
                var lastOccurrence = RouletteHelper.GetLastOccurance(numbers, t);

                if (lastSeeNumbers.ContainsKey(t))
                {
                    lastSeeNumbers[t] = lastOccurrence;
                }
                else
                {
                    lastSeeNumbers.Add(t, lastOccurrence);
                }
            }

            lastSeeNumbers = lastSeeNumbers.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            var bets = new List<Bet>();

            foreach (var number in lastSeeNumbers.Skip(Math.Max(0, lastSeeNumbers.Count() - 3)))
            {
                if (number.Key < 0 || number.Value < _config.LongTimeNoSeeFrom ||
                    number.Value > _config.LongTimeNoSeeTo) continue;
                var seriesWithoutSee = (number.Value + 1 - _config.LongTimeNoSeeFrom) / 33;
                var multiplier = Convert.ToInt32(Math.Pow(2, Convert.ToDouble(seriesWithoutSee)));
                bets.Add(new NumberBet(number.Key)
                    { RuleName = "LongTimeNoSee", Multiplier = multiplier * _config.LongTimeNoSeeAmount });
            }

            return bets.ToArray();
        }

        private static bool IsRed(int number)
        {
            return RouletteHelper.GetRedNumbers().Contains(number);
        }
    }
}