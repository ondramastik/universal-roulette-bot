using System;
using System.Collections.Generic;
using System.Linq;
using RouletteBot.Models.Bets;

namespace RouletteBot.Models.Rules
{
    public class ColorsSwitchingRule : Rule
    {
        public ColorsSwitchingRule(BetEvaluationConfig evaluationConfig) : base(evaluationConfig)
        {
            RuleName = "ColorsSwitching";
        }

        public override bool IsApplicable(IReadOnlyCollection<int> numbers)
        {
            if (numbers.Count < 5) return false;

            var lastFive = numbers.Skip(Math.Max(0, numbers.Count - 5)).ToArray();

            return !lastFive.Contains(0)
                   && RouletteHelper.IsRed(lastFive[0]) != RouletteHelper.IsRed(lastFive[1])
                   && RouletteHelper.IsRed(lastFive[1]) != RouletteHelper.IsRed(lastFive[2])
                   && RouletteHelper.IsRed(lastFive[2]) != RouletteHelper.IsRed(lastFive[3])
                   && RouletteHelper.IsRed(lastFive[3]) != RouletteHelper.IsRed(lastFive[4]);
        }

        protected override IReadOnlyCollection<Bet> GenerateBets(IReadOnlyCollection<int> numbers)
        {
            return new Bet[]
            {
                new ColorBet(!RouletteHelper.IsRed(numbers.Last()))
                    { RuleName = RuleName, Multiplier = EvaluationConfig.ColorSwitchingAmount }
            };
        }
    }
}