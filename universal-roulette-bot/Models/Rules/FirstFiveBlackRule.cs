using System;
using System.Collections.Generic;
using System.Linq;
using RouletteBot.Models.Bets;

namespace RouletteBot.Models.Rules
{
    public class FirstFiveBlackRule : Rule
    {
        public FirstFiveBlackRule(BetEvaluationConfig evaluationConfig) : base(evaluationConfig)
        {
            RuleName = "FirstFiveBlack";
        }

        public override bool IsApplicable(IReadOnlyCollection<int> numbers)
        {
            var lastThree = numbers.Skip(Math.Max(0, numbers.Count - 3)).ToArray();

            return lastThree.Any(number => number <= 10 && number != 0 && !RouletteHelper.IsRed(number));
        }

        protected override IReadOnlyCollection<Bet> GenerateBets(IReadOnlyCollection<int> numbers)
        {
            var bets = new List<Bet>();

            for (var y = 2; y <= 10; y += 2)
            {
                bets.Add(new NumberBet(y)
                    { RuleName = RuleName, Multiplier = EvaluationConfig.FirstFiveBlackAmount });
            }

            return bets.ToArray();
        }
    }
}