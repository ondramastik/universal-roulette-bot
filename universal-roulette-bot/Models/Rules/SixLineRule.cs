using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using RouletteBot.Models.Bets;

namespace RouletteBot.Models.Rules
{
    public class SixLineRule : Rule
    {
        private readonly Point _initiatedOnNumber;

        public SixLineRule(Point initiatedOnNumber, BetEvaluationConfig evaluationConfig) : base(evaluationConfig, 3)
        {
            RuleName = "SixLine";
            _initiatedOnNumber = initiatedOnNumber;
        }

        public override bool IsApplicable(IReadOnlyCollection<int> numbers)
        {
            if (numbers.Count < 5) return false;
            var lastFive = numbers.Skip(Math.Max(0, numbers.Count - 5)).ToArray();

            var indexes = RouletteHelper.FindIndexes(lastFive);

            var last = indexes.Last();
            for (var i = 0; i < indexes.Count - 1; i++)
            {
                var checkX = last.X == 0 ? 1 : last.X;
                if (indexes[i].X == checkX || indexes[i].X == checkX + 1 || indexes[i].X == checkX - 1)
                {
                    return false;
                }
            }

            return true;
        }

        protected override IReadOnlyCollection<Bet> GenerateBets(IReadOnlyCollection<int> numbers)
        {
            var grid = RouletteHelper.GetNumbersGrid();
            var lastFive = numbers.Skip(Math.Max(0, numbers.Count - 5)).ToArray();

            var result = new List<Bet>();
            var multiplier = EvaluationConfig.SixLineBetAmount;

            switch (_initiatedOnNumber.X)
            {
                case 12:
                    result.Add(new SixLineBet(_initiatedOnNumber.X)
                        { RuleName = RuleName, Multiplier = 2 * multiplier });
                    break;
                case 1:
                case 0:
                    result.Add(new NumberBet(0)
                        { RuleName = RuleName, Multiplier = multiplier });
                    result.Add(new SixLineBet(2)
                        { RuleName = RuleName, Multiplier = multiplier * 2 });
                    break;
                case 2:
                    result.Add(new NumberBet(0)
                        { RuleName = RuleName, Multiplier = multiplier });
                    result.Add(new SixLineBet(_initiatedOnNumber.X)
                        { RuleName = RuleName, Multiplier = multiplier });
                    result.Add(new SixLineBet(_initiatedOnNumber.X + 1)
                        { RuleName = RuleName, Multiplier = multiplier });
                    break;
                default:
                    result.Add(new SixLineBet(_initiatedOnNumber.X)
                        { RuleName = RuleName, Multiplier = multiplier });
                    result.Add(new SixLineBet(_initiatedOnNumber.X + 1)
                        { RuleName = RuleName, Multiplier = multiplier });
                    break;
            }

            var numberBeforeMultiplier = EvaluationConfig.SixLineBetNumberBeforeAmount;
            var numberToBet = lastFive[3];
            for (var i = _initiatedOnNumber.X - 1; i <= _initiatedOnNumber.X + 1; i++)
            {
                if (i < 0 || i >= grid[0].Length) continue;
                for (var j = 0; j < 3; j++)
                {
                    if (grid[j][i] % 10 != numberToBet % 10) continue;
                    result.Add(new NumberBet(grid[j][i])
                    {
                        RuleName = RuleName,
                        Multiplier = (_initiatedOnNumber.X == 12 || _initiatedOnNumber.X == 1
                            ? numberBeforeMultiplier * 2
                            : numberBeforeMultiplier)
                    });
                    break;
                }
            }

            return result;
        }
    }
}