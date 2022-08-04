using System;
using System.Collections.Generic;
using System.Linq;
using RouletteBot.Models.Bets;

namespace RouletteBot.Models.Rules
{
    public class ThreeOfFourRule : Rule
    {
        public ThreeOfFourRule(BetEvaluationConfig evaluationConfig) : base(evaluationConfig)
        {
            RuleName = "ThreeOfFour";
        }

        public override bool IsApplicable(IReadOnlyCollection<int> numbers)
        {
            if (numbers.Count < 2) return false;
            
            var lastThree = numbers.Skip(Math.Max(0, numbers.Count - 3)).ToArray();

            var counts = GetCounts(lastThree);

            return counts.Any(count => count > 1);
        }

        protected override IReadOnlyCollection<Bet> GenerateBets(IReadOnlyCollection<int> numbers)
        {
            var lastThree = numbers.Skip(Math.Max(0, numbers.Count - 3)).ToArray();
            var counts = GetCounts(lastThree);
            var bets = new List<Bet>();


            for (var i = 0; i < counts.Length; i++)
            {
                if (counts[i] < 2) continue;
                for (var j = 0; j <= 36; j++)
                {
                    if (j % 10 == i)
                    {
                        bets.Add(new NumberBet(j)
                            { RuleName = RuleName, Multiplier = EvaluationConfig.ThreeOfFourAmount });
                    }
                }
            }

            return bets.ToArray();
        }

        private static int[] GetCounts(IReadOnlyCollection<int> numbers)
        {
            var counts = new int[10];

            foreach (var number in numbers)
            {
                counts[number % 10]++;
            }

            return counts;
        }
    }
}