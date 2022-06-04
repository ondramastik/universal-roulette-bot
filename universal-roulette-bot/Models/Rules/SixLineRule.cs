using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using RouletteBot.Models.Bets;

namespace RouletteBot.Models.Rules
{
    public class SixLineRule : Rule
    {
        private Point InitiatedOnNumber { get; }

        private Bet[] CoreBets { get; set; }

        public SixLineRule(Bet[] bets, Point initiatedOnNumber) : base(bets, 3)
        {
            RuleName = "SixLine";
            InitiatedOnNumber = initiatedOnNumber;
            CoreBets = bets;
        }

        public override Bet[] GetBets(IReadOnlyCollection<int> numbers, int currentSpin, BetEvaluationConfig config)
        {
            if (numbers.Count < 5) return Array.Empty<Bet>();
            var grid = RouletteHelper.getNumbersGrid();
            var lastFive = numbers.Skip(Math.Max(0, numbers.Count - 5)).ToArray();

            var result = new List<Bet>(CoreBets);
            var numberBeforeMultiplier = config.SixLineBetNumberBeforeAmount;
            var numberToBet = lastFive[3];
            for (var i = InitiatedOnNumber.X - 1; i <= InitiatedOnNumber.X + 1; i++)
            {
                if (i < 0 || i >= grid[0].Length) continue;
                for (var j = 0; j < 3; j++)
                {
                    if (grid[j][i] % 10 != numberToBet % 10) continue;
                    result.Add(new NumberBet(grid[j][i])
                    {
                        Multiplier = (InitiatedOnNumber.X == 12 || InitiatedOnNumber.X == 1
                            ? numberBeforeMultiplier * 2
                            : numberBeforeMultiplier)
                    });
                    break;
                }
            }
            Bets = result.ToArray();

            return Bets;
        }
    }
}