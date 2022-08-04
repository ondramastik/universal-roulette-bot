using System;
using System.Collections.Generic;
using System.Linq;
using RouletteBot.Models.Bets;

namespace RouletteBot.Models.Rules
{
    public class TwoColorsInRowRule : Rule
    {
        public TwoColorsInRowRule(BetEvaluationConfig evaluationConfig) : base(evaluationConfig)
        {
            RuleName = "TwoColorsInRow";
        }

        public override bool IsApplicable(IReadOnlyCollection<int> numbers)
        {
            if (numbers.Count < 3) return false;

            var lastThree = numbers.Skip(Math.Max(0, numbers.Count - 3)).ToArray();

            return lastThree.All(number => number != 0) &&
                   RouletteHelper.IsRed(lastThree[0]) != RouletteHelper.IsRed(lastThree[1]) &&
                   RouletteHelper.IsRed(lastThree[1]) == RouletteHelper.IsRed(lastThree[2]);
        }

        protected override IReadOnlyCollection<Bet> GenerateBets(IReadOnlyCollection<int> numbers)
        {
            return new Bet[]
            {
                new ColorBet(!RouletteHelper.IsRed(numbers.Last()))
                    { RuleName = RuleName, Multiplier = EvaluationConfig.TwoColorsInRowAmount }
            };
        }
    }
}